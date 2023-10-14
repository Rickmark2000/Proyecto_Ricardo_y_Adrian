using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Analog_Signal : Signals
    {
        /*Creates a new Analog signal*/
        public override bool create_signal(string name, int value)
        {
            bool created = false;

            if (!check_repeated(name))
            {

                signal = new Signal(name, DateTime.UtcNow, Signal_Type.Analog, value);

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

        /*Register new values of an Analog signal to the list*/
        public override bool add_valuesToSignal(string name, int value)
        {
            if (check_repeated(name))
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

    }
}

