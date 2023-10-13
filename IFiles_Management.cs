using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public interface IFiles_Management
    {
        public void save_signal(List<Signal> signals);
        public void save_signal(Signal signal);
        public List<Signal> charge_list();
        public List<Signal> charge_list(string search_name);
        public List<Signal> charge_list(DateTime time_search);
        public List<Signal> remove_signals(string name);
        public List<Signal> remove_signals(DateTime time_delete);

    }
}
