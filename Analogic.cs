using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Analogic : Signals
    {
        private int degrees;

        public Analogic(int degrees)
        {
            this.degrees = degrees;
        }

        public int Degrees { get => degrees; set => degrees = value; }

        protected override bool add_signal(Signal signal)
        {
            throw new NotImplementedException();
        }

        public override void add_valuesToSignal(Signal signal)
        {
            throw new NotImplementedException();
        }

        public override bool create_signal(string name, int value)
        {
            throw new NotImplementedException();
        }

        public override void remove_signal(string name)
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
