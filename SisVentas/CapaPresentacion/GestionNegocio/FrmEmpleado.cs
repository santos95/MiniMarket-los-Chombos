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
    public partial class FrmEmpleado : Form
    {
        //Guardar dato de empleado 
        private int IdEmpleado = 0;

        //control de agregar o actualizar registro
        private bool nuevo = false;
        private bool editar = false;

        public FrmEmpleado()
        {
            InitializeComponent();

            //Definir mensajes de ayuda para el usuario respecto a botones y campos.

            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del empleado");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese los apellidos del empleado.");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección actual del empleado.");
            this.ttMensaje.SetToolTip(this.txtBuscar, "Ingrese nombre del rol a buscar.");
            this.ttMensaje.SetToolTip(this.txtInss, "Ingrese el número de INSS");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el número de teléfono. Debe poseer 8 caracteres.");
            this.ttMensaje.SetToolTip(this.txtCelular, "Ingrese el número de Celular. Debe poseer 8 caracteres.");
            this.ttMensaje.SetToolTip(this.cbTipoIdent, "Seleccione el tipo de identificación con el que se registrará el empleado.");
            this.ttMensaje.SetToolTip(this.cbGenero, "Seleccione el género del empleado");
            this.ttMensaje.SetToolTip(this.cbEstadoCiv, "Seleccione el estado civil del empleado");
            this.ttMensaje.SetToolTip(this.cbContrato, "Seleccione el tipo de contrato");
            this.ttMensaje.SetToolTip(this.cbEstado, "Seleccione el estado actual, activo o inactivo.");
            this.ttMensaje.SetToolTip(this.cbBusqueda, "Seleccione el tipo de búsqueda que desea realizar.");
            this.ttMensaje.SetToolTip(this.txtBuscar, "Escriba su texto de búsqueda según el tipo de búsqueda seleccionado.");
            this.ttMensaje.SetToolTip(btnNuevo, "Agregar nuevo rol");
            this.ttMensaje.SetToolTip(btnGuardar, "Guardar rol.");
            this.ttMensaje.SetToolTip(btnEditar, "Editar rol");
            this.ttMensaje.SetToolTip(btnDeshacer, "Deshacer editar o agregar rol.");
            this.ttMensaje.SetToolTip(btnSalir, "Cerrar catalogo.");


        }

        //Gestión de la habilitación de los campos
        public void Habilitar(bool valor)
        {

            this.txtIdentificacion.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtInss.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCelular.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtObservacion.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbGenero.Enabled = valor;
            this.cbContrato.Enabled = valor;
            this.cbEstadoCiv.Enabled = valor;
            this.cbTipoIdent.Enabled = valor;
            this.cbEstado.Enabled = valor;


        }

        //Limpiar campos
        public void Limpiar()
        {

            this.txtIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtDireccion.Clear();
            this.txtInss.Clear();
            this.txtTelefono.Clear();
            this.txtCelular.Clear();
            this.txtCorreo.Clear();
            this.txtObservacion.Clear();
            this.cbEstado.Text = "Seleccion un Estado";
            

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

        private void TotalRegistros(int registros)
        {

            this.lblTotal.Text = "Total de registros: " + Convert.ToString(registros);

        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Listar todos los datos
        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleado.Mostrar();
            TotalRegistros(dataListado.Rows.Count);

        }

        //Configurar el formulario al abrir
        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            //listar empleados
            // Mostrar(); Redundante Revisar otros formularios.
            //definir filtro
            this.rbtnTodos.Select();

            //Definir estado de los botones y campos de texto
            this.Habilitar(false);
            this.Botones();

           

            //definir los combobox.
            this.cbTipoIdent.SelectedIndex = 0;
            this.cbGenero.SelectedIndex = 0;
            this.cbEstadoCiv.SelectedIndex = 0;
            this.cbContrato.SelectedIndex = 0;
            this.cbEstado.SelectedIndex = 0;
           
                
        }

        private void txtInss_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica que solo se introduzcan dígitos
            if (char.IsLetterOrDigit(e.KeyChar))
            {

                e.Handled = false;

            } 
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else 
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            //verifica que solo se introduzcan dígitos
            if (char.IsDigit(e.KeyChar))
            {

                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }

        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica que solo se introduzcan dígitos
            if (char.IsDigit(e.KeyChar))
            {

                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica que solo se introduzcan dígitos y letras
            if (char.IsLetterOrDigit(e.KeyChar))
            {

                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica que solo se introduzcan letras
            if (char.IsLetter(e.KeyChar))
            {

                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else if (char.IsSeparator(e.KeyChar))
            {

                e.Handled = false;

            }
            else
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica que solo se introduzcan letras
            if (char.IsLetter(e.KeyChar))
            {

                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                //permite teclas de control
                e.Handled = false;

            }
            else if (char.IsSeparator(e.KeyChar))
            {

                e.Handled = false;

            }
            else
            {
                //desactiva resto de teclas pulsadas
                e.Handled = true;

            }
        }

        //Seleccionar nuevo registro
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Limpia y habilita campos, así como botones para guardar y deshacer.
            Limpiar();
            nuevo = true;
            this.Botones();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";


            if (txtNombre.Text != "" && txtApellido.Text != "" && txtIdentificacion.Text != "" && txtDireccion.Text != "" && txtInss.Text != "")
            {

                string tipoIdent, tipoContrato;
                char genero, estadoCiv, estado;


                //Guardar nuevo registro
                if (nuevo)
                {

                    //Definir datos a guardar según la selección del ComboBox
                    if (cbTipoIdent.SelectedIndex == 0)
                        tipoIdent = "CED";
                    else
                        tipoIdent = "PAS";

                    if (cbGenero.SelectedIndex == 0)
                        genero = 'M';
                    else
                        genero = 'F';

                    if (cbEstadoCiv.SelectedIndex == 0)
                        estadoCiv = 'S';
                    else if (cbEstadoCiv.SelectedIndex == 1)
                        estadoCiv = 'C';
                    else if (cbEstadoCiv.SelectedIndex == 2)
                        estadoCiv = 'D';
                    else
                        estadoCiv = 'V';

                    if (cbContrato.SelectedIndex == 0)
                        tipoContrato = "TI";
                    else
                        tipoContrato = "TD";

                    if (cbEstado.SelectedIndex == 0)
                        estado = 'A';
                    else
                        estado = 'I';


                    //obtiene la respuesta de la ejecución del procedimiento.
                    rpta = NEmpleado.Guardar(tipoIdent, txtIdentificacion.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), this.dtFechaNac.Value, genero, estadoCiv, txtDireccion.Text.Trim(), txtInss.Text.Trim(), tipoContrato, txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtCorreo.Text.Trim(), estado, txtObservacion.Text.Trim());

                }
                else
                {
                    //actualizar datos de empleado

                    if (IdEmpleado != 0)
                    {
                        //Definir datos a guardar según la selección del ComboBox
                        if (cbTipoIdent.SelectedIndex == 0)
                            tipoIdent = "CED";
                        else
                            tipoIdent = "PAS";

                        if (cbGenero.SelectedIndex == 0)
                            genero = 'M';
                        else
                            genero = 'F';

                        if (cbEstadoCiv.SelectedIndex == 0)
                            estadoCiv = 'S';
                        else if (cbEstadoCiv.SelectedIndex == 1)
                            estadoCiv = 'C';
                        else if (cbEstadoCiv.SelectedIndex == 2)
                            estadoCiv = 'D';
                        else
                            estadoCiv = 'V';

                        if (cbContrato.SelectedIndex == 0)
                            tipoContrato = "TI";
                        else
                            tipoContrato = "TD";

                        if (cbEstado.SelectedIndex == 0)
                            estado = 'A';
                        else
                            estado = 'I';

                        //Envia datos para actualizar mediante el método Actualiazar() y guarda la respuesta.
                        rpta = NEmpleado.Actualizar(IdEmpleado, tipoIdent, txtIdentificacion.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), this.dtFechaNac.Value, genero, estadoCiv, txtDireccion.Text.Trim(), txtInss.Text.Trim(), tipoContrato, txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtCorreo.Text.Trim(), estado, txtObservacion.Text.Trim());

                    }

                }
                //Mostrar respuesta 
                MessageBox.Show(rpta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualizar listado
                Mostrar();

                //Limpiar campos
                Limpiar();

                //desactivar botones y deshabilitar campos.
                nuevo = false;
                editar = false;
                this.Habilitar(false);
                this.Botones();

            }
            else
            {

                MessageBox.Show("Debe ingresar datos en los campos remarcados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error.SetError(txtIdentificacion, "Ingrese el número de indentificación del empleado(a). Revise si lo ha ingresado correctamente.");
                error.SetError(txtNombre, "Ingrese el nombre del empleado(a).");
                error.SetError(txtApellido, "Ingrese los apellidos del empleado(a)");
                error.SetError(txtDireccion, "Ingrese la dirección del empleado(a).");
                
            }
        }

        //Definir máscara Identificación según cédula
        private void cbTipoIdent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoIdent.SelectedIndex == 0)
            {
                this.txtIdentificacion.Mask = "000-000000-0000L";
            }
        }

        //Gestión búsqueda según tipo
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.cbBusqueda.SelectedIndex == 1)
            {

                dataListado.DataSource = NEmpleado.BuscarNombre(txtBuscar.Text);
                TotalRegistros(dataListado.Rows.Count);

            }
            else if (this.cbBusqueda.SelectedIndex == 2)
            {
                dataListado.DataSource = NEmpleado.BuscarApellido(txtBuscar.Text);
                TotalRegistros(dataListado.Rows.Count);

            }
            else if (this.cbBusqueda.SelectedIndex == 0)
            {

                if (txtBuscar.Text != "")
                {

                    dataListado.DataSource = NEmpleado.BuscarCodigo(Convert.ToInt32(txtBuscar.Text));
                    TotalRegistros(dataListado.Rows.Count);

                }
                else
                {

                    Mostrar();

                }
            }
        }

        //Validar tipo de caracteres por campo
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBusqueda.SelectedIndex == 0)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if(char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {

                    e.Handled = true;

                }

            }
        }

        //Gestión de los filtros
        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {

            this.Mostrar();

        }

        private void rbtnActivo_CheckedChanged(object sender, EventArgs e)
        {

            this.dataListado.DataSource = NEmpleado.MostrarA();
            TotalRegistros(dataListado.Rows.Count);

        }

        private void rbtnInactivo_CheckedChanged(object sender, EventArgs e)
        {

            this.dataListado.DataSource = NEmpleado.MostrarI();
            TotalRegistros(dataListado.Rows.Count);

        }

        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.txtBuscar.Clear();

        }

        //Boton editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Si es 0, no se ha seleccionado níngun registro a editar.
            if (IdEmpleado == 0)
            {

                MessageBox.Show("Debe seleccionar un registro para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                //se ha seleccionado registro
                editar = true;
                Botones();
                Habilitar(true);

            }
        }

        //Boton deshacer
        private void btnDeshacer_Click(object sender, EventArgs e)
        {

            IdEmpleado = 0;
            nuevo = false;
            editar = false;
            Botones();
            Limpiar();
            Habilitar(false);
            error.Clear();

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            string tipoIdent, tipoContrato;
            char genero, estado;

            

            IdEmpleado = Convert.ToInt32(dataListado.CurrentRow.Cells["Código"].Value);
            txtIdentificacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Identificación"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["Nombre"].Value);
            txtApellido.Text = Convert.ToString(dataListado.CurrentRow.Cells["Apellidos"].Value);
            dtFechaNac.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["Fecha_Nacimiento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Dirección"].Value);
            txtInss.Text = Convert.ToString(dataListado.CurrentRow.Cells["INSS"].Value);
            txtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["Telefono"].Value);
            txtCelular.Text = Convert.ToString(dataListado.CurrentRow.Cells["Celular"].Value);
            txtCorreo.Text = Convert.ToString(dataListado.CurrentRow.Cells["Correo"].Value);
            txtObservacion.Text = Convert.ToString(dataListado.CurrentRow.Cells["Observación"].Value);

            tipoIdent = Convert.ToString(dataListado.CurrentRow.Cells["TipoIdentificación"].Value);

            if (tipoIdent == "CED")
                cbTipoIdent.SelectedIndex = 0;
            else
                cbTipoIdent.SelectedIndex = 1;

            genero = Convert.ToChar(dataListado.CurrentRow.Cells["Genero"].Value);

            if (genero == 'M')
                cbGenero.SelectedIndex = 0;
            else
                cbGenero.SelectedIndex = 1;


            if (Convert.ToChar(dataListado.CurrentRow.Cells["Estado_Civil"].Value) == 'S')
                cbEstadoCiv.SelectedIndex = 0;
            else if (Convert.ToChar(dataListado.CurrentRow.Cells["Estado_Civil"].Value) == 'C')
                cbEstadoCiv.SelectedIndex = 1;
            else if (Convert.ToChar(dataListado.CurrentRow.Cells["Estado_Civil"].Value) == 'D')
                cbEstadoCiv.SelectedIndex = 2;
            else
                cbEstadoCiv.SelectedIndex = 3;

            tipoContrato = Convert.ToString(dataListado.CurrentRow.Cells["Tipo_Contrato"].Value);

            if (tipoContrato == "TI")
                cbContrato.SelectedIndex = 0;
            else
                cbContrato.SelectedIndex = 1;

            estado = Convert.ToChar(dataListado.CurrentRow.Cells["Estado"].Value);

            if (estado == 'A')
                cbEstado.SelectedIndex = 0;
            else
                cbEstado.SelectedIndex = 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellido.Text != "" || txtDireccion.Text != "" || txtInss.Text != "" || txtTelefono.Text != "" || txtCelular.Text != "" || txtCorreo.Text != "" || txtObservacion.Text != "" )
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
