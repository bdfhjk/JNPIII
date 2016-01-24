using _1023alternatyw;
using Csv.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;




namespace _1023alternatyw
{

    public partial class Panel : Form
    {
        private Powitanie form2;

        public Panel()
        {
            InitializeComponent();
            if (Singleton.dane != null)
            {
                label21.Text = Singleton.dane.pseudonim;
                label22.Text = Singleton.dane.wiek.ToString();
                label23.Text = (Singleton.dane.plec == 1 ? "Mężczyzna" : "Kobieta");
            }
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
            Singleton.ustawienia = new Ustawienia();
            Singleton.ustawienia.czas_lampy = (int)numericCzasLampy.Value;
            Singleton.ustawienia.czas_zwloki = (int)numericCzasZwloki.Value;
            Singleton.ustawienia.dl_sesji_treningowej = (int)numericDlugoscSesjiTreningowej.Value;
            Singleton.ustawienia.ilosc_powtorzen = (int)numericIloscPowtorzenEksperymentu.Value;
            Singleton.ustawienia.tryb = domainTryb.SelectedIndex;
            Singleton.ustawienia.subtryb = domainSubtryb.SelectedIndex;
            Singleton.ustawienia.powitanie = textBoxPowitanie.Text;
            Singleton.ustawienia.posesjitreningowej = textBoxPoTreningu.Text;
            Singleton.ustawienia.podziekowanie = textBoxPodziekowanie.Text;

            List<Ustawienia> lista = new List<Ustawienia>();
            lista.Add(Singleton.ustawienia);
                
            using (var stream = new FileStream("Ustawienia.csv", FileMode.Create, FileAccess.Write))
            {
                var cs = new CsvSerializer<Ustawienia>()
                {
                    UseTextQualifier = true,
                };
                cs.Serialize(stream, lista);
            }

            List<Kombinacja> trening = new List<Kombinacja>();
            List<Kombinacja>[] kombinacje = new List<Kombinacja>[Singleton.ustawienia.ilosc_powtorzen];

            for (int i = 0; i < Singleton.ustawienia.dl_sesji_treningowej; i++)
            {
                Kombinacja kombinacja = new Kombinacja();
                kombinacja.czas = 0;
                kombinacja.treningowa = true;
                kombinacja.nr_powtorzenia = -1;
                kombinacja.numer_w_powtorzeniu = i;
                kombinacja.L1 = ((i >> 0) % 2) == 1 ? true : false;
                kombinacja.L2 = ((i >> 1) % 2) == 1 ? true : false;
                kombinacja.L3 = ((i >> 2) % 2) == 1 ? true : false;
                kombinacja.L4 = ((i >> 3) % 2) == 1 ? true : false;
                kombinacja.L5 = ((i >> 4) % 2) == 1 ? true : false;
                kombinacja.L6 = ((i >> 5) % 2) == 1 ? true : false;
                kombinacja.L7 = ((i >> 6) % 2) == 1 ? true : false;
                kombinacja.L8 = ((i >> 7) % 2) == 1 ? true : false;
                kombinacja.L9 = ((i >> 8) % 2) == 1 ? true : false;
                kombinacja.L10 = ((i >> 9) % 2) == 1 ? true : false;
                trening.Add(kombinacja);
            }
            for (int w = 0; w < Singleton.ustawienia.ilosc_powtorzen; w++)
            {
                kombinacje[w] = new List<Kombinacja>();
                for (int i = 0; i < 1023; i++)
                {
                    Kombinacja kombinacja = new Kombinacja();
                    kombinacja.czas = 0;
                    kombinacja.treningowa = false;
                    kombinacja.nr_powtorzenia = -1;
                    kombinacja.numer_w_powtorzeniu = i;
                    kombinacja.L1 = ((i >> 0) % 2) == 1 ? true : false;
                    kombinacja.L2 = ((i >> 1) % 2) == 1 ? true : false;
                    kombinacja.L3 = ((i >> 2) % 2) == 1 ? true : false;
                    kombinacja.L4 = ((i >> 3) % 2) == 1 ? true : false;
                    kombinacja.L5 = ((i >> 4) % 2) == 1 ? true : false;
                    kombinacja.L6 = ((i >> 5) % 2) == 1 ? true : false;
                    kombinacja.L7 = ((i >> 6) % 2) == 1 ? true : false;
                    kombinacja.L8 = ((i >> 7) % 2) == 1 ? true : false;
                    kombinacja.L9 = ((i >> 8) % 2) == 1 ? true : false;
                    kombinacja.L10 = ((i >> 9) % 2) == 1 ? true : false;
                    kombinacje[w].Add(kombinacja);
                }
            }

            trening.Shuffle();
            for (int i = 0; i < Singleton.ustawienia.ilosc_powtorzen; i++)
                kombinacje[i].Shuffle();

            List<Kombinacja> merged = new List<Kombinacja>();
            merged.AddRange(trening);

            for (int i = 0; i < Singleton.ustawienia.ilosc_powtorzen; i++)
                merged.AddRange(kombinacje[i]);

            using (var stream = new FileStream("Kombinacje.csv", FileMode.Create, FileAccess.Write))
            {
                var cs = new CsvSerializer<Kombinacja>()
                {
                    UseTextQualifier = true,
                };
                cs.Serialize(stream, merged);
            }

            Singleton.merged = merged;

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
            if (File.Exists("Dane.csv")) File.Delete("Dane.csv");
            if (File.Exists("Ustawienia.csv")) File.Delete("Ustawienia.csv");
            if (File.Exists("Kombinacje.csv")) File.Delete("Kombinacje.csv");
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }


    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
