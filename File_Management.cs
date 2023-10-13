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
        private Times_Management time;

        public File_Management()
        {
            time = new Times_Management();
        }
        public string Path { get => path; private set => path = value; }
        public Times_Management Time { get => time; private set => time = value; }
    }
}
