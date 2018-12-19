using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class Operacion
    {
        public string COD_COMPANIA { get; set; }
        public string DES_IDENTIFICACION { get; set; }
        public int COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public string NUM_OPERACION { get; set; }
        public DateTime FEC_CONSTITUCION { get; set; }
        public DateTime FEC_VENCIMIENTO { get; set; }
        public Decimal MON_ORIGINAL {get;set;}
        public Decimal SALDO {get;set;}
        public Decimal NUM_GARANTIA {get;set;}
        public string GARANTIASIC {get;set;}
        public string ESTADO {get;set;}        
    }
}
