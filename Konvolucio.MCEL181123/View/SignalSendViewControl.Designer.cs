namespace Konvolucio.MCEL181123.View
{
    partial class SignalSendViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownRack = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownModul = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxScope = new System.Windows.Forms.ComboBox();
            this.comboBoxSignal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModul)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownRack
            // 
            this.numericUpDownRack.Location = new System.Drawing.Point(133, 17);
            this.numericUpDownRack.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownRack.Name = "numericUpDownRack";
            this.numericUpDownRack.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownRack.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rack:";
            // 
            // numericUpDownModul
            // 
            this.numericUpDownModul.Location = new System.Drawing.Point(184, 17);
            this.numericUpDownModul.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownModul.Name = "numericUpDownModul";
            this.numericUpDownModul.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownModul.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modul:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxScope
            // 
            this.comboBoxScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScope.FormattingEnabled = true;
            this.comboBoxScope.Items.AddRange(new object[] {
            "BROADCAST",
            "TARGETED"});
            this.comboBoxScope.Location = new System.Drawing.Point(6, 16);
            this.comboBoxScope.Name = "comboBoxScope";
            this.comboBoxScope.Size = new System.Drawing.Size(121, 21);
            this.comboBoxScope.TabIndex = 6;
            this.comboBoxScope.SelectedIndexChanged += new System.EventHandler(this.comboBoxScope_SelectedIndexChanged);
            // 
            // comboBoxSignal
            // 
            this.comboBoxSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSignal.FormattingEnabled = true;
            this.comboBoxSignal.Items.AddRange(new object[] {
            "Broadcast",
            "Target"});
            this.comboBoxSignal.Location = new System.Drawing.Point(235, 16);
            this.comboBoxSignal.Name = "comboBoxSignal";
            this.comboBoxSignal.Size = new System.Drawing.Size(226, 21);
            this.comboBoxSignal.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Scope:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Value:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(467, 17);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxValue.TabIndex = 13;
            // 
            // SignalSendViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSignal);
            this.Controls.Add(this.comboBoxScope);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownModul);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownRack);
            this.Name = "SignalSendViewControl";
            this.Size = new System.Drawing.Size(651, 45);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModul)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownRack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownModul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxScope;
        private System.Windows.Forms.ComboBox comboBoxSignal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}
