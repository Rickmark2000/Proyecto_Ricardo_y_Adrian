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
        public float max_value(string signal_name);
        public float average_values(string signal_name);
    }
}
