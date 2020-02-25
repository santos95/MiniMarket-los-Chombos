using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int cod_trabajador, int cod_proveedor, DateTime fecha,
               string tipo_comprobante, string serie, string correlativo, decimal igv,
               string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Cod_trabajador = cod_trabajador;
            Obj.Cod_proveedor = cod_proveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Cod_articulo = Convert.ToInt32(row["cod_articulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Anular(int cod_ingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Cod_ingreso = cod_ingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
