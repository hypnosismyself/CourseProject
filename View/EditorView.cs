using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class EditorView: Form
    {
        // поля конфига инструментов
        private Pen SelectedTool;
        private string UsingTool;
        private int ToolWidth = 1;
        public Color CanvasColor = Color.White;
        public Color MainColor = Color.Black;
        public Color AdditionalColor = Color.White;

        // флаг возможности рисования
        private bool CanPaint;

        // поля объекты для работы с графикой
        private Bitmap CanvasBitmap;
        private Graphics Graphics;
        private Point ToolStartPoint;

        public EditorView()
        {
            InitializeComponent();

            // не можем рисовать
            CanPaint = false;

            // создаем битмап и зполняем им холст
            CanvasBitmap = new Bitmap(Canvas.Width, Canvas.Height);
            Graphics = Graphics.FromImage(CanvasBitmap);
            Canvas.Image = CanvasBitmap;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedTool != null)
            {
                CanPaint = true;
                ToolStartPoint = e.Location;
                Cursor.Current = Cursors.Cross;

                if (e.Button == MouseButtons.Left)
                {
                    UseTool(MainColor, e);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    UseTool(AdditionalColor, e);
                }
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanPaint)
            {
                Graphics.DrawLine(SelectedTool, ToolStartPoint, e.Location);
                ToolStartPoint = e.Location;
            }
            Canvas.Refresh();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            CanPaint = false;
        }

        private void WidthTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            ToolWidth = WidthTrackBar.Value;
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
               
        }

        private void ToolMenu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            SelectTool(s);
        }

        private void SelectTool(RadioButton s = null)
        {
            if (s.Name == "PenToolRadioButton" && s.Checked)
            {
                UsingTool = "Карандаш";
            }
            else if (s.Name == "BrushToolRadioButton" && s.Checked)
            {
                UsingTool = "Кисть";
            }
            else if (s.Name == "EraserRadioButton" && s.Checked)
            {
                UsingTool = "Ластик";
            }
            else if (s.Name == "DropperRadioButton" && s.Checked)
            {
                UsingTool = "Пипетка";
            }

            UseTool(MainColor);
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

        private void UseTool(Color color, MouseEventArgs e = null)
        {
            switch (UsingTool)
            {
                case "Карандаш":
                    SelectedTool = new PenTool(color, ToolWidth).GetTool();
                    break;
                case "Кисть":
                    SelectedTool = new BrushTool(color, ToolWidth).GetTool();
                    break;
                case "Ластик":
                    SelectedTool = new EraserTool(CanvasColor, ToolWidth).GetTool();
                    break;
                case "Пипетка":
                    DropperTool Dropper = new DropperTool();
                    SelectedTool = Dropper.GetTool();
                    break;
                default:
                    SelectedTool = null;
                    break;
            }
        }

        public abstract class Tool
        {
            public string Name;
            public float Width;
            public Color MainColor;
            public Color AdditionalColor;
        }

        public class PenTool : Tool
        {
            public PenTool(Color color, float width)
            {
                MainColor = color;
                Width = width;
            }

            public Pen GetTool()
            {
                Pen PenTool = new Pen(MainColor, Width)
                {
                    EndCap = LineCap.Flat,
                    StartCap = LineCap.Flat
                };

                return PenTool;
            }
        }

        public class BrushTool : Tool
        {
            public BrushTool(Color color, float width)
            {
                MainColor = color;
                Width = width;
            }

            public Pen GetTool()
            {
                Pen BrushTool = new Pen(MainColor, Width)
                {
                    EndCap = LineCap.Round,
                    StartCap = LineCap.Round
                };

                return BrushTool;
            }
        }

        public class EraserTool : Tool
        {
            public EraserTool(Color color, float width)
            {
                AdditionalColor = color;
                Width = width;
            }

            public Pen GetTool()
            {
                Pen BrushTool = new Pen(AdditionalColor, Width)
                {
                    EndCap = LineCap.SquareAnchor,
                    StartCap = LineCap.SquareAnchor
                };

                return BrushTool;
            }
        }

        public class DropperTool : Tool
        {
            public Color GetColor(Bitmap image, Point position)
            {
                Color color;
                color = image.GetPixel(position.X, position.Y);

                return color;
            }

            public Pen GetTool()
            {
                Pen DropperTool = new Pen(Color.Transparent, 1) { };

                return DropperTool;
            }
        }
    }
}
