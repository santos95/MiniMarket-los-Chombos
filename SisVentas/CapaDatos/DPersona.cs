using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPersona
    {
        private int _Cod_persona;
        private string _Cedula_ruc;
        private string _Nombre;
        private string _Apellido_sucursal;
        private string _Fechanac_fechaconstitucion;
        private int _Telefono;
        private string _Correo;
        private string _Direccion;

        public int Cod_persona
        {
            get
            {
                return _Cod_persona;
            }

            set
            {
                _Cod_persona = value;
            }
        }

        public string Cedula_ruc
        {
            get
            {
                return _Cedula_ruc;
            }

            set
            {
                _Cedula_ruc = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Apellido_sucursal
        {
            get
            {
                return _Apellido_sucursal;
            }

            set
            {
                _Apellido_sucursal = value;
            }
        }

        public string Fechanac_fechaconstitucion
        {
            get
            {
                return _Fechanac_fechaconstitucion;
            }

            set
            {
                _Fechanac_fechaconstitucion = value;
            }
        }

        public int Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return _Correo;
            }

            set
            {
                _Correo = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }
        public DPersona()
        {

        }
        public DPersona(int cod_persona, string cedula_ruc, string nombre, string apellido_sucursal,string fechanac_fechaconstitucion,
            int telefono,string correo,string direccion)
        {
            this.Cod_persona = cod_persona;
            this.Cedula_ruc = cedula_ruc;
            this.Nombre = nombre;
            this.Apellido_sucursal = apellido_sucursal;
            this.Fechanac_fechaconstitucion = fechanac_fechaconstitucion;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;
        }
    }
}
