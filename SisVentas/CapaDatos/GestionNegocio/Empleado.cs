using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.GestionNegocio
{
    public class Empleado : DPersona
    {

        private int CodEmpleado { get; set; }
        private string NumInss { get; set; }
        private string TipoContrato { get; set; }
        private string Telefono { get; set; }
        private string Celular { get; set; }
        private string Correo { get; set; }
        private DateTime FechaReg { get; set; }
        private char Estado { get; set; }
        private string Observacion { get; set; }

        public Empleado()
        {

        }

        public Empleado(string tipoIdent,  string nombre, string apellido)
        {
            this.TipoIdentificacion = TipoIdentificacion;



        }

        public Empleado (string tipoIdentificacion, string identificacion, string nombre, string apellido, DateTime fechaNac, char genero, char estadoCivil, string direccion, string inss, string tipoCon, string telefono, string celular, string correo, char estado, string observacion)
        {
            
            TipoIdentificacion = tipoIdentificacion;
            Identificacion = identificacion;
            Nombre = nombre;
            ApellidoRazon = apellido;
            FechaNacConst = fechaNac;
            Genero = genero;
            EstadoCivilNat = estadoCivil;
            Direccion = direccion;
            NumInss = inss;
            TipoContrato = tipoCon;
            Telefono = telefono;
            Celular = celular;
            Correo = correo;
            Estado = estado;
            Observacion = observacion;
            

        }

        public Empleado(int codEmpleado, string tipoIdentificacion, string identificacion, string nombre, string apellido, DateTime fechaNac, char genero, char estadoCivil, string direccion, string inss, string tipoCon, string telefono, string celular, string correo, char estado, string observacion)
        {

            CodEmpleado = codEmpleado;
            TipoIdentificacion = tipoIdentificacion;
            Identificacion = identificacion;
            Nombre = nombre;
            ApellidoRazon = apellido;
            FechaNacConst = fechaNac;
            Genero = genero;
            EstadoCivilNat = estadoCivil;
            Direccion = direccion;
            NumInss = inss;
            TipoContrato = tipoCon;
            Telefono = telefono;
            Celular = celular;
            Correo = correo;
            Estado = estado;
            Observacion = observacion;

        }


        //Mostrar todos los empleados
        public DataTable Mostrar()
        {

            DataTable dt = new DataTable("Empleados");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarEmpleado",
                    CommandType = CommandType.StoredProcedure

                };



                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dt);
            }
            catch
            {

                dt = null;

            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }

            return dt;

        }

        //Filtros
        //Mostrar empleados activos
        public DataTable MostrarA()
        {

            DataTable dtResultado = new DataTable("EmpleadosActivos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarEmpleadoA",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtResultado);

            }
            catch 
            {

                dtResultado = null;

            }

            return dtResultado;

        }

        //Listar empleados inactivos
        public DataTable MostrarI()
        {

            DataTable dtResultado = new DataTable("EmpleadosInactivos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarEmpleadoI",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dtResultado);

            }
            catch 
            {

                dtResultado = null;
                
            }

            return dtResultado;
        }

        //Búsqueda por nombre de empleado
        public DataTable BuscarNombre(string nombre)
        {

            DataTable dt = new DataTable("Empleado");

            try
            {

                SqlConnection con = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = con,
                    CommandText = "spBuscarEmpleadoNombre",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parTextoBuscar = new SqlParameter
                {

                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = nombre

                };

                cmd.Parameters.Add(parTextoBuscar);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


            }
            catch
            {
                dt = null;
            }

            return dt;
        }

        //Búsqueda por apellido de empleado
        public DataTable BuscarApellido(string apellido)
        {
            DataTable dt = new DataTable("Empleados");

            try
            {

                SqlConnection con = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = con,
                    CommandText = "spBuscarEmpleadoApellido",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parTextoBuscar = new SqlParameter
                {

                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = apellido

                };

                cmd.Parameters.Add(parTextoBuscar);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch
            {

                dt = null;

            }

            return dt;

        }

        //Búsqueda por documento o código de empleado
        public DataTable BuscarCodigo(int numDocumento)
        {
            DataTable dt = new DataTable("Empleados");

            try
            {

                SqlConnection con = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = con,
                    CommandText = "spBuscarEmpleadoCodigo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parNumDocumento = new SqlParameter
                {

                    ParameterName = "@numDocumento",
                    SqlDbType = SqlDbType.Int,
                    Value = numDocumento

                };

                cmd.Parameters.Add(parNumDocumento);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch
            {

                dt = null;

            }

            return dt;

        }

        //Almacenar nuevo registro de empleado
        public string Guardar(Empleado E)
        {

            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spGuardarEmpleado",
                    CommandType = CommandType.StoredProcedure

                };

                //definir y agregar parametros
                SqlParameter parTipoIdent = new SqlParameter
                {

                    ParameterName = "@tipoIdent",
                    SqlDbType = SqlDbType.Char,
                    Size = 3,
                    Value = E.TipoIdentificacion

                };

                sqlCmd.Parameters.Add(parTipoIdent);

                SqlParameter parIdent = new SqlParameter
                {

                    ParameterName = "@ident",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = E.Identificacion

                };

                sqlCmd.Parameters.Add(parIdent);

                SqlParameter parNombre = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = E.Nombre

                };

                sqlCmd.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter
                {

                    ParameterName = "@apellido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = E.ApellidoRazon

                };

                sqlCmd.Parameters.Add(parApellido);

                SqlParameter parFechaNac = new SqlParameter
                {

                    ParameterName = "@fechaNac",
                    SqlDbType = SqlDbType.Date,
                    Size = 40,
                    Value = E.FechaNacConst

                };

                sqlCmd.Parameters.Add(parFechaNac);

                SqlParameter parGenero = new SqlParameter
                {

                    ParameterName = "@genero",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.Genero

                };

                sqlCmd.Parameters.Add(parGenero);

                SqlParameter parEstadoCiv = new SqlParameter
                {

                    ParameterName = "@estadoCiv",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.EstadoCivilNat

                };

                sqlCmd.Parameters.Add(parEstadoCiv);

                SqlParameter parDireccion = new SqlParameter
                {

                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = E.Direccion

                };

                sqlCmd.Parameters.Add(parDireccion);

                SqlParameter parInss = new SqlParameter
                {

                    ParameterName = "@inss",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = E.NumInss

                };

                sqlCmd.Parameters.Add(parInss);

                SqlParameter parTipoCon = new SqlParameter
                {

                    ParameterName = "@tipoCon",
                    SqlDbType = SqlDbType.Char,
                    Size = 2,
                    Value = E.TipoContrato

                };

                sqlCmd.Parameters.Add(parTipoCon);

                SqlParameter parTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 12,
                    Value = E.Telefono

                };

                sqlCmd.Parameters.Add(parTelefono);

                SqlParameter parCelular = new SqlParameter
                {
                    ParameterName = "@celular",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 12,
                    Value = E.Celular

                };

                sqlCmd.Parameters.Add(parCelular);

                SqlParameter parCorreo = new SqlParameter
                {

                    ParameterName = "@correo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = E.Correo

                };

                sqlCmd.Parameters.Add(parCorreo);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = E.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output,

                };

                sqlCmd.Parameters.Add(parMensaje);

                //Ejecuta el procedimiento
                sqlCmd.ExecuteNonQuery();
                rpta = parMensaje.Value.ToString();

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            { 

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;

        }

        public string Actualizar(Empleado E)
        {

            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spActualizarEmpleado",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodEmpleado = new SqlParameter
                {

                    ParameterName = "@codEmpleado",
                    SqlDbType = SqlDbType.Int,
                    Value = E.CodEmpleado

                };

                sqlCmd.Parameters.Add(parCodEmpleado);

                SqlParameter parTipoIdent = new SqlParameter
                {

                    ParameterName = "@tipoIdent",
                    SqlDbType = SqlDbType.Char,
                    Size = 3,
                    Value = E.TipoIdentificacion

                };

                sqlCmd.Parameters.Add(parTipoIdent);

                SqlParameter parIdent = new SqlParameter
                {

                    ParameterName = "@ident",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = E.Identificacion

                };

                sqlCmd.Parameters.Add(parIdent);

                SqlParameter parNombre = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = E.Nombre

                };

                sqlCmd.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter
                {

                    ParameterName = "@apellido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = E.ApellidoRazon

                };

                sqlCmd.Parameters.Add(parApellido);

                SqlParameter parFechaNac = new SqlParameter
                {

                    ParameterName = "@fechaNac",
                    SqlDbType = SqlDbType.Date,
                    Size = 40,
                    Value = E.FechaNacConst

                };

                sqlCmd.Parameters.Add(parFechaNac);

                SqlParameter parGenero = new SqlParameter
                {

                    ParameterName = "@genero",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.Genero

                };

                sqlCmd.Parameters.Add(parGenero);

                SqlParameter parEstadoCiv = new SqlParameter
                {

                    ParameterName = "@estadoCiv",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.EstadoCivilNat

                };

                sqlCmd.Parameters.Add(parEstadoCiv);

                SqlParameter parDireccion = new SqlParameter
                {

                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = E.Direccion

                };

                sqlCmd.Parameters.Add(parDireccion);

                SqlParameter parInss = new SqlParameter
                {

                    ParameterName = "@inss",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = E.NumInss

                };

                sqlCmd.Parameters.Add(parInss);

                SqlParameter parTipoCon = new SqlParameter
                {

                    ParameterName = "@tipoCon",
                    SqlDbType = SqlDbType.Char,
                    Size = 2,
                    Value = E.TipoContrato

                };

                sqlCmd.Parameters.Add(parTipoCon);

                SqlParameter parTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 12,
                    Value = E.Telefono

                };

                sqlCmd.Parameters.Add(parTelefono);

                SqlParameter parCelular = new SqlParameter
                {
                    ParameterName = "@celular",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 12,
                    Value = E.Celular

                };

                sqlCmd.Parameters.Add(parCelular);

                SqlParameter parCorreo = new SqlParameter
                {

                    ParameterName = "@correo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = E.Correo

                };

                sqlCmd.Parameters.Add(parCorreo);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = E.Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = E.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output,

                };

                sqlCmd.Parameters.Add(parMensaje);

                sqlCmd.ExecuteNonQuery();
                rpta = parMensaje.Value.ToString();
                

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            return rpta;

        }

    }
}
