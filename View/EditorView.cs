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
        // поля конфига инструментов
        private string SelectedTool;
        private int ToolWidth = 1;
        public Color CanvasColor = Color.White;
        public Color MainColor = Color.Black;
        public Color AdditionalColor = Color.White;
        public bool CtrlPressed;

        // флаг возможности рисования
        private bool CanPaint;

        // поля объекты для работы с графикой
        private Bitmap CanvasBitmap;
        private DraggedFragment draggedFragment;
        private Bitmap TempBitmap; // Временное изображение для предпросмотра
        private Point ToolStartPoint;

        private Point mousePos2;

        public EditorView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // не можем рисовать
            CanPaint = false;

            // создаем битмап и заполняем им холст
            CanvasBitmap = new Bitmap(Canvas.Width, Canvas.Height);
            using (Graphics g = Graphics.FromImage(CanvasBitmap))
            {
                g.Clear(CanvasColor);
            }
            Canvas.Image = CanvasBitmap;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedTool != null)
            {
                CanPaint = true;
                ToolStartPoint = e.Location;
                Cursor.Current = Cursors.Cross;

                if (draggedFragment != null && !draggedFragment.Rect.Contains(e.Location))
                {
                    //уничтожаем фрагмент
                    draggedFragment = null;
                    Canvas.Invalidate();
                }

                TempBitmap = (Bitmap)CanvasBitmap.Clone();
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!CanPaint || SelectedTool == "Пипетка" || SelectedTool == "Заливка")
                return;

            // Определяем цвет в зависимости от кнопки мыши
            Color color = e.Button == MouseButtons.Left ? MainColor : AdditionalColor;

            // Создаем Pen в зависимости от выбранного инструмента
            Pen Pen = CreatePenForTool(SelectedTool, color);

            if (SelectedTool == "Выделить")
            {
                if (e.Button == MouseButtons.Left)
                {
                    //юзер тянет фрагмент?
                    if (draggedFragment != null)
                    {
                        //сдвигаем фрагмент
                        draggedFragment.Location.Offset(e.Location.X - mousePos2.X, e.Location.Y - mousePos2.Y);
                        ToolStartPoint = e.Location;
                    }
                    //сдвигаем выделенную область
                    mousePos2 = e.Location;
                    Canvas.Invalidate();
                }
                else
                {
                    ToolStartPoint = mousePos2 = e.Location;
                }
            }
            else if (SelectedTool == "Квадрат" || SelectedTool == "Линия" || SelectedTool == "Эллипс")
            {
                // Рисуем на временном изображении
                using (Graphics g = Graphics.FromImage(TempBitmap))
                {
                    // Восстанавливаем оригинальное изображение
                    g.DrawImage(CanvasBitmap, 0, 0);

                    // Проверяем, нажата ли клавиша Ctrl
                    bool isCtrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;

                    // Рисуем в зависимости от выбранного инструмента
                    switch (SelectedTool)
                    {
                        case "Линия":
                            g.DrawLine(Pen, ToolStartPoint, e.Location);
                            break;

                        case "Квадрат":
                            if (isCtrlPressed)
                            {
                                // Рисуем квадрат, если нажат Ctrl
                                int size = Math.Max(Math.Abs(e.X - ToolStartPoint.X), Math.Abs(e.Y - ToolStartPoint.Y));
                                int xx = ToolStartPoint.X;
                                int yy = ToolStartPoint.Y;
                                if (e.X < ToolStartPoint.X) xx = ToolStartPoint.X - size;
                                if (e.Y < ToolStartPoint.Y) yy = ToolStartPoint.Y - size;
                                g.DrawRectangle(Pen, xx, yy, size, size);
                            }
                            else
                            {
                                // Рисуем прямоугольник
                                int width = e.X - ToolStartPoint.X;
                                int height = e.Y - ToolStartPoint.Y;
                                g.DrawRectangle(Pen, ToolStartPoint.X, ToolStartPoint.Y, width, height);
                            }
                            break;

                        case "Эллипс":
                            int diameterX = e.X - ToolStartPoint.X;
                            int diameterY = e.Y - ToolStartPoint.Y;

                            // Если нажат Ctrl, рисуем круг (ширина и высота одинаковы)
                            if (isCtrlPressed)
                            {
                                int size = Math.Max(Math.Abs(diameterX), Math.Abs(diameterY));
                                diameterX = size;
                                diameterY = size;
                            }

                            // Корректируем координаты и размеры, если пользователь рисует справа налево или снизу вверх
                            int x = ToolStartPoint.X;
                            int y = ToolStartPoint.Y;
                            if (diameterX < 0)
                            {
                                x = e.X;
                                diameterX = -diameterX;
                            }
                            if (diameterY < 0)
                            {
                                y = e.Y;
                                diameterY = -diameterY;
                            }

                            // Если нажат Ctrl, корректируем координаты для круга
                            if (isCtrlPressed)
                            {
                                if (e.X < ToolStartPoint.X) x = ToolStartPoint.X - diameterX;
                                if (e.Y < ToolStartPoint.Y) y = ToolStartPoint.Y - diameterY;
                            }

                            // Рисуем эллипс (или круг, если нажат Ctrl)
                            g.DrawEllipse(Pen, x, y, diameterX, diameterY);
                            break;
                    }
                }
                // Отображаем временное изображение
                Canvas.Image = TempBitmap;
            }
            else
            {
                // Рисуем линию
                using (Graphics g = Graphics.FromImage(Canvas.Image))
                {
                    g.DrawLine(Pen, ToolStartPoint, e.Location);
                }

                // Обновляем начальную точку для следующего отрезка
                ToolStartPoint = e.Location;

                // Обновляем Canvas
                Canvas.Refresh();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (SelectedTool == "Выделить")
            {
                //если есть сдвигаемый фрагмент
                if (draggedFragment != null)
                {
                    //рисуем вырезанное белое место
                    e.Graphics.SetClip(draggedFragment.SourceRect);
                    e.Graphics.Clear(Color.White);

                    //рисуем сдвинутый фрагмент
                    e.Graphics.SetClip(draggedFragment.Rect);
                    e.Graphics.DrawImage(Canvas.Image, draggedFragment.Location.X - draggedFragment.SourceRect.X, draggedFragment.Location.Y - draggedFragment.SourceRect.Y);

                    //рисуем рамку
                    e.Graphics.ResetClip();
                    ControlPaint.DrawFocusRectangle(e.Graphics, draggedFragment.Rect);
                }
                else
                {
                    //если выделена область
                    if (ToolStartPoint != mousePos2)
                        ControlPaint.DrawFocusRectangle(e.Graphics, GetRect(ToolStartPoint, mousePos2));//рисуем рамку
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            CanPaint = false;

            if (SelectedTool == "Выделить")
            {
                //пользователь выделил фрагмент и отпустил мышь?
                if (ToolStartPoint != mousePos2)
                {
                    //создаем DraggedFragment
                    var rect = GetRect(ToolStartPoint, mousePos2);
                    draggedFragment = new DraggedFragment(rect, rect.Location, CanvasColor);
                }
                else
                {
                    //пользователь сдвинул фрагмент и отпутил мышь?
                    if (draggedFragment != null)
                    {
                        //фиксируем изменения в исходном изображении
                        draggedFragment.Fix(Canvas.Image);
                        //уничтожаем фрагмент
                        draggedFragment = null;
                        ToolStartPoint = mousePos2 = e.Location;
                    }
                }
                Canvas.Invalidate();
            }
            else if (SelectedTool == "Пипетка")
            {
                HandleColorPicker(e);
            }
            else if (SelectedTool == "Заливка")
            {
                HandleFillTool(e);
            }
            else if (SelectedTool == "Квадрат" || SelectedTool == "Линия" || SelectedTool == "Эллипс")
            {
                // Копируем временное изображение на основной холст
                using (Graphics g = Graphics.FromImage(CanvasBitmap))
                {
                    g.DrawImage(TempBitmap, 0, 0);
                }

                // Обновляем изображение в PictureBox
                Canvas.Image = CanvasBitmap;

                // Освобождаем временное изображение
                if (CanvasBitmap != null)
                {
                    TempBitmap.Dispose();
                    TempBitmap = null;
                }
            }
        }

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

        private void HandleFillTool(MouseEventArgs e)
        {
            // Создаем копию изображения для работы
            Bitmap image = new Bitmap(Canvas.Image);

            // Получаем цвет пикселя, на который кликнули
            Color oldColor = image.GetPixel(e.X, e.Y);
            Color newColor = e.Button == MouseButtons.Left ? MainColor : AdditionalColor;

            // Если старый и новый цвета совпадают, заливка не требуется
            if (oldColor.ToArgb() == newColor.ToArgb()) return;

            // Выполняем заливку
            FloodFill(image, e.X, e.Y, oldColor, newColor);

            // Обновляем изображение в PictureBox
            Canvas.Image = image;
        }

        private void FloodFill(Bitmap image, int x, int y, Color oldColor, Color newColor)
        {
            // Проверяем, что начальные координаты находятся в пределах изображения
            if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
                return;

            // Блокируем биты изображения для прямого доступа
            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );

            // Создаем массив для хранения данных изображения
            int[] pixels = new int[image.Width * image.Height];

            // Копируем данные изображения в массив
            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            // Получаем ARGB-значение старого и нового цветов
            int oldArgb = oldColor.ToArgb();
            int newArgb = newColor.ToArgb();

            // Используем стек для хранения точек, которые нужно обработать
            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));

            while (points.Count > 0)
            {
                Point pt = points.Pop();

                // Проверяем, что точка находится в пределах изображения
                if (pt.X < 0 || pt.X >= image.Width || pt.Y < 0 || pt.Y >= image.Height)
                    continue;

                // Вычисляем индекс пикселя в массиве
                int index = pt.Y * image.Width + pt.X;

                // Проверяем, что цвет текущего пикселя совпадает с oldColor
                if (pixels[index] == oldArgb)
                {
                    // Устанавливаем новый цвет
                    pixels[index] = newArgb;

                    // Добавляем соседние пиксели в стек
                    points.Push(new Point(pt.X - 1, pt.Y)); // Слева
                    points.Push(new Point(pt.X + 1, pt.Y)); // Справа
                    points.Push(new Point(pt.X, pt.Y - 1)); // Сверху
                    points.Push(new Point(pt.X, pt.Y + 1)); // Снизу
                }
            }

            // Копируем измененные данные обратно в изображение
            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);

            // Разблокируем биты изображения
            image.UnlockBits(data);
        }

        private void WidthTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            ToolWidth = WidthTrackBar.Value;
        }

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
            public Rectangle SourceRect;//прямоугольник фрагмента в исходном изображении
            public Point Location;//положение сдвинутого фрагмента
            public Color CanvasColor;

            public DraggedFragment(Rectangle rectangle, Point location, Color color)
            {
                SourceRect = rectangle;
                Location = location;
                CanvasColor = color;
            }

            //прямоугольник сдвинутого фрагмента
            public Rectangle Rect
            {
                get { return new Rectangle(Location, SourceRect.Size); }
            }

            //фиксация изменений в исх изображении
            public void Fix(System.Drawing.Image image)
            {
                using (var clone = (System.Drawing.Image)image.Clone())
                using (var gr = Graphics.FromImage(image))
                {
                    //рисуем вырезанное белое место
                    gr.SetClip(SourceRect);
                    gr.Clear(CanvasColor);

                    //рисуем сдвинутый фрагмент
                    gr.SetClip(Rect);
                    gr.DrawImage(clone, Location.X - SourceRect.X, Location.Y - SourceRect.Y);
                }
            }
        }

        //получение Rectangle из двух точек
        Rectangle GetRect(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
    }
}
