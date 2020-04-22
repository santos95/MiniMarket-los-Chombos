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
using System.Data.OleDb;
using System.Data;

namespace CapaPresentacion.GestionNegocio
{
    public partial class FrmTasaCambio : Form
    {
        private DataTable DtTasa;

        public FrmTasaCambio()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string ruta = "";
            string nombre = "";


            try
            {
                OpenFileDialog openFile = new OpenFileDialog
                {
                    Filter = "Excel Files | *.xls",
                    Title = "Seleccione el archivo de Excel."
                };

                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (openFile.FileName.Equals("") == false)
                    {

                        ruta = openFile.FileName;
                        nombre = openFile.SafeFileName;

                    }
                        
                }

                //MessageBox.Show(ruta + nombre, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //DataTable dt = new DataTable("TasaCambio");

                /*
                DataSet ds = new DataSet();
                OleDbConnection con;
                OleDbDataAdapter dtAdap;

                try
                {
                    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties='Excel 12.0 xml; HDR = YES'
                    con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +  ruta + ";Extended Properties=\"Excel 8.0; HDR = Yes\"");
                    con.Open();

                    dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo$A1:B]", con);
                    dtAdap.Fill(ds);
                    dgvImportar.DataSource = ds.Tables[0];

                    con.Close();
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                */  

                this.DtTasa = NTasaCambio.Importar(ruta);

                dgvImportar.DataSource = DtTasa;

            }
            catch (Exception ex)
            {
                              
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


           

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            NTasaCambio ts = new NTasaCambio();


            rpta = ts.Exportar(DtTasa);


            MessageBox.Show(rpta);
      



        }
    }
}
