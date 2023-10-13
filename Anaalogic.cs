using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Anaalogic : Signals
    {
        private bool status;
        private string srt;

        public bool Status { get => status; set => status = value; }

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

