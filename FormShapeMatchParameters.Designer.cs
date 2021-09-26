
namespace EmguCVDemoJmalino
{
    partial class FormShapeMatchParameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.submenutoolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.submenutoolStripMenuItemRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.submenutoolStripMenuItemScale = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbMinArea = new System.Windows.Forms.TextBox();
            this.tbDistanceThreshold = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenutoolStripMenuItemOpen,
            this.submenutoolStripMenuItemRotate,
            this.submenutoolStripMenuItemScale});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // submenutoolStripMenuItemOpen
            // 
            this.submenutoolStripMenuItemOpen.Name = "submenutoolStripMenuItemOpen";
            this.submenutoolStripMenuItemOpen.Size = new System.Drawing.Size(108, 22);
            this.submenutoolStripMenuItemOpen.Text = "Open";
            this.submenutoolStripMenuItemOpen.Click += new System.EventHandler(this.submenutoolStripMenuItemOpen_Click);
            // 
            // submenutoolStripMenuItemRotate
            // 
            this.submenutoolStripMenuItemRotate.Name = "submenutoolStripMenuItemRotate";
            this.submenutoolStripMenuItemRotate.Size = new System.Drawing.Size(108, 22);
            this.submenutoolStripMenuItemRotate.Text = "Rotate";
            this.submenutoolStripMenuItemRotate.Click += new System.EventHandler(this.submenutoolStripMenuItemRotate_Click);
            // 
            // submenutoolStripMenuItemScale
            // 
            this.submenutoolStripMenuItemScale.Name = "submenutoolStripMenuItemScale";
            this.submenutoolStripMenuItemScale.Size = new System.Drawing.Size(108, 22);
            this.submenutoolStripMenuItemScale.Text = "Scale";
            this.submenutoolStripMenuItemScale.Click += new System.EventHandler(this.submenutoolStripMenuItemScale_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.tbMinArea);
            this.panel1.Controls.Add(this.tbDistanceThreshold);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 100);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(392, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "I1",
            "I2",
            "I3"});
            this.comboBox1.Location = new System.Drawing.Point(8, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 6;
            // 
            // tbMinArea
            // 
            this.tbMinArea.Location = new System.Drawing.Point(135, 69);
            this.tbMinArea.Name = "tbMinArea";
            this.tbMinArea.Size = new System.Drawing.Size(121, 23);
            this.tbMinArea.TabIndex = 5;
            this.tbMinArea.Text = "1000";
            // 
            // tbDistanceThreshold
            // 
            this.tbDistanceThreshold.Location = new System.Drawing.Point(265, 69);
            this.tbDistanceThreshold.Name = "tbDistanceThreshold";
            this.tbDistanceThreshold.Size = new System.Drawing.Size(121, 23);
            this.tbDistanceThreshold.TabIndex = 4;
            this.tbDistanceThreshold.Text = "0.0001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dist Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Min. Area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance Type";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 550);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormShapeMatchParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 674);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormShapeMatchParameters";
            this.Text = "Shape Match Parameters";
            this.TopMost = true;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem submenutoolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem submenutoolStripMenuItemRotate;
        private System.Windows.Forms.ToolStripMenuItem submenutoolStripMenuItemScale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tbMinArea;
        private System.Windows.Forms.TextBox tbDistanceThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}