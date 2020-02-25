using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NCliente
    { //Métodos para comunicarnos con la capa datos
        //Método Insertar que llama al método Insertar de la clase DCliente
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string genero,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Genero = genero;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int cod_cliente, string nombre, string apellidos, string genero,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Cod_cliente = cod_cliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Genero = genero;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int cod_cliente)
        {
            DCliente Obj = new DCliente();
            Obj.Cod_cliente = cod_cliente;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCLiente de la CapaDatos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarNum_Documento
        //de la clase DCliente de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
