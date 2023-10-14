using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Analogic_Signal : Signals
    {
        //nos va a servir para saber el tipo de calculo que haremos en operations
        // igual nos vendría bien una sobrecarga del constructor signal para añadir el tipo de valor
        //y dependiendo de un tipo de valor u otro que el valor cambie

        public override bool create_signal(string name, int value)
        {
            bool created = false;

            if (!check_repeated(name))
            {

                signal = new Signal(name, DateTime.UtcNow, Signal_Type.Analogic, value);

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

