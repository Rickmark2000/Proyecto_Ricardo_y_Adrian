using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public interface ISignal_Operations
    {
        //añadir mas tipos de operacion
        public string max_value(string signal_name);
        public string average_values(string signal_name);
        public string min_value(string signal_name);
        public string typical_deviation(string signal_name);
    }
}
