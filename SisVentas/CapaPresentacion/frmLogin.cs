using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {

        CapaDatos.ConexiondbDataContext conexionlinq = new CapaDatos.ConexiondbDataContext();
        public int accesousuario;
        string nombreusu;
        string passuser;
        int codigousu;
        int count = 0;
        char estadousu;

        FrmMenu frm = new FrmMenu();
        int Count = 0;
        public frmLogin()
        {

            InitializeComponent();
            this.ttMensaje.SetToolTip(this.TxtUsuario, "Ingrese su nombre de usuario");
            this.ttMensaje.SetToolTip(this.TxtPassword, "Inserte su contraseña");
            this.ttMensaje.SetToolTip(this.BtnIngresar, "Para ingresar, introduzca su nombre de usuario y contraseña correctos");
            this.ttMensaje.SetToolTip(this.btnminimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.btnClose, "Cerrar");
            this.TxtUsuario.ForeColor = Color.LightGray;
            this.TxtPassword.ForeColor = Color.LightGray;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.TxtPassword.UseSystemPasswordChar = false;
            this.TxtPassword.Text = "Contraseña";
            this.TxtUsuario.Text = "Usuario";
            this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
            this.TxtPassword.TextAlign = HorizontalAlignment.Center;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
        }
        
 
        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            if ((this.TxtPassword.Text == "Contraseña" || this.TxtPassword.Text == "") && (this.TxtUsuario.Text == "Usuario" || this.TxtUsuario.Text == "" ))
            {

                MessageBox.Show("No ha ingresado un nombre de usuario y contraseña.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else 
            {

                Login();

                if (count < 3)
                {

                    //formatear textboxs
                    this.TxtPassword.UseSystemPasswordChar = false;
                    this.TxtPassword.ForeColor = Color.LightGray;
                    this.TxtPassword.Text = "Contraseña";
                    this.TxtUsuario.Text = "Usuario";
                    this.TxtUsuario.ForeColor = Color.LightGray;
                    this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
                    this.TxtPassword.TextAlign = HorizontalAlignment.Center;

                }

               

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        void desbloqueo()
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
         
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {


        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
         
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUsuario_Enter_1(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "Usuario")
            {
                TxtUsuario.Text = "";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                this.TxtUsuario.ForeColor = Color.Black;
                //  TxtUsuario.ForeColor = Color.Black;
            }
        }

        private void TxtUsuario_Leave_1(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "")
            {
                TxtUsuario.Text = "Usuario";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Center;
                this.TxtUsuario.ForeColor = Color.LightGray;
                
                // TxtUsuario.ForeColor = Color.Black;
            }
        }

        
        private void TxtPassword_Enter_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Contraseña")
            {
                TxtPassword.Text = "";
               // TxtPassword.ForeColor = Color.Black;
                TxtPassword.UseSystemPasswordChar = true;
                this.TxtPassword.TextAlign = HorizontalAlignment.Left;
                this.TxtPassword.ForeColor = Color.Black;

            }
        }

        private void TxtPassword_Leave_1(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                TxtPassword.Text = "Contraseña";
               // TxtPassword.ForeColor = Color.Black;
                TxtPassword.UseSystemPasswordChar = false;
                this.TxtPassword.TextAlign = HorizontalAlignment.Center;
                this.TxtPassword.ForeColor = Color.LightGray;

            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        //Manejar Click event
        private void TxtUsuario_MouseClick(object sender, MouseEventArgs e)
        {

            if (this.TxtUsuario.Text == "Usuario")
            {

                this.TxtUsuario.Text = "";
                this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                this.TxtUsuario.ForeColor= Color.Black;

            }

        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {

            //eliminar este método/redundante
            if (this.TxtPassword.Text == "Contraseña")
                this.TxtPassword.Text = "Contraseña";
     
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {

            if (this.TxtPassword.Text == "Contraseña")
            {

                this.TxtPassword.Text = "";
                this.TxtPassword.TextAlign = HorizontalAlignment.Left;
                this.TxtPassword.ForeColor = Color.Black;

            }

            this.TxtPassword.UseSystemPasswordChar = true;

        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {

        }

        private void Login()
        {

            try
            {
                count++;

                data.DataSource = conexionlinq.accesologin(TxtUsuario.Text, TxtPassword.Text);
                accesousuario = int.Parse(data[0, 0].Value.ToString());
                nombreusu = data[1, 0].Value.ToString();
                codigousu = int.Parse(data[3, 0].Value.ToString());
                passuser = data[2, 0].Value.ToString();
                estado.DataSource = conexionlinq.estadoconexion(codigousu);
                estadousu = char.Parse(estado[2, 0].Value.ToString());
                frm.Acceso = accesousuario;
                

                //control de intento
                if (data.RowCount != 0 && estadousu == 'c')
                {

                    data.Visible = true;
                    if (accesousuario == 1)
                    {
                        //   MessageBox.Show(passuser);
                        frm.Show();
                        frm.btnUser.Text = TxtUsuario.Text;
                        frm.usuario = TxtUsuario.Text;
                      
                        this.Hide();

                    }
                    if (accesousuario == 2)
                    {

                        frm.Show();
                        frm.usuario = TxtUsuario.Text;
                        frm.btnUser.Text = TxtUsuario.Text;
                        this.Hide();

                    }
                    if (accesousuario == 3)
                    {
                        frm.Show();
                        frm.usuario = TxtUsuario.Text;
                        frm.btnUser.Text = TxtUsuario.Text;
                        this.Hide();
                    }
                }
                else
                {

                    if (count >= 3)
                    {
                        this.TxtUsuario.Text = "Usuario";
                        this.TxtPassword.Text = "Contraseña";
                        this.TxtPassword.Enabled = false;
                        this.TxtUsuario.Enabled = false;
                        this.lblError.Text = "Solicite ayuda a soporte técnico para ingresar al sistema.";


                    }
                    else
                    {

                        MessageBox.Show("Usuario o contraseña incorrecto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.lblError.Text = "Usuario o contraseña Incorrecto";
                        this.pnlUsuario.BackColor = Color.Red;
                        this.pnlContraseña.BackColor = Color.Red;

                    }
                    

                }

            }
            catch (Exception)
            {

                if (count >= 3)
                {

                    this.TxtUsuario.Text = "Usuario";
                    this.TxtPassword.Text = "Contraseña";
                    this.TxtPassword.Enabled = false;
                    this.TxtUsuario.Enabled = false;
                    this.lblError.Text = "Solicite ayuda a soporte técnico para ingresar al sistema.";


                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.lblError.Text = "Usuario o contraseña Incorrecto";
                    this.pnlUsuario.BackColor = Color.Red;
                    this.pnlContraseña.BackColor = Color.Red;

                }

            

            }
        }

        //ingresar presionando enter
        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if ((this.TxtPassword.Text != "Contraseña" && this.TxtPassword.Text != "") && (this.TxtUsuario.Text != "Usuario" && this.TxtUsuario.Text != ""))
                {

                    Login();

                    if (count < 3)
                    {

                        this.TxtUsuario.Text = "";
                        this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                        this.TxtUsuario.Focus();
                        this.TxtPassword.UseSystemPasswordChar = false;
                        this.TxtPassword.TextAlign = HorizontalAlignment.Center;
                        this.TxtPassword.ForeColor = Color.LightGray;
                        this.TxtPassword.Text = "Contraseña";

                    }

               

                                    

                }
               

            }
            
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if ((this.TxtPassword.Text != "Contraseña" && this.TxtPassword.Text != "") && (this.TxtUsuario.Text != "Usuario" && this.TxtUsuario.Text != ""))
                {

                    Login();


                    if (count < 3)
                    {

                        
                        this.TxtUsuario.Text = "";
                        this.TxtUsuario.Focus();
                        this.TxtUsuario.TextAlign = HorizontalAlignment.Left;
                        this.TxtPassword.UseSystemPasswordChar = false;
                        this.TxtPassword.ForeColor = Color.LightGray;
                        this.TxtPassword.TextAlign = HorizontalAlignment.Center;
                        this.TxtPassword.Text = "Contraseña";

                    }

                }


            }

        }

        private void TxtUsuario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}
