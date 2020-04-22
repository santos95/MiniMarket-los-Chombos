using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos.Administracion;
using CapaDatos;

namespace CapaNegocio
{
    public class NRol
    {

        public static DataTable Mostrar()
        {
            return new DRol().Mostrar();
        }

        public static DataTable MostrarA()
        {

            return new DRol().MostrarA();

        }

        public static DataTable MostrarI()
        {

            return new DRol().MostrarI();

        }

        public static string Guardar(string rol, string descripcion, string registrado, char estado)
        {

            DRol Rol = new DRol
            {
                Rol = rol,
                Descripcion = descripcion,
                Registrado = registrado,
                Estado = estado
            };
            return Rol.Guardar(Rol);
        
        }

        public static string Actualizar(int id, string rol, string descripcion, char estado)
        {

            DRol Rol = new DRol
            {

                IdRol = id,
                Rol = rol,
                Descripcion = descripcion,
                Estado = estado

            };

            return Rol.Actualizar(Rol);
        }

        public static DataTable BuscarNombre(String textoBuscar)
        {

            DRol Rol = new DRol();
            Rol.TextoBuscar = textoBuscar;

            return Rol.BuscarNombre(Rol);

        }
    }

    
}
