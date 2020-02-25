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
    public partial class FrmReporteFactura : Form
    {
        private int _Cod_venta;
        public int Cod_venta
        {
            get { return _Cod_venta; }
            set { _Cod_venta = value; }
        }
        public FrmReporteFactura()
        {
            
            InitializeComponent();
        }

        private void FrmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_factura' Puede moverla o quitarla según sea necesario.

            try
            {
                this.spreporte_facturaTableAdapter.Fill(this.dsPrincipal.spreporte_factura, Cod_venta);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
