using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
        public void OptionMenu()
        {
            
            int choice;

            do
            {
                Console.WriteLine("\n~ 1) Create signal: \n" +
                                    "~ 2) Add values to signal: \n" +
                                    "~ 3) aaa: \n" +
                                    "~ 4) aaa: \n" +
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

                        add_values_to_signal();
                        break;

                    case 3:

                        break;

                    case 4:

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

                if (type == 1)
                {
                    if(analogic.create_signal(name, value))
                    {
                        created = true;
                        signal_list.Add(analogic.search_signal(name));
                        
                    }
                    else
                    {
                        created = false;
                    }


                }
                else if (type == 2)
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
        private void add_values_to_signal()
        {

        }

    }
}
