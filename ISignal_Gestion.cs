using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Ricardo_y_Adrian
{
    public interface ISignal_Gestion
    {
        public bool create_signal(string name, int value);
        public bool add_signal(Signal signal);
        public bool add_valuesToSignal(string name, int value);
        public void remove_signal(string name);
        public Signal search_signal(string name);
        public List<Signal> search_signal(DateTime date);

    }
}
