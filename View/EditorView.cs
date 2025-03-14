using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class EditorView : Form
    {
        // Настройки инструмента
        private string SelectedTool;
        private int ToolWidth = 1;

        // Цветовая палитра
        public Color CanvasColor = Color.White;
        public Color MainColor = Color.Black;
        public Color AdditionalColor = Color.White;

        // Флаги для управления рисования
        public bool CtrlPressed;
        private bool CanPaint;

        // Объекты для работы с изображением
        private readonly Bitmap CanvasBitmap;
        private Bitmap TempBitmap;
        private DraggedFragment FragmentToDrag;

        // Положение мыши
        private Point ToolStartPoint;
        private Point ToolFinishPoint;

        private Dictionary<string, Action<Graphics, Pen, Point, Point>> toolActions;

        public EditorView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            CanPaint = false;

            CanvasBitmap = new Bitmap(Canvas.Width, Canvas.Height);
            using (Graphics g = Graphics.FromImage(CanvasBitmap))
            {
                g.Clear(CanvasColor);
            }
            Canvas.Image = CanvasBitmap;

            InitializeToolActions();
        }

        // Инициализатор словаря сложных инструментов
        private void InitializeToolActions()
        {
            toolActions = new Dictionary<string, Action<Graphics, Pen, Point, Point>>
            {
                { "Линия", (g, pen, start, end) => g.DrawLine(pen, start, end) },
                { "Квадрат", DrawRectangle },
                { "Эллипс", DrawEllipse }
            };
        }

        // Нарисовать прямоугольник
        private void DrawRectangle(Graphics g, Pen pen, Point start, Point end)
        {
            bool isCtrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;

            // Вычисляем разницу по осям X и Y
            int deltaX = end.X - start.X;
            int deltaY = end.Y - start.Y;

            // Если нажат Ctrl, рисуем квадрат (ширина и высота равны максимальному значению)
            if (isCtrlPressed)
            {
                int size = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
                deltaX = Math.Sign(deltaX) * size; // Сохраняем направление
                deltaY = Math.Sign(deltaY) * size; // Сохраняем направление
            }

            // Определяем начальные координаты для рисования
            int x = deltaX < 0 ? start.X + deltaX : start.X;
            int y = deltaY < 0 ? start.Y + deltaY : start.Y;

            // Рисуем прямоугольник (или квадрат, если нажат Ctrl)
            g.DrawRectangle(pen, x, y, Math.Abs(deltaX), Math.Abs(deltaY));
        }

        // Нарисовать эллипс
        private void DrawEllipse(Graphics g, Pen pen, Point start, Point end)
        {
            bool isCtrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;

            // Вычисляем разницу по осям X и Y
            int deltaX = end.X - start.X;
            int deltaY = end.Y - start.Y;

            // Если нажат Ctrl, рисуем круг (ширина и высота равны максимальному значению)
            if (isCtrlPressed)
            {
                int size = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
                deltaX = Math.Sign(deltaX) * size; // Сохраняем направление
                deltaY = Math.Sign(deltaY) * size; // Сохраняем направление
            }

            // Определяем начальные координаты для рисования
            int x = deltaX < 0 ? start.X + deltaX : start.X;
            int y = deltaY < 0 ? start.Y + deltaY : start.Y;

            // Рисуем эллипс (или круг, если нажат Ctrl)
            g.DrawEllipse(pen, x, y, Math.Abs(deltaX), Math.Abs(deltaY));
        }

        // При нажатии кнопки мыши на холсте
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedTool != null)
            {
                CanPaint = true;
                ToolStartPoint = e.Location;
                Cursor.Current = Cursors.Cross;

                if (FragmentToDrag != null && !FragmentToDrag.Rect.Contains(e.Location))
                {
                    FragmentToDrag = null;
                    Canvas.Invalidate();
                }

                TempBitmap = (Bitmap)CanvasBitmap.Clone();
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!CanPaint || SelectedTool == "Пипетка" || SelectedTool == "Заливка")
                return;

            Color color = e.Button == MouseButtons.Left ? MainColor : AdditionalColor;
            Pen pen = CreatePenForTool(SelectedTool, color);

            if (SelectedTool == "Выделить")
            {
                HandleSelectionTool(e);
            }
            else if (toolActions.ContainsKey(SelectedTool))
            {
                using (Graphics g = Graphics.FromImage(TempBitmap))
                {
                    g.DrawImage(CanvasBitmap, 0, 0);
                    toolActions[SelectedTool](g, pen, ToolStartPoint, e.Location);
                }
                Canvas.Image = TempBitmap;
            }
            else
            {
                using (Graphics g = Graphics.FromImage(Canvas.Image))
                {
                    g.DrawLine(pen, ToolStartPoint, e.Location);
                }
                ToolStartPoint = e.Location;
                Canvas.Refresh();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (SelectedTool == "Выделить")
            {
                if (FragmentToDrag != null)
                {
                    e.Graphics.SetClip(FragmentToDrag.SourceRect);
                    e.Graphics.Clear(Color.White);

                    e.Graphics.SetClip(FragmentToDrag.Rect);
                    e.Graphics.DrawImage(Canvas.Image, FragmentToDrag.Location.X - FragmentToDrag.SourceRect.X, FragmentToDrag.Location.Y - FragmentToDrag.SourceRect.Y);

                    e.Graphics.ResetClip();
                    ControlPaint.DrawFocusRectangle(e.Graphics, FragmentToDrag.Rect);
                }
                else if (ToolStartPoint != ToolFinishPoint)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, GetRect(ToolStartPoint, ToolFinishPoint));
                }
            }
        }

        // При отпускании клавиши мыши на холсте
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            CanPaint = false;

            if (SelectedTool == "Пипетка")
            {
                HandleColorPicker(e);
            }
            else if (SelectedTool == "Заливка")
            {
                HandleFillTool(e);
            }
            else if (SelectedTool == "Выделить")
            {
                if (ToolStartPoint != ToolFinishPoint)
                {
                    var rect = GetRect(ToolStartPoint, ToolFinishPoint);
                    FragmentToDrag = new DraggedFragment(rect, rect.Location, CanvasColor);
                }
                else if (FragmentToDrag != null)
                {
                    FragmentToDrag.Fix(Canvas.Image);
                    FragmentToDrag = null;
                    ToolStartPoint = ToolFinishPoint = e.Location;
                }
                Canvas.Invalidate();
            }
            else if (toolActions.ContainsKey(SelectedTool))
            {
                using (Graphics g = Graphics.FromImage(CanvasBitmap))
                {
                    g.DrawImage(TempBitmap, 0, 0);
                }

                Canvas.Image = CanvasBitmap;

                if (TempBitmap != null)
                {
                    TempBitmap.Dispose();
                    TempBitmap = null;
                }
            }
        }

        // Создание Pen для инструмента
        private Pen CreatePenForTool(string tool, Color color)
        {
            Pen pen;

            switch (tool)
            {
                case "Карандаш":
                    pen = new Pen(color, ToolWidth)
                    {
                        EndCap = LineCap.Flat,
                        StartCap = LineCap.Flat
                    };
                    break;
                case "Кисть":
                    pen = new Pen(color, ToolWidth)
                    {
                        EndCap = LineCap.Round,
                        StartCap = LineCap.Round
                    };
                    break;
                case "Ластик":
                    pen = new Pen(CanvasColor, ToolWidth)
                    {
                        EndCap = LineCap.Square,
                        StartCap = LineCap.Round
                    };
                    break;
                default:
                    pen = new Pen(color, ToolWidth);
                    break;
            }

            return pen;
        }

        // Обработчик выделения
        private void HandleSelectionTool(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (FragmentToDrag != null)
                {
                    FragmentToDrag.Location.Offset(e.Location.X - ToolFinishPoint.X, e.Location.Y - ToolFinishPoint.Y);
                    ToolStartPoint = e.Location;
                }
                ToolFinishPoint = e.Location;
                Canvas.Invalidate();
            }
            else
            {
                ToolStartPoint = ToolFinishPoint = e.Location;
            }
        }

        // Обработчик пипетки
        private void HandleColorPicker(MouseEventArgs e)
        {
            using (Bitmap image = new Bitmap(Canvas.Image))
            {
                Color color = image.GetPixel(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                {
                    MainColor = color;
                    MainColorButton.BackColor = color;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    AdditionalColor = color;
                    AdditionalColorButton.BackColor = color;
                }
                ColorDialog.Color = color;
            }
        }

        // Обработчик заливки
        private void HandleFillTool(MouseEventArgs e)
        {
            Bitmap image = new Bitmap(Canvas.Image);

            Color oldColor = image.GetPixel(e.X, e.Y);
            Color newColor = e.Button == MouseButtons.Left ? MainColor : AdditionalColor;

            if (oldColor.ToArgb() == newColor.ToArgb()) return;

            FloodFill(image, e.X, e.Y, oldColor, newColor);

            Canvas.Image = image;
        }

        // Обработчик заливки
        private void FloodFill(Bitmap image, int x, int y, Color oldColor, Color newColor)
        {
            if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
                return;

            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );

            int[] pixels = new int[image.Width * image.Height];
            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            int oldArgb = oldColor.ToArgb();
            int newArgb = newColor.ToArgb();

            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));

            while (points.Count > 0)
            {
                Point pt = points.Pop();

                if (pt.X < 0 || pt.X >= image.Width || pt.Y < 0 || pt.Y >= image.Height)
                    continue;

                int index = pt.Y * image.Width + pt.X;

                if (pixels[index] == oldArgb)
                {
                    pixels[index] = newArgb;

                    points.Push(new Point(pt.X - 1, pt.Y));
                    points.Push(new Point(pt.X + 1, pt.Y));
                    points.Push(new Point(pt.X, pt.Y - 1));
                    points.Push(new Point(pt.X, pt.Y + 1));
                }
            }

            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            image.UnlockBits(data);
        }

        // Изменение толщины
        private void WidthTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            ToolWidth = WidthTrackBar.Value;
        }

        // Выбор инструмента
        private void ToolMenu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            SelectedTool = s.Text;
        }

        private void MainColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog)
            {
                if (ColorDialog.ShowDialog() == DialogResult.OK)
                {
                    MainColor = ColorDialog.Color;
                    MainColorButton.BackColor = ColorDialog.Color;
                }
            }
        }

        private void AdditionalColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog)
            {
                if (ColorDialog.ShowDialog() == DialogResult.OK)
                {
                    AdditionalColor = ColorDialog.Color;
                    AdditionalColorButton.BackColor = ColorDialog.Color;
                }
            }
        }

        class DraggedFragment
        {
            public Rectangle SourceRect;
            public Point Location;
            public Color CanvasColor;

            public DraggedFragment(Rectangle rectangle, Point location, Color color)
            {
                SourceRect = rectangle;
                Location = location;
                CanvasColor = color;
            }

            public Rectangle Rect
            {
                get { return new Rectangle(Location, SourceRect.Size); }
            }

            // Фиксация изменения выделения
            public void Fix(Image image)
            {
                using (var clone = (Image)image.Clone())
                using (var gr = Graphics.FromImage(image))
                {
                    gr.SetClip(SourceRect);
                    gr.Clear(CanvasColor);

                    gr.SetClip(Rect);
                    gr.DrawImage(clone, Location.X - SourceRect.X, Location.Y - SourceRect.Y);
                }
            }
        }

        private Rectangle GetRect(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
    }
}