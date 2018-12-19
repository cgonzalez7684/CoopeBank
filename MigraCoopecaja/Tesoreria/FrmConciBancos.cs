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

namespace AppEscritorio.Tesoreria
{
    public partial class FrmConciBancos : Form
    {

        CapaLogica objLogica;
        MoviBanco objMoviBanco;
        List<MoviBanco> ListadoMovimientos;
        int AccionBtn;

        public FrmConciBancos()
        {
            InitializeComponent();
        }

        private void FrmConciBancos_Load(object sender, EventArgs e)
        {
            ConsultarBancos();
            ConsultarTipoMoviBanco();
            ConsultarEstadoMovimientos();
            ConsultarMovimientoBancos();
            HabilitarControles(false);
            AccionBtn = 1; //Registrar
        }


        private void ConsultarBancos()
        {
            try
            {
                objLogica = new CapaLogica();
                CmbNUM_CUENTA.DataSource = objLogica.ConsultarBancos().ToList();
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }  
        }

        private void ConsultarEstadoMovimientos()
        {
            try
            {
                objLogica = new CapaLogica();
                CmbCOD_ESTADO.DataSource = objLogica.ConsultarEstadosMovimientos().ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ConsultarTipoMoviBanco() 
        {
            try
            {
                objLogica = new CapaLogica();
                CmbTIP_MOVIM.DataSource = objLogica.ConsultarMoviBanco().ToList();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.ToString());
            }
        }

        private void ConsultarMovimientoBancos()
        {
            try
            {
                TxtBuscar.Text = string.Empty;
                objLogica = new CapaLogica();
                ListadoMovimientos = objLogica.ConsultarMovimientosBancos().ToList();
                DgMovimientos.DataSource = ListadoMovimientos;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarControles()
        {
            try
            {
                cmbCompania.Text = DgMovimientos.CurrentRow.Cells["dgCOD_COMPANIA"].Value.ToString() == "01001001" ? "Coopecaja" : "Cesantia";
                TxtBeneficiario.Text = DgMovimientos.CurrentRow.Cells["dgNOM_BENEFICIARIO"].Value.ToString();
                CmbNUM_CUENTA.SelectedValue = DgMovimientos.CurrentRow.Cells["dgNUM_CUENTA"].Value.ToString();
                CmbTIP_MOVIM.SelectedValue = DgMovimientos.CurrentRow.Cells["dgTIP_MOVIM"].Value.ToString();
                TxtNUM_MOVIM.Text = DgMovimientos.CurrentRow.Cells["dgNUM_MOVIM"].Value.ToString();
                TxtDetalle.Text = DgMovimientos.CurrentRow.Cells["dgDESCRIPCION"].Value.ToString();
                TxtMON_MOVIM.Text = DgMovimientos.CurrentRow.Cells["dgMON_MOVIM"].Value.ToString();
                DtFEC_MOVIM.Value = Convert.ToDateTime(DgMovimientos.CurrentRow.Cells["dgFEC_MOVIM"].Value.ToString());
                TxtMON_MOVIM.Text = DgMovimientos.CurrentRow.Cells["dgMON_MOVIM"].Value.ToString();
                CmbCOD_ESTADO.Text = DgMovimientos.CurrentRow.Cells["dgCOD_ESTADO"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void LimpiarControles()
        {
            try
            {
                cmbCompania.SelectedIndex = 0;
                CmbNUM_CUENTA.SelectedIndex = 0;
                CmbTIP_MOVIM.SelectedIndex = 0;
                TxtNUM_MOVIM.Text = string.Empty;
                TxtMON_MOVIM.Text = string.Empty;
                TxtBeneficiario.Text = string.Empty;
                DtFEC_MOVIM.Value = DateTime.Now;
                CmbCOD_ESTADO.SelectedIndex = 0;
                TxtDetalle.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void HabilitarControles(bool habilitar)
        {
            cmbCompania.Enabled = habilitar;
            CmbNUM_CUENTA.Enabled = habilitar;
            CmbTIP_MOVIM.Enabled = habilitar;
            TxtNUM_MOVIM.ReadOnly = !habilitar;
            TxtDetalle.ReadOnly = !habilitar;
            TxtMON_MOVIM.ReadOnly = !habilitar;
            TxtBeneficiario.ReadOnly = !habilitar;
            DtFEC_MOVIM.Enabled = habilitar;
            CmbCOD_ESTADO.Enabled = habilitar;

        }

        private void DgMovimientos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            CargarControles();
            HabilitarControles(false);
            BtnNuevo.Text = "&Nuevo";
        }

        private bool ValidarDatos()
        {
            try
            {
                bool valido = false;
                if (!TxtNUM_MOVIM.Text.Equals(string.Empty))
                {
                    valido = true;
                }

                if (!TxtBeneficiario.Text.Equals(string.Empty))
                {
                    valido = true;
                }

                if (!TxtMON_MOVIM.Text.Equals(string.Empty))
                {
                    valido = true;
                }

                if (!TxtDetalle.Text.Equals(string.Empty))
                {
                    valido = true;
                }

                if (!valido)
                {
                    MessageBox.Show(null,"Se deben registra todos los datos", "Validación de datos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

                return valido;
            }
            catch (Exception)
            {
                
                throw;
            }
        }



        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            try
            {

                if (BtnNuevo.Text == "&Nuevo")
                {
                    ConsultarMovimientoBancos();
                    LimpiarControles();
                    HabilitarControles(true);
                    CmbNUM_CUENTA.Focus();
                    AccionBtn = 1;
                    BtnNuevo.Text = "&Guardar";
                    BtnModificar.Enabled = false;
                    BtnEliminar.Enabled = false;
                    return;
                }

                if (BtnNuevo.Text == "&Guardar")
                {
                    if (!ValidarDatos())
                    {
                        return;
                    }




                    objMoviBanco = new MoviBanco();
                    objMoviBanco.COD_COMPANIA = cmbCompania.SelectedIndex == 0 ? "01001001" : "02001001";
                    objMoviBanco.NUM_CUENTA = CmbNUM_CUENTA.SelectedValue.ToString();
                    objMoviBanco.TIP_MOVIM = CmbTIP_MOVIM.SelectedValue.ToString();
                    objMoviBanco.NUM_MOVIM = TxtNUM_MOVIM.Text;
                    objMoviBanco.MON_MOVIM = Convert.ToDecimal(TxtMON_MOVIM.Text);
                    objMoviBanco.NOM_BENEFICIARIO = TxtBeneficiario.Text;
                    objMoviBanco.FEC_MOVIM = DtFEC_MOVIM.Value;
                    //objMoviBanco.COD_ESTADO = CmbCOD_ESTADO.Text == "Activo" ? "01" : "18";
                    objMoviBanco.COD_ESTADO = CmbCOD_ESTADO.SelectedValue.ToString();
                    objMoviBanco.DESCRIPCION = TxtDetalle.Text;
                    objMoviBanco.IND_DIFERENCIA = "";
                    objLogica = new CapaLogica();
                    if (AccionBtn == 2)
                    {
                        AccionBtn = 1;
                        objLogica.ActualizarMoviBanco(objMoviBanco);
                        MessageBox.Show(null, "Confirmación", "Movimiento actualizado", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        objLogica.RegistarMoviBanco(objMoviBanco);
                        MessageBox.Show(null, "Confirmación", "Movimiento registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    LimpiarControles();
                    HabilitarControles(false);
                    BtnModificar.Enabled = true;
                    BtnEliminar.Enabled = true;
                    BtnNuevo.Text = "&Nuevo";
                    ConsultarMovimientoBancos();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter))
            {

                if ((ListadoMovimientos.Count <= 0))
                {
                    return;
                }
                if (TxtBuscar.Text.Trim().Equals(string.Empty))
                {

                    DgMovimientos.DataSource = ListadoMovimientos.OrderBy(x => x.FEC_MOVIM).ToList();
                }
                else
                {
                    DgMovimientos.DataSource = ListadoMovimientos.Where(x => x.NUM_MOVIM.Trim().ToUpper().Equals(TxtBuscar.Text.ToUpper().Trim())).ToList();
                }

            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            AccionBtn = 2; //Modificar
            //HabilitarControles(true);
            CmbNUM_CUENTA.Focus();
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            cmbCompania.Enabled = false;
            CmbNUM_CUENTA.Enabled = false;
            CmbTIP_MOVIM.Enabled = false;
            TxtNUM_MOVIM.Enabled = false;
            DtFEC_MOVIM.Enabled = true;
            TxtDetalle.Enabled = true;
            TxtBeneficiario.Enabled = true;
            TxtMON_MOVIM.Enabled = true;
            CmbCOD_ESTADO.Enabled = true;
            TxtDetalle.ReadOnly = false;
            TxtBeneficiario.ReadOnly = false;
            TxtMON_MOVIM.ReadOnly = false;
            BtnNuevo.Text = "&Guardar";
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            objMoviBanco = new MoviBanco();
            objMoviBanco.COD_COMPANIA = cmbCompania.SelectedIndex == 0 ? "01001001" : "02001001";
            objMoviBanco.NUM_CUENTA = CmbNUM_CUENTA.SelectedValue.ToString();
            objMoviBanco.TIP_MOVIM = CmbTIP_MOVIM.SelectedValue.ToString();
            objMoviBanco.NUM_MOVIM = TxtNUM_MOVIM.Text;
            objMoviBanco.MON_MOVIM = Convert.ToDecimal(TxtMON_MOVIM.Text);
            objMoviBanco.NOM_BENEFICIARIO = TxtBeneficiario.Text;
            objMoviBanco.FEC_MOVIM = DtFEC_MOVIM.Value;
            //objMoviBanco.COD_ESTADO = CmbCOD_ESTADO.Text == "Activo" ? "01" : "18";
            objMoviBanco.COD_ESTADO = CmbCOD_ESTADO.SelectedValue.ToString();
            objMoviBanco.DESCRIPCION = TxtDetalle.Text;
            DialogResult rs = MessageBox.Show(null,"Esta seguro de borrar el movimiento : " + objMoviBanco.NUM_MOVIM + ", del banco seleccionado?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == System.Windows.Forms.DialogResult.Yes)
            {
                objLogica = new CapaLogica();
                objLogica.EliminarMoviBanco(objMoviBanco);
                MessageBox.Show(null, "Movimiento eliminado", "Confirmarción");
            }

            LimpiarControles();
            HabilitarControles(false);
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnNuevo.Text = "&Nuevo";
            ConsultarMovimientoBancos();
         
        }


    }
}
