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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextToolStripMenuItem = new ToolStripMenuItem();
            cmTextBox_StepMin = new ToolStripTextBox();
            cmTextBox_StepMid = new ToolStripTextBox();
            cmTextBox_StepMax = new ToolStripTextBox();
            velocityToolStripMenuItem = new ToolStripMenuItem();
            cmTextBox_Vel = new ToolStripTextBox();
            acceleartionToolStripMenuItem = new ToolStripMenuItem();
            cmTextBox_Acc = new ToolStripTextBox();
            LAB_DIRECTION = new Label();
            LAB_NAME = new Label();
            BUTTON_pos0 = new Button();
            BUTTON_pos1 = new Button();
            BUTTON_pos2 = new Button();
            BUTTON_neg0 = new Button();
            BUTTON_neg1 = new Button();
            BUTTON_neg2 = new Button();
            numericUpDown1 = new NumericUpDown();
            LAB_UNI = new Label();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
            tableLayoutPanel1.Controls.Add(LAB_DIRECTION, 0, 0);
            tableLayoutPanel1.Controls.Add(LAB_NAME, 1, 0);
            tableLayoutPanel1.Controls.Add(BUTTON_pos0, 0, 1);
            tableLayoutPanel1.Controls.Add(BUTTON_pos1, 1, 1);
            tableLayoutPanel1.Controls.Add(BUTTON_pos2, 2, 1);
            tableLayoutPanel1.Controls.Add(BUTTON_neg0, 0, 2);
            tableLayoutPanel1.Controls.Add(BUTTON_neg1, 1, 2);
            tableLayoutPanel1.Controls.Add(BUTTON_neg2, 2, 2);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 0, 3);
            tableLayoutPanel1.Controls.Add(LAB_UNI, 2, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(150, 125);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { contextToolStripMenuItem, velocityToolStripMenuItem, acceleartionToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 92);
            // 
            // contextToolStripMenuItem
            // 
            contextToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cmTextBox_StepMin, cmTextBox_StepMid, cmTextBox_StepMax });
            contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            contextToolStripMenuItem.Size = new Size(180, 22);
            contextToolStripMenuItem.Text = "StepSize";
            // 
            // cmTextBox_StepMin
            // 
            cmTextBox_StepMin.Name = "cmTextBox_StepMin";
            cmTextBox_StepMin.Size = new Size(100, 23);
            cmTextBox_StepMin.TextChanged += cmTextBox_TextChanged;
            // 
            // cmTextBox_StepMid
            // 
            cmTextBox_StepMid.Name = "cmTextBox_StepMid";
            cmTextBox_StepMid.Size = new Size(100, 23);
            cmTextBox_StepMid.TextChanged += cmTextBox_TextChanged;
            // 
            // cmTextBox_StepMax
            // 
            cmTextBox_StepMax.Name = "cmTextBox_StepMax";
            cmTextBox_StepMax.Size = new Size(100, 23);
            cmTextBox_StepMax.TextChanged += cmTextBox_TextChanged;
            // 
            // velocityToolStripMenuItem
            // 
            velocityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cmTextBox_Vel });
            velocityToolStripMenuItem.Name = "velocityToolStripMenuItem";
            velocityToolStripMenuItem.Size = new Size(180, 22);
            velocityToolStripMenuItem.Text = "Velocity";
            // 
            // cmTextBox_Vel
            // 
            cmTextBox_Vel.Name = "cmTextBox_Vel";
            cmTextBox_Vel.Size = new Size(100, 23);
            cmTextBox_Vel.TextChanged += cmTextBox_TextChanged;
            // 
            // acceleartionToolStripMenuItem
            // 
            acceleartionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cmTextBox_Acc });
            acceleartionToolStripMenuItem.Name = "acceleartionToolStripMenuItem";
            acceleartionToolStripMenuItem.Size = new Size(180, 22);
            acceleartionToolStripMenuItem.Text = "Acceleartion";
            // 
            // cmTextBox_Acc
            // 
            cmTextBox_Acc.Name = "cmTextBox_Acc";
            cmTextBox_Acc.Size = new Size(100, 23);
            cmTextBox_Acc.TextChanged += cmTextBox_TextChanged;
            // 
            // LAB_DIRECTION
            // 
            LAB_DIRECTION.AutoSize = true;
            LAB_DIRECTION.Dock = DockStyle.Fill;
            LAB_DIRECTION.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LAB_DIRECTION.Location = new Point(3, 0);
            LAB_DIRECTION.Name = "LAB_DIRECTION";
            LAB_DIRECTION.Size = new Size(43, 30);
            LAB_DIRECTION.TabIndex = 0;
            LAB_DIRECTION.Text = "NA";
            LAB_DIRECTION.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LAB_NAME
            // 
            LAB_NAME.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(LAB_NAME, 2);
            LAB_NAME.Dock = DockStyle.Fill;
            LAB_NAME.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LAB_NAME.Location = new Point(52, 0);
            LAB_NAME.Name = "LAB_NAME";
            LAB_NAME.Size = new Size(95, 30);
            LAB_NAME.TabIndex = 1;
            LAB_NAME.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BUTTON_pos0
            // 
            BUTTON_pos0.Dock = DockStyle.Fill;
            BUTTON_pos0.Location = new Point(3, 33);
            BUTTON_pos0.Name = "BUTTON_pos0";
            BUTTON_pos0.Size = new Size(43, 24);
            BUTTON_pos0.TabIndex = 2;
            BUTTON_pos0.Text = "+";
            BUTTON_pos0.UseVisualStyleBackColor = true;
            BUTTON_pos0.Click += BUTTON_pos0_Click;
            // 
            // BUTTON_pos1
            // 
            BUTTON_pos1.Dock = DockStyle.Fill;
            BUTTON_pos1.Location = new Point(52, 33);
            BUTTON_pos1.Name = "BUTTON_pos1";
            BUTTON_pos1.Size = new Size(44, 24);
            BUTTON_pos1.TabIndex = 2;
            BUTTON_pos1.Text = "++";
            BUTTON_pos1.UseVisualStyleBackColor = true;
            BUTTON_pos1.Click += BUTTON_pos1_Click;
            // 
            // BUTTON_pos2
            // 
            BUTTON_pos2.Dock = DockStyle.Fill;
            BUTTON_pos2.Location = new Point(102, 33);
            BUTTON_pos2.Name = "BUTTON_pos2";
            BUTTON_pos2.Size = new Size(45, 24);
            BUTTON_pos2.TabIndex = 2;
            BUTTON_pos2.Text = "+++";
            BUTTON_pos2.UseVisualStyleBackColor = true;
            BUTTON_pos2.Click += BUTTON_pos2_Click;
            // 
            // BUTTON_neg0
            // 
            BUTTON_neg0.Dock = DockStyle.Fill;
            BUTTON_neg0.Location = new Point(3, 63);
            BUTTON_neg0.Name = "BUTTON_neg0";
            BUTTON_neg0.Size = new Size(43, 24);
            BUTTON_neg0.TabIndex = 2;
            BUTTON_neg0.Text = "-";
            BUTTON_neg0.UseVisualStyleBackColor = true;
            BUTTON_neg0.Click += BUTTON_neg0_Click;
            // 
            // BUTTON_neg1
            // 
            BUTTON_neg1.Dock = DockStyle.Fill;
            BUTTON_neg1.Location = new Point(52, 63);
            BUTTON_neg1.Name = "BUTTON_neg1";
            BUTTON_neg1.Size = new Size(44, 24);
            BUTTON_neg1.TabIndex = 2;
            BUTTON_neg1.Text = "--";
            BUTTON_neg1.UseVisualStyleBackColor = true;
            BUTTON_neg1.Click += BUTTON_neg1_Click;
            // 
            // BUTTON_neg2
            // 
            BUTTON_neg2.Dock = DockStyle.Fill;
            BUTTON_neg2.Location = new Point(102, 63);
            BUTTON_neg2.Name = "BUTTON_neg2";
            BUTTON_neg2.Size = new Size(45, 24);
            BUTTON_neg2.TabIndex = 2;
            BUTTON_neg2.Text = "---";
            BUTTON_neg2.UseVisualStyleBackColor = true;
            BUTTON_neg2.Click += BUTTON_neg2_Click;
            // 
            // numericUpDown1
            // 
            tableLayoutPanel1.SetColumnSpan(numericUpDown1, 2);
            numericUpDown1.DecimalPlaces = 3;
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(3, 93);
            numericUpDown1.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1000000000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(93, 29);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // LAB_UNI
            // 
            LAB_UNI.AutoSize = true;
            LAB_UNI.Dock = DockStyle.Fill;
            LAB_UNI.Location = new Point(102, 90);
            LAB_UNI.Name = "LAB_UNI";
            LAB_UNI.Size = new Size(45, 35);
            LAB_UNI.TabIndex = 4;
            LAB_UNI.Text = "mm";
            LAB_UNI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ActuatorControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ActuatorControl";
            Size = new Size(150, 125);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
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
    }
}
