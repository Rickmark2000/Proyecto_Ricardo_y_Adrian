using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Menu
    {
        /*Tenemos varias opciones:
         * 1) al añadir indicar un límite de señales que se pueden agregar y gestionarlo en signals
         * 2) que al entrar en el programa(si al final decidimos implementar el json) cual es el formato en
         * el que se desean guardar los datos
         * 3) metodos para cada opción
         * 4)Habilitar y deshabilitar metodos en función de si se ha usado un método creado
         * 5) decidir si al crear una señal se habilita añadir valores y que hacer con los valores
         * (se puede preguntar al usuario si añadir o no los valores que acaba de modificar)
         * 6)Los datos que se quieran mostrar e interactuar con el usuario se debe de hacer en esta clase
         * 7) recordar que de momento el datetime que pasemos por parametro aqui solo tendra año, dia y mes
         * 8) se puede preguntar al usuario si desea buscar por nombre o tiempo
         * 
         */

        /*
         * Recordatorios:
         * -Actualizar la uml
         * -Comentar el código cuando acabemos(que hace cada método etc...)
         */

        /*
         * Cosas interesantes para implementar:
         * -Mas intterfaces
         * -Mas clases
         * -Mas abstraccion y modularidad
         * -Json
         * -Cadena de dependencia
         * -Expresiones regulares que controlen las respuestas del usuario(Estas opciones de respuestas se almacenarian en 
         * un array de strings)
         * -Try/catch para controlar las excepciones que podamos tener
         * Out,ref e in
         * Usar el equals
         * Cualquier idea que se nos ocurra hacer un comentario de ella donde corresponda
         */

        private List<Signals> signals_list;
        private List<Signal> signal_list;
        private Digital_Signal digital;
        private Analogic_Signal analogic;
        private Files_Management files;
        private Operation operation;
        private Signals signals_class;

        public Menu()
        {
            signals_list = new List<Signals>();
            signal_list = new List<Signal>();
            digital = new Digital_Signal();
            analogic = new Analogic_Signal();
            files = new Files_Management();
            operation = new Operation();

        }
        public void OptionMenu()
        {
            
            int choice;

            do
            {

                Console.WriteLine("\n~ 1) Create signal: \n" +
                                    "~ 2) Add values to file: \n" +
                                    "~ 3) Search signal (By Name): \n" +
                                    "~ 4) Search signal (By date): \n" +
                                    "~ 5) Remove signals (By Name): \n" +
                                    "~ 6) Remove signals (By Date): \n" +
                                    "~ 7) Show file: \n" +
                                    "~ 8) Do operations: \n" +
                                    "~ 0) Exit: \n");

                choice = Convert.ToInt32(Console.ReadLine()); 

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("The program has ended.");
                        break;

                    case 1:
                        create_signal();
                        break;

                    case 2:
                        add_values_to_file();
                        break;

                    case 3:
                        search_signal_name();
                        break;

                    case 4:
                        search_signal_time();
                        break;
                    case 5:
                        remove_signal_name();
                        break;

                    case 6:
                        remove_signal_date();
                        break;

                    case 7:
                        show_file();
                        break;
                    case 8:
                        do_operations();
                        break;

                }

            } while (choice != 0);

        }

      

        private void create_signal()
        {
            int type = 0;
            string name = "";
            int value = 0;
            bool created = false;

            Console.WriteLine("Choose a Type to create the signal: \n" +
                            "~1) Analog \n" +
                            "~2) Digital \n");

            try
            {
                type = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write the signal's Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Write the signal's Value: ");
                value = Convert.ToInt32(Console.ReadLine());

                if (type == 1 && !check_name_list(name))
                {
                    if (analogic.create_signal(name, value))
                    {
                        created = true;
                        signal_list.Add(analogic.search_signal(name));

                    }
                    else
                    {
                        created = false;
                    }


                }
                else if (type == 2 && !check_name_list(name))
                {
                    if (digital.create_signal(name, value))
                    {
                        created = true;
                        signal_list.Add(digital.search_signal(name));
                    }
                    else
                    {
                        created = false;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong value, try again: ");
                    create_signal();
                }

                if (!created)
                {
                    Console.WriteLine("Error creating, try again.");
                    create_signal();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                create_signal();
            }


        }

        private void add_values_to_actual_list()
        {

            int pos = 0, value = 0;
            bool find = false;
            Signal_Type type = Signal_Type.Analogic;
            Signal signal;
            string name = "";

            Console.WriteLine("Introduce the name");
            name = Console.ReadLine();
            try
            {
                Console.WriteLine("Introduce the value");
                value = Convert.ToInt32(Console.ReadLine());

                while (!find && pos < signal_list.Count)
                {
                    if (name == signal_list.ElementAt(pos).Name)
                    {
                        find = true;
                        type = signal_list.ElementAt(pos).Type_Signal;
                    }
                    else
                    {
                        pos++;
                    }

                }

                if (find && type == Signal_Type.Analogic)
                {
                    analogic.add_valuesToSignal(name, value);
                }
                else if (find && type == Signal_Type.Digital)
                {
                    digital.add_valuesToSignal(name, value);
                }
                else
                {
                    Console.WriteLine("The signal hasn´t been found");
                }
            }
            catch (FormatException e)
            {
                add_values_to_actual_list();
                Console.WriteLine(e.Message);
            }

        }

        private bool check_name_list(string name)
        {
            foreach (Signal analogic in analogic.Signals_list)
            {
                if (analogic.Name == name)
                {
                    return true;
                }
            }

            foreach (Signal digital in digital.Signals_list)
            {
                if (digital.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        private void search_signal_name()
        {
            string name;
            List<Signal> signal_searched = new List<Signal>();

            Console.WriteLine("\nWrite the signal's name: ");
            name = Console.ReadLine();

            signal_searched = files.charge_list(name);
            Console.WriteLine("\nFile content: ");
            show_signal(signal_searched);

        }
        private void search_signal_time()
        {
            DateTime time;
            int day = 0, month = 0, year = 0;

            List<Signal> signal_searched = new List<Signal>();

            Console.WriteLine("\nWrite the signal's day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWrite the signal's month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWrite the signal's year: ");
            year = Convert.ToInt32(Console.ReadLine());

            time = new DateTime(year, month, day);

            signal_searched = files.charge_list(time);
            Console.WriteLine("\nFile content: ");
            show_signal(signal_searched);

        }

        private void show_signal(List<Signal> signal_list)
        {
            foreach (Signal signal in signal_list)
            {
                Console.WriteLine(signal.ToString());
            }
        }

        private void show_file()
        {
            List<Signal> signals = files.charge_list();
            show_signal(signals);
        }

        private void add_values_to_file()
        {
            string name;
            int value;
            Signal signal = null;
            Console.WriteLine("Introduce the name");
            name = Console.ReadLine();
            Console.WriteLine("Introduce the value");
            value = Convert.ToInt32(Console.ReadLine());

            files.add_valuesToSignal(name, value);
          
        }

        private void remove_signal_name()
        {
            string name = "";

            Console.WriteLine("Introduce the name");
            name = Console.ReadLine();

            files.remove_signals(name);
        }

        private void remove_signal_date()
        {
            DateTime time;
            int day = 0, month = 0, year = 0;

            Console.WriteLine("\nWrite the signal's day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWrite the signal's month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWrite the signal's year: ");
            year = Convert.ToInt32(Console.ReadLine());

            time = new DateTime(year, month, day);

            files.remove_signals(time);
        }

        private void do_operations()
        {
            Signal_Type type = Signal_Type.Digital;
            int op=0,operation_option = 0;
            string signal_name = "";
            try
            {
                Console.WriteLine("Choose the type of signals you want to operate with:" +
               "\n 1) Digital" +
               "\n 2) Analog");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        type = Signal_Type.Digital;
                        break;
                    case 2:
                        type = Signal_Type.Analogic;
                        break;
                    default:
                        Console.WriteLine("WRONG OPTION!!!");
                        do_operations();
                        break;
                }

                if (type == Signal_Type.Digital)
                {
                    operation.Signal_Operation = new Digital_Operations(files);
                }
                else
                {
                    operation.Signal_Operation = new Analogic_Operations(files);
                }

                Console.WriteLine("Choose the name of the signal:");
                signal_name = Console.ReadLine();

                if(files.check_repeated(signal_name,type) && !string.IsNullOrEmpty(signal_name))
                {
                    Console.WriteLine("Choose the operation to do:" +
                    "\n 1) Max value:" +
                    "\n 2) Average values: ");
                    operation_option = Convert.ToInt32(Console.ReadLine());

                    if (operation_option <= 2 && operation_option > 0)
                    {
                        Console.WriteLine("The result of the operation is: " + operation.DoOperation(operation_option, signal_name));
                    }
                    else
                    {
                        Console.WriteLine("Option unavailable.");
                    }
                }
                else
                {
                    Console.WriteLine("There is no signal with this name and type.");
                }

            }
            catch (FormatException) 
            {
                Console.WriteLine("Wrong value. Try again.");
                do_operations();
            }
           

        }

    }
}
