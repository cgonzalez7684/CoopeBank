using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class CamposEnvio
    {

        public string COD_CENTRO {get;set;}
        public int ID_CAMPO { get; set; }
        public string NOM_COLUMNA {get;set;}
        public string TIP_DATO {get;set;}
        public int LON_DATO  {get;set;}
        public int NUM_ORDEN_INICIO {get;set;}
        public string VAL_DEFECTO {get;set;}
        public char RELLENO_IZQ_DER {get;set;}
        public char CARACTER_RELLENO {get;set;}

  
    }
}
