using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Permissions;

namespace testbotworkplsshittything
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                Toggle(checkBox1); break;
                    
        default:
                    break;
            }
        }

        private void Toggle(CheckBox checkbox)
        {
            checkbox.Checked = !checkbox.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    if (GetAsyncKeyState(Keys.Delete) < 0)
                    {
                        try
                        {
                            SendKeys.SendWait(textBox1.Text + "{ENTER}");
                            Thread.Sleep(250);
                        }
                        catch
                        {
                        }
                    }
                }
                Thread.Sleep(10);

            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
