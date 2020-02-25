using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public  class NArticulo
    {  //Método Insertar que llama al método Insertar de la clase DArtículo
        //de la CapaDatos
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int cod_categoria, int cod_presentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Cod_categoria = cod_categoria;
            Obj.Cod_presentacion = cod_presentacion;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArtículo
        //de la CapaDatos
        public static string Editar(int cod_articulo, string codigo, string nombre, string descripcion, byte[] imagen, int cod_categoria, int cod_presentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Cod_articulo = cod_articulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Cod_categoria = cod_categoria;
            Obj.Cod_presentacion = cod_presentacion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArtículo
        //de la CapaDatos
        public static string Eliminar(int cod_articulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Cod_articulo = cod_articulo;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArtículo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArtículo de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable Stock_Articulo()
        {
            return new DArticulo().Stock_Articulos();
        }
    }
}
