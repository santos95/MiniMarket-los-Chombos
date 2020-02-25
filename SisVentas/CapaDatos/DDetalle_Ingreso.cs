using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        //Variables
        private int _Cod_detalle_ingreso;
        private int _Cod_ingreso;
        private int _Cod_articulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        //Propiedades
        public int Cod_detalle_ingreso
        {
            get { return _Cod_detalle_ingreso; }
            set { _Cod_detalle_ingreso = value; }
        }


        public int Cod_ingreso
        {
            get { return _Cod_ingreso; }
            set { _Cod_ingreso = value; }
        }

        public int Cod_articulo
        {
            get { return _Cod_articulo; }
            set { _Cod_articulo = value; }
        }


        public decimal Precio_Compra
        {
            get { return _Precio_Compra; }
            set { _Precio_Compra = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }

        public int Stock_Inicial
        {
            get { return _Stock_Inicial; }
            set { _Stock_Inicial = value; }
        }


        public int Stock_Actual
        {
            get { return _Stock_Actual; }
            set { _Stock_Actual = value; }
        }

        public DateTime Fecha_Produccion
        {
            get { return _Fecha_Produccion; }
            set { _Fecha_Produccion = value; }
        }

        public DateTime Fecha_Vencimiento
        {
            get { return _Fecha_Vencimiento; }
            set { _Fecha_Vencimiento = value; }
        }
        //Constructores 
        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int cod_detalle_ingreso, int cod_ingreso,
            int cod_articulo, decimal precio_compra, decimal precio_venta,
            int stock_inicial, int stock_actual, DateTime fecha_produccion,
            DateTime fecha_vencimiento)
        {
            this.Cod_detalle_ingreso = cod_detalle_ingreso;
            this.Cod_ingreso = cod_ingreso;
            this.Cod_articulo = cod_articulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccion = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;

        }

        //Método Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_detalle_ingreso = new SqlParameter();
                ParCod_detalle_ingreso.ParameterName = "@cod_detalle_ingreso";
                ParCod_detalle_ingreso.SqlDbType = SqlDbType.Int;
                ParCod_detalle_ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCod_detalle_ingreso);

                SqlParameter ParCod_ingreso = new SqlParameter();
                ParCod_ingreso.ParameterName = "@cod_ingreso";
                ParCod_ingreso.SqlDbType = SqlDbType.Int;
                ParCod_ingreso.Value = Detalle_Ingreso.Cod_ingreso;
                SqlCmd.Parameters.Add(ParCod_ingreso);

                SqlParameter ParCod_articulo = new SqlParameter();
                ParCod_articulo.ParameterName = "@cod_articulo";
                ParCod_articulo.SqlDbType = SqlDbType.Int;
                ParCod_articulo.Value = Detalle_Ingreso.Cod_articulo;
                SqlCmd.Parameters.Add(ParCod_articulo);


                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precio_compra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precio_venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);


                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@fecha_produccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.Date;
                ParFecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter();
                ParFecha_Vencimiento.ParameterName = "@fecha_vencimiento";
                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

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
