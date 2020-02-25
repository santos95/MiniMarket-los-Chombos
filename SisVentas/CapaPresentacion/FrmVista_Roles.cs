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
    public partial class FrmVista_Roles : Form
    {
        CapaDatos.ConexiondbDataContext con = new CapaDatos.ConexiondbDataContext();
        public FrmVista_Roles()
        {
            InitializeComponent();
            Mostrar();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = con.query_rolacceso();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarRegistro()
        {
            this.dataListado.DataSource = con.dinamicquery_rolacceso(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
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

        private void btnDeshacer_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                Mostrar();
            }
            else
            {
                BuscarRegistro();
            }
    }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

