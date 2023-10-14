﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Files_Management : IFiles_Management
    {
        //vendria bien optimizar los métodos de carga
        private File_Management file_Management;

        public Files_Management()
        {
            file_Management = new File_Management();
        }
        /*
         * el region nos vendria bien para poder acceder mejor al código
         * #region "----------------NOMBRE DE LA REGION---------------"
         * Contenido
         * #endregion
         */
        #region "--------------------SAVE SIGNAL--------------------"
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
        #endregion


        //seguro que estos 3 métodos se pueden optimizar
        #region "-----------------CHARGE LIST----------------------------"
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

            foreach (string content_file in content)
            {

                words = content_file.Split(delimiterChars);
                signal_name = words[1];

                type = words[3] == "Analogic" ? Signal_Type.Analogic : Signal_Type.Digital;
                time = file_Management.Date_Management.create_date(words[5]);
                value = Convert.ToInt32(words[7]);

                signal_support = new Signal(signal_name, time, type, value);
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

                signal_name = words[1];

                if (search_name == signal_name)
                {
                    type = words[3] == "Analogic" ? Signal_Type.Analogic : Signal_Type.Digital;
                    time = file_Management.Date_Management.create_date(words[5]);
                    value = Convert.ToInt32(words[7]);

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

                signal_name = words[1];
                type = words[3] == "Analogic" ? Signal_Type.Analogic : Signal_Type.Digital;
                time = file_Management.Date_Management.create_date(words[5]);

                if (file_Management.Date_Management.check_dates(time_search, time))
                {
                    value = Convert.ToInt32(words[7]);

                    signal_support = new Signal(signal_name, time, type, value);
                    signal_storage.Add(signal_support);
                }
            }
            return signal_storage;
        }
        #endregion


        #region "-------------CREATE FILE------------------"
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
        #endregion


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

        #region "------------REMOVE SIGNAL-------------------"
        public List<Signal> remove_signals(string name)
        {
            int pos = 0;
            List<Signal> file_content = charge_list();

            while (pos<file_content.Count)
            {
                if (file_content.ElementAt(pos).Name == name)
                {
                    file_content.RemoveAt(pos);
                }
                else
                {
                    pos++;
                }

            }
            overWrite_file(file_content);
            return file_content;
        }

        public List<Signal> remove_signals(DateTime time_delete)
        {
            List<Signal> file_content = charge_list();
            List<Signal> signals = charge_list(time_delete);

            foreach (Signal signal in file_content)
            {
                foreach (Signal signal_time in signals)
                {
                    if (file_Management.Date_Management.check_dates(signal.Time, signal_time.Time))
                    {
                        file_content.Remove(signal);
                    }
                }


            }
            overWrite_file(file_content);
            return file_content;
        }

        private void overWrite_file(List<Signal> signals)
        {
            if (File.Exists(file_Management.Path))
            {
                File.Delete(file_Management.Path);
            }

            create_file(signals);
        }


        #endregion

        public bool check_repeated(string name)
        {
            string[] lines;
            bool find = false;

            if (File.Exists(file_Management.Path))
            {
                lines = File.ReadAllLines(file_Management.Path);

                foreach (string line in lines)
                {
                    if (line.Contains($"{name}"))
                    {
                       find = true;
                    }
                    else
                    {
                        find = false;
                    }
                }
            }
            else
            {
                find = false;
            }

            return find;
        }

        public Signal search_signal(string name)
        {
            Signal signal = null;
            List<Signal> signals = new List<Signal>();

            if (check_repeated(name))
            {
                signals = charge_list(name);
                signal = new Signal(name, signals.ElementAt(0).Type_Signal);
            }

            return signal;
        }

        public bool add_valuesToSignal(string name, int value)
        {
            if (check_repeated(name))
            {
                Signal new_record = search_signal(name);
                new_record.Numeric_value = value;
                new_record.Time = DateTime.UtcNow;

                save_signal(new_record);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

