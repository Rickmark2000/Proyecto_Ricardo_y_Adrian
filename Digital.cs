using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Digital : Signals
    {
        private bool status;

        public bool Status { get => status; set => status = value; }

        public override bool add_signal(Signal signal)
        {

            if(signal != null)
            {
                signals_list.Add(signal);
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool add_valuesToSignal(string name, int value)
        {
            if (check_repeated(name))
            {
                string new_record = $"{name} {} {} {value}";
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool check_repeated(string name)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SignalRecords.txt";

            if (File.Exists(path))
            {
                string[] lineas = File.ReadAllLines(path);

                foreach (string linea in lineas)
                {
                    if (linea.Contains($"{name}"))
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public override bool create_signal(string name, int value)
        {
           bool anadido = false;

           signal = new Signal(name,23,Signal_Type.Digital,value);
           status = signal.Numeric_value == 0 ? status=false : status = true;

            if (add_signal(signal))
            {
                anadido = true;
            }
            else
            {
                anadido = false;
            }

            return anadido;
        }

        public override void remove_signal(string name)
        {
            int pos = 0;
            bool find = false;

            while(pos < signals_list.Count && !find) 
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

        public override List<Signal> search_signal(string name)
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

        public override void search_signal(JSType.Date date)
        {
            throw new NotImplementedException();
        }
    }
}
