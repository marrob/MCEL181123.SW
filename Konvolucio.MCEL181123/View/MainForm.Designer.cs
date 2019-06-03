namespace Konvolucio.MCEL181123
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLastModify = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRowColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainViewControl1 = new Konvolucio.MCEL181123.MainViewControl();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLoadTime,
            this.toolStripStatusLabelLastModify,
            this.toolStripStatusLabelRowColumn,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 187);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(0, 19);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLoadTime
            // 
            this.toolStripStatusLoadTime.Name = "toolStripStatusLoadTime";
            this.toolStripStatusLoadTime.Size = new System.Drawing.Size(63, 19);
            this.toolStripStatusLoadTime.Text = "Load Time";
            // 
            // toolStripStatusLabelLastModify
            // 
            this.toolStripStatusLabelLastModify.AutoToolTip = true;
            this.toolStripStatusLabelLastModify.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelLastModify.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelLastModify.Name = "toolStripStatusLabelLastModify";
            this.toolStripStatusLabelLastModify.Size = new System.Drawing.Size(121, 19);
            this.toolStripStatusLabelLastModify.Text = "Last write timestamp";
            // 
            // toolStripStatusLabelRowColumn
            // 
            this.toolStripStatusLabelRowColumn.AutoToolTip = true;
            this.toolStripStatusLabelRowColumn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabelRowColumn.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelRowColumn.Name = "toolStripStatusLabelRowColumn";
            this.toolStripStatusLabelRowColumn.Size = new System.Drawing.Size(80, 19);
            this.toolStripStatusLabelRowColumn.Text = "Row Column";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(344, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(58, 19);
            this.toolStripStatusLabelVersion.Text = "VERSION";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Orange;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(103, 19);
            this.toolStripStatusLabel2.Text = "KONVOLUCIÓ BT";
            // 
            // mainViewControl1
            // 
            this.mainViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewControl1.Location = new System.Drawing.Point(0, 24);
            this.mainViewControl1.Name = "mainViewControl1";
            this.mainViewControl1.Size = new System.Drawing.Size(784, 163);
            this.mainViewControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 211);
            this.Controls.Add(this.mainViewControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private MainViewControl mainViewControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoadTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLastModify;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRowColumn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

