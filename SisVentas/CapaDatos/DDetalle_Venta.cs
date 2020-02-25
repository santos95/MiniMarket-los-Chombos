using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalle_Venta
    {

        private int _Cod_detalle_venta;
        private int _Cod_venta;
        private int _Cod_detalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;
        //Propiedades
        public int Cod_detalle_venta
        {
            get { return _Cod_detalle_venta; }
            set { _Cod_detalle_venta = value; }
        }


        public int Cod_venta
        {
            get { return _Cod_venta; }
            set { _Cod_venta = value; }
        }

        public int Cod_detalle_ingreso
        {
            get { return _Cod_detalle_ingreso; }
            set { _Cod_detalle_ingreso = value; }
        }


        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }


        public decimal Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        //Constructores
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int cod_detalle_venta, int cod_venta, int cod_detalle_ingreso,
            int cantidad, decimal precio_venta, decimal descuento)
        {
            this.Cod_detalle_venta = cod_detalle_venta;
            this.Cod_venta = cod_venta;
            this.Cod_detalle_ingreso = cod_detalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
            this.Descuento = descuento;
        }

        //Método Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_detalle_Venta = new SqlParameter();
                ParCod_detalle_Venta.ParameterName = "@cod_detalle_venta";
                ParCod_detalle_Venta.SqlDbType = SqlDbType.Int;
                ParCod_detalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCod_detalle_Venta);

                SqlParameter ParCod_venta = new SqlParameter();
                ParCod_venta.ParameterName = "@cod_venta";
                ParCod_venta.SqlDbType = SqlDbType.Int;
                ParCod_venta.Value = Detalle_Venta.Cod_venta;
                SqlCmd.Parameters.Add(ParCod_venta);

                SqlParameter ParCod_detalle_ingreso = new SqlParameter();
                ParCod_detalle_ingreso.ParameterName = "@cod_detalle_ingreso";
                ParCod_detalle_ingreso.SqlDbType = SqlDbType.Int;
                ParCod_detalle_ingreso.Value = Detalle_Venta.Cod_detalle_ingreso;
                SqlCmd.Parameters.Add(ParCod_detalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = Detalle_Venta.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
    }
}
