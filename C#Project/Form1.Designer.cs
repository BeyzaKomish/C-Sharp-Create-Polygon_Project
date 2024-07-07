namespace C_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            centerX = new TextBox();
            centerY = new TextBox();
            length = new TextBox();
            numofedge = new TextBox();
            angle = new TextBox();
            coordinates = new ListBox();
            pictureBox = new PictureBox();
            Rotate = new Button();
            draw = new Button();
            setrandom = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 44);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Center Points";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 151);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Number Of Edges";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 98);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "Length";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 208);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 3;
            label4.Text = "Rotation Angel";
            // 
            // centerX
            // 
            centerX.Location = new Point(188, 37);
            centerX.Name = "centerX";
            centerX.Size = new Size(181, 27);
            centerX.TabIndex = 4;
            // 
            // centerY
            // 
            centerY.Location = new Point(424, 37);
            centerY.Name = "centerY";
            centerY.Size = new Size(183, 27);
            centerY.TabIndex = 5;
            // 
            // length
            // 
            length.Location = new Point(188, 95);
            length.Name = "length";
            length.Size = new Size(181, 27);
            length.TabIndex = 6;
            // 
            // numofedge
            // 
            numofedge.Location = new Point(188, 144);
            numofedge.Name = "numofedge";
            numofedge.Size = new Size(181, 27);
            numofedge.TabIndex = 7;
            // 
            // angle
            // 
            angle.Location = new Point(188, 205);
            angle.Name = "angle";
            angle.Size = new Size(181, 27);
            angle.TabIndex = 8;
            // 
            // coordinates
            // 
            coordinates.BackColor = Color.LightGray;
            coordinates.FormattingEnabled = true;
            coordinates.ItemHeight = 20;
            coordinates.Location = new Point(159, 273);
            coordinates.Name = "coordinates";
            coordinates.Size = new Size(210, 144);
            coordinates.TabIndex = 9;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Location = new Point(683, 30);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(696, 610);
            pictureBox.TabIndex = 10;
            pictureBox.TabStop = false;
            // 
            // Rotate
            // 
            Rotate.BackColor = Color.DarkGray;
            Rotate.Location = new Point(424, 319);
            Rotate.Name = "Rotate";
            Rotate.Size = new Size(183, 40);
            Rotate.TabIndex = 12;
            Rotate.Text = "Rotate";
            Rotate.UseVisualStyleBackColor = false;
            Rotate.Click += button2_Click;
            // 
            // draw
            // 
            draw.BackColor = SystemColors.ActiveBorder;
            draw.Location = new Point(424, 273);
            draw.Name = "draw";
            draw.Size = new Size(183, 40);
            draw.TabIndex = 14;
            draw.Text = "Draw";
            draw.UseVisualStyleBackColor = false;
            draw.Click += draw_Click;
            // 
            // setrandom
            // 
            setrandom.BackColor = SystemColors.ActiveBorder;
            setrandom.Location = new Point(424, 365);
            setrandom.Name = "setrandom";
            setrandom.Size = new Size(183, 40);
            setrandom.TabIndex = 15;
            setrandom.Text = "Set Random Variable";
            setrandom.UseVisualStyleBackColor = false;
            setrandom.Click += setrandom_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1419, 675);
            Controls.Add(setrandom);
            Controls.Add(draw);
            Controls.Add(Rotate);
            Controls.Add(pictureBox);
            Controls.Add(coordinates);
            Controls.Add(angle);
            Controls.Add(numofedge);
            Controls.Add(length);
            Controls.Add(centerY);
            Controls.Add(centerX);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
          
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox centerX;
        private TextBox centerY;
        private TextBox length;
        private TextBox numofedge;
        private TextBox angle;
        private ListBox coordinates;
        private PictureBox pictureBox;
        private Button Rotate;
        private Button draw;
        private Button setrandom;
    }
}