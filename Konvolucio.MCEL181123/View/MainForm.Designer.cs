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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new Konvolucio.MCEL181123.Controls.KnvDataGridView();
            this.signalSendViewControl1 = new Konvolucio.MCEL181123.View.SignalSendViewControl();
            this.columnRack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnModul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coulmnCrng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVmeas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coulmnCmeas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatusOe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coulmnStatusCv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coulmnStatusCc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coulmnUcTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTrTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coulmnRunTimeTick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRxErr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTxErr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRxTestCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 169);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(874, 22);
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
            this.panel1.Size = new System.Drawing.Size(874, 145);
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
            this.splitContainer1.Size = new System.Drawing.Size(874, 145);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(190, 145);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 145);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.signalSendViewControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 145);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BackgroundText = "Cell Emulators";
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnRack,
            this.columnModul,
            this.coulmnCrng,
            this.columnVmeas,
            this.coulmnCmeas,
            this.columnStatusOe,
            this.coulmnStatusCv,
            this.coulmnStatusCc,
            this.coulmnUcTemp,
            this.columnTrTemp,
            this.coulmnRunTimeTick,
            this.columnRxErr,
            this.columnTxErr,
            this.columnRxTestCnt,
            this.columnVersion});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.FirstZebraColor = System.Drawing.Color.Bisque;
            this.dataGridView1.Location = new System.Drawing.Point(3, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SecondZebraColor = System.Drawing.Color.White;
            this.dataGridView1.Size = new System.Drawing.Size(674, 92);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ZebraRow = true;
            // 
            // signalSendViewControl1
            // 
            this.signalSendViewControl1.Address = ((byte)(0));
            this.signalSendViewControl1.Broadcast = true;
            this.signalSendViewControl1.Location = new System.Drawing.Point(3, 3);
            this.signalSendViewControl1.Name = "signalSendViewControl1";
            this.signalSendViewControl1.SelectedSignal = "Broadcast";
            this.signalSendViewControl1.Size = new System.Drawing.Size(674, 41);
            this.signalSendViewControl1.TabIndex = 1;
            this.signalSendViewControl1.Value = "";
            // 
            // columnRack
            // 
            this.columnRack.DataPropertyName = "Rack";
            dataGridViewCellStyle1.NullValue = null;
            this.columnRack.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnRack.Frozen = true;
            this.columnRack.HeaderText = "Rack [0..15]";
            this.columnRack.Name = "columnRack";
            // 
            // columnModul
            // 
            this.columnModul.DataPropertyName = "Modul";
            this.columnModul.Frozen = true;
            this.columnModul.HeaderText = "Modul [0..15]";
            this.columnModul.Name = "columnModul";
            // 
            // coulmnCrng
            // 
            this.coulmnCrng.DataPropertyName = "SIG_MCEL_C_RANGE";
            this.coulmnCrng.HeaderText = "C RANGE";
            this.coulmnCrng.Name = "coulmnCrng";
            // 
            // columnVmeas
            // 
            this.columnVmeas.DataPropertyName = "SIG_MCEL_V_MEAS";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.columnVmeas.DefaultCellStyle = dataGridViewCellStyle2;
            this.columnVmeas.HeaderText = "V meas [V]";
            this.columnVmeas.Name = "columnVmeas";
            this.columnVmeas.ReadOnly = true;
            // 
            // coulmnCmeas
            // 
            this.coulmnCmeas.DataPropertyName = "SIG_MCEL_C_MEAS";
            dataGridViewCellStyle3.Format = "N4";
            this.coulmnCmeas.DefaultCellStyle = dataGridViewCellStyle3;
            this.coulmnCmeas.HeaderText = "C meas [A]";
            this.coulmnCmeas.Name = "coulmnCmeas";
            // 
            // columnStatusOe
            // 
            this.columnStatusOe.DataPropertyName = "SIG_MCEL_OE_STATUS";
            this.columnStatusOe.HeaderText = "OE";
            this.columnStatusOe.Name = "columnStatusOe";
            this.columnStatusOe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnStatusOe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnStatusOe.Width = 50;
            // 
            // coulmnStatusCv
            // 
            this.coulmnStatusCv.DataPropertyName = "SIG_MCEL_CV_STATUS";
            this.coulmnStatusCv.HeaderText = "CV";
            this.coulmnStatusCv.Name = "coulmnStatusCv";
            this.coulmnStatusCv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coulmnStatusCv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.coulmnStatusCv.Width = 50;
            // 
            // coulmnStatusCc
            // 
            this.coulmnStatusCc.DataPropertyName = "SIG_MCEL_CC_STATUS";
            this.coulmnStatusCc.HeaderText = "CC";
            this.coulmnStatusCc.Name = "coulmnStatusCc";
            this.coulmnStatusCc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coulmnStatusCc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.coulmnStatusCc.Width = 50;
            // 
            // coulmnUcTemp
            // 
            this.coulmnUcTemp.DataPropertyName = "SIG_MCEL_UC_TEMP";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.coulmnUcTemp.DefaultCellStyle = dataGridViewCellStyle4;
            this.coulmnUcTemp.HeaderText = "uC Temp [°C]";
            this.coulmnUcTemp.Name = "coulmnUcTemp";
            // 
            // columnTrTemp
            // 
            this.columnTrTemp.DataPropertyName = "SIG_MCEL_TR_TEMP";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.columnTrTemp.DefaultCellStyle = dataGridViewCellStyle5;
            this.columnTrTemp.HeaderText = "Tr Temp [°C]";
            this.columnTrTemp.Name = "columnTrTemp";
            // 
            // coulmnRunTimeTick
            // 
            this.coulmnRunTimeTick.DataPropertyName = "SIG_MCEL_RUN_TIME_TICK";
            this.coulmnRunTimeTick.HeaderText = "Up Time [sec]";
            this.coulmnRunTimeTick.Name = "coulmnRunTimeTick";
            // 
            // columnRxErr
            // 
            this.columnRxErr.DataPropertyName = "SIG_MCEL_RXERRCNT";
            this.columnRxErr.HeaderText = "Rx Error";
            this.columnRxErr.Name = "columnRxErr";
            // 
            // columnTxErr
            // 
            this.columnTxErr.DataPropertyName = "SIG_MCEL_TXERRCNT";
            this.columnTxErr.HeaderText = "Tx Error";
            this.columnTxErr.Name = "columnTxErr";
            // 
            // columnRxTestCnt
            // 
            this.columnRxTestCnt.DataPropertyName = "SIG_MCEL_RXTESTCNT";
            this.columnRxTestCnt.HeaderText = "Rx Test Cnt";
            this.columnRxTestCnt.Name = "columnRxTestCnt";
            // 
            // columnVersion
            // 
            this.columnVersion.DataPropertyName = "SIG_MCEL_VERSION";
            dataGridViewCellStyle6.Format = "X8";
            this.columnVersion.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnVersion.HeaderText = "Version[YYMMDDHH]";
            this.columnVersion.Name = "columnVersion";
            this.columnVersion.Width = 150;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(890, 230);
            this.Name = "MainForm";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private Controls.KnvDataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private View.SignalSendViewControl signalSendViewControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRack;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnModul;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnCrng;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVmeas;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnCmeas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnStatusOe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coulmnStatusCv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coulmnStatusCc;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnUcTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTrTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn coulmnRunTimeTick;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRxErr;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTxErr;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRxTestCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVersion;
    }
}

