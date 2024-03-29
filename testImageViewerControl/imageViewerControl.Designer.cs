﻿using System.ComponentModel;

namespace testImageViewerControl
{
    partial class imageViewerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            trackBar1 = new TrackBar();
            NumericMin = new NumericUpDown();
            pictureBox1 = new PictureBox();
            CM_ImgCM = new ContextMenuStrip(components);
            CMItemSave = new ToolStripMenuItem();
            saveInclOverlaysToolStripMenuItem = new ToolStripMenuItem();
            CMcopytoClipboard = new ToolStripMenuItem();
            copyToClipboardInclOverlaysToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            keepAspektRatioToolStripMenuItem = new ToolStripMenuItem();
            autoscaleToolStripMenuItem = new ToolStripMenuItem();
            rescaleToolStripMenuItem = new ToolStripMenuItem();
            highlightThresholdedAreasToolStripMenuItem = new ToolStripMenuItem();
            scaleViewToolStripMenuItem = new ToolStripMenuItem();
            linearToolStripMenuItem = new ToolStripMenuItem();
            logToolStripMenuItem = new ToolStripMenuItem();
            centerCursorToolStripMenuItem = new ToolStripMenuItem();
            showCorsairCirclesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            selectionToolStripMenuItem = new ToolStripMenuItem();
            simpleToolStripMenuItem = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            unzoomToolStripMenuItem = new ToolStripMenuItem();
            zoomSelectedAreaToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            overlaysToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            OverlayColorStripComboBox1 = new ToolStripComboBox();
            toolStripOverlayLineSize = new ToolStripComboBox();
            CM_CMPLX = new ToolStripMenuItem();
            CM_cmplxAbs = new ToolStripMenuItem();
            CM_cmplxPhase = new ToolStripMenuItem();
            CM_cmplxReal = new ToolStripMenuItem();
            CM_cmplxImag = new ToolStripMenuItem();
            label3 = new Label();
            label4 = new Label();
            NumericGamma = new NumericUpDown();
            textBoxCursorInfo = new TextBox();
            NumericMax = new NumericUpDown();
            label2 = new Label();
            textBoxSelectionInfo = new TextBox();
            textBoxFrameLoadTime = new TextBox();
            backgroundWorker1 = new BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)trackBar1).BeginInit();
            ((ISupportInitialize)NumericMin).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            CM_ImgCM.SuspendLayout();
            ((ISupportInitialize)NumericGamma).BeginInit();
            ((ISupportInitialize)NumericMax).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(trackBar1, 5, 4);
            tableLayoutPanel1.Controls.Add(NumericMin, 3, 3);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 5, 3);
            tableLayoutPanel1.Controls.Add(NumericGamma, 6, 3);
            tableLayoutPanel1.Controls.Add(textBoxCursorInfo, 0, 1);
            tableLayoutPanel1.Controls.Add(NumericMax, 1, 3);
            tableLayoutPanel1.Controls.Add(label2, 2, 3);
            tableLayoutPanel1.Controls.Add(textBoxSelectionInfo, 4, 3);
            tableLayoutPanel1.Controls.Add(textBoxFrameLoadTime, 5, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1200, 800);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // trackBar1
            // 
            tableLayoutPanel1.SetColumnSpan(trackBar1, 2);
            trackBar1.Dock = DockStyle.Fill;
            trackBar1.Location = new Point(1044, 773);
            trackBar1.Margin = new Padding(4, 3, 4, 3);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = -200;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeftLayout = true;
            trackBar1.Size = new Size(152, 24);
            trackBar1.TabIndex = 3;
            // 
            // NumericMin
            // 
            NumericMin.DecimalPlaces = 3;
            NumericMin.Dock = DockStyle.Fill;
            NumericMin.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            NumericMin.Location = new Point(222, 743);
            NumericMin.Margin = new Padding(4, 3, 4, 3);
            NumericMin.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumericMin.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
            NumericMin.Name = "NumericMin";
            tableLayoutPanel1.SetRowSpan(NumericMin, 2);
            NumericMin.Size = new Size(92, 35);
            NumericMin.TabIndex = 3;
            // 
            // pictureBox1
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 5);
            pictureBox1.ContextMenuStrip = CM_ImgCM;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(4, 3);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1032, 544);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            // 
            // CM_ImgCM
            // 
            CM_ImgCM.Items.AddRange(new ToolStripItem[] { CMItemSave, saveInclOverlaysToolStripMenuItem, CMcopytoClipboard, copyToClipboardInclOverlaysToolStripMenuItem, toolStripSeparator1, keepAspektRatioToolStripMenuItem, autoscaleToolStripMenuItem, rescaleToolStripMenuItem, highlightThresholdedAreasToolStripMenuItem, scaleViewToolStripMenuItem, centerCursorToolStripMenuItem, showCorsairCirclesToolStripMenuItem, toolStripSeparator2, selectionToolStripMenuItem, unzoomToolStripMenuItem, zoomSelectedAreaToolStripMenuItem, toolStripSeparator3, overlaysToolStripMenuItem, CM_CMPLX });
            CM_ImgCM.Name = "CM_ImgCM";
            CM_ImgCM.Size = new Size(246, 374);
            // 
            // CMItemSave
            // 
            CMItemSave.Name = "CMItemSave";
            CMItemSave.Size = new Size(245, 22);
            CMItemSave.Text = "Save";
            // 
            // saveInclOverlaysToolStripMenuItem
            // 
            saveInclOverlaysToolStripMenuItem.Name = "saveInclOverlaysToolStripMenuItem";
            saveInclOverlaysToolStripMenuItem.Size = new Size(245, 22);
            saveInclOverlaysToolStripMenuItem.Text = "Save Incl. Overlays";
            // 
            // CMcopytoClipboard
            // 
            CMcopytoClipboard.Name = "CMcopytoClipboard";
            CMcopytoClipboard.Size = new Size(245, 22);
            CMcopytoClipboard.Text = "Copy To Clipboard";
            // 
            // copyToClipboardInclOverlaysToolStripMenuItem
            // 
            copyToClipboardInclOverlaysToolStripMenuItem.Name = "copyToClipboardInclOverlaysToolStripMenuItem";
            copyToClipboardInclOverlaysToolStripMenuItem.Size = new Size(245, 22);
            copyToClipboardInclOverlaysToolStripMenuItem.Text = "Copy To Clipboard Incl. Overlays";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(242, 6);
            // 
            // keepAspektRatioToolStripMenuItem
            // 
            keepAspektRatioToolStripMenuItem.Checked = true;
            keepAspektRatioToolStripMenuItem.CheckState = CheckState.Checked;
            keepAspektRatioToolStripMenuItem.Name = "keepAspektRatioToolStripMenuItem";
            keepAspektRatioToolStripMenuItem.Size = new Size(245, 22);
            keepAspektRatioToolStripMenuItem.Text = "Keep Aspekt Ratio";
            // 
            // autoscaleToolStripMenuItem
            // 
            autoscaleToolStripMenuItem.Name = "autoscaleToolStripMenuItem";
            autoscaleToolStripMenuItem.Size = new Size(245, 22);
            autoscaleToolStripMenuItem.Text = "Autoscale";
            // 
            // rescaleToolStripMenuItem
            // 
            rescaleToolStripMenuItem.Name = "rescaleToolStripMenuItem";
            rescaleToolStripMenuItem.Size = new Size(245, 22);
            rescaleToolStripMenuItem.Text = "Rescale";
            // 
            // highlightThresholdedAreasToolStripMenuItem
            // 
            highlightThresholdedAreasToolStripMenuItem.Name = "highlightThresholdedAreasToolStripMenuItem";
            highlightThresholdedAreasToolStripMenuItem.Size = new Size(245, 22);
            highlightThresholdedAreasToolStripMenuItem.Text = "Highlight Thresholded Areas";
            // 
            // scaleViewToolStripMenuItem
            // 
            scaleViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { linearToolStripMenuItem, logToolStripMenuItem });
            scaleViewToolStripMenuItem.Name = "scaleViewToolStripMenuItem";
            scaleViewToolStripMenuItem.Size = new Size(245, 22);
            scaleViewToolStripMenuItem.Text = "Scale View";
            // 
            // linearToolStripMenuItem
            // 
            linearToolStripMenuItem.Checked = true;
            linearToolStripMenuItem.CheckState = CheckState.Checked;
            linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            linearToolStripMenuItem.Size = new Size(106, 22);
            linearToolStripMenuItem.Text = "Linear";
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new Size(106, 22);
            logToolStripMenuItem.Text = "Log";
            // 
            // centerCursorToolStripMenuItem
            // 
            centerCursorToolStripMenuItem.Name = "centerCursorToolStripMenuItem";
            centerCursorToolStripMenuItem.Size = new Size(245, 22);
            centerCursorToolStripMenuItem.Text = "Center Cursor";
            // 
            // showCorsairCirclesToolStripMenuItem
            // 
            showCorsairCirclesToolStripMenuItem.Name = "showCorsairCirclesToolStripMenuItem";
            showCorsairCirclesToolStripMenuItem.Size = new Size(245, 22);
            showCorsairCirclesToolStripMenuItem.Text = "Show Corsair Circles";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(242, 6);
            // 
            // selectionToolStripMenuItem
            // 
            selectionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { simpleToolStripMenuItem, zoomToolStripMenuItem });
            selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            selectionToolStripMenuItem.Size = new Size(245, 22);
            selectionToolStripMenuItem.Text = "Selection";
            // 
            // simpleToolStripMenuItem
            // 
            simpleToolStripMenuItem.Checked = true;
            simpleToolStripMenuItem.CheckState = CheckState.Checked;
            simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            simpleToolStripMenuItem.Size = new Size(110, 22);
            simpleToolStripMenuItem.Text = "Simple";
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(110, 22);
            zoomToolStripMenuItem.Text = "Zoom";
            // 
            // unzoomToolStripMenuItem
            // 
            unzoomToolStripMenuItem.Name = "unzoomToolStripMenuItem";
            unzoomToolStripMenuItem.Size = new Size(245, 22);
            unzoomToolStripMenuItem.Text = "Unzoom";
            // 
            // zoomSelectedAreaToolStripMenuItem
            // 
            zoomSelectedAreaToolStripMenuItem.Name = "zoomSelectedAreaToolStripMenuItem";
            zoomSelectedAreaToolStripMenuItem.Size = new Size(245, 22);
            zoomSelectedAreaToolStripMenuItem.Text = "Zoom Selected Area";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(242, 6);
            // 
            // overlaysToolStripMenuItem
            // 
            overlaysToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showToolStripMenuItem, OverlayColorStripComboBox1, toolStripOverlayLineSize });
            overlaysToolStripMenuItem.Name = "overlaysToolStripMenuItem";
            overlaysToolStripMenuItem.Size = new Size(245, 22);
            overlaysToolStripMenuItem.Text = "Overlays";
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Checked = true;
            showToolStripMenuItem.CheckState = CheckState.Checked;
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(181, 22);
            showToolStripMenuItem.Text = "Show";
            // 
            // OverlayColorStripComboBox1
            // 
            OverlayColorStripComboBox1.AccessibleRole = AccessibleRole.ScrollBar;
            OverlayColorStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            OverlayColorStripComboBox1.Items.AddRange(new object[] { "Blue", "Red", "Yellow", "Green", "LightBlue", "Pink", "Violet" });
            OverlayColorStripComboBox1.Name = "OverlayColorStripComboBox1";
            OverlayColorStripComboBox1.Size = new Size(121, 23);
            // 
            // toolStripOverlayLineSize
            // 
            toolStripOverlayLineSize.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripOverlayLineSize.Items.AddRange(new object[] { "Line Width 1", "Line Width 2", "Line Width 3", "Line Width 5", "Line Width 10" });
            toolStripOverlayLineSize.Name = "toolStripOverlayLineSize";
            toolStripOverlayLineSize.Size = new Size(121, 23);
            // 
            // CM_CMPLX
            // 
            CM_CMPLX.DropDownItems.AddRange(new ToolStripItem[] { CM_cmplxAbs, CM_cmplxPhase, CM_cmplxReal, CM_cmplxImag });
            CM_CMPLX.Name = "CM_CMPLX";
            CM_CMPLX.Size = new Size(245, 22);
            CM_CMPLX.Text = "Show Complex";
            // 
            // CM_cmplxAbs
            // 
            CM_cmplxAbs.Checked = true;
            CM_cmplxAbs.CheckState = CheckState.Checked;
            CM_cmplxAbs.Name = "CM_cmplxAbs";
            CM_cmplxAbs.Size = new Size(121, 22);
            CM_cmplxAbs.Text = "Absolute";
            // 
            // CM_cmplxPhase
            // 
            CM_cmplxPhase.Name = "CM_cmplxPhase";
            CM_cmplxPhase.Size = new Size(121, 22);
            CM_cmplxPhase.Text = "Phase";
            // 
            // CM_cmplxReal
            // 
            CM_cmplxReal.Name = "CM_cmplxReal";
            CM_cmplxReal.Size = new Size(121, 22);
            CM_cmplxReal.Text = "Real";
            // 
            // CM_cmplxImag
            // 
            CM_cmplxImag.Name = "CM_cmplxImag";
            CM_cmplxImag.Size = new Size(121, 22);
            CM_cmplxImag.Text = "Imag";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(4, 740);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            tableLayoutPanel1.SetRowSpan(label3, 2);
            label3.Size = new Size(51, 60);
            label3.TabIndex = 0;
            label3.Text = "Max";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(1044, 740);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(72, 30);
            label4.TabIndex = 0;
            label4.Text = "Gamma";
            // 
            // NumericGamma
            // 
            NumericGamma.DecimalPlaces = 3;
            NumericGamma.Dock = DockStyle.Fill;
            NumericGamma.Location = new Point(1124, 743);
            NumericGamma.Margin = new Padding(4, 3, 4, 3);
            NumericGamma.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumericGamma.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            NumericGamma.Name = "NumericGamma";
            NumericGamma.Size = new Size(72, 23);
            NumericGamma.TabIndex = 2;
            NumericGamma.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBoxCursorInfo
            // 
            tableLayoutPanel1.SetColumnSpan(textBoxCursorInfo, 5);
            textBoxCursorInfo.Dock = DockStyle.Fill;
            textBoxCursorInfo.Location = new Point(4, 553);
            textBoxCursorInfo.Margin = new Padding(4, 3, 4, 3);
            textBoxCursorInfo.Multiline = true;
            textBoxCursorInfo.Name = "textBoxCursorInfo";
            textBoxCursorInfo.ReadOnly = true;
            textBoxCursorInfo.Size = new Size(1032, 24);
            textBoxCursorInfo.TabIndex = 4;
            textBoxCursorInfo.WordWrap = false;
            // 
            // NumericMax
            // 
            NumericMax.DecimalPlaces = 3;
            NumericMax.Dock = DockStyle.Fill;
            NumericMax.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            NumericMax.Location = new Point(63, 743);
            NumericMax.Margin = new Padding(4, 3, 4, 3);
            NumericMax.Name = "NumericMax";
            tableLayoutPanel1.SetRowSpan(NumericMax, 2);
            NumericMax.Size = new Size(92, 35);
            NumericMax.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(163, 740);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            tableLayoutPanel1.SetRowSpan(label2, 2);
            label2.Size = new Size(51, 60);
            label2.TabIndex = 0;
            label2.Text = "Min";
            // 
            // textBoxSelectionInfo
            // 
            textBoxSelectionInfo.Dock = DockStyle.Fill;
            textBoxSelectionInfo.Location = new Point(322, 743);
            textBoxSelectionInfo.Margin = new Padding(4, 3, 4, 3);
            textBoxSelectionInfo.Multiline = true;
            textBoxSelectionInfo.Name = "textBoxSelectionInfo";
            textBoxSelectionInfo.ReadOnly = true;
            tableLayoutPanel1.SetRowSpan(textBoxSelectionInfo, 2);
            textBoxSelectionInfo.Size = new Size(714, 54);
            textBoxSelectionInfo.TabIndex = 5;
            // 
            // textBoxFrameLoadTime
            // 
            tableLayoutPanel1.SetColumnSpan(textBoxFrameLoadTime, 2);
            textBoxFrameLoadTime.Dock = DockStyle.Fill;
            textBoxFrameLoadTime.Location = new Point(1044, 553);
            textBoxFrameLoadTime.Margin = new Padding(4, 3, 4, 3);
            textBoxFrameLoadTime.Name = "textBoxFrameLoadTime";
            textBoxFrameLoadTime.ReadOnly = true;
            textBoxFrameLoadTime.Size = new Size(152, 23);
            textBoxFrameLoadTime.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // imageViewerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "imageViewerControl";
            Size = new Size(1200, 800);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)trackBar1).EndInit();
            ((ISupportInitialize)NumericMin).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            CM_ImgCM.ResumeLayout(false);
            ((ISupportInitialize)NumericGamma).EndInit();
            ((ISupportInitialize)NumericMax).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ContextMenuStrip CM_ImgCM;
        private ToolStripMenuItem CMItemSave;
        private ToolStripMenuItem keepAspektRatioToolStripMenuItem;
        private ToolStripMenuItem showCorsairCirclesToolStripMenuItem;
        private ToolStripMenuItem CMcopytoClipboard;
        private ToolStripMenuItem CM_CMPLX;
        private ToolStripMenuItem CM_cmplxAbs;
        private ToolStripMenuItem CM_cmplxPhase;
        private ToolStripMenuItem CM_cmplxReal;
        private ToolStripMenuItem CM_cmplxImag;
        //private ScottPlot.WinForms.FormsPlot PlotFormX;
        private ToolStripMenuItem centerCursorToolStripMenuItem;
        //private ScottPlot.WinForms.FormsPlot PlotFormY;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown NumericMax;
        private NumericUpDown NumericGamma;
        private ToolStripMenuItem autoscaleToolStripMenuItem;
        private ToolStripMenuItem selectionToolStripMenuItem;
        private ToolStripMenuItem simpleToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem unzoomToolStripMenuItem;
        private ToolStripMenuItem scaleViewToolStripMenuItem;
        private ToolStripMenuItem linearToolStripMenuItem;
        private ToolStripMenuItem logToolStripMenuItem;
        private ToolStripMenuItem saveInclOverlaysToolStripMenuItem;
        private ToolStripMenuItem copyToClipboardInclOverlaysToolStripMenuItem;
        private ToolStripMenuItem overlaysToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripComboBox OverlayColorStripComboBox1;
        private ToolStripComboBox toolStripOverlayLineSize;
        private ToolStripMenuItem zoomSelectedAreaToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem highlightThresholdedAreasToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private NumericUpDown NumericMin;
        private TrackBar trackBar1;
        private ToolStripMenuItem rescaleToolStripMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn parCol;
        private DataGridViewTextBoxColumn ValueCol;
        private TextBox textBoxCursorInfo;
        private TextBox textBoxSelectionInfo;
        private TextBox textBoxFrameLoadTime;
        private BackgroundWorker backgroundWorker1;
    }
}
