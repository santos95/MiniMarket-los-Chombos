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
        private bool IsNuevo = false;
        private bool IsEditar = false;

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


        //cerrar ventana
        private void btbCerrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && txtApellido.Text == "" && txtNumIdent.Text == "" && txtCorreo.Text == "" && txtDireccion.Text == "" && txtTelefono.Text == "")
            {

                this.Close();

            }
            else if(MessageBox.Show("Posee datos sin guardar\n  ¿Desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
          
                this.Close();

            }
                
        }
    }
}
