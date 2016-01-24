using Csv.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Singleton.dane = new Dane();
            Singleton.dane.pseudonim = textBox2.Text;
            Singleton.dane.wiek = (int)numericUpDown1.Value;
            Singleton.dane.plec = domainUpDown1.SelectedIndex;

            List<Dane> lista = new List<Dane>();
            lista.Add(Singleton.dane);

            using (var stream = new FileStream("Dane.csv", FileMode.Create, FileAccess.Write))
            {
                var cs = new CsvSerializer<Dane>()
                {
                    UseTextQualifier = true,
                };
                cs.Serialize(stream, lista);
            }

            Hide();
            eks = new Eksperyment();
            eks.FormClosing += (s, ec) => Close();
            eks.Show();
        }
    }
}
