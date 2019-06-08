﻿
namespace Konvolucio.MCEL181123.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    public interface ISignalSendView
    {
        bool Broadcast { set; get; }
        byte Address { get; set; }
        string[] Signals { set; }
        string SelectedSignal { get; set; }
        string Value { get; set; }
        event EventHandler SelectedSignalChanged;
        event EventHandler Send;
    }


    public partial class SignalSendViewControl : UserControl, ISignalSendView
    {
        public bool Broadcast
        { 
            get
            {
                return (comboBoxScope.Text == "BROADCAST");
            }
            set
            {
                if (value)
                    comboBoxScope.Text = "BROADCAST";
                else
                    comboBoxScope.Text = "TARGETED";
            }
        }

        public byte Address
        {
            get
            {
                return (byte)((byte)((byte)numericUpDownRack.Value << 4) | (byte)(numericUpDownModul.Value));
            }
            set
            {
                numericUpDownRack.Value = value >> 4;
                numericUpDownModul.Value = value & 0x0F;
            }
        }

        public string[] Signals
        {
            set
            {
                comboBoxSignal.Items.Clear();
                comboBoxSignal.Items.AddRange(value);
            }
        }

        public string SelectedSignal
        {
            get =>  comboBoxSignal.Text;
            set => comboBoxSignal.Text = value;
        }

        public string Value
        {
            get => textBoxValue.Text;
            set => textBoxValue.Text = value;
        }

        public event EventHandler Send
        {
            add => button1.Click += value;
            remove => button1.Click -= value;
        }
    
        public event EventHandler SelectedSignalChanged
        {
            add => comboBoxSignal.SelectedIndexChanged += value;
            remove => comboBoxSignal.SelectedIndexChanged -= value;
        }

        public SignalSendViewControl()
        {
            InitializeComponent();
            comboBoxScope.Text = comboBoxScope.Items[0].ToString();
        }

        private void comboBoxScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxScope.Text == "BROADCAST")
            {
                numericUpDownModul.Enabled = false;
                numericUpDownRack.Enabled = false;
            }
            else
            {
                numericUpDownModul.Enabled = true;
                numericUpDownRack.Enabled = true;
            }

        }
    }
}