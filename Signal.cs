using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregable_Ricardo_y_Adrian
{
    public class Signal
    {
        private string name;
        private int numeric_value;
        private int time;
        private Signal_Type type_Signal;

        public Signal(string name, int numeric_value, int time, Signal_Type type_Signal)
        {
            this.name = name;
            this.numeric_value = numeric_value;
            this.time = time;
            this.type_Signal = type_Signal;
        }

        public string Name { get => name; set => name = value; }
        public int Numeric_value { get => numeric_value; set => numeric_value = value; }
        public int Time { get => time; set => time = value; }
        internal Signal_Type Type_Signal { get => type_Signal; set => type_Signal = value; }
    }
}
