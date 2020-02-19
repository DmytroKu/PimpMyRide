using System;
using System.Linq;
using System.Windows.Forms;

namespace PimpMyRide.WindowsFormsApp
{
    public partial class PimpMyRideForm : Form
    {
        public int? choice;

        public PimpMyRideForm()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (int.TryParse(textBox1.Text.Split(Environment.NewLine).Last(), out var input))
            {
                choice = input;
            }
        }

        private void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((Action<string>) WriteTextSafe, text);
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

        public void RequestInput()
        {
            Invoke((Action) (() => choice = null));
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 1;
            DisableControls();
        }


        private void DisableControls()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 2;
            DisableControls();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choice = 3;
            DisableControls();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice = 4;
            DisableControls();
        }
    }
}