using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public abstract class Signals : ISignal_Gestion, ISignal_Check
    {
        protected List<Signal> signals_list;
        protected Signal signal;
        protected File_Management file_management;
        protected Files_Management files_management;

        public Signals()
        {
            signals_list = new List<Signal>();
            file_management = new File_Management();
            files_management = new Files_Management();
        }

        public bool add_signal(Signal signal)
        {

            if (signal != null)
            {
                signals_list.Add(signal);
                return true;
            }
            else
            {
                return false;
            }

        }

        //esto iria mas en files si esta repetido en el fichero
        // se puede crear el mismo método aquí para saber si es en la lista si esta repetido
        // si esta repetido en la lista esto influye para crear un objeto file.
        // el nombre es un identificador único por lo que no puede haber en la lista actual
        // 2 nombres iguales. Podriamos hacer que si existe en la lista actual, lo registre 
        //en el fichero y borre la señal en la lista para añadir el nuevo que se quiere agregar
        public bool check_repeated(string name)
        {

            if (File.Exists(file_management.Path))
            {
                string[] lines = File.ReadAllLines(file_management.Path);

                foreach (string line in lines)
                {
                    if (line.Contains($"{name}"))
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
       
        public void remove_signal(string name)
        {
            int pos = 0;
            bool find = false;

            while (pos < signals_list.Count && !find)
            {
                if (signals_list.ElementAt(pos).Name == name)
                {
                    signals_list.RemoveAt(pos);
                    find = true;
                }
                else
                {
                    pos++;
                }
            }
        }
        //para mostrar algo en el program usar.toString() de la clase signal
        public List<Signal> search_signal(string name)
        {
            /*
             * Decidamos si buscar en la lista o el fichero, sera importante type_use
             */
            List<Signal> signal_data = new List<Signal>();

            if (check_repeated(name))
            {
                // Llamada a file, retorna una Lista con los Datos de esta Señal "name".
                // search_signal = esa lista.
            }
            else
            {
                signal_data = null;
            }

            return signal_data;

        }

        //para mostrar algo en el program usar.toString() de la clase signal
        public void search_signal(DateTime date)
        {
            /*
             * Importante el type_use para decidir que hacer en caso de fichero o lista
             * 
             */
        }

        public abstract bool create_signal(string name, int value);
        public abstract bool add_valuesToSignal(string name, int value);

    }
}
