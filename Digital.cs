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

        public override void add_valuesToSignal(Signal signal)
        {
            throw new NotImplementedException();
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

        public override void remove_signal()
        {
            throw new NotImplementedException();
        }

        public override void search_signal(string name)
        {
            throw new NotImplementedException();
        }

        public override void search_signal(JSType.Date date)
        {
            throw new NotImplementedException();
        }
    }
}
