using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Digital_Signal : Signals
    {
        //hay que controlar que si el status es 1 el valor sera false y que si el valor sera 0 es verdadero
        private bool status;

        public bool Status { get => status; set => status = value; }

        public override bool create_signal(string name, int value)
        {
            bool created = false;

            if (!check_repeated(name))
            {
                //comprobacion de si es 1 o 0 para determinar verdadero o falso
                signal = new Signal(name, DateTime.UtcNow, Signal_Type.Digital, value);

                if (add_signal(signal))
                {
                    created = true;
                }
                else
                {
                    created = false;
                }

            }
            else
            {
                created = false;
            }

            return created;

        }

        //¿usar tipo aqui para saber que valores añadir?
        public override bool add_valuesToSignal(string name, int value)
        {
            if (check_repeated(name))
            {
                Signal new_record = new Signal(name, DateTime.UtcNow, Signal_Type.Digital, value);
                files_management.save_signal(new_record);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
