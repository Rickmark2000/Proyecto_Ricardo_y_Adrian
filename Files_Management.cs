using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Files_Management
    {
        private File_Management file_Management;

        public Files_Management()
        {
            file_Management = new File_Management();
        }

        public void save_signal(List<Signal> signals)
        {
            if (!File.Exists(file_Management.Path))
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
            if (!File.Exists(file_Management.Path))
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
            using (StreamWriter sw = File.AppendText(file_Management.Path))
            {
                sw.WriteLine("Name:" + signal.Name
                    + ",Type:" + signal.Type_Signal
                    + ",Time:" + signal.Time.ToString("dd-MM-yyyy/HH-mm-ss")
                    + ",Value:" + signal.Numeric_value);
            }
        }

        private void add_content(List<Signal> signals)
        {
            using (StreamWriter sw = File.AppendText(file_Management.Path))
            {
                foreach (Signal signal in signals)
                {
                    sw.WriteLine("Name:" + signal.Name
                        + ",Type:" + signal.Type_Signal
                        + ",Time:" + signal.Time.ToString("dd-MM-yyyy/HH-mm-ss")
                        + ",Value:" + signal.Numeric_value);
                }
            }
        }

        public List<Signal> charge_list()
        {
            List<Signal> signal_storage = new List<Signal>();
            List<string> content = new List<string>();
            char[] delimiterChars = { ' ', ',', '.', ':' };
            string[] words;
            Signal signal_support;
            string signal_name = "";
            Signal_Type type = Signal_Type.Analogic;
            DateTime time = DateTime.MaxValue;
            int value = 0;

            content = read_file();

            words = new string[content.Count];
            
            foreach(string content_file in content)
            {

                words = content_file.Split(delimiterChars);

                signal_name = words[0];

                type = words[1] == "Analogic"? Signal_Type.Analogic : Signal_Type.Digital;
                time = file_Management.Time.create_time(words[2]);
                value = Convert.ToInt32(words[3]);

                signal_support = new Signal(signal_name,time,type,value);
                signal_storage.Add(signal_support);
            }
           
            return signal_storage;
        }

        public List<Signal> charge_list(string search_name)
        {
            List<Signal> signal_storage = new List<Signal>();
            List<string> content = new List<string>();
            char[] delimiterChars = { ' ', ',', '.', ':' };
            string[] words;
            Signal signal_support;
            string signal_name = "";
            Signal_Type type = Signal_Type.Analogic;
            DateTime time = DateTime.MaxValue;
            int value = 0;

            content = read_file();

            words = new string[content.Count];

            foreach (string content_file in content)
            {
                words = content_file.Split(delimiterChars);

                signal_name = words[0];

                if(search_name == signal_name)
                {
                    type = words[1] == "Analogic" ? Signal_Type.Analogic : Signal_Type.Digital;
                    time = file_Management.Time.create_time(words[2]);
                    value = Convert.ToInt32(words[3]);

                    signal_support = new Signal(signal_name, time, type, value);
                    signal_storage.Add(signal_support);
                }
            }
            return signal_storage;
        }

        public List<Signal> charge_list(DateTime time_search)
        {
            List<Signal> signal_storage = new List<Signal>();
            List<string> content = new List<string>();
            char[] delimiterChars = { ' ', ',', '.', ':' };
            string[] words;
            Signal signal_support;
            string signal_name = "";
            Signal_Type type = Signal_Type.Analogic;
            DateTime time = DateTime.MaxValue;
            int value = 0;

            content = read_file();

            words = new string[content.Count];

            foreach (string content_file in content)
            {
                words = content_file.Split(delimiterChars);

                signal_name = words[0];
                type = words[1] == "Analogic" ? Signal_Type.Analogic : Signal_Type.Digital;
                time = file_Management.Time.create_time(words[2]);

                if (file_Management.Time.check_times(time_search,time))
                {
                    value = Convert.ToInt32(words[3]);

                    signal_support = new Signal(signal_name, time, type, value);
                    signal_storage.Add(signal_support);
                }
            }
            return signal_storage;
        }


        private void create_file(List<Signal> signals)
        {
            using (StreamWriter sw = File.CreateText(file_Management.Path))
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
            using (StreamWriter sw = File.CreateText(file_Management.Path))
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

            if (File.Exists(file_Management.Path))
            {
                using (StreamReader sr = File.OpenText(file_Management.Path))
                {
                    while ((read = sr.ReadLine()) != null)
                    {
                        signals_read.Add(read);
                    }
                }
            }

            return signals_read;
        }

        public List<Signal> remove_signals(string name)
        {
            List<Signal> file_content = charge_list();
            
            foreach (Signal signal in file_content) 
            { 
                if (signal.Name == name)
                {
                    file_content.Remove(signal);
                }
            
            }
            overWrite_file(file_content);
            return file_content;
        }

        private void overWrite_file(List<Signal> signals)
        {
            if(File.Exists(file_Management.Path))
            {
                File.Delete(file_Management.Path);
            }

            create_file(signals);
        }
    }
}

