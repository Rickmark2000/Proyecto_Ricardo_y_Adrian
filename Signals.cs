﻿using Entregable_Ricardo_y_Adrian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public abstract class Signals : ISignal_Gestion
    {
        private List<Signal> signals_list;
        protected Signal signal;

        public Signals()
        {
            signals_list = new List<Signal>();
        }
        public abstract bool add_signal(Signal signal);
        public abstract void add_valuesToSignal(Signal signal);
        public abstract void create_signal();
        public abstract void remove_signal();
        public abstract void search_signal(string name);
        public abstract void search_signal(JSType.Date date);
    }
}