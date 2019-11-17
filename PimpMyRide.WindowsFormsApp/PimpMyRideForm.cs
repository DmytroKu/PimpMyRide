using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PimpMyRide.WindowsFormsApp
{
    public partial class PimpMyRideForm : Form
    {
        public bool chosen;
        public PimpMyRideForm()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            chosen = textBox1.Text.EndsWith(Environment.NewLine);
        }
        private void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((Action<string>)WriteTextSafe, text);
            }
            else
            {
                textBox1.AppendText(text);
            }
        }

        public void Append(string text)
        {
            WriteTextSafe(text);
        }
        public void AppendLine(string text)
        {
            Append(text);
            Append(Environment.NewLine);
        }

    }
}
