using Csv.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1023alternatyw
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("Ustawienia.csv"))
            {
                // Deserialization
                IList<Ustawienia> deserializedData = null;
                using (var stream = new FileStream("Ustawienia.csv", FileMode.Open, FileAccess.Read))
                {
                    var cs = new CsvSerializer<Ustawienia>()
                    {
                        UseTextQualifier = true,
                    };

                    deserializedData = cs.Deserialize(stream);
                }
                Singleton.ustawienia = deserializedData.ElementAt(0);

                // Deserialization
                IList<Kombinacja> deserializedData3 = null;
                using (var stream = new FileStream("Kombinacje.csv", FileMode.Open, FileAccess.Read))
                {
                    var cs = new CsvSerializer<Kombinacja>()
                    {
                        UseTextQualifier = true,
                    };

                    deserializedData3 = cs.Deserialize(stream);
                }

                Singleton.merged = (List<Kombinacja>)deserializedData3;

                if (File.Exists("Dane.csv"))
                {
                    // Deserialization
                    IList<Dane> deserializedData2 = null;
                    using (var stream = new FileStream("Dane.csv", FileMode.Open, FileAccess.Read))
                    {
                        var cs = new CsvSerializer<Dane>()
                        {
                            UseTextQualifier = true,
                        };

                        deserializedData2 = cs.Deserialize(stream);
                    }

                    Singleton.dane = deserializedData2.ElementAt(0);
                    Application.Run(new Eksperyment());
                }
                else
                {
                    Application.Run(new Powitanie());
                }
            }
            else
            {
                Application.Run(new Panel());
            }
        }
    }
}
