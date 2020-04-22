using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Administracion;
using CapaNegocio;
using System.Text.RegularExpressions;

namespace CapaPresentacion.Administración
{
    public partial class FrmUsuario : Form       
    {
        private int idUsuario = 0;
        //Nombre de usuario
        public string usuario;
        //Variables para control de botones de nuevo y actualizar
        private bool nuevo = false;
        private bool editar = false;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        public void Habilitar(bool valor)
        {

            this.txtObservacion.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtContraseña.ReadOnly = !valor;
            this.txtConfirmar.ReadOnly = !valor;
            this.cbRol.Enabled = valor;
            this.cbEstado.Enabled = valor;


        }

        public void Limpiar()
        {

            this.txtCodEmpleado.Clear();
            this.txtCargo.Clear();
            this.txtCodCargo.Clear();
            this.txtIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtUsuario.Clear();
            this.txtConfirmar.Clear();
            this.txtContraseña.Clear();
            this.txtRegistrado.Clear();
            this.txtObservacion.Clear();
            this.txtAutorizado.Clear();
            this.cbEstado.Text = "-Seleccione un Estado-";
            this.cbRol.SelectedIndex = 0;
            this.txtCodRol.Clear();
            

        }

        //Gestión de la habilitación de botones
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
        //Llenar cbRol
        public void LlenarRol()
        {

            cbRol.DataSource = NRol.MostrarA();
            cbRol.ValueMember = "ID";
            cbRol.DisplayMember = "Rol";

        }


        public void TotalRegistros(int registros)
        {

            this.lblTotal.Text = "Total de registros: " + Convert.ToString(registros);

        }

        public void FiltroTodos()
        {

            dataListado.DataSource = NUsuario.Mostrar();
            TotalRegistros(dataListado.Rows.Count);

        }

        public void FiltroActivos()
        {

            dataListado.DataSource = NUsuario.MostrarA();
            TotalRegistros(dataListado.Rows.Count);

        }

        public void FiltroInactivos()
        {

            dataListado.DataSource = NUsuario.MostrarI();
            TotalRegistros(dataListado.Rows.Count);

        }

        public void FiltroEmpleadaos()
        {

            dataListado.DataSource = NUsuario.MostrarEmpleados();
            TotalRegistros(dataListado.Rows.Count);

        }



        private void FrmUsuario_Load(object sender, EventArgs e)
        {

            //Definir estado de los botones y campos de texto
            this.Habilitar(false);
            Botones();
            
            //Definir índice de cbBusqueda
            cbBusqueda.SelectedIndex = 0;

            //Definir filtro
            this.rbtnCompleto.Select();

            //Llenar listado de roles
            this.LlenarRol();
            txtCodRol.Clear();

        }

        private void rbtnCompleto_CheckedChanged(object sender, EventArgs e)
        {
            FiltroTodos();
        }

        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {
            FiltroActivos();
        }

        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {
            FiltroInactivos();
        }

        private void rbtnEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            FiltroEmpleadaos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (editar)
            {

                editar = false;

            }

            //Limpiar y habilitar campos
            Limpiar();
            nuevo = true;
            rbtnEmpleados.Select();
            Botones();

            //Mensaje
            MessageBox.Show("Seleccione Empleado a asignar Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Definir  usuario registro
            txtRegistrado.Text = usuario;

            if (cbRol.SelectedIndex == 0)
                txtCodRol.Text = Convert.ToString(cbRol.SelectedValue);


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

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.txtCodRol.Text = Convert.ToString(cbRol.SelectedValue);


        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            if (nuevo)
            {

                txtCodEmpleado.Text = Convert.ToString(dataListado.CurrentRow.Cells["CodEmpleado"].Value);
                txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
                txtCodCargo.Text = Convert.ToString(dataListado.CurrentRow.Cells["CodCargo"].Value);
                txtCargo.Text = Convert.ToString(dataListado.CurrentRow.Cells["Cargo"].Value);


            }
            else if (editar)
            {
                if (rbtnCompleto.Checked || rbtnActivo.Checked || rbtnInactivo.Checked)
                {

                    idUsuario = Convert.ToInt32(dataListado.CurrentRow.Cells["CodUsuario"].Value);
                    txtCodEmpleado.Text = Convert.ToString(dataListado.CurrentRow.Cells["CodEmpleado"].Value);
                    txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                    txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                    txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
                    txtCodCargo.Text = Convert.ToString(dataListado.CurrentRow.Cells["CodCargo"].Value);
                    txtCargo.Text = Convert.ToString(dataListado.CurrentRow.Cells["Cargo"].Value);
                    txtUsuario.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre de Usuario"].Value);
                   // txtContraseña.Text = Convert.ToString(dataListado.CurrentRow.Cells["Contraseña"].Value);
                    txtRegistrado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Registrado Por"].Value);
                    txtAutorizado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Autorizado Por"].Value);
                    txtObservacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Observación"].Value);
                    cbRol.SelectedValue = Convert.ToInt32(dataListado.CurrentRow.Cells["CodRol"].Value);

                    if (Convert.ToChar(dataListado.CurrentRow.Cells["Estado"].Value) == 'A')
                        cbEstado.SelectedIndex = 0;
                    else
                        cbEstado.SelectedIndex = 1;

                }
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (nuevo)
                nuevo = false;

            editar = true;
            Botones();
            Habilitar(true);

            MessageBox.Show("Seleccione un registro para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            int errorCode = validarContraseña();



            if (txtCodEmpleado.Text != "" && txtCodRol.Text != "" && txtUsuario.Text != "" && txtContraseña.Text != ""  && txtRegistrado.Text != "")
            {
                //En caso que la contraseña cumpla los requisitos
                if (errorCode == 0)
                {
                    if (txtContraseña.Text == txtConfirmar.Text)
                    {
                        if (nuevo)
                        {

                            if (cbEstado.SelectedIndex == 0)
                            {

                                if (txtAutorizado.Text != "")
                                {

                                    rpta = NUsuario.NuevoUsuario(Convert.ToInt32(txtCodEmpleado.Text), Convert.ToInt32(txtCodRol.Text), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtRegistrado.Text.Trim(), txtAutorizado.Text.Trim(), txtObservacion.Text.Trim(), 'A');

                                }

                            }
                            else
                            {

                                rpta = NUsuario.NuevoUsuario(Convert.ToInt32(txtCodEmpleado.Text), Convert.ToInt32(txtCodRol.Text), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtRegistrado.Text.Trim(), txtAutorizado.Text.Trim(), txtObservacion.Text.Trim(), 'I');

                            }

                            nuevo = false;
                        }
                        else if (editar)
                        {

                            //se ha seleccionado usuario a actualizar
                            if (idUsuario != 0)
                            {

                                if (cbEstado.SelectedIndex == 0)
                                {

                                    rpta = NUsuario.ActualizarUsuario(idUsuario, Convert.ToInt32(txtCodRol.Text), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtAutorizado.Text.Trim(), txtObservacion.Text.Trim(), 'A');

                                }
                                else
                                {

                                    rpta = NUsuario.ActualizarUsuario(idUsuario, Convert.ToInt32(txtCodRol.Text), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtAutorizado.Text.Trim(), txtObservacion.Text.Trim(), 'I');

                                }

                            }

                        }

                        //Mostrar respuesta
                        MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //actualizar listado
                        FiltroTodos();

                        //Limpiar campos
                        Limpiar();
                        error.Clear();

                        //deshabilitar botones y campos
                        editar = false;
                        nuevo = false;
                        Habilitar(false);
                        Botones();
                    }
                    else
                    {

                        MessageBox.Show("La contraseña no coincide. Debe confirmar la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {

                    MessageBox.Show("La contraseña no cumple con los requisitos. Ingrese una nueva contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {

                //Mensaje de error por falta de campos llenados
                MessageBox.Show("Necesita ingresar datos en los campos remarcados. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                error.SetError(txtCodEmpleado, "Seleccione un empleado.");
                error.SetError(txtCodRol, "Seleccione un Rol de acceso");
                error.SetError(txtUsuario, "Ingrese un nombre de usuario");
                error.SetError(txtContraseña, "Ingrese una contraseña válida");
                
            }

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex == 0)
            {

                txtAutorizado.Text = usuario;

            }
        }

        //validar requerimientos de contraseña
        private int validarContraseña()
        {

            bool errorFlag = false;
            int errorCode = 0;

            //Longitud, número, caracteres especiales y mayúsculas
            Match matchLongitud = Regex.Match(txtContraseña.Text, @"^\w{8,20}\b");
            Match matchNumeros = Regex.Match(txtContraseña.Text, @"\d");
            Match matchEspeciales = Regex.Match(txtContraseña.Text, @"[ñÑ\-_¿.#¡]");
            Match matchMayusculas = Regex.Match(txtContraseña.Text, @"[A-Z]");

            //Si no cumple longitud mínima
            if (!matchLongitud.Success)
            {

                errorCode = 1;
                errorFlag = true;

            } //Si no cumple incorporación de al menos un número.
            else if (errorFlag || !matchNumeros.Success)
            {

                errorCode = 2;
                errorFlag = true;

            } //al menos una letra mayúscula
            else if (errorFlag || !matchMayusculas.Success)
            {

                errorCode = 3;
                errorFlag = true;

            } //al menos un caracter especial
            else if (errorFlag || !matchEspeciales.Success)
            {

                errorCode = 4;
                errorFlag = true;

            }

            return errorCode;

        }

        //Mostrar errores al definir contraseña
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

           
   
            int errorCode = validarContraseña();

            switch (errorCode)
            {

                case 1:
                    error.SetError(txtContraseña, "La contraseña debe medir entre 8 y 20 caracteres.");
                    break;
                case 2:
                    error.SetError(txtContraseña, "La contraseña debe contener al menos un número.");
                    break;
                case 3:
                    error.SetError(txtContraseña, "La contraseña debe contener al menos un caracter en mayúscula.");
                    break;
                case 4:
                    error.SetError(txtContraseña, "La contraseña debe contener al menos un caracter especial");
                    break;
                default:
                    error.Clear();
                    break;
            }

        }

        public void BuscarCodUsuario(int codUsuario, int filtro)
        {

            dataListado.DataSource = NUsuario.BuscarCodUsuario(codUsuario, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }


        public void BuscarNombreUsuario(string usuario, int filtro)
        {

            dataListado.DataSource = NUsuario.BuscarUsuario(usuario, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }

        public void BuscarUsuarioNombre(string nombre, int filtro)
        {

            dataListado.DataSource = NUsuario.BuscarUsuarioNombre(nombre, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {

                if (cbBusqueda.SelectedIndex == 0)
                {
                    if (rbtnCompleto.Checked)
                        BuscarCodUsuario(Convert.ToInt32(txtBuscar.Text), 0);
                    else if (rbtnActivo.Checked)
                        BuscarCodUsuario(Convert.ToInt32(txtBuscar.Text), 1);
                    else if (rbtnInactivo.Checked)
                        BuscarCodUsuario(Convert.ToInt32(txtBuscar.Text), 2);
                    else if (rbtnEmpleados.Checked)
                        BuscarCodUsuario(Convert.ToInt32(txtBuscar.Text), 3);
                }
                else if (cbBusqueda.SelectedIndex == 1)
                {

                    if (rbtnCompleto.Checked)
                        BuscarNombreUsuario(txtBuscar.Text, 0);
                    else if (rbtnActivo.Checked)
                        BuscarNombreUsuario(txtBuscar.Text, 1);
                    else if (rbtnInactivo.Checked)
                        BuscarNombreUsuario(txtBuscar.Text, 2);

                }
                else if (cbBusqueda.SelectedIndex == 2)
                {

                    if (rbtnCompleto.Checked)
                        BuscarUsuarioNombre(txtBuscar.Text, 0);
                    else if (rbtnActivo.Checked)
                        BuscarUsuarioNombre(txtBuscar.Text, 1);
                    else if (rbtnInactivo.Checked)
                        BuscarUsuarioNombre(txtBuscar.Text, 2);
                    else if (rbtnEmpleados.Checked)
                        BuscarUsuarioNombre(txtBuscar.Text, 3);
                }

            }
            else
            {

                if (rbtnEmpleados.Checked)
                {

                    FiltroEmpleadaos();

                }
                else if (rbtnCompleto.Checked)
                {
                    FiltroTodos();
                }
                else if (rbtnActivo.Checked)
                {
                    FiltroActivos();
                }
                else if (rbtnInactivo.Checked)
                {
                    FiltroInactivos();
                }

            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBusqueda.SelectedIndex == 0)
            {

                if (char.IsDigit(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;

            }
            else
            {

                if (char.IsLetter(e.KeyChar))
                    e.Handled = false;
                else if (char.IsSeparator(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Limpiar cuadro de búsqueda
            this.txtBuscar.Clear();


        }

        private void txtConfirmar_TextChanged(object sender, EventArgs e)
        {
            if ((txtContraseña.Text != "" && txtConfirmar.Text != "") && (txtContraseña.Text != txtConfirmar.Text) )
            {

                error.SetError(txtConfirmar, "La contraseña no coincide.");

            } 
            else
            {
                error.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (txtCodEmpleado.Text != "" && txtCodRol.Text != "" && txtUsuario.Text != "" && txtContraseña.Text != "" && txtCodCargo.Text != "" && txtRegistrado.Text != "")
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
