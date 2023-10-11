﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Ricardo_y_Adrian
{
    public interface ISignal_Gestion
    {
        public bool create_signal(string name, int value);
        protected bool add_signal(Signal signal);
        public void add_valuesToSignal(Signal signal);
        public void remove_signal(string name);
        public void search_signal(string name);
        public void search_signal(Date date);

    }
}
