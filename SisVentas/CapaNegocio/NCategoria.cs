using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string nombrecat, string observacion, DateTime fecharegistro)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombrecat = nombrecat;
            Obj.Observacion = observacion;
            Obj.Fecharegistro = fecharegistro;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCategoría
        //de la CapaDatos
        public static string Editar(int id_categoria, string nombrecat, string observacion, DateTime fecharegistro)
        {
            DCategoria Obj = new DCategoria();
            Obj.Id_categoria = id_categoria;
            Obj.Nombrecat = nombrecat;
            Obj.Observacion = observacion;
            Obj.Fecharegistro = fecharegistro;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int id_categoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Id_categoria = id_categoria;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static string Editar(int v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public static string Insertar(string v)
        {
            throw new NotImplementedException();
        }
    }
}
