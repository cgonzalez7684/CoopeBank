using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.estructuras
{
    //Estructura del archivo de Pago para CGP. Creado por machaves.
  public  class datosXmlNominas
    {

      public string CodMoneda { get; set; }
      public string Servicio { get; set; }
      public string IdNegocio { get; set; }
      public string NomNegocio { get; set; }
      public string CuentaClienteOrigen { get; set; }
      public string IdDestino { get; set; }
      public string TitularServicio { get; set; }
      public string CuentaClienteDestino { get; set; }
      public string Monto { get; set; }
      public string DesGeneral { get; set; }
   
    }
}
