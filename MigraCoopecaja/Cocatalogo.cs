using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio
{
    public class Cocatalogo
    {
        public DateTime Corte { get; set; }
        public string ccuentaconSIC { get; set; }
        public string NumCuentaPS { get; set; }
        public string DescSic { get; set; }
        public string DescPS { get; set; }
        public decimal SaldoInicia { get; set; }
        public decimal DebeMes { get; set; }
        public decimal HaberMes { get; set; }
        public int Nivel { get; set; }
        public char TipoCuenta { get; set; }

        public Cocatalogo()
        {
            this.SaldoInicia = 0.00M;
            this.DebeMes = 0.00M;
            this.HaberMes = 0.00M;
            this.TipoCuenta = 'N';
        }
    }
}
