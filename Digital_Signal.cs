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

        private bool status;

        public bool Status { get => status; set => status = value; }

        public override bool create_signal(string name, int value)
        {
            bool created = false;

            if (!check_repeated(name) && check_status(value))
            {
                //comprobacion de si es 1 o 0 para determinar verdadero o falso
                signal = new Signal(name, DateTime.UtcNow, Signal_Type.Digital, value);
                Status = value == 0 ? false : true;


                if (add_signal(signal))
                {
                    files_management.save_signal(signal);
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

        public override bool add_valuesToSignal(string name, int value)
        {
            if (check_repeated(name) && check_status(value))
            {
                Signal new_record = search_signal(name);
                new_record.Time = DateTime.UtcNow;
                new_record.Numeric_value = value;
                remove_signal(name);
                add_signal(new_record);
                files_management.save_signal(signal);
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool check_status(int value)
        {
            bool alright;

            if (value == 0 || value == 1)
            {
                alright = true;
            }
            else
            {
                alright = false;
            }

            return alright;
        }

    }
}
