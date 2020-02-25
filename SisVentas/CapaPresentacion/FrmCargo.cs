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
    public partial class FrmCargo : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        CapaDatos.ConexiondbDataContext con = new CapaDatos.ConexiondbDataContext();
        public FrmCargo()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            this.txt_nombre.Text = string.Empty;
            this.txt_descripcion.Text = string.Empty;
            this.txt_observacion.Text = string.Empty;
        }
        private void Habilitar(bool valor)
        {
            this.txt_nombre.ReadOnly = !valor;
            this.txt_descripcion.ReadOnly = !valor;
            this.txt_observacion.ReadOnly = !valor;
        }
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
        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconcerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCargo_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Escape)
                {
                    this.Hide();
               
            }
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            FrmCargo frm = new FrmCargo();
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txt_nombre.Focus();
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" || txt_observacion.Text != ""||txt_descripcion.Text !="")
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" && txt_descripcion.Text != "" && txt_observacion.Text != "")
            {
                con.Insertar_cargo(txt_nombre.Text.Trim(), txt_descripcion.Text.Trim(), txt_observacion.Text.Trim(), 'A');
                con.SubmitChanges();
                MessageBox.Show("Registro Guardado con Exito");
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios");
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" || txt_observacion.Text != "" || txt_descripcion.Text != "")
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
