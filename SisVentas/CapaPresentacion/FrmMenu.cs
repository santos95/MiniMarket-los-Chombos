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
using System.Diagnostics;//manda a llmar los recursos del process.stark

namespace CapaPresentacion
{
    public partial class FrmMenu : Form
    {

        public string Cod_trabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public int Acceso;
        public FrmMenu()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.iconminimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.iconcerrar, "Cerrar");
            this.ttMensaje.SetToolTip(this.btnMenu, "Minimizar iconos");
            this.ttMensaje.SetToolTip(this.pictureBox1, "Cerrar sesion ");
            this.ttMensaje.SetToolTip(this.btnMcaja, "Despleglar modulos de caja");
            this.ttMensaje.SetToolTip(this.btnaperturacaja, "Abrir caja");

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 224)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 224;

        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               Application.Exit();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.None;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnlogoInicio_Click(object sender, EventArgs e)
        {
   
        }


        private void FrmMenu_Load(object sender, EventArgs e)
        {
            btnlogoInicio_Click(null, e);
            GestionUsuario();
        }

        private void GestionUsuario()
        {
            //COntrolar los accesos de los usuarios 
            //administrador
            if (Acceso == 1)
            {
                this.btnCategoria.Enabled = true;
                this.btnPresentacion.Enabled = true;
                this.btnMGestion.Enabled = true;
                this.btnProveedor.Enabled = true;
                this.btnEmpleado.Enabled = true;
                this.btnnuevaventa.Enabled = true;
                this.btnnuevacompra.Enabled = true;
                this.btnanularcompra.Enabled = true;
                //this.btnaprobarcompra.Enabled = true;
            }
            //cajero, vendedor
            else if (Acceso == 2)
            {
                this.btnnuevacompra.Enabled = false;
                this.btnanularcompra.Enabled = false;
                this.btnordencompra.Enabled = false;
                this.btnrecepcioncompra.Enabled = false;
                this.btncuentasxpagar.Enabled = false;
                this.btncotizacion.Enabled = false;
                this.btnEmpleado.Enabled = false;
                this.btnCargo.Enabled = false;
                this.btnroles.Enabled = false;
                this.btnusuario.Enabled = false;

                this.btnanularventa.Enabled = false;

                /*
                this.btnCategoria.Enabled = true;
                this.btnPresentacion.Enabled = true;
                this.btnMGestion.Enabled = true;
                this.btnProveedor.Enabled = false;
                this.btnEmpleado.Enabled = false;
                //this.btnEmpleado.Visible = false;
                this.btnnuevaventa.Enabled = true;
                this.btnnuevacompra.Enabled = true;
               // this.btnaprobarcompra.Enabled = false;
                /*
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                */

            }
            //bodega
            else if (Acceso == 3)
            {

                this.btnCategoria.Enabled = true;
                this.btnPresentacion.Enabled = true;
                this.btnMGestion.Enabled = true;
                this.btnProveedor.Enabled = true;
                this.btnEmpleado.Enabled = false;
                this.btnnuevaventa.Enabled = false;
                this.btnnuevacompra.Enabled = false;
              //  this.btnaprobarcompra.Enabled = false;
                /*
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                */

            }
            else
            {

                this.btnMcaja.Enabled = false;
                this.btnMcompras.Enabled = false;
                this.btnMventas.Enabled = false;
                this.btnMGestion.Enabled = false;
                this.btnMadmin.Enabled = false;


                 /*this.btnCategoria.Enabled = false;
                this.btnPresentacion.Enabled = false;
                this.btnGestion.Enabled = false;
                this.btnProveedor.Enabled = false;
                this.btnEmpleado.Enabled = false;
                this.btnnuevaventa.Enabled = false;
                this.btnnuevacompra.Enabled = false;
               this.btnaprobarcompra.Enabled = false;
                this.btnCargo.Enabled = false;*/

            /*
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = false;
                */

            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblh.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblf.Text = DateTime.Now.ToShortDateString();
        }

        private void btnCambiarSesion_Click(object sender, EventArgs e)
        {

            
        }

      

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCategoria());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmPresentacion());
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(FrmArticulo.GetInstancia());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProveedor());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmTrabajador());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                AbrirFormEnPanel(new FrmVenta/*.GetInstancia*/());
        }

        private void btnlogoInicio_Click_1(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void psesion_Paint(object sender, PaintEventArgs e)
        {

        }
        //añadir esto a a gestion de usuarios
        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmIngreso());
        }
        //agregar un formulario para este boton
        private void btnReportes_Click(object sender, EventArgs e)
        {
            

        }


        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        //Abre la ruta de la calculadora directmente en el pane pricipal de la aplicacion

        private void cALCULADORAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea abrir la calculadora?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Process.Start(@"calc.exe");
        }

        private void exelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea abrir Excel?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Process.Start(@"excel.exe");
        }

        private void agregarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HerramientasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCargo());
        }

        private void userlbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión?", "Advertencia",
 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Restart();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelinvent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void atajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Process atajos = new Process();
            atajos.StartInfo.FileName = @"C:\Users\josemanuel\Desktop\sisventafinal 24-11-2019 6.30 pm\guia\Atajos del proyecto software.txt";
            atajos.Start();*/
            frmayuda_atajos at = new frmayuda_atajos();
            at.Show();

        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            if (pnlcaja.Visible == false)
            {
                pnlcaja.Visible = true;
            }
            else
            pnlcaja.Visible = false;
            pnlcompras.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlventas.Visible = false;

        }
       


        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void pnladmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            if (pnlcompras.Visible == false)
            {
                pnlcompras.Visible = true;
            }
            else
                pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;
            pnlventas.Visible = false;
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            if (pnlventas.Visible == false)
            {
                pnlventas.Visible = true;
            }
            else
                pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            pnlnegocio.Visible = false;

        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            if (pnlnegocio.Visible == false)
            {
                pnlnegocio.Visible = true;
            }
            else
                pnlnegocio.Visible = false;
            pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnladmin.Visible = false;
            
        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            if (pnladmin.Visible == false)
            {
                pnladmin.Visible = true;
            }
            else
                pnladmin.Visible = false;
            pnlventas.Visible = false;
            pnlcompras.Visible = false;
            pnlcaja.Visible = false;
            pnlnegocio.Visible = false;
        }

        private void btningresos_Click(object sender, EventArgs e)
        {
  
        }

        private void btnnuevacompra_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmVenta());
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCliente());
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmArticulo());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProveedor());
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCategoria());
        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmPresentacion());
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmTrabajador());
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmRoles());
        }

        private void btnroles_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmRoles());
        }

        private void AyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAyuda a = new frmAyuda();
            a.Show();
        }
    }
}
