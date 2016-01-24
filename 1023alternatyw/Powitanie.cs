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
    public partial class Powitanie : Form
    {
        Eksperyment eks;
        Ankieta ank;
        public Powitanie()
        {
            InitializeComponent();
            textBox1.Text = Singleton.ustawienia.powitanie;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ank = new Ankieta();
            ank.Show();
            ank.FormClosing += (sa, ea) => Close();
            Hide();
        }

        private void Powitanie_Shown(object sender, EventArgs e)
        {

        }
    }
}
