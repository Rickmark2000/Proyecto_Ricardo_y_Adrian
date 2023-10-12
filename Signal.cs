using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Signal
    {
        private string name;
        private DateTime time;
        private Signal_Type type_Signal;
        private int numeric_value;

        public Signal(string name, DateTime time, Signal_Type type_Signal, int numeric_value)
        {
            this.name = name;
            this.time = time;
            this.type_Signal = type_Signal;
            this.numeric_value = numeric_value;
        }

        public string Name { get => name; set => name = value; }
        public DateTime Time { get => time; set => time = value; }
        public int Numeric_value { get => numeric_value; set => numeric_value = value; }
        internal Signal_Type Type_Signal { get => type_Signal; set => type_Signal = value; }

        public override string ToString()
        {
            return $"Name: {name}, time: {time}, type: {type_Signal}, value: {numeric_value}";
        }
    }
}
