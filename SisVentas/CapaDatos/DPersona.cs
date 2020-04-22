using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPersona
    {

        public int CodPersona { get; set; }
        public char TipoPersona { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoRazon { get; set; }
        public DateTime FechaNacConst { get; set; }
        public char Genero { get; set; }
        public char EstadoCivilNat { get; set; }
        public string Direccion { get; set; }

   
 
          
        public DPersona()
        {

        }

        public DPersona(int codPersona, char tipoPersona, string tipoIdentificacion, string identificacion ,string nombre, string apellido, DateTime fechaNac, char genero, char estadoCivil, string direccion)        
        {
            CodPersona = codPersona;
            TipoPersona = tipoPersona;
            TipoIdentificacion = tipoIdentificacion;
            Identificacion = identificacion;
            Nombre = nombre;
            ApellidoRazon = apellido;
            FechaNacConst = fechaNac;
            Genero = genero;
            EstadoCivilNat = estadoCivil;
            Direccion = direccion;

        }
       
    }
}
