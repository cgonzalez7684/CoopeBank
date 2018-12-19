using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class LiqProduct
    {

        public string DES_IDENTIFICACION {get;set;}
        public Decimal MON_APLICADO {get;set;}
        public string COD_CUENTA {get;set;}
        public string COD_INVERSION {get;set;}
        public string COD_USUARIO_CARGA {get;set;}
        public DateTime ? FEC_CARGA {get;set;}
        public DateTime ? FEC_LIQUIDA {get;set;}
        public string COD_USUARIO_LIQUIDA {get;set;}
        public string COD_COMPANIA { get; set; }
        public int COD_CLIENTE { get; set; }
        public Int64 ? NUM_CONTRATO { get; set; }

    }
}
