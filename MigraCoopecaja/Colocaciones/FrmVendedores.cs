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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace AppEscritorio.Colocaciones
{
    public partial class FrmVendedores : Form
    {
        CapaLogica objLogica;
        Vendedor objVendedor;
        char AccionBotones;
        public static UsuarioPS UsPs;
        
        private void ConsultarVendedores()
        {
            try
            {
                objLogica = new CapaLogica();
                DgVendedores.DataSource = objLogica.ConsultarVendedores().ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargaControles()
        {
            try
            {

                TxtCodVendedor.Text = DgVendedores.CurrentRow.Cells["DgCOD_VENDEDOR"].Value.ToString();
                TxtCodUsuario.Text = DgVendedores.CurrentRow.Cells["DgCOD_USUARIO"].Value.ToString();
                CmbEstado.SelectedIndex = Convert.ToInt32(DgVendedores.CurrentRow.Cells["DgIND_ESTADO"].Value) == 1 ? 0 : 1;
                TxtNombreVendedor.Text = DgVendedores.CurrentRow.Cells["DgNOMBRE_VENDEDOR"].Value.ToString();
                TxtMtoCap.Text = DgVendedores.CurrentRow.Cells["DgMTO_META_CAPTACION"].Value.ToString();
                TxtMtoCred.Text = DgVendedores.CurrentRow.Cells["DgMTO_META_CREDITO"].Value.ToString();
                TxtMtoSeg.Text = DgVendedores.CurrentRow.Cells["DgMTO_META_SEGURO"].Value.ToString();
                CmbOrigen.SelectedIndex = DgVendedores.CurrentRow.Cells["DgIND_ORIGEN"].Value.ToString() == "I" ? 0 : 1;
                TxtTelefono.Text = DgVendedores.CurrentRow.Cells["DgTELEFONO"].Value.ToString();
                TxtFax.Text = DgVendedores.CurrentRow.Cells["DgFAX"].Value.ToString();
                
                


        
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }
        
        public FrmVendedores()
        {
            InitializeComponent();
        }

        private void FrmVendedores_Load(object sender, EventArgs e)
        {
            ConsultarVendedores();
            CmbFPago.SelectedIndex = 2;
            AccionBotones = 'N';
            UsPs = new UsuarioPS();
        }

        private void DgVendedores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarControles(false);
            CargaControles();
            BtnNuevo.Text = "Nuevo";
            
        }

        private void ObjetoVendedor()
        {
            objVendedor = new Vendedor();
            objVendedor.COD_COMPANIA = "01001001";
            objVendedor.COD_USUARIO = TxtCodUsuario.Text;
            //objVendedor.COD_VENDEDOR = TxtCodVendedor.Text;
            objVendedor.FAX = TxtFax.Text;
            objVendedor.IND_ESTADO = CmbEstado.Text;
            objVendedor.IND_FORMA_PAGO = CmbFPago.Text;
            objVendedor.IND_ORIGEN = CmbOrigen.Text;
            objVendedor.MTO_META_CAPTACION = Convert.ToDecimal(TxtMtoCap.Text);
            objVendedor.MTO_META_CREDITO = Convert.ToDecimal(TxtMtoCred.Text);
            objVendedor.MTO_META_SEGURO = Convert.ToDecimal(TxtMtoSeg.Text);
            objVendedor.NOMBRE_VENDEDOR = TxtNombreVendedor.Text;
            objVendedor.TELEFONO = TxtTelefono.Text;            

        }

        private void HabilitarControles(bool Habilitar)
        {
            TxtCodUsuario.Enabled = Habilitar;
            TxtNombreVendedor.Enabled = Habilitar;
            TxtFax.Enabled = Habilitar;
            TxtTelefono.Enabled = Habilitar;
            TxtMtoCap.Enabled = Habilitar;
            TxtMtoCred.Enabled = Habilitar;
            TxtMtoSeg.Enabled = Habilitar;
            CmbEstado.Enabled = Habilitar;
            CmbFPago.Enabled = Habilitar;
            CmbOrigen.Enabled = Habilitar;
        }

    
        private void EjecutarAccion(char Tipo)
        {
            if (Tipo == 'N')
            {
                
                BtnNuevo.Text = "Guardar";
                BtnEliminar.Text = "Cancelar";
                BtnModificar.Enabled = false;
                HabilitarControles(true);
                LimpiarControles();
                return;
            }

            if (Tipo == 'G')
            {
                BtnNuevo.Text = "Nuevo";
                BtnEliminar.Text = "Eliminar";
                BtnModificar.Enabled = true;
                objLogica = new CapaLogica();
                //MessageBox.Show(objLogica.ConsultarSiguienteVendendedor().ToString());
                ObjetoVendedor();
                objVendedor.COD_VENDEDOR = objLogica.ConsultarSiguienteVendendedor()+1;
                int i = 1;
                while (i<=2)
                {
                    if (i == 1)
                    {
                        objVendedor.COD_COMPANIA = "01001001";
                    }
                    else
                    {
                        objVendedor.COD_COMPANIA = "02001001";
                    }
                    objLogica.RegistrarVendedor(objVendedor);
                    i += 1;
                }
                HabilitarControles(false);
                
                return;
            }
        }

        private void LimpiarControles()
        {
            TxtCodVendedor.Text = string.Empty;
            TxtCodUsuario.Text = string.Empty;
            TxtFax.Text = string.Empty;
            TxtMtoCap.Text = 0.00.ToString("C2");
            TxtMtoCred.Text = 0.00.ToString("C2");
            TxtMtoSeg.Text = 0.00.ToString("C2");
            TxtNombreVendedor.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            CmbEstado.SelectedIndex = 0;
            CmbFPago.SelectedIndex = 0;
            CmbOrigen.SelectedIndex = 0;

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (BtnNuevo.Text == "Nuevo")
            {
                LimpiarControles();
                FrmBuscarUsuariosPs objBuscarUsuariosPs = new FrmBuscarUsuariosPs(this.Location.X, this.Location.Y);
                //this.Opacity = 0.80;
                objBuscarUsuariosPs.Parent = objBuscarUsuariosPs.ParentForm;
                objBuscarUsuariosPs.ShowDialog(this);
                if (UsPs.COD_USUARIO.Length > 0)
                {
                    TxtCodUsuario.Text = UsPs.COD_USUARIO;
                    HabilitarControles(true);
                    BtnNuevo.Text = "Guardar";
                }
                else
                {
                    return;
                }
                AccionBotones = 'N';
                
               
                
                return;
            }

            if (BtnNuevo.Text == "Guardar")
            {
                EjecutarAccion('G');
                return;

            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void TxtMtoCap_Enter(object sender, EventArgs e)
        {
            TxtMtoCap.Text = string.Empty;
        }

        private void TxtMtoCred_Enter(object sender, EventArgs e)
        {
            TxtMtoCred.Text = string.Empty;
        }

        private void TxtMtoSeg_Enter(object sender, EventArgs e)
        {
            TxtMtoSeg.Text = string.Empty;
        }

        private void TxtMtoCap_Leave(object sender, EventArgs e)
        {
            TxtMtoCap.Text = Convert.ToDouble(TxtMtoCap.Text).ToString("C2");
        }

        private void TxtMtoCred_Leave(object sender, EventArgs e)
        {
            TxtMtoCred.Text = Convert.ToDouble(TxtMtoCred.Text).ToString("C2");
        }

        private void TxtMtoSeg_Leave(object sender, EventArgs e)
        {
            TxtMtoSeg.Text = Convert.ToDouble(TxtMtoSeg.Text).ToString("C2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionStringO = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.28.39.205)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = UATDOS)));User Id = SYS; Password = Neodesa2017;DBA Privilege=SYSDBA";
                using (OracleConnection connORA = new OracleConnection(connectionStringO))
                {
                    
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("OCX.SP_OCX_Seguro", connORA);
                    Query.CommandType = CommandType.StoredProcedure;
                    Query.CommandTimeout = 10000;
                    Query.Parameters.Add(new OracleParameter("p_des_identificacion", "103760762"));
                    Query.Parameters.Add("Salida", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataReader SqlDR = Query.ExecuteReader();


                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            
                            Console.WriteLine(SqlDR["NUM_OPERACION"].ToString());
                        }

                    }
                    else
                    {

                    }
                    SqlDR.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // this.txtNomCliente.Text = "error en la consulta";
            }

        }
    }
}
