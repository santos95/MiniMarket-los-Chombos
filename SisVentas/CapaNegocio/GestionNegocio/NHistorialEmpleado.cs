using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.GestionNegocio;
using System.Data;

namespace CapaNegocio.GestionNegocio
{
    public class NHistorialEmpleado
    {

        public static DataTable Mostrar()
        {

            return new HistorialEmpleado().Mostrar();

        }

        public static DataTable MostrarA()
        {

            return new HistorialEmpleado().MostrarA();

        }

        public static DataTable MostrarI()
        {

            return new HistorialEmpleado().MostrarI();

        }

        public static DataTable MostrarNuevoEmpleado()
        {

            return new HistorialEmpleado().MostrarNuevoEmpleado();

        }

        //Búsquedas
        public static DataTable BuscarCodigo (int codigo, int filtro)
        {

            return new HistorialEmpleado().BuscarCodigo(codigo, filtro);

        }

        public static DataTable BuscarNombre (string nombre, int filtro)
        {

            return new HistorialEmpleado().BuscarNombre(nombre, filtro);

        }

        public static DataTable BuscarApellido(string apellido, int filtro)
        {

            return new HistorialEmpleado().BuscarApellido(apellido, filtro);

        }

        public static DataTable BuscarCargo(string cargo, int filtro)
        {

            return new HistorialEmpleado().BuscarCargo(cargo, filtro);

        }

        public static string Guardar(int codEmpleado, int codCargo, string registrado, string observacion)
        {

            HistorialEmpleado HE = new HistorialEmpleado(codCargo, codEmpleado, registrado, observacion);

            return HE.GuardarSinAutorizar(HE);

        }

        public static string GuardarAutorizar(int codEmpleado, int codCargo, string registrado, string autorizado, string observacion)
        {

            HistorialEmpleado HE = new HistorialEmpleado(codCargo, codEmpleado, registrado, autorizado, observacion);

            return HE.GuardarAutorizar(HE);

        }

        public static string ActualizarHistorial(int idHistorial, string observacion, string autorizado, char estado)
        {

            HistorialEmpleado HE = new HistorialEmpleado(idHistorial, observacion, autorizado, estado);

            return HE.ActualizarHistorial(HE);

        }
    }
}
