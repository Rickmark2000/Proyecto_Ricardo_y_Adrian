using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Analog_Operations : ISignal_Operations
    {

        private Files_Management files_management;
        public Analog_Operations(Files_Management files_management)
        {
            this.files_management = files_management;
        }
        public string average_values(string signal_name)
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
            return "The average is " + average_value;
        }

        public string max_value(string signal_name)
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

            return "The maximum value of " + signal_name + " is: " + max_value + ".";
        }

        public string min_value(string signal_name)
        {
            List<Signal> signals = new List<Signal>();
            signals = files_management.charge_list(signal_name);
            int min_value = 0;

            for (int i = 0; i < signals.Count(); i++)
            {
                if (min_value > signals.ElementAt(i).Numeric_value)
                {
                    min_value = signals.ElementAt(i).Numeric_value;
                }

            }

            return "The minimum value of " + signal_name + " is: " + min_value + ".";
        }

        public string typical_deviation(string signal_name)
        {
            List<Signal> signals = new List<Signal>();
            signals = files_management.charge_list(signal_name);

            float average = 0.00f;
            float sum = 0.00f;
            int total = 1;

            foreach (Signal signal in signals)
            {
                float temp_average = average; 
                average += ((float)signal.Numeric_value - temp_average) / total;
                sum += ((float)signal.Numeric_value - temp_average) * (signal.Numeric_value - average); 
                total++;
            }
            return $"The Typical Deviation of {signal_name} is: {Math.Sqrt(sum / (total - 2))}";

        }

    }
}
