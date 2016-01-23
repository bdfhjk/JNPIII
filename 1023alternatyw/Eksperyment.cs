using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace _1023alternatyw
{
    public partial class Eksperyment : Form
    {
        Panel form1;
        public Eksperyment()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Form2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1 = new Panel();
            form1.FormClosing += (s, es) => Close();
            Hide();
            form1.Show();
            form1.Focus();
        }
    }
}
