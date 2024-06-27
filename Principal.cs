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
using System.Net;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Management.Instrumentation;
using System.Drawing.Imaging;

namespace ProyectoFinal
{
    public partial class menuPrincipal : Form {

        string cadenaConexion = "server=DESKTOP-BNU6A8E\\SQLEXPRESS01;database=envios;integrated security=true;";

        SqlConnection MiConexion = new SqlConnection("server=DESKTOP-BNU6A8E\\SQLEXPRESS01;database=envios;integrated security=true;");

        public menuPrincipal()
        {
            InitializeComponent();
            eventosAsignados();
            closeUsuario();
            closeAdmin();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void closeAdmin()
        {
            panelAdmin.Visible = false;
        }
        private void closeUsuario()
        {
            panelAdmin.Visible = true;
        }

        private void eventosAsignados()
        {
            this.label1.MouseEnter += new EventHandler(this.panel3_MouseEnter);
            this.label1.MouseLeave += new EventHandler(this.panel3_MouseLeave);
            this.fotoBtnUsuario.MouseLeave += new EventHandler(this.panel3_MouseLeave);
            this.fotoBtnUsuario.MouseEnter += new EventHandler(this.panel3_MouseEnter);
            this.label1.Click += new EventHandler(this.btnMenuUsuario_Click);
            this.fotoBtnUsuario.Click += new EventHandler(this.btnMenuUsuario_Click);

            this.txtAdmin.MouseEnter += new EventHandler(this.btnAdmin_MouseEnter);
            this.txtAdmin.MouseLeave += new EventHandler(this.btnAdmin_MouseLeave);

            this.iconAdmin.MouseEnter += new EventHandler(this.btnAdmin_MouseEnter);
            this.iconAdmin.MouseLeave += new EventHandler(this.btnAdmin_MouseLeave);

            this.iconAdmin.MouseClick += new MouseEventHandler(this.btnAdmin_MouseClick);
            this.txtAdmin.MouseClick += new MouseEventHandler(this.btnAdmin_MouseClick);

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void barraMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            popup.Visible = true;
            popup.Refresh();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if(popup.Visible == true)
            {
                popup.Visible = false;
                popup.Refresh();
            }
        }

        private void popup_Click(object sender, EventArgs e)
        {

        }

        private bool formSeguimientoAbierto = false;

        private string comprobacion;

        private void dniComprobacion_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                comprobacion = textBox.Text;
            }
        }

        private void btnSeguimiento_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comprobacion))
            {
                MessageBox.Show("Error: El valor de comprobacion es nulo o está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                string consultaDniCorrecto = "SELECT dni FROM usuarios WHERE dni = @dni";
                MiConexion.Open();
                SqlCommand dniCorrecto = new SqlCommand(consultaDniCorrecto, MiConexion);
                dniCorrecto.Parameters.AddWithValue("@dni", comprobacion);

                object result = dniCorrecto.ExecuteScalar();

                if (result != null)
                {
                    int CDC = Convert.ToInt32(result);

                    if (CDC > 0)
                    {
                        if (formSeguimientoAbierto)
                        {
                            MessageBox.Show("Error: El Formulario de seguimiento se encuentra activo.", "Error 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            seguimiento fS = new seguimiento();
                            fS.FormClosed += (s, args) => formSeguimientoAbierto = false;
                            formSeguimientoAbierto = true;
                            fS.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Tu dni no esta en nuestra base de datos, si crees que es un error contacta con soporte.", "Error 102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error: No se encontró ningún resultado para el DNI proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnMaximizar_MouseEnter(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.DimGray;
            btnMaximizar.Refresh();
        }

        private void btnMaximizar_MouseLeave(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.Transparent;
            btnMaximizar.Refresh();
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.DimGray;
            btnMinimizar.Refresh();
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.Refresh();
        }

        private void btnRestaurar_MouseEnter(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.DimGray;
            btnRestaurar.Refresh();
        }

        private void btnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurar.BackColor= Color.Transparent;
            btnRestaurar.Refresh();

        }

        private void panelLateralIzquierdo_Paint(object sender, PaintEventArgs e)
        {
            int CornerRadius = 50;

            GraphicsPath path = new GraphicsPath();
            float radius = CornerRadius;
            path.AddArc(new RectangleF(0, 0, radius, radius), 180, 90);
            path.AddArc(new RectangleF(panelLateralIzquierdo.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new RectangleF(panelLateralIzquierdo.Width - radius, panelLateralIzquierdo.Height - radius, radius, radius), 0, 90);
            path.AddArc(new RectangleF(0, panelLateralIzquierdo.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            panelLateralIzquierdo.Region = new Region(path);

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int CornerRadius = 10;

            GraphicsPath path = new GraphicsPath();
            float radius = CornerRadius;
            path.AddArc(new RectangleF(0, 0, radius, radius), 180, 90);
            path.AddArc(new RectangleF(btnMenuUsuario.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new RectangleF(btnMenuUsuario.Width - radius, panelLateralIzquierdo.Height - radius, radius, radius), 0, 90);
            path.AddArc(new RectangleF(0, btnMenuUsuario.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            btnMenuUsuario.Region = new Region(path);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            btnMenuUsuario.BackColor = Color.FromArgb(35, 35, 35);
            btnMenuUsuario.Refresh();
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            btnMenuUsuario.BackColor = Color.FromArgb(20, 20, 20);
            btnMenuUsuario.Refresh();
        }

        private void btnUsuario_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenuUsuario_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnMenuUsuario_Click(object sender, EventArgs e)
        {
            if (panelAdmin.Visible == true)
            {
                panelAdmin.Visible = false;
                panelUsuario.Visible = true;
            }
            else
            {
                panelUsuario.Visible = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelUsuario.Visible == true)
            {
                panelUsuario.Visible = false;
                panelAdmin.Visible = true;
            }
            else
            {
                panelAdmin.Visible = true;
            }
        }

        private void btnAdmin_MouseEnter(object sender, EventArgs e)
        {
            btnAdmin.BackColor = Color.FromArgb(35, 35, 35);
            btnAdmin.Refresh();
        }

        private void btnAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnAdmin.BackColor = Color.FromArgb(20, 20, 20);
            btnAdmin.Refresh();
        }
        private void btnAdmin_Paint(object sender, PaintEventArgs e)
        {
            int CornerRadius = 10;

            GraphicsPath path = new GraphicsPath();
            float radius = CornerRadius;
            path.AddArc(new RectangleF(0, 0, radius, radius), 180, 90);
            path.AddArc(new RectangleF(btnAdmin.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new RectangleF(btnAdmin.Width - radius, panelLateralIzquierdo.Height - radius, radius, radius), 0, 90);
            path.AddArc(new RectangleF(0, btnAdmin.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            btnAdmin.Region = new Region(path);
        }
        string usuario;
        string clave;
        private void btnIngresarAdmin_Click(object sender, EventArgs e)
        {
            //aca va la comprobacion en sql si es usuario administrador y hacer que aparezcan el panel "panelAdminOpciones"

            string consultaAdmin = "select usuario, clave from admin where usuario = @usuario and clave = @clave";
            using (SqlConnection MiConexion = new SqlConnection(cadenaConexion))
            {
                MiConexion.Open();
                SqlCommand datosCorrectos = new SqlCommand(consultaAdmin, MiConexion);

                datosCorrectos.Parameters.AddWithValue("@usuario", usuario);
                datosCorrectos.Parameters.AddWithValue("@clave", clave);

                object result = datosCorrectos.ExecuteScalar();

                if (result != null)
                {
                    panelAdministradorOpciones.Visible = true;
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrecto!", "Error", MessageBoxButtons.AbortRetryIgnore);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            usuario = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            clave = textBox1.Text;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar Ag = new Agregar();
            Ag.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar Mo = new Modificar();
            Mo.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar El = new Eliminar();
            El.Show();
        }

        private void barraMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }

