using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Operation
    {
        private ISignal_Operations signal_Operation;

        public ISignal_Operations Signal_Operation {private get => signal_Operation; set => signal_Operation = value; }

        public Operation()
        {
            
        }
        public Operation(ISignal_Operations signal_Operation)
        {
            this.signal_Operation = signal_Operation;
        }

        public float DoOperation(int op, string signal_name)
        {
            float value = 0;
            switch (op)
            {
                case 1:
                    value = signal_Operation.max_value(signal_name);
                    break;
                case 2:
                    value = signal_Operation.average_values(signal_name);
                    break;
            }
            return value;
        }
    }
}
