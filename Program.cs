using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Program
    {

        public static void Main(string[] args)
        {
            // aqui para pruebas de cosas sueltas que queramos probar 
            //aqui solo se llamara a la clase menu al metodo menu_option
            // por lo que el resto de métodos de esa clase deben estar en privados
            string fechaActual = DateTime.UtcNow.ToString("dd-MM-yyyy/HH-mm-ss");


            Analogic_Signal s = new Analogic_Signal(Analogic_Value_Type.Degrees);

            s.create_signal("ssda", 2);

            s.Operation.DoOperation();

   

        }

    }
}
