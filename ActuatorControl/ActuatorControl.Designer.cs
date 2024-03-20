namespace ActuatorControl
{
    partial class ActuatorControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTextBox_StepMin = new System.Windows.Forms.ToolStripTextBox();
            this.cmTextBox_StepMid = new System.Windows.Forms.ToolStripTextBox();
            this.cmTextBox_StepMax = new System.Windows.Forms.ToolStripTextBox();
            this.velocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTextBox_Vel = new System.Windows.Forms.ToolStripTextBox();
            this.acceleartionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTextBox_Acc = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setToDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LAB_DIRECTION = new System.Windows.Forms.Label();
            this.LAB_NAME = new System.Windows.Forms.Label();
            this.BUTTON_pos0 = new System.Windows.Forms.Button();
            this.BUTTON_pos1 = new System.Windows.Forms.Button();
            this.BUTTON_pos2 = new System.Windows.Forms.Button();
            this.BUTTON_neg0 = new System.Windows.Forms.Button();
            this.BUTTON_neg1 = new System.Windows.Forms.Button();
            this.BUTTON_neg2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LAB_UNI = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.tableLayoutPanel1.Controls.Add(this.LAB_DIRECTION, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LAB_NAME, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_pos0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_pos1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_pos2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_neg0, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_neg1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BUTTON_neg2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LAB_UNI, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextToolStripMenuItem,
            this.velocityToolStripMenuItem,
            this.acceleartionToolStripMenuItem,
            this.toolStripSeparator1,
            this.setToDeviceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 98);
            // 
            // contextToolStripMenuItem
            // 
            this.contextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTextBox_StepMin,
            this.cmTextBox_StepMid,
            this.cmTextBox_StepMax});
            this.contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            this.contextToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.contextToolStripMenuItem.Text = "StepSize";
            // 
            // cmTextBox_StepMin
            // 
            this.cmTextBox_StepMin.Name = "cmTextBox_StepMin";
            this.cmTextBox_StepMin.Size = new System.Drawing.Size(100, 23);
            // 
            // cmTextBox_StepMid
            // 
            this.cmTextBox_StepMid.Name = "cmTextBox_StepMid";
            this.cmTextBox_StepMid.Size = new System.Drawing.Size(100, 23);
            // 
            // cmTextBox_StepMax
            // 
            this.cmTextBox_StepMax.Name = "cmTextBox_StepMax";
            this.cmTextBox_StepMax.Size = new System.Drawing.Size(100, 23);
            // 
            // velocityToolStripMenuItem
            // 
            this.velocityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTextBox_Vel});
            this.velocityToolStripMenuItem.Name = "velocityToolStripMenuItem";
            this.velocityToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.velocityToolStripMenuItem.Text = "Velocity";
            // 
            // cmTextBox_Vel
            // 
            this.cmTextBox_Vel.Name = "cmTextBox_Vel";
            this.cmTextBox_Vel.Size = new System.Drawing.Size(100, 23);
            // 
            // acceleartionToolStripMenuItem
            // 
            this.acceleartionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTextBox_Acc});
            this.acceleartionToolStripMenuItem.Name = "acceleartionToolStripMenuItem";
            this.acceleartionToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.acceleartionToolStripMenuItem.Text = "Acceleartion";
            // 
            // cmTextBox_Acc
            // 
            this.cmTextBox_Acc.Name = "cmTextBox_Acc";
            this.cmTextBox_Acc.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // setToDeviceToolStripMenuItem
            // 
            this.setToDeviceToolStripMenuItem.Name = "setToDeviceToolStripMenuItem";
            this.setToDeviceToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.setToDeviceToolStripMenuItem.Text = "Set to device";
            this.setToDeviceToolStripMenuItem.Click += new System.EventHandler(this.setToDeviceToolStripMenuItem_Click);
            // 
            // LAB_DIRECTION
            // 
            this.LAB_DIRECTION.AutoSize = true;
            this.LAB_DIRECTION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LAB_DIRECTION.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LAB_DIRECTION.Location = new System.Drawing.Point(3, 0);
            this.LAB_DIRECTION.Name = "LAB_DIRECTION";
            this.LAB_DIRECTION.Size = new System.Drawing.Size(43, 26);
            this.LAB_DIRECTION.TabIndex = 0;
            this.LAB_DIRECTION.Text = "NA";
            this.LAB_DIRECTION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LAB_NAME
            // 
            this.LAB_NAME.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LAB_NAME, 2);
            this.LAB_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LAB_NAME.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LAB_NAME.Location = new System.Drawing.Point(52, 0);
            this.LAB_NAME.Name = "LAB_NAME";
            this.LAB_NAME.Size = new System.Drawing.Size(95, 26);
            this.LAB_NAME.TabIndex = 1;
            this.LAB_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BUTTON_pos0
            // 
            this.BUTTON_pos0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_pos0.Location = new System.Drawing.Point(3, 29);
            this.BUTTON_pos0.Name = "BUTTON_pos0";
            this.BUTTON_pos0.Size = new System.Drawing.Size(43, 20);
            this.BUTTON_pos0.TabIndex = 2;
            this.BUTTON_pos0.Text = "+";
            this.BUTTON_pos0.UseVisualStyleBackColor = true;
            // 
            // BUTTON_pos1
            // 
            this.BUTTON_pos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_pos1.Location = new System.Drawing.Point(52, 29);
            this.BUTTON_pos1.Name = "BUTTON_pos1";
            this.BUTTON_pos1.Size = new System.Drawing.Size(44, 20);
            this.BUTTON_pos1.TabIndex = 2;
            this.BUTTON_pos1.Text = "++";
            this.BUTTON_pos1.UseVisualStyleBackColor = true;
            // 
            // BUTTON_pos2
            // 
            this.BUTTON_pos2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_pos2.Location = new System.Drawing.Point(102, 29);
            this.BUTTON_pos2.Name = "BUTTON_pos2";
            this.BUTTON_pos2.Size = new System.Drawing.Size(45, 20);
            this.BUTTON_pos2.TabIndex = 2;
            this.BUTTON_pos2.Text = "+++";
            this.BUTTON_pos2.UseVisualStyleBackColor = true;
            // 
            // BUTTON_neg0
            // 
            this.BUTTON_neg0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_neg0.Location = new System.Drawing.Point(3, 55);
            this.BUTTON_neg0.Name = "BUTTON_neg0";
            this.BUTTON_neg0.Size = new System.Drawing.Size(43, 20);
            this.BUTTON_neg0.TabIndex = 2;
            this.BUTTON_neg0.Text = "-";
            this.BUTTON_neg0.UseVisualStyleBackColor = true;
            // 
            // BUTTON_neg1
            // 
            this.BUTTON_neg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_neg1.Location = new System.Drawing.Point(52, 55);
            this.BUTTON_neg1.Name = "BUTTON_neg1";
            this.BUTTON_neg1.Size = new System.Drawing.Size(44, 20);
            this.BUTTON_neg1.TabIndex = 2;
            this.BUTTON_neg1.Text = "--";
            this.BUTTON_neg1.UseVisualStyleBackColor = true;
            // 
            // BUTTON_neg2
            // 
            this.BUTTON_neg2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BUTTON_neg2.Location = new System.Drawing.Point(102, 55);
            this.BUTTON_neg2.Name = "BUTTON_neg2";
            this.BUTTON_neg2.Size = new System.Drawing.Size(45, 20);
            this.BUTTON_neg2.TabIndex = 2;
            this.BUTTON_neg2.Text = "---";
            this.BUTTON_neg2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.numericUpDown1, 2);
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDown1.Location = new System.Drawing.Point(3, 81);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(93, 29);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // LAB_UNI
            // 
            this.LAB_UNI.AutoSize = true;
            this.LAB_UNI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LAB_UNI.Location = new System.Drawing.Point(102, 78);
            this.LAB_UNI.Name = "LAB_UNI";
            this.LAB_UNI.Size = new System.Drawing.Size(45, 47);
            this.LAB_UNI.TabIndex = 4;
            this.LAB_UNI.Text = "mm";
            this.LAB_UNI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActuatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ActuatorControl";
            this.Size = new System.Drawing.Size(150, 125);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label LAB_DIRECTION;
        private Label LAB_NAME;
        private Button BUTTON_pos0;
        private Button BUTTON_pos1;
        private Button BUTTON_pos2;
        private Button BUTTON_neg0;
        private Button BUTTON_neg1;
        private Button BUTTON_neg2;
        private NumericUpDown numericUpDown1;
        private Label LAB_UNI;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem contextToolStripMenuItem;
        private ToolStripTextBox cmTextBox_StepMin;
        private ToolStripTextBox cmTextBox_StepMid;
        private ToolStripTextBox cmTextBox_StepMax;
        private ToolStripMenuItem velocityToolStripMenuItem;
        private ToolStripTextBox cmTextBox_Vel;
        private ToolStripMenuItem acceleartionToolStripMenuItem;
        private ToolStripTextBox cmTextBox_Acc;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem setToDeviceToolStripMenuItem;
    }
}
