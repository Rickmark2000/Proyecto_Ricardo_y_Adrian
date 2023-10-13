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
        private Analogic_Value_Type anaalogic_type;

        public Analogic_Signal(Analogic_Value_Type type)
        {
            this.anaalogic_type = type;
        }

        public Analogic_Value_Type Anaalogic_type { get => anaalogic_type; set => anaalogic_type = value; }

        public override bool create_signal(string name, int value)
        {
            bool created = false;

            if (!check_repeated(name))
            {

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

