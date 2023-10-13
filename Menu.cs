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
        public void OptionMenu()
        {

            int choice;

            do
            {
                Console.WriteLine("\n~ 1) Create signal: \n" +
                                    "~ 2) Add values: \n" +
                                    "~ 3) Remove signal: \n" +
                                    "~ 4) Search signal: \n" +
                                    "~ 0) Salir: \n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:

                        break;

                    case 1:

                        break;

                    case 2:

                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                }

            } while (choice != 0);
        }

    }
}
