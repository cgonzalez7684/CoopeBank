using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Datos.EntidadesAux;


namespace AppEscritorio.Colocaciones
{
    public partial class FrmBuscarOperacion : Form
    {

        CapaLogica objCapaLogica;
        List<Operacion> ListadoOperaciones;
        
       

        private void ConsultarOperacionesPS()
        {
            objCapaLogica = new CapaLogica();
            ListadoOperaciones = objCapaLogica.ConsultarOperacionesPS();
            dgOperaciones.DataSource = ListadoOperaciones.ToList();
        }
        
        public FrmBuscarOperacion()
        {
            InitializeComponent();
           
        }

        private void FrmBuscarOperacion_Load(object sender, EventArgs e)
        {
            ConsultarOperacionesPS();
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            if (TxtBuscar.Text.Length > 0 || (TxtBuscar.Text.Length > 0 && (e.KeyChar == (char)Keys.Back)))
            {
                dgOperaciones.DataSource =  ListadoOperaciones.Where(x => (x.DES_IDENTIFICACION.Trim() + x.NOM_CLIENTE.Trim() + x.NUM_OPERACION.Trim()).Trim().ToUpper().Contains(TxtBuscar.Text.ToUpper().Trim())).ToList();
            }
            else {
                dgOperaciones.DataSource = ListadoOperaciones.ToList();
            }
            
            
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
                
            //}
        }

        private void dgOperaciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            FrmAvaluos.opeNueva.COD_COMPANIA = dgOperaciones.CurrentRow.Cells["dgCOD_COMPANIA"].Value.ToString();
            FrmAvaluos.opeNueva.DES_IDENTIFICACION = dgOperaciones.CurrentRow.Cells["dgDes_Identificacion"].Value.ToString();
            FrmAvaluos.opeNueva.COD_CLIENTE = Convert.ToInt32(dgOperaciones.CurrentRow.Cells["dgCOD_CLIENTE"].Value);
            FrmAvaluos.opeNueva.NOM_CLIENTE = dgOperaciones.CurrentRow.Cells["dgNOM_CLIENTE"].Value.ToString();
            FrmAvaluos.opeNueva.NUM_OPERACION = dgOperaciones.CurrentRow.Cells["dgNUM_OPERACION"].Value.ToString();
            FrmAvaluos.opeNueva.FEC_CONSTITUCION = Convert.ToDateTime(dgOperaciones.CurrentRow.Cells["dgFEC_CONSTITUCION"].Value);
            FrmAvaluos.opeNueva.FEC_VENCIMIENTO = Convert.ToDateTime(dgOperaciones.CurrentRow.Cells["dgFEC_VENCIMIENTO"].Value);
            FrmAvaluos.opeNueva.MON_ORIGINAL = Convert.ToInt32(dgOperaciones.CurrentRow.Cells["dgMON_ORIGINAL"].Value);
            FrmAvaluos.opeNueva.SALDO = Convert.ToDecimal(dgOperaciones.CurrentRow.Cells["dgSALDO"].Value);
            FrmAvaluos.opeNueva.NUM_GARANTIA = Convert.ToDecimal(dgOperaciones.CurrentRow.Cells["dgNUM_GARANTIA"].Value);
            FrmAvaluos.opeNueva.GARANTIASIC = dgOperaciones.CurrentRow.Cells["dgGARANTIASIC"].Value.ToString();
            FrmAvaluos.opeNueva.ESTADO = dgOperaciones.CurrentRow.Cells["dgDes_Identificacion"].Value.ToString();
            Close();


        }

        private void dgOperaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
