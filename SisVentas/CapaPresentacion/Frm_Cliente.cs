using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Frm_Cliente : Form
    {

        //variables para gestionar el bloqueo de botones
        private bool nuevo = false;
        private bool editar = false;

        public Frm_Cliente()
        {
            InitializeComponent();


            //definición de los tooltips
            this.tltCliente.SetToolTip(this.cmbTipoCliente, "Seleccione el tipo de cliente.");
            this.tltCliente.SetToolTip(this.cmbGenero, "Seleccione el genero del cliente.");
            this.tltCliente.SetToolTip(this.cmbTipoIdent, "Seleccione el tipo de identificación del cliente.");
            this.tltCliente.SetToolTip(this.txtNombre, "Ingrese el nombre del cliente.");
            this.tltCliente.SetToolTip(this.txtApellido, "Ingrese los apellidos del cliente.");
            this.tltCliente.SetToolTip(this.txtDireccion, "Ingrese la dirección del cliente.");
            this.tltCliente.SetToolTip(this.txtNumIdent, "Ingrese el número de identificación del cliente.");
            this.tltCliente.SetToolTip(this.txtTelefono, "Ingrese el teléfono del cliente.");
            this.tltCliente.SetToolTip(this.txtCorreo, "Ingrese el correo del cliente.");

        }

        private void Mensaje(char tipo)
        {
            if (tipo == 'I')
            {
                MessageBox.Show("Se ha guardado el registro de forma correcta.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Error, no se ha podido guardar el registro.", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Limpiar()
        {

            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtNumIdent.Clear();
            this.txtDireccion.Clear();
            this.txtTelefono.Clear();
            this.txtCorreo.Clear();

        }

        private void Habilitar(bool valor)
        {

            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtNumIdent.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;

        }

        private void Botones()
        {

            if (this.nuevo || this.editar)
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

        private void MensajeError(string mensaje)
        {

            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //cerrar ventana
        private void btbCerrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && txtApellido.Text == "" && txtNumIdent.Text == "" && txtCorreo.Text == "" && txtDireccion.Text == "" && txtTelefono.Text == "")
            {

                this.Close();

            }
            else if (MessageBox.Show("Posee datos sin guardar\n  ¿Desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close();

            }

        }

        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipoCliente.SelectedIndex == 0)
            {

                if (this.cmbTipoIdent.Items.Contains("RUC") && this.cmbGenero.Items.Contains("Neutro"))
                {

                    this.lblApellido.Text = "Razón Social:";
                    this.cmbGenero.Enabled = false;
                    this.cmbTipoIdent.SelectedItem = "RUC";
                    this.cmbTipoIdent.Enabled = false;
                    this.cmbGenero.SelectedItem = "Neutro";
                    this.cmbGenero.Enabled = false;


                }
                else
                {

                    this.cmbTipoIdent.Items.Add("RUC");
                    this.lblApellido.Text = "Razón Social:";
                    this.cmbGenero.Items.Add("Neutro");
                    this.cmbGenero.Enabled = false;
                    this.cmbTipoIdent.SelectedItem = "RUC";
                    this.cmbTipoIdent.Enabled = false;

                }


            }
            else if (this.cmbTipoCliente.SelectedItem.ToString() == "Natural")
            {

                if (this.cmbTipoIdent.Items.Contains("RUC") && this.cmbGenero.Items.Contains("Neutro"))
                {

                    this.cmbTipoIdent.Items.Remove("RUC");
                    this.cmbGenero.Items.Remove("Neutro");

                }

                this.lblApellido.Text = "Apellido:";
                this.cmbGenero.Enabled = true;
                this.cmbTipoIdent.Enabled = true;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.nuevo = true;
            this.editar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cmbTipoCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";

                if (this.txtNombre.Text == "" || this.txtApellido.Text == "" || this.txtNumIdent.Text == "" || this.cmbGenero.Text == "" || this.cmbTipoCliente.Text == "")
                {

                    MensajeError("Debe ingresar datos en los campos marcados.");
                    errorIcon.SetError(txtNombre, "Ingrese nombre");
                    errorIcon.SetError(txtApellido, "Ingrese Apellidos");
                    errorIcon.SetError(txtNumIdent, "Ingrese número de identificación.");
                    errorIcon.SetError(cmbGenero, "Seleccione un género");
                    errorIcon.SetError(cmbTipoCliente, "Seleccione tipo de cliente");

                }
                else
                {
                    string genero, tipoCliente;
                    if (this.cmbGenero.Text == "Masculino")
                    {

                        genero = "M";

                    }
                    else if (this.cmbGenero.Text == "Femenino")
                    {

                        genero = "F";

                    }
                    else
                    {
                        genero = "N";
                    }

                    if (this.cmbTipoCliente.Text == "Jurídico")
                        tipoCliente = "JU";
                    else
                        tipoCliente = "NA";

                    //resp = NCliente.Insertar(this.txtNombre.Text, txtApellido.Text, genero, dtFechaNac.Text, tipoCliente, this.txtNumIdent.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtCorreo.Text);

                    if (resp.Equals("OK"))
                    {
                        this.Mensaje('I');

                    }
                
                }

            }
            catch
            {


            }

        }

        private void Frm_Cliente_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            // this.Botones();
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.btnDeshacer.Enabled = false;
            this.Mostrar();
            
        }

        private void Mostrar()
        {

          //  this.tblCliente.DataSource = NCliente.Mostrar();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && txtApellido.Text == "" && txtNumIdent.Text == "" && txtCorreo.Text == "" && txtDireccion.Text == "" && txtTelefono.Text == "")
            {

                this.Close();

            }
            else if (MessageBox.Show("Posee datos sin guardar\n  ¿Desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close();

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
