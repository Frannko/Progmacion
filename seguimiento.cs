using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public partial class seguimiento : Form
    {
        string cadenaConexion = "server=DESKTOP-BNU6A8E\\SQLEXPRESS01;database=envios;integrated security=true;";
        public seguimiento()
        {
            InitializeComponent();
            estado1.Visible = false;
            estado2.Visible = false;
            estado3.Visible = false;
        }

        private void seguimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
       
        }

        private void barraMenuSeguimiento_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string dni;
        private string nombre;
        private string apellido;
        private string num_seg;

        private void nombreSeguimiento_TextChanged(object sender, EventArgs e)
        {

            nombre = nombreSeguimiento.Text;
           
        }

        private void apellidoSeguimiento_TextChanged(object sender, EventArgs e)
        {
            apellido = apellidoSeguimiento.Text;

        }
        private void dniSeguimiento_TextChanged(object sender, EventArgs e)
        {
            dni = dniSeguimiento.Text;
        }

        private void npedidoSeguimiento_TextChanged(object sender, EventArgs e)
        {

            num_seg = npedidoSeguimiento.Text;

        }

        private void btnAplicarSeguimiento_Click(object sender, EventArgs e)
        {
            string consultaDatosCorrectos = "select debe from usuarios where dni = @dni AND nombre = @nombre AND apellido = @apellido AND num_seg = @num_seg";
            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                MiConexion.Open();
                SqlCommand datosCorrectos = new SqlCommand(consultaDatosCorrectos,MiConexion);

                datosCorrectos.Parameters.AddWithValue("@dni",dni);
                datosCorrectos.Parameters.AddWithValue("@nombre", nombre);
                datosCorrectos.Parameters.AddWithValue("@apellido", apellido);
                datosCorrectos.Parameters.AddWithValue("@num_seg", num_seg);

                object result = datosCorrectos.ExecuteScalar();

                if (result != null)
                {
                    debeS.Text = "" + result;
                }
                else
                {
                    MessageBox.Show("No hay pedidos con esos datos, si crees que fue un error contacta con soporte. Gracias Por confiar!");
                }
            }

            string consultaDatosCorrectosTWO = "select pago from usuarios where dni = @dni AND nombre = @nombre AND apellido = @apellido AND num_seg = @num_seg";
            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                MiConexion.Open();
                SqlCommand datosCorrectos = new SqlCommand(consultaDatosCorrectosTWO, MiConexion);

                datosCorrectos.Parameters.AddWithValue("@dni", dni);
                datosCorrectos.Parameters.AddWithValue("@nombre", nombre);
                datosCorrectos.Parameters.AddWithValue("@apellido", apellido);
                datosCorrectos.Parameters.AddWithValue("@num_seg", num_seg);

                object result = datosCorrectos.ExecuteScalar();

                if (result != null)
                {
                    pagoS.Text = "" + result;
                }
                else
                {
                    MessageBox.Show("No hay pedidos con esos datos, si crees que fue un error contacta con soporte. Gracias Por confiar!");
                }
            }

            string consultaDatosCorrectosTHREE = "select estado from usuarios where dni = @dni AND nombre = @nombre AND apellido = @apellido AND num_seg = @num_seg";
            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                MiConexion.Open();
                SqlCommand datosCorrectos = new SqlCommand(consultaDatosCorrectosTHREE, MiConexion);

                datosCorrectos.Parameters.AddWithValue("@dni", dni);
                datosCorrectos.Parameters.AddWithValue("@nombre", nombre);
                datosCorrectos.Parameters.AddWithValue("@apellido", apellido);
                datosCorrectos.Parameters.AddWithValue("@num_seg", num_seg);

                object result = datosCorrectos.ExecuteScalar();

                if (result != null)
                {
                    switch (result)
                    {
                        case "1":
                            estadoS.Text = "Tu paquete esta viajando!";
                            estado1.Visible = true;
                            break;

                        case "2":
                            estadoS.Text = "Preparando el paquete!";
                            estado2.Visible = true;
                            break;

                        case "3":
                            estadoS.Text = "Entregado!";
                            estado3.Visible = true;
                            break;
                        default:
                            MessageBox.Show("Error!");
                            break;

                    }

                }
                else
                {
                    MessageBox.Show("No hay pedidos con esos datos, si crees que fue un error contacta con soporte. Gracias Por confiar!");
                }
            }
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Crimson;
            btnCerrar.Refresh();
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Refresh();
        }

        private void barraMenuSeguimiento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
