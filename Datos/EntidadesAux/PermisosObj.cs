using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.EntidadesAux
{
    public class PermisosObj
    {
            public int aIdUsuario { get; set; }
            public int aIdModulo {get;set;}
            public int aIdPantalla { get; set; }
            public string aDesModulo { get; set;}
            public int aIdSubOp { get; set; }
            public string aNomBoton { get; set; }

            public int aVisible { get; set; }
            public int aLectura { get; set; }
            public int aEscritura { get; set;}
            public int aBorrado { get; set; }

            public PermisosObj()
            {
                this.aIdPantalla = -1;
                this.aIdUsuario = -1;
            }
           
    }
}
