using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1023alternatyw
{
    public partial class Ankieta : Form
    {
        Eksperyment eks;
        public Ankieta()
        {
            InitializeComponent();
            domainUpDown1.SelectedIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.nickname = textBox2.Text;
            Properties.Settings.Default.age = numericUpDown1.Value.ToString();
            Properties.Settings.Default.sex = domainUpDown1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            Hide();
            eks = new Eksperyment();
            eks.Show();
            eks.FormClosing += (s, ec) => Close();
        }
    }
}
