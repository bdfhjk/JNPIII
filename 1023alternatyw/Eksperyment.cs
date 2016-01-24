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
using System.IO;
using Csv.Serialization;

namespace _1023alternatyw
{
    public partial class Eksperyment : Form
    {
        Panel form1;
        int next_to_show;
        bool[] zapalone;
        public Eksperyment()
        {
            zapalone = new bool[10];
            InitializeComponent();
            for(int i = 0; i < Singleton.merged.Count; i++)
            {
                if (Singleton.merged[i].czas == 0)
                {
                    next_to_show = i;
                    break;
                }
                if (Singleton.merged[next_to_show].treningowa)
                    label2.Text = "Treningowa";
                else
                    label2.Text = "Właściwa";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            { zapalone[1] = false; pictureBox1.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D2)
            { zapalone[2] = false; pictureBox2.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D3)
            { zapalone[3] = false; pictureBox3.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D4)
            { zapalone[4] = false; pictureBox4.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D5)
            { zapalone[5] = false; pictureBox5.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D6)
            { zapalone[6] = false; pictureBox6.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D7)
            { zapalone[7] = false; pictureBox7.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D8)
            { zapalone[8] = false; pictureBox8.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D9)
            { zapalone[9] = false; pictureBox9.Image = Properties.Resources.L11; }
            if (e.KeyCode == Keys.D0)
            { zapalone[0] = false; pictureBox10.Image = Properties.Resources.L11; }

            if (e.KeyCode == Keys.D1 && zapalone[1] && Singleton.ustawienia.tryb == 1) { /* Ding ding */}

            bool jest_zapalona = false;
            if (zapalone[1]) jest_zapalona = true;
            if (zapalone[2]) jest_zapalona = true;
            if (zapalone[3]) jest_zapalona = true;
            if (zapalone[4]) jest_zapalona = true;
            if (zapalone[5]) jest_zapalona = true;
            if (zapalone[6]) jest_zapalona = true;
            if (zapalone[7]) jest_zapalona = true;
            if (zapalone[8]) jest_zapalona = true;
            if (zapalone[9]) jest_zapalona = true;
            if (zapalone[0]) jest_zapalona = true;

            if (!jest_zapalona)
            {
                Singleton.merged[next_to_show].czas = 42; //TODO

                using (var stream = new FileStream("Kombinacje.csv", FileMode.Create, FileAccess.Write))
                {
                    var cs = new CsvSerializer<Kombinacja>()
                    {
                        UseTextQualifier = true,
                    };
                    cs.Serialize(stream, Singleton.merged);
                }
                next_to_show++;
                if (next_to_show >= Singleton.merged.Count)
                {
                    Close();
                }
                zapal();
            }

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

        private void zapal()
        {
            pictureBox1.Image = (Singleton.merged[next_to_show].L1 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox2.Image = (Singleton.merged[next_to_show].L2 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox3.Image = (Singleton.merged[next_to_show].L3 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox4.Image = (Singleton.merged[next_to_show].L4 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox5.Image = (Singleton.merged[next_to_show].L5 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox6.Image = (Singleton.merged[next_to_show].L6 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox7.Image = (Singleton.merged[next_to_show].L7 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox8.Image = (Singleton.merged[next_to_show].L8 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox9.Image = (Singleton.merged[next_to_show].L9 == true) ? Properties.Resources.L21 : Properties.Resources.L11;
            pictureBox10.Image = (Singleton.merged[next_to_show].L10 == true) ? Properties.Resources.L21 : Properties.Resources.L11;

            zapalone[1] = Singleton.merged[next_to_show].L1;
            zapalone[2] = Singleton.merged[next_to_show].L2;
            zapalone[3] = Singleton.merged[next_to_show].L3;
            zapalone[4] = Singleton.merged[next_to_show].L4;
            zapalone[5] = Singleton.merged[next_to_show].L5;
            zapalone[6] = Singleton.merged[next_to_show].L6;
            zapalone[7] = Singleton.merged[next_to_show].L7;
            zapalone[8] = Singleton.merged[next_to_show].L8;
            zapalone[9] = Singleton.merged[next_to_show].L9;
            zapalone[0] = Singleton.merged[next_to_show].L10;

            pictureBox1.Refresh();
            pictureBox2.Refresh();
            pictureBox3.Refresh();
            pictureBox4.Refresh();
            pictureBox5.Refresh();
            pictureBox6.Refresh();
            pictureBox7.Refresh();
            pictureBox8.Refresh();
            pictureBox9.Refresh();
            pictureBox10.Refresh();

            if (label2.Text == "Treningowa" && !Singleton.merged[next_to_show].treningowa)
            {
                label2.Text = "Właściwa";
                MessageBox.Show(Singleton.ustawienia.posesjitreningowej);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zapal();
        }
    }
}
