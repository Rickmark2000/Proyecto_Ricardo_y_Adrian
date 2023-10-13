﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public abstract class Signals : ISignal_Gestion, ISignal_Check
    {
        protected List<Signal> signals_list;
        protected Signal signal;
        protected File_Management file_management;
        protected Files_Management files_management;

        public Signals()
        {
            signals_list = new List<Signal>();
        }

        public bool add_signal(Signal signal)
        {

            if (signal != null)
            {
                signals_list.Add(signal);
                return true;
            }
            else
            {
                return false;
            }

        }
        public abstract bool add_valuesToSignal(string name, int value);
        public bool check_repeated(string name)
        {

            if (File.Exists(file_management.Path))
            {
                string[] lines = File.ReadAllLines(file_management.Path);

                foreach (string line in lines)
                {
                    if (line.Contains($"{name}"))
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
        public abstract bool create_signal(string name, int value);
        public void remove_signal(string name)
        {
            int pos = 0;
            bool find = false;

            while (pos < signals_list.Count && !find)
            {
                if (signals_list.ElementAt(pos).Name == name)
                {
                    signals_list.RemoveAt(pos);
                    find = true;
                }
                else
                {
                    pos++;
                }
            }
        }
        public List<Signal> search_signal(string name)
        {
            List<Signal> signal_data = new List<Signal>();

            if (check_repeated(name))
            {
                // Llamada a file, retorna una Lista con los Datos de esta Señal "name".
                // search_signal = esa lista.
            }
            else
            {
                signal_data = null;
            }

            return signal_data;

        }
        public void search_signal(JSType.Date date)
        {
            throw new NotImplementedException();
        }

    }
}
