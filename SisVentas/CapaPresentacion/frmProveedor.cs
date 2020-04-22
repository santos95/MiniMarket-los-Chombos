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
    public partial class frmProveedor : Form
    {
 
        CapaDatos.ConexiondbDataContext con = new CapaDatos.ConexiondbDataContext();
        private bool IsNuevo = false;
        private bool IsEditar = false;
        int cod;
        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazonsocial_Nombre, "Ingrese Razón Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Número de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del Proveedor");
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtRazonsocial_Nombre.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtNombre.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtRazonsocial_Nombre.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            //this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            //this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        /*private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }*/

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            //this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            //this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            //this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
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
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonsocial_Nombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazonsocial_Nombre.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazonsocial_Nombre, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        /*rpta = NProveedor.Insertar(this.txtRazonsocial_Nombre.Text.Trim().ToUpper(),
                            //this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text;
                            //txtEmail.Text, txtUrl.Text);*/

                    }
                    else
                    {
                        /*rpta = NProveedor.Editar(Convert.ToInt32(this.txtNombre.Text),
                            this.txtRazonsocial_Nombre.Text.Trim().ToUpper(),
                            //this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            //txtEmail.Text, txtUrl.Text);*/
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!this.txtNombre.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtNombre.Text = string.Empty;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cod_proveedor"].Value);
            this.txtRazonsocial_Nombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razonsocial_nombre"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            //this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            //this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonsocial_Nombre.Focus();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNum_Documento.Text != "" || txtNombre.Text != "" || txtEmail.Text != "" || txtTelefono.Text != "" || txtDireccion.Text != "")
            {
                if (politcb.SelectedIndex == 0)
                {
                    con.spinsertar_per(txtNum_Documento.Text.Trim(), txtNombre.Text.Trim(), txtRazonsocial_Nombre.Text.Trim(), dateTimePicker1.Value.Date.ToShortDateString(), int.Parse(txtTelefono.Text), txtEmail.Text.Trim(), txtDireccion.Text.Trim());
                    con.SubmitChanges();
                    loadcode();
                    con.insert_proveedor(1, "Cred", "Nada", 'A');
                    con.SubmitChanges();
                }
                else
                {
                    con.spinsertar_per(txtNum_Documento.Text.Trim(), txtNombre.Text.Trim(), txtRazonsocial_Nombre.Text.Trim(), dateTimePicker1.Value.Date.ToShortDateString(), int.Parse(txtTelefono.Text), txtEmail.Text.Trim(), txtDireccion.Text.Trim());
                    con.SubmitChanges();
                    con.insert_proveedor(cod, "Con", "Nada", 'A');
                    con.SubmitChanges();
                }
            }
            else
            {
                MessageBox.Show("Registro Agregado con Exito","Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            

            /*try
            {
                string rpta = "";
                if (this.txtRazonsocial_Nombre.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazonsocial_Nombre, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazonsocial_Nombre.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text, txtUrl.Text);

                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtNombre.Text),
                            this.txtRazonsocial_Nombre.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text, txtUrl.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (!this.txtNombre.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtNombre.Text = string.Empty;
        }

        private void iconcerrar_Click_1(object sender, EventArgs e)
        {
            if (txtRazonsocial_Nombre.Text != "" || txtNum_Documento.Text != "" ||  txtDireccion.Text != ""
               || txtTelefono.Text != "" )
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
        void loadcode()
        {
            codegenerator.DataSource = con.query_persona();
            for (int i = 0; i < codegenerator.Rows.Count; i++)
            {
                cod = int.Parse(codegenerator.Rows[i].Cells[0].Value.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (txtRazonsocial_Nombre.Text != "" || txtNum_Documento.Text != "" || txtDireccion.Text != ""
   || txtTelefono.Text != "")
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
