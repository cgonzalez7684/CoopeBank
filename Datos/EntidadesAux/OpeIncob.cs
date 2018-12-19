using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class OpeIncob
    {
        public string DES_IDENTIFICACION { get; set; }
        public int COD_CLIENTE { get; set; }
        public string NOM_CLIENTE { get; set; }
        public string NUM_OPERACION { get; set; }
        public DateTime FEC_ULTPINT { get; set; }
        public decimal Saldo { get; set; }
        public int CancelarSaldo { get; set; }
    }
}
