using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public abstract class Signals : ISignal_Gestion, ISignal_Check
    {
        protected List<Signal> signals_list;
        protected Signal signal;

        public Signals()
        {
            signals_list = new List<Signal>();

        }

        public abstract bool add_signal(Signal signal);
        public abstract bool add_valuesToSignal(string name, int value);
        public abstract bool check_repeated(string name);
        public abstract bool create_signal(string name, int value);
        public abstract void remove_signal(string name);
        public abstract List<Signal> search_signal(string name);
        public abstract void search_signal(JSType.Date date);

    }
}
