using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class frmTrabajador : Form
    {
        int cod;
        CapaDatos.ConexiondbDataContext con = new CapaDatos.ConexiondbDataContext();
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public frmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese Los Apellidos del Cliente");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el Documento del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Cliente");
        }
        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpia los controles del formulario
        private void Limpiar()
        {
            //this.txtcod_trabajador.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            //this.txtUsuario.Text = string.Empty;
            //this.txtPassword.Text = string.Empty;

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            //this.txtcod_trabajador.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cbGenero.Enabled = Valor;
            this.dtFecha_Nacimiento.Enabled = Valor;
            this.txtNum_Documento.Enabled = Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtEmail.ReadOnly = !Valor;
            //this.cbAcceso.Enabled = Valor;
            //this.txtUsuario.ReadOnly = !Valor;
            //this.txtPassword.ReadOnly = !Valor;
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnDeshacer.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnDeshacer.Enabled = false;
            }
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
     
            this.Top = 0;
            this.Left = 0; 
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //this.txtcod_trabajador.Text = string.Empty;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }


        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
           
            //this.txtcod_trabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cod_trabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.cbGenero.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["genero"].Value);
            this.dtFecha_Nacimiento.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            //this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            //this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            //this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNum_Documento.Text != "" || txtNombre.Text != "" || txtEmail.Text != "" || txtTelefono.Text != "" || txtDireccion.Text != "")
            {
                if (politcb.SelectedIndex == 0)
                {
                    con.spinsertar_per(txtNum_Documento.Text.Trim(), txtNombre.Text.Trim(), txtApellidos.Text.Trim(), dtFecha_Nacimiento.Value.Date.ToShortDateString(), int.Parse(txtTelefono.Text), txtEmail.Text.Trim(), txtDireccion.Text.Trim());
                    con.SubmitChanges();
                    //loadcode();
                    /*con.insert_trabajador(1, "Cred", "Nada", 'A');
                    con.SubmitChanges();*/
                }
                else
                {
                    con.spinsertar_per(txtNum_Documento.Text.Trim(), txtNombre.Text.Trim(), txtApellidos.Text.Trim(), dtFecha_Nacimiento.Value.Date.ToShortDateString(), int.Parse(txtTelefono.Text), txtEmail.Text.Trim(), txtDireccion.Text.Trim());
                    con.SubmitChanges();
                    /*con.insert_trabajador(cod, "Con", "Nada", 'A');
                    con.SubmitChanges();*/
                }
            }
            /*try
            {

                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty || txtNum_Documento.Text == string.Empty || txtUsuario.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidos, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {

                        Rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidos.Text.Trim().ToUpper(), cbGenero.Text,
                        dtFecha_Nacimiento.Value,
                        txtNum_Documento.Text, txtDireccion.Text,
                        txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtPassword.Text);

                    }
                    else
                    {

                        Rpta = NTrabajador.Editar(Convert.ToInt32(this.txtcod_trabajador.Text), this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidos.Text.Trim().ToUpper(), cbGenero.Text,
                        dtFecha_Nacimiento.Value,
                        txtNum_Documento.Text, txtDireccion.Text,
                        txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtPassword.Text);
                    }

                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }

                    }
                    else
                    {

                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtcod_trabajador.Text = "";

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (!this.txtcod_trabajador.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }*/
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //this.txtcod_trabajador.Text = string.Empty;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellidos.Text != "" || txtNum_Documento.Text != "" || txtDireccion.Text != ""
                )
            {
                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 181)
            {
                MenuVertical.Width = 68;
            }
            else
                MenuVertical.Width = 181;
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }
        void loadcode()
        {
            codegenerator.DataSource = con.query_persona();
            for (int i = 0; i < codegenerator.Rows.Count; i++)
            {
                cod = int.Parse(codegenerator.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellidos.Text != "" || txtNum_Documento.Text != "" || txtDireccion.Text != ""
    )
            {
                if (MessageBox.Show("¿Tiene datos sin guardar, desea salir?", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                Close();
            }
        }
    }
    }

