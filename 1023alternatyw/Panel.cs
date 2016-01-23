using _1023alternatyw;
using System;
using System.Windows.Forms;




namespace _1023alternatyw
{

    public partial class Panel : Form
    {
        private Powitanie form2;

        public Panel()
        {
            InitializeComponent();
            label21.Text = Properties.Settings.Default.nickname;
            label22.Text = Properties.Settings.Default.age;
            label23.Text = Properties.Settings.Default.sex;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.greeting = textBox1.Text;
            Properties.Settings.Default.greeting2 = textBox2.Text;
            Properties.Settings.Default.thankyou = textBox3.Text;
            Properties.Settings.Default.Save();
            form2 = new Powitanie();
            form2.FormClosing += (s, se) => Close();
            form2.Show();
            Hide();
            form2.Show();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
