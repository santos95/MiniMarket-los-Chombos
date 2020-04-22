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
    public partial class FrmHistorialEmpleado : Form
    {
        private int idHistorial = 0;
        //Nombre de usuario
        public string usuario;
        //Variables para control de botones de nuevo y actualizar
        private bool nuevo = false;
        private bool editar = false;

        public FrmHistorialEmpleado()
        {
            InitializeComponent();

            ttMensaje.SetToolTip(rbtnEmpleados, "Listado de empleados activos con y sin cargos asignados.");
            ttMensaje.SetToolTip(rbtnCompleto, "Listado de historial completo (Activos e Inactivos)");
            ttMensaje.SetToolTip(rbtnActivo, "Listado de historial activo.");
            ttMensaje.SetToolTip(rbtnInactivo, "Listado de historial inactivo");
            ttMensaje.SetToolTip(txtBuscar, "Ingrese su búsqueda según tipo.");
            ttMensaje.SetToolTip(cbBusqueda, "Seleccione tipo de búsqueda: por código de empleado, nombre o apellido y por nombre de cargo.");
            ttMensaje.SetToolTip(txtCodEmpleado, "Al seleccionar un empleado, mostrará su código");
            ttMensaje.SetToolTip(txtIdentificacion, "Al seleccionar un empleado, mostrará su número de identificación.");
            ttMensaje.SetToolTip(txtNombre, "Al seleccionar un empleado, mostrará su nombre");
            ttMensaje.SetToolTip(txtApellido, "Al seleccionar un empleado, mostrará su apellido");
            ttMensaje.SetToolTip(txtCodCargo, "Al seleccionar un cargo, mostrará el código de cargo.");
            ttMensaje.SetToolTip(btnNuevo, "Registrar una nueva asignación de cargo");
            ttMensaje.SetToolTip(btnGuardar, "Guardar nuevo registro o actualización de un registro existente.");
            ttMensaje.SetToolTip(btnEditar, "Editar o Actualizar un registro de historial de asignación de cargo.");
            ttMensaje.SetToolTip(btnDeshacer, "Cancelar nuevo registro o edición de registro");
            ttMensaje.SetToolTip(txtRegistrado, "Nombre de usuario que realiza el registro.");
            ttMensaje.SetToolTip(txtObservacion, "Ingrese una observación respecto a la asignación (Si se actualiza o si es un registro nuevo, entre otra información.)");
            ttMensaje.SetToolTip(cbEstado, "Seleccione el estado respecto al nuevo registro u actualización de registro de historial de asignación de cargo.");
            ttMensaje.SetToolTip(txtAutorizado, "Usuario que autoriza la asignación de cargo.");


        }



        //Gestión de la habilitación de los campos
        public void Habilitar(bool valor)
        {

            this.txtObservacion.ReadOnly = !valor;
            this.cbCargo.Enabled = valor;
            this.cbEstado.Enabled = valor;

        }

        //Limpiar campos
        public void Limpiar()
        {

            this.txtCodEmpleado.Clear();
            this.txtIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.cbCargo.SelectedIndex = 0;
            this.txtCodCargo.Clear();
            this.txtRegistrado.Clear();
            this.txtObservacion.Clear();
            this.txtAutorizado.Clear();
            this.cbEstado.Text = "-Seleccione un Estado-";

        }




        //Listar elementos de datos
        private void Mostrar()
        {

            dataListado.DataSource = NHistorialEmpleado.Mostrar();
            TotalRegistros(dataListado.Rows.Count);


        }

        private void TotalRegistros(int registros)
        {

            this.lblTotal.Text = "Total de registros: " + Convert.ToString(registros);

        }

        private void LLenarCargo()
        {

            cbCargo.DataSource = NCargo.MostrarA();
            cbCargo.ValueMember = "Código";
            cbCargo.DisplayMember = "Cargo";
              

        }

        //Configurar formulario al abrir
        private void FrmHistorialEmpleado_Load(object sender, EventArgs e)
        {
            //Definir estado de los botones y campos de texto
            this.Habilitar(false);
            this.Botones();

            //Definir índice cbBusqueda
            cbBusqueda.SelectedIndex = 0;
            //definir filtro
            this.rbtnCompleto.Select();


            //Llenar cargo
            this.LLenarCargo();
            txtCodCargo.Clear();


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

        //Filtro todos
        private void rbtnCompleto_CheckedChanged(object sender, EventArgs e)
        {

            FiltroTodos();

        }

        //Filtro activos
        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {

            FiltroActivos();

        }

        //Filtro inactivos
        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {

            FiltroInactivos();

        }

        //Filtro nuevos empleados (Sin historial)
        private void rbnEmpleados_CheckedChanged(object sender, EventArgs e)
        {
            //En caso de que editar sea seleccionado evitar mostrar empleados.
            if (!editar)
                FiltroEmpleados();
            else
                rbtnCompleto.Select();

        }

        //Define el filtrado todos
        public void FiltroTodos()
        {

            dataListado.DataSource = NHistorialEmpleado.Mostrar();
            TotalRegistros(dataListado.Rows.Count);

        }

        //Define el filtrado activos
        public void FiltroActivos()
        {

            dataListado.DataSource = NHistorialEmpleado.MostrarA();
            TotalRegistros(dataListado.Rows.Count); 

        }

        //Define el filtrado inactivos
        public void FiltroInactivos()
        {

            dataListado.DataSource = NHistorialEmpleado.MostrarI();
            TotalRegistros(dataListado.Rows.Count);

        }

        //Define el filtrado por empleados sin historial
        public void FiltroEmpleados()
        {

            dataListado.DataSource = NHistorialEmpleado.MostrarNuevoEmpleado();
            TotalRegistros(dataListado.Rows.Count);

        }

        //Búsqueda por documento (Código Empleado)
        public void BuscarCodigo(int codigo, int filtro)
        {

            dataListado.DataSource = NHistorialEmpleado.BuscarCodigo(codigo, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }

        //Búsqueda por nombre de empleado
        public void BuscarNombre(string nombre, int filtro)
        {

            dataListado.DataSource = NHistorialEmpleado.BuscarNombre(nombre, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }

        //Búsqueda por apellido de empleado
        public void BuscarApellido(string apellido, int filtro)
        {

            dataListado.DataSource = NHistorialEmpleado.BuscarApellido(apellido, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }

        //Búsqueda por nombre de cargo
        public void BuscarCargo(string cargo, int filtro)
        {

            dataListado.DataSource = NHistorialEmpleado.BuscarCargo(cargo, filtro);
            TotalRegistros(dataListado.Rows.Count);

        }


        //Ejecuta la búsqueda
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                if (cbBusqueda.SelectedIndex == 0)
                {

                    if (rbtnCompleto.Checked)
                        BuscarCodigo(Convert.ToInt32(txtBuscar.Text), 0);
                    else if (rbtnActivo.Checked)
                        BuscarCodigo(Convert.ToInt32(txtBuscar.Text), 1);
                    else if (rbtnInactivo.Checked)
                        BuscarCodigo(Convert.ToInt32(txtBuscar.Text), 2);
                    else if (rbtnEmpleados.Checked)
                        BuscarCodigo(Convert.ToInt32(txtBuscar.Text), 3);

                }
                else if (cbBusqueda.SelectedIndex == 1)
                {


                    if (rbtnCompleto.Checked)
                        BuscarNombre(txtBuscar.Text, 0);
                    else if (rbtnActivo.Checked)
                        BuscarNombre(txtBuscar.Text, 1);
                    else if (rbtnInactivo.Checked)
                        BuscarNombre(txtBuscar.Text, 2);
                    else if (rbtnEmpleados.Checked)
                        BuscarNombre(txtBuscar.Text, 3);
                }
                else if (cbBusqueda.SelectedIndex == 2)
                {


                    if (rbtnCompleto.Checked)
                        BuscarApellido(txtBuscar.Text, 0);
                    else if (rbtnActivo.Checked)
                        BuscarApellido(txtBuscar.Text, 1);
                    else if (rbtnInactivo.Checked)
                        BuscarApellido(txtBuscar.Text, 2);
                    else if (rbtnEmpleados.Checked)
                        BuscarApellido(txtBuscar.Text, 3);

                }
                else if (cbBusqueda.SelectedIndex == 3)
                {


                    if (rbtnCompleto.Checked)
                        BuscarCargo(txtBuscar.Text, 0);
                    else if (rbtnActivo.Checked)
                        BuscarCargo(txtBuscar.Text, 1);
                    else if (rbtnInactivo.Checked)
                        BuscarApellido(txtBuscar.Text, 2);

                }
            }
            else
            {
                //En caso de estar vacio, define cuadro según filtro
                if (rbtnCompleto.Checked)
                    FiltroTodos();
                else if (rbtnActivo.Checked)
                    FiltroActivos();
                else if (rbtnInactivo.Checked)
                    FiltroInactivos();
                else
                    FiltroEmpleados();

            }
        }

        //Limpia txtBuscar y define filtro en caso de búsqueda por cargo
        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Limpiar cuadro de búsqueda
            this.txtBuscar.Clear();


            //deshabilitar en caso de que la búsqueda sea por cargo y se filtre por empleados
            if (cbBusqueda.SelectedIndex == 3)
            {

                if (rbtnEmpleados.Checked)
                {

                    rbtnCompleto.Select();

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

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtCodCargo.Text = Convert.ToString(cbCargo.SelectedValue);
        }

        //Seleccionar botón nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (editar)
            {

                editar = false;

            }

            //LImpia y habilita campos
            Limpiar();
            nuevo = true;
            this.Botones();

            //Mensaje
            MessageBox.Show("Seleccione Empleado a asignar cargo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Definir usuario registro
            txtRegistrado.Text = usuario;

            
            if (cbCargo.SelectedIndex == 0)
            {
                this.txtCodCargo.Text = Convert.ToString(cbCargo.SelectedValue);

            }




        }

        //Seleccionar botón deshacer
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

            if (txtCodCargo.Text != "" && txtCodEmpleado.Text != "" && txtRegistrado.Text != "")
            {

                if (nuevo)
                {
                    //recordar definir que cuando se seleccone limpie autorizado
                    if (cbEstado.SelectedIndex == 1)
                    {

                        rpta = NHistorialEmpleado.Guardar(Convert.ToInt32(txtCodEmpleado.Text), Convert.ToInt32(txtCodCargo.Text), txtRegistrado.Text.Trim(), txtObservacion.Text.Trim());
                        

                    }
                    else if (cbEstado.SelectedIndex == 0)
                    {
                        if (txtAutorizado.Text != "")
                        {

                            rpta = NHistorialEmpleado.GuardarAutorizar(Convert.ToInt32(txtCodEmpleado.Text), Convert.ToInt32(txtCodCargo.Text), txtRegistrado.Text.Trim(), txtAutorizado.Text.Trim(), txtObservacion.Text.Trim());
                            

                        }

                    }
                   
                }
                else if (editar)
                {

                    if (idHistorial != 0)
                    {

                        char estado;

                        if (cbEstado.SelectedIndex == 0)
                        {

                            estado = 'A';

                        }
                        else
                        {

                            estado = 'I';

                        }

                        rpta = NHistorialEmpleado.ActualizarHistorial(idHistorial, txtObservacion.Text.Trim(), txtAutorizado.Text.Trim(), estado);

                    }
                    else
                    {

                        MessageBox.Show("No ha seleccionado un registro para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }

                }



                //Mostrar respuesta
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualizar listado
                FiltroTodos();

                //Limpiar campos
                Limpiar();

                //Deshabilitar botones y campos
                editar = false;
                nuevo = false;
                Habilitar(false);
                Botones();



            }
            else
            {
                if (nuevo)
                {

                    MessageBox.Show("Se debe seleccionar un empleado y un cargo para realizar la asignación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error.SetError(txtCodEmpleado, "Seleccione un empleado");
                    error.SetError(txtCodCargo, "Seleccione un cargo");

                }
                else if (editar)
                {

                    MessageBox.Show("Debe seleccionar registro de historial para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }


            }



        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            if (nuevo)
            {

                if (rbtnCompleto.Checked || rbtnActivo.Checked || rbtnInactivo.Checked)
                {
                    txtCodEmpleado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Código de Empleado"].Value);
                    txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
                    txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                    txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                    txtObservacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Observación"].Value);
                }
                else
                {
                    //Agregar identificación para los otros filtros. TO DO --> Listo
                    txtCodEmpleado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Código de Empleado"].Value);
                    txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
                    txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                    txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                }

            }
            else if (editar)
            {   
              
                if (rbtnCompleto.Checked || rbtnActivo.Checked || rbtnInactivo.Checked)
                {
                    char estado;

                    idHistorial = Convert.ToInt32(dataListado.CurrentRow.Cells["NumHistorial"].Value);
                    txtCodEmpleado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Código de Empleado"].Value);
                    txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
                    txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
                    txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellido"].Value);
                    txtObservacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Observación"].Value);
                    cbCargo.SelectedValue = Convert.ToInt32(dataListado.CurrentRow.Cells["Código de Cargo"].Value);
                    txtRegistrado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Registrado Por"].Value);
                    estado = Convert.ToChar(dataListado.CurrentRow.Cells["Estado"].Value);
                    txtAutorizado.Text = Convert.ToString(dataListado.CurrentRow.Cells["Autorizado Por"].Value);

                    if (estado == 'A')
                    {

                        cbEstado.SelectedIndex = 0;

                    }
                    else
                    {

                        cbEstado.SelectedIndex = 1;

                    }


                }

            }

        }

        //Autorizar asignación durante el registro 
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbEstado.SelectedIndex == 0)
            {

                this.txtAutorizado.Text = usuario;

            }
            else
            {
                this.txtAutorizado.Clear();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (nuevo)
            {

                nuevo = false;

            }
                //Se ha seleccionado registro
                editar = true;
                Botones();
                Habilitar(true);


            if (cbCargo.SelectedIndex == 0)
            {
                this.txtCodCargo.Text = Convert.ToString(cbCargo.SelectedValue);

            }



            MessageBox.Show("Seleccione un registro para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (txtCodCargo.Text != "" && txtCodEmpleado.Text != "" && txtRegistrado.Text != "")
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
