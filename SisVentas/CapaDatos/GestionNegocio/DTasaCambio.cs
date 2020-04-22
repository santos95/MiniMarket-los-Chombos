using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;





namespace CapaDatos
{
    public class DTasaCambio
    {
        int IDtasa { get; set; }
        float ValorCambio { get; set; }
        DateTime FechaRegistro { get; set; }


        public DTasaCambio()
        {

        }

        public DTasaCambio(float valorCambio, DateTime fechaRegistro)
        {
            ValorCambio = valorCambio;
            FechaRegistro = fechaRegistro;
        }

        public DataTable Importar(string ruta)
        {
            DataTable dt = new DataTable("TasaCambio");
            OleDbConnection con;
            OleDbDataAdapter dtAdap;


            try
            {
               //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myOldExcelFile.xls;Extended Properties="Excel 8.0;HDR=YES
               //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myOldExcelFile.xls;Extended Properties="Excel 8.0;HDR=YES";
               /* con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties='Excel 12.0 xml; HDR = YES'");
               dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo]", con);
               dtAdap.Fill(dt);*/
                con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0; HDR = Yes\"");
                con.Open();

                dtAdap = new OleDbDataAdapter("SELECT * FROM  [Archivo$A1:B]", con);
                dtAdap.Fill(dt);

                con.Close();
            }
            catch 
            {

                dt = null;
                

            }

            return dt;

        }

        public string Exportar(DataTable dtTasa)
        {
            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                
                SqlBulkCopy exportar = new SqlBulkCopy(sqlCon);
                exportar.DestinationTableName= "tblTasaCambio";
                exportar.WriteToServer(dtTasa);

                rpta = "Se realizó la exportación.";
                
                /*
                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spInsertarTasa",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parFecha = new SqlParameter
                {

                    ParameterName = "@fecha",
                    DbType = DbType.Date,
                    Value = fecha

                };

                sqlCmd.Parameters.Add(parFecha);


                SqlParameter parValor = new SqlParameter
                {

                    ParameterName = "@valor",
                    DbType = DbType.Decimal,
                    Value = valor

                };

                sqlCmd.Parameters.Add(parValor);

                sqlCmd.ExecuteNonQuery();
                */
            }

            
            catch (Exception ex)
            {

                rpta = ex.ToString();

            }

            return rpta;
        }
    }
}
