using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generar_OpenOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ejecutar_Click(object sender, EventArgs e)
        {
            try
            {
                string conex =
                "Data Source =" + this.txt_instancia.Text + "; Initial Catalog= " + this.txt_base.Text + ";User ID =" + this.txt_usuario.Text + ";Password=" + this.txt_contrasena.Text + ";Trusted_Connection = False;";
                SqlConnection operativa = new SqlConnection(conex);
                operativa.Open();

                if (operativa.State == ConnectionState.Open)
                {
                    MessageBox.Show("Conexión Establecida a base operativa: " + this.txt_base.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Grabar.grabar("Conexión Establecida a base operativa: " + this.txt_base.Text);
                }
                
                operativa.Close();

                DataTable tabla = new DataTable(); // El resultado lo guardaremos en una tabla
                string kopr = string.Empty;

                for (int i = 0; i < txt_openorder.Lines.Length; i++)
                {
                    operativa.Open();
                    string orden = txt_openorder.Lines[i];
                    SqlDataAdapter AdaptadorTabla = new SqlDataAdapter(Libreria.consultar_openorder(orden), operativa); // Usaremos un DataAdapter para leer los datos
                    AdaptadorTabla.Fill(tabla);// Llenamos la tabla con los datos leídos
                    if (tabla.Rows.Count == 0)
                    {
                        kopr = "";
                    }
                    else
                    {
                        kopr = tabla.Rows[0]["IDEN"].ToString();//guardo informacion en variables
                    }
                    if (kopr =="")
                    {
                        SqlCommand comando = new SqlCommand(Libreria.generar_openorder(orden), operativa);
                        SqlDataReader registros_nombre = comando.ExecuteReader();
                        Grabar.grabar("Se guardo openorder para: " + orden);
                    }
                    else
                    {
                        Console.WriteLine("La orden: " + orden + " ya existe.");
                        Grabar.grabar("La orden: " + orden + " ya existe.");

                    }
                    if (operativa.State == ConnectionState.Open)
                    {
                        operativa.Close();
                    }
                }
                MessageBox.Show("Proceso terminado.");
                Grabar.grabar("Proceso Terminado");
            }
            catch(Exception error)
            {
                MessageBox.Show("Surgió un error: " + error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            bool flag = MessageBox.Show("Desea salir", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            if (flag)
            {
                base.Close();
            }
        }
    }
}
