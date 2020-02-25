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
    public partial class FrmRoles : Form
    {
        CapaDatos.ConexiondbDataContext con = new CapaDatos.ConexiondbDataContext();
        public FrmRoles()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "")
            {
                con.Insertar_roles(txt_nombre.Text.Trim(), 'A');
                con.SubmitChanges();
                MessageBox.Show("Registro Guardado con Exito");
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" || txt_observacion.Text != "")
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
