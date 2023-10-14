using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Digital_Operations : ISignal_Operations
    {
        private Files_Management files_management;
        public Digital_Operations(Files_Management files_management)
        {
            this.files_management = files_management;
        }
        public float average_values(string signal_name)
        {
            List<Signal> signals = new List<Signal>();
            signals = files_management.charge_list(signal_name);
            int average_value = 0;
            int sum = 0;

            foreach (Signal signal in signals)
            {
                sum += signal.Numeric_value;
            }

            average_value = sum / signals.Count;
            return average_value;
        }

        public float max_value(string signal_name)
        {
            List<Signal> signals = new List<Signal>();
            signals = files_management.charge_list(signal_name);
            int max_value = 0;

            for (int i = 0; i < signals.Count(); i++)
            {
                if (max_value < signals.ElementAt(i).Numeric_value)
                {
                    max_value = signals.ElementAt(i).Numeric_value;
                }

            }

            return max_value;
        }
        //necesario patron para los calculos
        // Los calculos de la humedad y temperatura con el patrón "Strategy"
    }
}
