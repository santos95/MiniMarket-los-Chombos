using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.GestionNegocio;

namespace CapaNegocio.GestionNegocio
{
    public class NEmpleado
    {

        public static DataTable Mostrar()
        {
            return new Empleado().Mostrar();
        }

        public static DataTable MostrarA()
        {
            return new Empleado().MostrarA();
        }

        public static DataTable MostrarI()
        {

            return new Empleado().MostrarI();

        }

        
        public static string Guardar(string tipoIdentificacion, string identificacion, string nombre, string apellido, DateTime fechaNac, char genero, char estadoCivil, string direccion, string inss, string tipoCon, string telefono, string celular, string correo, char estado, string observacion)
        {

            Empleado E = new Empleado(tipoIdentificacion, identificacion, nombre, apellido, fechaNac, genero, estadoCivil, direccion, inss, tipoCon, telefono, celular, correo, estado, observacion);

            return E.Guardar(E);

        }

        public static string Actualizar(int codEmpleado, string tipoIdentificacion, string identificacion, string nombre, string apellido, DateTime fechaNac, char genero, char estadoCivil, string direccion, string inss, string tipoCon, string telefono, string celular, string correo, char estado, string observacion)
        {

            Empleado E = new Empleado(codEmpleado, tipoIdentificacion, identificacion, nombre, apellido, fechaNac, genero, estadoCivil, direccion, inss, tipoCon, telefono, celular, correo, estado, observacion);

            return E.Actualizar(E);

        }
        public static DataTable BuscarNombre(string nombre)
        {
            return new Empleado().BuscarNombre(nombre);
        }

        public static DataTable BuscarApellido(string apellido)
        {
            return new Empleado().BuscarApellido(apellido);
        }

        public static DataTable BuscarCodigo(int numDocumento)
        {
            return new Empleado().BuscarCodigo(numDocumento);
        }

    }
}
