namespace CourseProject
{
    partial class EditorView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.WidthTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.LineRadioButton = new System.Windows.Forms.RadioButton();
            this.CircleRadioButton = new System.Windows.Forms.RadioButton();
            this.SquareRadioButton = new System.Windows.Forms.RadioButton();
            this.DropperRadioButton = new System.Windows.Forms.RadioButton();
            this.EraserRadioButton = new System.Windows.Forms.RadioButton();
            this.BucketRadioButton = new System.Windows.Forms.RadioButton();
            this.BrushToolRadioButton = new System.Windows.Forms.RadioButton();
            this.PenToolRadioButton = new System.Windows.Forms.RadioButton();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.AdditionalColorButton = new System.Windows.Forms.Button();
            this.MainColorButton = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // WidthTrackBar
            // 
            this.WidthTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthTrackBar.Location = new System.Drawing.Point(628, 431);
            this.WidthTrackBar.Maximum = 100;
            this.WidthTrackBar.Minimum = 1;
            this.WidthTrackBar.Name = "WidthTrackBar";
            this.WidthTrackBar.Size = new System.Drawing.Size(161, 45);
            this.WidthTrackBar.TabIndex = 1;
            this.WidthTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.WidthTrackBar.Value = 1;
            this.WidthTrackBar.ValueChanged += new System.EventHandler(this.WidthTrackBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(628, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Толщина";
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LineRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.LineRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.LineRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LineRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LineRadioButton.FlatAppearance.BorderSize = 0;
            this.LineRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.LineRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineRadioButton.Image = global::CourseProject.Properties.Resources.line;
            this.LineRadioButton.Location = new System.Drawing.Point(706, 160);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(68, 68);
            this.LineRadioButton.TabIndex = 10;
            this.LineRadioButton.Text = "Линия";
            this.LineRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LineRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LineRadioButton.UseVisualStyleBackColor = false;
            // 
            // CircleRadioButton
            // 
            this.CircleRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CircleRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.CircleRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.CircleRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CircleRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CircleRadioButton.FlatAppearance.BorderSize = 0;
            this.CircleRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.CircleRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CircleRadioButton.Image = global::CourseProject.Properties.Resources.circle;
            this.CircleRadioButton.Location = new System.Drawing.Point(632, 234);
            this.CircleRadioButton.Name = "CircleRadioButton";
            this.CircleRadioButton.Size = new System.Drawing.Size(68, 68);
            this.CircleRadioButton.TabIndex = 9;
            this.CircleRadioButton.Text = "Эллипс";
            this.CircleRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CircleRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CircleRadioButton.UseVisualStyleBackColor = false;
            this.CircleRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // SquareRadioButton
            // 
            this.SquareRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SquareRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.SquareRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SquareRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SquareRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SquareRadioButton.FlatAppearance.BorderSize = 0;
            this.SquareRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.SquareRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SquareRadioButton.Image = global::CourseProject.Properties.Resources.square;
            this.SquareRadioButton.Location = new System.Drawing.Point(706, 234);
            this.SquareRadioButton.Name = "SquareRadioButton";
            this.SquareRadioButton.Size = new System.Drawing.Size(68, 68);
            this.SquareRadioButton.TabIndex = 8;
            this.SquareRadioButton.Text = "Квадрат";
            this.SquareRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SquareRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SquareRadioButton.UseVisualStyleBackColor = false;
            this.SquareRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // DropperRadioButton
            // 
            this.DropperRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DropperRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.DropperRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.DropperRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DropperRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DropperRadioButton.FlatAppearance.BorderSize = 0;
            this.DropperRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.DropperRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropperRadioButton.Image = global::CourseProject.Properties.Resources.dropper;
            this.DropperRadioButton.Location = new System.Drawing.Point(706, 86);
            this.DropperRadioButton.Name = "DropperRadioButton";
            this.DropperRadioButton.Size = new System.Drawing.Size(68, 68);
            this.DropperRadioButton.TabIndex = 7;
            this.DropperRadioButton.Text = "Пипетка";
            this.DropperRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.DropperRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DropperRadioButton.UseVisualStyleBackColor = false;
            this.DropperRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // EraserRadioButton
            // 
            this.EraserRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EraserRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.EraserRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.EraserRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EraserRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EraserRadioButton.FlatAppearance.BorderSize = 0;
            this.EraserRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.EraserRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraserRadioButton.Image = global::CourseProject.Properties.Resources.eraser;
            this.EraserRadioButton.Location = new System.Drawing.Point(632, 86);
            this.EraserRadioButton.Name = "EraserRadioButton";
            this.EraserRadioButton.Size = new System.Drawing.Size(68, 68);
            this.EraserRadioButton.TabIndex = 6;
            this.EraserRadioButton.Text = "Ластик";
            this.EraserRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EraserRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EraserRadioButton.UseVisualStyleBackColor = false;
            this.EraserRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // BucketRadioButton
            // 
            this.BucketRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BucketRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.BucketRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.BucketRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BucketRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BucketRadioButton.FlatAppearance.BorderSize = 0;
            this.BucketRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.BucketRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BucketRadioButton.Image = global::CourseProject.Properties.Resources.bucket;
            this.BucketRadioButton.Location = new System.Drawing.Point(632, 160);
            this.BucketRadioButton.Name = "BucketRadioButton";
            this.BucketRadioButton.Size = new System.Drawing.Size(68, 68);
            this.BucketRadioButton.TabIndex = 5;
            this.BucketRadioButton.Text = "Заливка";
            this.BucketRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BucketRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BucketRadioButton.UseVisualStyleBackColor = false;
            this.BucketRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // BrushToolRadioButton
            // 
            this.BrushToolRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrushToolRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.BrushToolRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.BrushToolRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BrushToolRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BrushToolRadioButton.FlatAppearance.BorderSize = 0;
            this.BrushToolRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.BrushToolRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrushToolRadioButton.Image = global::CourseProject.Properties.Resources.brush;
            this.BrushToolRadioButton.Location = new System.Drawing.Point(706, 12);
            this.BrushToolRadioButton.Name = "BrushToolRadioButton";
            this.BrushToolRadioButton.Size = new System.Drawing.Size(68, 68);
            this.BrushToolRadioButton.TabIndex = 4;
            this.BrushToolRadioButton.Text = "Кисть";
            this.BrushToolRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BrushToolRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BrushToolRadioButton.UseVisualStyleBackColor = false;
            this.BrushToolRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // PenToolRadioButton
            // 
            this.PenToolRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PenToolRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.PenToolRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.PenToolRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PenToolRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PenToolRadioButton.FlatAppearance.BorderSize = 0;
            this.PenToolRadioButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.PenToolRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PenToolRadioButton.Image = global::CourseProject.Properties.Resources.pencil;
            this.PenToolRadioButton.Location = new System.Drawing.Point(632, 12);
            this.PenToolRadioButton.Name = "PenToolRadioButton";
            this.PenToolRadioButton.Size = new System.Drawing.Size(68, 68);
            this.PenToolRadioButton.TabIndex = 3;
            this.PenToolRadioButton.Text = "Карандаш";
            this.PenToolRadioButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PenToolRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PenToolRadioButton.UseVisualStyleBackColor = false;
            this.PenToolRadioButton.CheckedChanged += new System.EventHandler(this.ToolMenu_CheckedChanged);
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Margin = new System.Windows.Forms.Padding(0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(621, 476);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // AdditionalColorButton
            // 
            this.AdditionalColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AdditionalColorButton.BackColor = System.Drawing.Color.White;
            this.AdditionalColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdditionalColorButton.Location = new System.Drawing.Point(700, 340);
            this.AdditionalColorButton.Name = "AdditionalColorButton";
            this.AdditionalColorButton.Size = new System.Drawing.Size(45, 45);
            this.AdditionalColorButton.TabIndex = 11;
            this.AdditionalColorButton.UseVisualStyleBackColor = false;
            this.AdditionalColorButton.Click += new System.EventHandler(this.AdditionalColorButton_Click);
            // 
            // MainColorButton
            // 
            this.MainColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MainColorButton.BackColor = System.Drawing.Color.Black;
            this.MainColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainColorButton.Location = new System.Drawing.Point(679, 321);
            this.MainColorButton.Name = "MainColorButton";
            this.MainColorButton.Size = new System.Drawing.Size(45, 45);
            this.MainColorButton.TabIndex = 12;
            this.MainColorButton.UseVisualStyleBackColor = false;
            this.MainColorButton.Click += new System.EventHandler(this.MainColorButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(689, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Цвет";
            // 
            // EditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MainColorButton);
            this.Controls.Add(this.AdditionalColorButton);
            this.Controls.Add(this.LineRadioButton);
            this.Controls.Add(this.CircleRadioButton);
            this.Controls.Add(this.SquareRadioButton);
            this.Controls.Add(this.DropperRadioButton);
            this.Controls.Add(this.EraserRadioButton);
            this.Controls.Add(this.BucketRadioButton);
            this.Controls.Add(this.BrushToolRadioButton);
            this.Controls.Add(this.PenToolRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthTrackBar);
            this.Controls.Add(this.Canvas);
            this.Name = "EditorView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.WidthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TrackBar WidthTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton PenToolRadioButton;
        private System.Windows.Forms.RadioButton BrushToolRadioButton;
        private System.Windows.Forms.RadioButton BucketRadioButton;
        private System.Windows.Forms.RadioButton EraserRadioButton;
        private System.Windows.Forms.RadioButton DropperRadioButton;
        private System.Windows.Forms.RadioButton SquareRadioButton;
        private System.Windows.Forms.RadioButton CircleRadioButton;
        private System.Windows.Forms.RadioButton LineRadioButton;
        private System.Windows.Forms.Button AdditionalColorButton;
        private System.Windows.Forms.Button MainColorButton;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label label2;
    }
}

