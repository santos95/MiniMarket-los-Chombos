using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio.GestionNegocio
{
    public class NTasaCambio
    {
        public static DataTable Importar(string ruta)
        {
           
            return  new DTasaCambio().Importar(ruta);

        }

        public string Exportar(DataTable dtTasa)
        {

            return new DTasaCambio().Exportar(dtTasa);

        }
    }
}
