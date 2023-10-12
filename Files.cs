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
            if (!File.Exists(path))
            {
                create_file(signals);
            }
            else
            {
                add_content(signals);
            }
        }

        private void add_content(List<Signal> signals)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (Signal signal in signals)
                {
                    sw.WriteLine("Name:" + signal.Name
                        + ",Type:" + signal.Type_Signal
                        + ",Time:" + signal.Time
                        + ",Value:" + signal.Numeric_value);
                }
            }
        }

        public List<Signal> charge_list()
        {
            List<Signal> signal_support = new List<Signal>();

            return signal_support;
        }


        private void create_file(List<Signal> signals)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Signal signal in signals)
                {
                    {
                        sw.WriteLine("Name:" + signal.Name
                        + ",Type:" + signal.Type_Signal
                        + ",Time:" + signal.Time
                        + ",Value:" + signal.Numeric_value);
                    }
                }
            }
        }
            private List<string> read_file()
            {
                List<string> signals_read = new List<string>();
                string read = "";

                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        while ((read = sr.ReadLine()) != null)
                        {
                            signals_read.Add(read);
                        }
                    }
                }

                return signals_read;
            }



            void guardar_palabras()
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
                char[] delimiterChars = { ' ', ',', '.', ':' };

                string text = "one:ttwo,three:four,five six seven";
                System.Console.WriteLine($"Original text: '{text}'");

                string[] words = text.Split(delimiterChars);
                System.Console.WriteLine($"{words.Length} words in text:");

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
                read_file(nombreFichero);
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

