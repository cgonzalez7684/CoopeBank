using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio
{
    public class Script
    {


        public Script() { }

        public int IdScript { get; set; }
        public string NombreScripts { get; set; }
        public string Motor { get; set; }
        public int TipoBorrado { get; set; }
        public int OrdenBorrado { get; set; }
        public char AplicaMIGRACION { get; set; }
        public string NombreSp { get; set; }
        public string ImplementaScript { get; set; }
        public string dTiempoEje { get; set; }
        public string Ejecutado { get; set; }

    }

    public class CertiCredito
    {

        public string Operacion { get; set; }
        public string Linea { get; set; }
        public string Asociado { get; set; }
        public string Asociado1 { get; set; }
        public int Titulo { get; set; }
        public int id { get; set; }
    }
}

