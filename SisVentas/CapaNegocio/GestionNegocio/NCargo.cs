using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.GestionNegocio;

namespace CapaNegocio.GestionNegocio
{
    public class NCargo
    {

        public static DataTable Mostrar()
        {
            return new Cargo().Mostrar();
        }

        public static DataTable MostrarA()
        {
            return new Cargo().MostrarA();
        }

        public static DataTable MostrarI()
        {
            return new Cargo().MostrarI();
        }

        public static DataTable BuscarNombre(string cargo)
        {

            Cargo C = new Cargo();

            return C.BuscarNombre(cargo);

        }

        public static string Guardar(string nombre, string descripcion, string registrado, string autorizado, char estado)
        {

            Cargo C = new Cargo(nombre, descripcion, registrado, autorizado, estado);

            return C.Guardar(C);
            
        }

        public static string Autorizar(int id, string autorizar)
        {

            Cargo C = new Cargo(id, autorizar);

            return C.Autorizar(C);

        }

        public static string Desautorizar(int id, string autorizar)
        {

            Cargo C = new Cargo(id, autorizar);

            return C.Desautorizar(C);

        }

        public static string Actualizar(int id, string nombre, string descripcion, string registrado, string autorizado, char estado)
        {

            Cargo C = new Cargo(id, nombre, descripcion, registrado, autorizado, estado);

            return C.Actualizar(C);

        }
    }
}
