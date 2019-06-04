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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.columnRack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnModul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coulmnCCset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coulmnCMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 267);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 267);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 267);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnRack,
            this.columnModul,
            this.columnVSet,
            this.columnCRange,
            this.coulmnCCset,
            this.columnOe,
            this.columnVMon,
            this.coulmnCMon});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(612, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(168, 267);
            this.treeView1.TabIndex = 0;
            // 
            // columnRack
            // 
            this.columnRack.DataPropertyName = "Rack";
            this.columnRack.Frozen = true;
            this.columnRack.HeaderText = "Rack";
            this.columnRack.Name = "columnRack";
            this.columnRack.Width = 60;
            // 
            // columnModul
            // 
            this.columnModul.DataPropertyName = "Modul";
            this.columnModul.Frozen = true;
            this.columnModul.HeaderText = "Modul";
            this.columnModul.Name = "columnModul";
            this.columnModul.Width = 50;
            // 
            // columnVSet
            // 
            this.columnVSet.DataPropertyName = "VSet";
            this.columnVSet.HeaderText = "CV Set";
            this.columnVSet.Name = "columnVSet";
            this.columnVSet.Width = 80;
            // 
            // columnCRange
            // 
            this.columnCRange.HeaderText = "C Rng [A]";
            this.columnCRange.Name = "columnCRange";
            // 
            // coulmnCCset
            // 
            this.coulmnCCset.DataPropertyName = "CSet";
            this.coulmnCCset.HeaderText = "CC Set [A]";
            this.coulmnCCset.Name = "coulmnCCset";
            this.coulmnCCset.Width = 80;
            // 
            // columnOe
            // 
            this.columnOe.DataPropertyName = "OeSet";
            this.columnOe.HeaderText = "OE Set";
            this.columnOe.Name = "columnOe";
            this.columnOe.Width = 80;
            // 
            // columnVMon
            // 
            this.columnVMon.DataPropertyName = "VMon";
            this.columnVMon.HeaderText = "V Mon [V]";
            this.columnVMon.Name = "columnVMon";
            this.columnVMon.ReadOnly = true;
            this.columnVMon.ToolTipText = "\"Measured Voltage\"";
            this.columnVMon.Width = 80;
            // 
            // coulmnCMon
            // 
            this.coulmnCMon.HeaderText = "C Mon [A]";
            this.coulmnCMon.Name = "coulmnCMon";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 313);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRack;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnModul;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnCCset;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOe;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnCMon;
    }
}

