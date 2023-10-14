using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public abstract class Signals : ISignal_Gestion, ISignal_Check
    {
        private List<Signal> signals_list;
        protected Signal signal;
        protected File_Management file_management;
        protected Files_Management files_management;

        public Signals()
        {
            signals_list = new List<Signal>();
            file_management = new File_Management();
            files_management = new Files_Management();
        }

        public List<Signal> Signals_list { get => signals_list; private set => signals_list = value; }

        /*Add new signal values to the list (not the file)*/
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

        /*Checks if a signal Exists on the list (not the signal)*/
        public bool check_repeated(string name)
        {

            foreach (Signal signal in signals_list)
            {
                if (signal.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        /*Removes a signal to the list (not the file)*/
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

        /*Returns a signal by name on the list (not the file)*/
        public Signal search_signal(string name)
        {
            Signal signal_found = null;

            if (check_repeated(name))
            {

                foreach (Signal signal in signals_list)
                {
                    if (signal.Name == name)
                    {
                        signal_found = signal;
                    }
                }

            }
            return signal_found;
        }

        /*Returns a list of signals with an specific Date from the file (not the file)*/
        public List<Signal> search_signal(DateTime date)
        {
            List<Signal> list_found = new List<Signal>();

            foreach(Signal signal in signals_list)
            {
                if((signal.Time.Year == date.Year) && (signal.Time.Month == date.Month) && (signal.Time.Day == date.Day))
                {
                    list_found.Add(signal);
                }
            }

            return list_found;
          
        }

        public abstract bool create_signal(string name, int value);

        public abstract bool add_valuesToSignal(string name, int value);

    }
}
