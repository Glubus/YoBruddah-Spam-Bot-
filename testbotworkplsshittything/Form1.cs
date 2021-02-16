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
        public int parsedValue;
        public int intervals = 50;
        public bool Click = false;

        private void AutoClick()
        {
            while (true)
            {
                if (Click == true)
                {
                    SendKeys.SendWait(textBox1.Text + "{ENTER}");
                    Thread.Sleep(intervals);
                }
                Thread.Sleep(2);
            }
        }

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
            Thread AC = new Thread(AutoClick);
            CheckForIllegalCrossThreadCalls = false; 
            AC.Start();
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
                  if (checkBox2.Checked)
                        {
                        if (GetAsyncKeyState(Keys.Insert) < 0)
                        {
                            Click = false;
                        }
                        else if (GetAsyncKeyState(Keys.Delete) < 0)
                        {
                            Click = true;
                        }
                        
                    }
                   else if 
                       (GetAsyncKeyState(Keys.Delete) < 0)
                    {
                        try
                        {
                            SendKeys.SendWait(textBox1.Text + "{ENTER}");
                            Thread.Sleep(intervals);

                        }
                        catch
                        {
                        }
                    }
                    Thread.Sleep(10);
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TextBox2.Text, out parsedValue))
            {
                MessageBox.Show("Fuckyou!");
                return;
            }
            else
            {
                intervals = int.Parse(TextBox2.Text);
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

