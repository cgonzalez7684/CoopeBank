using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.EntidadesAux;
using Logica;

namespace AppEscritorio.Cobros
{
    public partial class FrmCancCreditos : Form
    {
        
        List<OpeIncob> ListadoOpeIncob;
        CapaLogica objCapaLogica;
        
        public FrmCancCreditos()
        {
            InitializeComponent();
        }

        private void ConsultarCreditosIncobrables()
        {
            try
            {
                objCapaLogica = new CapaLogica();
                ListadoOpeIncob = objCapaLogica.ConsultarCreditosIncobrables();
                DgCreditosInco.DataSource = ListadoOpeIncob.ToList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CancelarOperacion()
        {
            try
            {

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmCancCreditos_Load(object sender, EventArgs e)
        {
            ConsultarCreditosIncobrables();
        }

        private void BtnCanSaldo_Click(object sender, EventArgs e)
        {
            foreach (OpeIncob item in ListadoOpeIncob)
            {
                Console.WriteLine(item.CancelarSaldo);
            }
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtBusqueda.Text.Length > 0 || (TxtBusqueda.Text.Length > 0 && (e.KeyChar == (char)Keys.Back)))
            {
                DgCreditosInco.DataSource = ListadoOpeIncob.Where(x => (x.COD_CLIENTE+x.DES_IDENTIFICACION+x.NOM_CLIENTE+x.NUM_OPERACION).Trim().ToUpper().Contains(TxtBusqueda.Text.ToUpper().Trim())).ToList();
                
            }
            else
            {
                DgCreditosInco.DataSource = ListadoOpeIncob.ToList();
            }
        }

      
    }
}
