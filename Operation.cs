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

        public void DoOperation()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            Signal_Operation.max_value();

         
        }
    }
}
