using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Files
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SignalRecords.txt";


        public void save_signal(List<Signals> signals)
        {
            string p;
        }

        public List<Signals> charge_list()
        {
            return new List<Signals>();
        }

        public void create_file()
        {

        }
    }
}
