using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Menu
    {
        public void MenuOpciones()
        {

            int opcion;

            do
            {
                Console.WriteLine("\n~ 1) Crear nueva señal: \n" +
                                    "~ 2) Añadir valores a señal: \n" +
                                    "~ 3) Opcion3: \n" +

                                    "~ 0) Salir: \n");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                }

            } while (opcion != 0);
        }

    }
}
