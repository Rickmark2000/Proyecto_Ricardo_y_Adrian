using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class File_Management
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SignalRecords.txt";
        private Dates_Management date_Management;

        public File_Management()
        {
            date_Management = new Dates_Management();
        }
        public string Path { get => path; private set => path = value; }
        public Dates_Management Date_Management { get => date_Management; private set => date_Management = value; }
    }
}
