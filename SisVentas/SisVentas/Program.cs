using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using CapaPresentacion.GestionNegocio;
using CapaPresentacion.Administración;
namespace SisVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            // Application.Run(new CapaPresentacion.GestionNegocio.FrmEmpleado());
            //Application.Run(FrmArticulo.GetInstancia());
            // Application.Run(new frmPresentacion());
             // Application.Run(new frmTrabajador());
           // Application.Run(new frmPrincipal());
        }
    }
}
