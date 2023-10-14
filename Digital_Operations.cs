using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Digital_Operations : ISignal_Operations
    {
        public float average_values()
        {
            return 0;
        }

        public float max_value()
        {
            Console.WriteLine("Digital");
            return 0;
        }
        //necesario patron para los calculos
        // Los calculos de la humedad y temperatura con el patrón "Strategy"
    }
}
