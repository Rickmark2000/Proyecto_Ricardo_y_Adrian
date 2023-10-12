using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Files
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SignalRecords.txt";

        public string Path { get => path;private set => path = value; }

        public void save_signal(List<Signal> signals)
        {
            if (!File.Exists(path))
            {
                create_file(signals);
            }
            else
            {
                add_content(signals);
            }
        }

        public void save_signal(Signal signal)
        {
            if (!File.Exists(path))
            {
                create_file(signal);
            }
            else
            {
                add_content(signal);
            }
        }

        private void add_content(Signal signal)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Name:" + signal.Name
                    + ",Type:" + signal.Type_Signal
                    + ",Time:" + signal.Time
                    + ",Value:" + signal.Numeric_value);
            }
        }

        private void add_content(List<Signal> signals)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (Signal signal in signals)
                {
                    sw.WriteLine("Name:" + signal.Name
                        + ",Type:" + signal.Type_Signal
                        + ",Time:" + signal.Time
                        + ",Value:" + signal.Numeric_value);
                }
            }
        }

        public List<Signal> charge_list()
        {
            List<Signal> signal_support = new List<Signal>();
            List<string> content = new List<string>();
            char[] delimiterChars = { ' ', ',', '.', ':' };
            string[] words;
            Signal signal_storage;
            string signal_name = "";
            Signal_Type type = Signal_Type.Analogic;
            DateTime time = DateTime.MaxValue;
            int value = 0;

            content = read_file();

            words = new string[content.Count];
            
            foreach(string c in content)
            {
                words = c.Split(delimiterChars);

                for(int i = 0; i < words.Length; i++)
                {



                }
                signal_storage = new Signal(signal_name,time,type,value);
                signal_support.Add(signal_storage);
            }
           
            return signal_support;
        }


        private void create_file(List<Signal> signals)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Signal signal in signals)
                {
                    {
                        sw.WriteLine("Name:" + signal.Name
                        + ",Type:" + signal.Type_Signal
                        + ",Time:" + signal.Time
                        + ",Value:" + signal.Numeric_value);
                    }
                }
            }
        }

        private void create_file(Signal signal)
        {
            using (StreamWriter sw = File.CreateText(path))
            {                 
                sw.WriteLine("Name:" + signal.Name
                + ",Type:" + signal.Type_Signal
                + ",Time:" + signal.Time
                + ",Value:" + signal.Numeric_value); 
            }
        }

        private List<string> read_file()
        {
            List<string> signals_read = new List<string>();
            string read = "";

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while ((read = sr.ReadLine()) != null)
                    {
                        signals_read.Add(read);
                    }
                }
            }

            return signals_read;
        }
    }
}

