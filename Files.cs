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


        public void save_signal(List<Signal> signals)
        {
            string p;
        }

        public List<Signal> charge_list()
        {
            return new List<Signal>();
        }

        public void create_file(List<Signal> signals)
        {
            if (!File.Exists(path))
            {
                file_content(signals);
            }
            else
            {
                File.Delete(path);
                file_content(signals);
            }
        }

        private void file_content(List<Signal> signals)
        {
            int position = 0;

            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Signal signal in signals) { }
                {
                    if (palabras[i] != null)
                    {
                        sw.WriteLine("ID: " + signals.ElementAt(position).Name
                        + " ,Palabra: " + signals.ElementAt(position).Type_Signal
                        + " ,Nivel: " + signals.ElementAt(position).Time);
                    }
                    position++;
                }
                Console.WriteLine("Fichero creado");

            }

        }

        public void mostrar_archivo(string nombre_fichero)
        {
            int posicion = 0;
            ruta_archivo = @"C:\Users\ricardsanchez\Desktop\" + nombre_fichero;

            if (File.Exists(ruta_archivo))
            {
                using (StreamReader sr = File.OpenText(ruta_archivo))
                {
                    string leer;
                    while ((leer = sr.ReadLine()) != null)
                    {
                        posicion++;
                        Console.WriteLine(leer);
                    }
                    almacenar_palabras = new Palabra[posicion];
                    contenido_archivo = new string[posicion];
                }
            }
            else
            {
                Console.WriteLine("¡NO EXISTE ARCHIVO PARA LEER!");
            }

        }

        int posicion = 0, anio = 0, ruedas = 0, cont = 0;



        private void guardar_palabras()
        {
            using (StreamReader sr = File.OpenText(ruta_archivo))
            {
                string leer, palabra = "";
                //cont se usa para incrementar individualmente el array donde se almacenan los coches
                int posicion = 0, id = 0, nivel = 0, cont = 0;

                while ((leer = sr.ReadLine()) != null)
                {
                    contenido_archivo[posicion] = leer;
                    separador_datos = contenido_archivo[posicion].Split(" ");
                    //como se usa un split se prepara el for para que solo se almacenen en variables
                    //los datos buscados
                    for (int i = 1; i < separador_datos.Length; i += 8)
                    {
                        id = Convert.ToInt32(separador_datos[i]);
                        palabra = separador_datos[i + 2];
                        nivel = Convert.ToInt32(separador_datos[i + 4]);

                        almacenar_palabras[cont] = new Palabra(palabra, id, nivel);
                        cont++;
                    }
                    posicion++;
                }

            }
        }

        public Palabra[] cargar_archivo(string nombreFichero)
        {
            mostrar_archivo(nombreFichero);
            guardar_palabras();


            return almacenar_palabras;
        }

        public void borrar_fichero(string nombreFichero, Palabra[] palabras)
        {
            ruta_archivo = @"C:\Users\ricardsanchez\Desktop\" + nombreFichero;

            if (File.Exists(ruta_archivo))
            {
                File.Delete(ruta_archivo);
                Console.WriteLine("Introduce el nombre del nuevo fichero");
                nombreFichero = Console.ReadLine();
                generar_fichero(nombreFichero, palabras);
            }
            else
            {
                Console.WriteLine("¡NO EXISTE ARCHIVO PARA BORRAR!");
            }


        }
    }
}
