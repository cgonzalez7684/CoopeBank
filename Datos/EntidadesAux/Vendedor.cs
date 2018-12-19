using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class Vendedor
    {

        public string COD_COMPANIA {get;set;}
        public int COD_VENDEDOR {get;set;}
        public string COD_USUARIO {get;set;}
        public string IND_ESTADO {get;set;}
        public string NOMBRE_VENDEDOR {get;set;}
        public decimal MTO_META_CAPTACION {get;set;}
        public decimal MTO_META_CREDITO {get;set;}
        public decimal MTO_META_SEGURO {get;set;}
        public string IND_ORIGEN {get;set;}
        public string TELEFONO {get;set;}
        public string FAX {get;set;}
        public string IND_FORMA_PAGO {get;set;}

        public Vendedor()
        {
         
        }

    
    }
}
