namespace testImageViewerControl
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
            splitContainer1 = new SplitContainer();
            imageViewerControl1 = new imageViewerControl();
            button7 = new Button();
            textBox1 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(imageViewerControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button7);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(button6);
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 539;
            splitContainer1.TabIndex = 0;
            // 
            // imageViewerControl1
            // 
            imageViewerControl1.Dock = DockStyle.Fill;
            imageViewerControl1.Location = new Point(0, 0);
            imageViewerControl1.Margin = new Padding(4, 3, 4, 3);
            imageViewerControl1.Name = "imageViewerControl1";
            imageViewerControl1.Size = new Size(539, 450);
            imageViewerControl1.TabIndex = 0;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.Location = new Point(0, 163);
            button7.Name = "button7";
            button7.Size = new Size(257, 23);
            button7.TabIndex = 7;
            button7.Text = "Set Custom Threshold";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Top;
            textBox1.Location = new Point(0, 140);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(257, 23);
            textBox1.TabIndex = 6;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.Location = new Point(0, 117);
            button6.Name = "button6";
            button6.Size = new Size(257, 23);
            button6.TabIndex = 5;
            button6.Text = "Get Some Image Info";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.Location = new Point(0, 94);
            button5.Name = "button5";
            button5.Size = new Size(257, 23);
            button5.TabIndex = 4;
            button5.Text = "Set Some Overlay";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.Location = new Point(0, 71);
            button4.Name = "button4";
            button4.Size = new Size(257, 23);
            button4.TabIndex = 3;
            button4.Text = "Rescale";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.Location = new Point(0, 48);
            button3.Name = "button3";
            button3.Size = new Size(257, 23);
            button3.TabIndex = 2;
            button3.Text = "Load Gaussian";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.Location = new Point(0, 25);
            button2.Name = "button2";
            button2.Size = new Size(257, 23);
            button2.TabIndex = 1;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(257, 25);
            button1.TabIndex = 0;
            button1.Text = "Load Random Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button1;
        private imageViewerControl imageViewerControl1;
        private Button button2;
        private TextBox textBox1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button7;
    }
}
