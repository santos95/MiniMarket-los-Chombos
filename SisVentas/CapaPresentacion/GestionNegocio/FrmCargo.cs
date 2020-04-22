using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.GestionNegocio;

namespace CapaPresentacion.GestionNegocio
{
    public partial class FrmCargo : Form
    {

        public string usuario;
        private int IdCargo = 0;
        private bool nuevo = false;
        private bool editar = false;

        public FrmCargo()
        {
            InitializeComponent();

            //set tooltips
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del rol.");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripción del rol.");
            this.ttMensaje.SetToolTip(this.txtRegistrado, "Usuario que realiza registro.");
            this.ttMensaje.SetToolTip(this.txtBuscar, "Ingrese nombre del rol a buscar.");
            this.ttMensaje.SetToolTip(btnNuevo, "Agregar nuevo rol");
            this.ttMensaje.SetToolTip(btnGuardar, "Guardar rol.");
            this.ttMensaje.SetToolTip(btnEditar, "Editar rol");
            this.ttMensaje.SetToolTip(btnDeshacer, "Deshacer editar o agregar rol.");
            this.ttMensaje.SetToolTip(btnSalir, "Cerrar catalogo.");
           
        }

        public void Botones()
        {

            if (nuevo || editar)
            {

                Habilitar(true);
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnDeshacer.Enabled = true;
                btnGuardar.Enabled = true;

            }
            else
            {

                Habilitar(false);
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnDeshacer.Enabled = false;


            }

        }


        public void Habilitar(bool valor)
        {

            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.cbEstado.Enabled = valor;

        }

        public void Limpiar()
        {

            txtNombre.Clear();
            txtDescripcion.Clear();
            txtRegistrado.Clear();
            txtAutorizado.Clear();
            cbEstado.Text = "-Seleccione un Estado-";

        }


        private void FrmCargo_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;

            //mostrar datos en la tabla, Selecciona rdButton Todos
            this.rbtnTodos.Select();

            //this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.btnAutorizar.Enabled = false;
            this.btnDesautorizar.Enabled = false;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCargo.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Limpia y habilita Campos
            Limpiar();
            nuevo = true;
            this.Botones();

            //Definir usuario registro
            txtRegistrado.Text = usuario;


        }


        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {
            this.dataListado.DataSource = NCargo.MostrarA();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {
            this.dataListado.DataSource = NCargo.MostrarI();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtBuscar.Text != "")
            {

                dataListado.DataSource = NCargo.BuscarNombre(txtBuscar.Text);
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

            }
            else
            {

                if (rbtnTodos.Checked)
                {

                    Mostrar();

                }
                else if (rbtnActivo.Checked)
                {

                    this.dataListado.DataSource = NCargo.MostrarA();
                    lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

                }
                else if (rbtnInactivo.Checked)
                {

                    this.dataListado.DataSource = NCargo.MostrarI();
                    lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

                }

            }


        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {

            nuevo = false;
            editar = false;
            Botones();
            Limpiar();
            Habilitar(false);
            error.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            

            if (txtNombre.Text != "" && txtDescripcion.Text != "")
            {

                if (nuevo)
                {
                    //Guardar nuevo registro


                    if (cbEstado.SelectedIndex == 0)
                    {

                        //obtiene la respuesta de la ejecución del procedimiento.
                        rpta = NCargo.Guardar(this.txtNombre.Text.Trim(), this.txtDescripcion.Text.Trim(), usuario.Trim(), txtAutorizado.Text, 'A');

                    }
                    else
                    {

                        //obtiene la respuesta de la ejecución del procedimiento.
                        rpta = NCargo.Guardar(this.txtNombre.Text.Trim(), this.txtDescripcion.Text.Trim(), usuario.Trim(), txtAutorizado.Text, 'I');

                    }
                    // rpta = NRol.Guardar(this.txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), usuario.Trim(), estado);

                }
                else
                {
                    //Actualizar registro
                    if (IdCargo != 0)
                    {
                        if (cbEstado.SelectedIndex == 0)
                        {

                            rpta = NCargo.Actualizar(IdCargo, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), usuario.Trim(), txtAutorizado.Text.Trim(), 'A');
                        }

                        else
                        {

                            rpta = NCargo.Actualizar(IdCargo, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), usuario.Trim(), txtAutorizado.Text.Trim(), 'I');

                        }


                    }

                }

                //Desplegue del mensaje del resultado del procedimiento
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpiar campos || actualizar listado.
                Mostrar();
                Limpiar();
                error.Clear();

                //Deshabilitar botones y campos
                nuevo = false;
                editar = false;
                Habilitar(false);
                Botones();

            }
            else
            {

                //mensaje de error por no llenar todos los campos
                MessageBox.Show("Necesita ingresar datos en los campos remarcados. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                error.SetError(txtNombre, "Ingrese el nombre del rol.");
                error.SetError(txtDescripcion, "Ingrese la descripción");

            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            char estado;

            //llenar los textbox con los datos en caso de editar
            IdCargo = Convert.ToInt32(dataListado.CurrentRow.Cells["Código"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Cargo"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Descripción"].Value);
            txtRegistrado.Text = Convert.ToString(dataListado.CurrentRow.Cells["RegistradoPor"].Value);
            txtAutorizado.Text = Convert.ToString(dataListado.CurrentRow.Cells["AutorizadoPor"].Value);
            estado = Convert.ToChar(dataListado.CurrentRow.Cells["Estado"].Value);

            if (Convert.ToChar(dataListado.CurrentRow.Cells["Estado"].Value) == 'A')
                cbEstado.SelectedIndex = 0;
            else
                cbEstado.SelectedIndex = 1;


            if (estado == 'A')
            {

                this.btnDesautorizar.Enabled = true;
                this.btnAutorizar.Enabled = false;

            }
            else
            {

                this.btnAutorizar.Enabled = true;
                this.btnDesautorizar.Enabled = false;

            }
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (MessageBox.Show("¿Desea autorizar el cargo seleccionado?", "Información",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                rpta = NCargo.Autorizar(IdCargo, usuario);

                //Desplegue del mensaje del resultado del procedimiento
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar();
                this.btnAutorizar.Enabled = false;
            }      

        }

        private void btnDesautorizar_Click(object sender, EventArgs e)
        {

            string rpta = "";

            if (MessageBox.Show("¿Desea autorizar el cargo seleccionado?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                rpta = NCargo.Desautorizar(IdCargo, usuario);

                //Desplegue del mensaje del resultado del procedimiento
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar();
                this.btnDesautorizar.Enabled = false;
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (IdCargo == 0)
            {

                MessageBox.Show("Debe seleccionar un registro para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                editar = true;
                Botones();
                Habilitar(true);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtDescripcion.Text != "")
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex == 0 && nuevo)
            {

                this.txtAutorizado.Text = usuario;

            }
            else if (cbEstado.SelectedIndex == 0 && editar && txtAutorizado.Text == "")
            {

                this.txtAutorizado.Text = usuario;

            }
            else if (cbEstado.SelectedIndex == 1 && nuevo)
            {

                this.txtAutorizado.Clear();

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                dataListado.DataSource = NCargo.BuscarNombre(txtBuscar.Text);
                lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

            }
            else
            {

                if (rbtnTodos.Checked)
                {

                    Mostrar();

                }
                else if (rbtnActivo.Checked)
                {

                    this.dataListado.DataSource = NCargo.MostrarA();
                    lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

                }
                else if (rbtnInactivo.Checked)
                {

                    this.dataListado.DataSource = NCargo.MostrarI();
                    lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);

                }

            }

        }
    }
}
