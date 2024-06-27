using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            menuPrincipal menuPr = new menuPrincipal();

            Button btnSeguimiento = new Button();
            btnSeguimiento.Size = new System.Drawing.Size(150, 50);
            btnSeguimiento.Location = new System.Drawing.Point(125, 100);
            btnSeguimiento.BackColor = System.Drawing.Color.LightGray;
            btnSeguimiento.FlatStyle = FlatStyle.Flat;
            btnSeguimiento.FlatAppearance.BorderSize = 0;

            

            Application.Run(menuPr);
        }

    }
}