using System;
using System.IO;
using System.Windows.Forms;

namespace Generar_OpenOrder
{
    public static class Grabar
    {
        public static void grabar(string cadena)
        {
            DateTime fechaX = DateTime.Now;
            string fecha_completa, nombre_archivo, comprobacion = string.Empty;
            fecha_completa = fechaX.ToString("dd/MM/yyyy hh:mm:ss tt ");
            nombre_archivo = "LogFile.log";
            //Está sentencia, abre el archivo.
            StreamWriter escrito = File.AppendText(nombre_archivo);
            //Se utiliza determinar la longitud del archivo, esto con el fin de evitar un salto de línea innecesario.
            FileInfo we = new FileInfo(nombre_archivo);

            if (we.Length == 0)
            {
                escrito.Write(fecha_completa + cadena.ToString());
            }
            else
            {
                escrito.Write("\r\n" + fecha_completa + cadena.ToString());
            }
            Console.WriteLine("Lo que se está grabando en este momento: \n" + fecha_completa + cadena.ToString());
            escrito.Flush();
            escrito.Close();
        }

        private static void Error(string mensaje)
        {
            grabar(mensaje);
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Aviso(string mensaje)
        {
            grabar(mensaje);
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
