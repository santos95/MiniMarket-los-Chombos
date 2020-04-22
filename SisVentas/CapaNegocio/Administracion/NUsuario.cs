using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.Administracion;

namespace CapaNegocio.Administracion
{
    public class NUsuario
    {

        public static DataTable Mostrar()
        {

            return new Usuario().Mostrar();

        }

        public static DataTable MostrarA()
        {

            return new Usuario().MostrarA();

        }

        public static DataTable MostrarI()
        {

            return new Usuario().MostrarI();

        }

        public static DataTable MostrarEmpleados()
        {

            return new Usuario().MostrarEmpleados();

        }

        public static string NuevoUsuario(int codEmpleado, int codRol, string usuario, string contraseña, string registrado, string autorizado, string observacion, char estado)
        {

            Usuario U = new Usuario(codEmpleado, codRol, usuario, contraseña, registrado, autorizado, observacion, estado);

            return U.NuevoUsuario(U);

        }

        public static string ActualizarUsuario(int codUsuario, int rol, string usuario, string contraseña, string autorizado, string observacion, char estado)
        {
            Usuario U = new Usuario(codUsuario, rol, usuario, contraseña, autorizado, observacion, estado);

            return U.ActualizarUsuario(U);

        }


        public static DataTable BuscarCodUsuario(int usuario, int filtro)
        {

            return new Usuario().BuscarCodUsuario(usuario, filtro);

        }

        public static DataTable BuscarUsuario(string usuario, int filtro)
        {

            return new Usuario().BuscarUsuario(usuario, filtro);

        }

        public static DataTable BuscarUsuarioNombre(string nombre, int filtro)
        {

            return new Usuario().BuscarUsuarioNombre(nombre, filtro);

        }

    }
}
