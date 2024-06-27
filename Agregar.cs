using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinal
{
    public partial class Agregar : Form
    {
        string cadenaConexion = "server=DESKTOP-BNU6A8E\\SQLEXPRESS01;database=envios;integrated security=true;";

        SqlConnection MiConexion = new SqlConnection("server=DESKTOP-BNU6A8E\\SQLEXPRESS01;database=envios;integrated security=true;");
        public Agregar()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void barraMenuSeguimiento_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        string Nombre, Apellido, Dni, NroPedido;
        string Pago, Debe, Estado;

        private void AgregarPago_TextChanged(object sender, EventArgs e)
        {
            Pago = AgregarPago.Text;
        }

        private void AgregarNPedido_TextChanged(object sender, EventArgs e)
        {
            NroPedido = AgregarNPedido.Text;
        }

        private void AgregarDebe_TextChanged(object sender, EventArgs e)
        {
            Debe = AgregarDebe.Text;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AgregarEstado_TextChanged(object sender, EventArgs e)
        {
            Estado = AgregarEstado.Text;
        }

        private void barraMenuSeguimiento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgregarNombre_TextChanged(object sender, EventArgs e)
        {
            Nombre = AgregarNombre.Text;
        }

        private void AgregarApellido_TextChanged(object sender, EventArgs e)
        {
            Apellido = AgregarApellido.Text;
        }

        private void AgregarDni_TextChanged(object sender, EventArgs e)
        {
            Dni = AgregarDni.Text;
        }
        private void ClearFormFields()
        {
            AgregarDni.Text = string.Empty;
            AgregarNombre.Text = string.Empty;
            AgregarApellido.Text = string.Empty;
            AgregarNPedido.Text = string.Empty;
            AgregarDebe.Text = string.Empty;
            AgregarPago.Text = string.Empty;
            AgregarEstado.Text = string.Empty;
        }
        private void btnAplicarSeguimiento_Click(object sender, EventArgs e)
        {
            // Define your SQL query with parameter placeholders
            string consultaAgregar = "insert into usuarios(dni, nombre, apellido, num_seg, debe, pago, estado) values(@Dni, @Nombre, @Apellido, @NroPedido, @Debe, @Pago, @Estado)";

            // Create a new connection using your connection string
            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    // Open the connection
                    MiConexion.Open();

                    // Create a SqlCommand object
                    SqlCommand datosCorrectos = new SqlCommand(consultaAgregar, MiConexion);

                    // Add parameters with their respective values
                    datosCorrectos.Parameters.AddWithValue("@Dni", Dni);
                    datosCorrectos.Parameters.AddWithValue("@Nombre", Nombre);
                    datosCorrectos.Parameters.AddWithValue("@Apellido", Apellido);
                    datosCorrectos.Parameters.AddWithValue("@NroPedido", NroPedido);
                    datosCorrectos.Parameters.AddWithValue("@Debe", Debe);
                    datosCorrectos.Parameters.AddWithValue("@Pago", Pago);
                    datosCorrectos.Parameters.AddWithValue("@Estado", Estado);

                    // Execute the query
                    datosCorrectos.ExecuteNonQuery();

                    // Show success message
                    MessageBox.Show("Usuario añadido con éxito");

                    ClearFormFields();
                }
                catch
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show("Error al añadir usuario");
                }
            }
        }
    }
}
