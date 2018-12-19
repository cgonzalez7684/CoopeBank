using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;
using Datos.EntidadesAux;

namespace AppEscritorio.Colocaciones
{
    public partial class FrmAvaluos : Form
    {
        //string cadena = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
        string CadenaSql = @"Data Source=rin\MIGRACION;Initial Catalog=TraceCore;User ID=CaseData;Password=Coopecaja1";
        List<Avaluo> ListadoAvaluos;
        char AccionBoton = 'G';
        public static Operacion opeNueva;
        Logica.CapaLogica objCapaLogica;

        Avaluo objAvaluo;

        private void RegistrarAvaluo()
        {

            if (ListadoAvaluos.Count <= 0)
            {
                return;
            }

            using (OracleConnection connORA = new OracleConnection(cadena))
            {
               
                //connORA.Open();
                //OracleCommand Query = ""


                //Query.CommandType = CommandType.Text;
                //Query.CommandTimeout = 0;
                //Query.ExecuteNonQuery();

            }


        }

        private string ConsultarOperacionSIC(string cnumoperac)
        {
            string ope = "";
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSql);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select cnumoperac from covi001..crprestamo where cnumoperac = '" + cnumoperac + "'";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                conn.Open();
                ope = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return ope;
        }

        private string ConsultaGarantiaSIC(string cnumoperac)
        {
            
            string garantia = "";
            try
            {
                SqlConnection conn = new SqlConnection(CadenaSql);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select cnumedocum from covi001..crgarafidu where cnumoperac = '" + cnumoperac.ToUpper() + "'  union Select cnumedocum from covi001..crgarantia where cnumoperac = '" + cnumoperac.ToUpper() + "'";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                conn.Open();
                garantia = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }
            
            return garantia;
        }

        private void RegistrarAvaluo2()
        {
            try
            {
                Avaluo objAvaluo = new Avaluo();
                objAvaluo.COD_COMPANIA = "01001001";
                objAvaluo.NUM_GARANTIA_MADRE = Convert.ToInt32(TxtGaranPS.Text);
                objAvaluo.FEC_AVALUO = DtFeAvaluo.Value;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ConsultarAvaluos()
        {
            try
            {
                using (OracleConnection connORA = new OracleConnection(cadena))
            {
                DataTable dt = new DataTable();
                OracleDataReader dr;
                connORA.Open();
                OracleCommand Query = new OracleCommand("SELECT  B.COD_COMPANIA,B.NUM_OPERACION,A.NUM_GARANTIA, to_Date(C.FEC_AVALUO) FEC_AVALUO,C.NUM_PERITO,TBLPERITO.NOM_PROFESIONAL," +
                                                          "NVL(C.MON_AVALUO,0),NVL(C.MON_TERRENO,0),NVL(C.MON_CONSTRUCCION,0),NVL(C.MON_VEHICULO,0),C.ESTADO,C.GENREG,NVL(C.COD_TIPOBIEN,'999') COD_TIPOBIEN,C.IND_BIENADJUDICADO " +
                                                          "FROM CREDITO.CR_GARANTIA_SOLICITUD A JOIN CREDITO.CR_OPERACIONES B ON A.NUM_SOLICITUD = B.NUM_SOLICITUD " +
                                                          "JOIN CREDITO.CR_AVALUOS_MAD C ON C.NUM_GARANTIA_MADRE = A.NUM_GARANTIA " +
                                                          "JOIN (SELECT COD_PROFESIONAL,NOM_PROFESIONAL FROM CREDITO.CR_PROFESIONALES where COD_COMPANIA = '01001001') TBLPERITO on  C.NUM_PERITO = TBLPERITO.COD_PROFESIONAL", connORA);
                               
        
        
                Query.CommandType = CommandType.Text;
                Query.CommandTimeout = 0;
                Query.ExecuteNonQuery();
                OracleDataAdapter adp = new OracleDataAdapter(Query);
                dr = Query.ExecuteReader();

                ListadoAvaluos = new List<Avaluo>();
                while (dr.Read())
                {
                    Avaluo objAvaluo = new Avaluo();
                    objAvaluo.COD_COMPANIA = dr.GetString(0);
                    objAvaluo.NUM_OPERACION = dr.GetString(1);
                    objAvaluo.NUM_GARANTIA_MADRE = Convert.ToInt32(dr.GetDecimal(2));
                    objAvaluo.CNUMEDOCUM = ConsultaGarantiaSIC(objAvaluo.NUM_OPERACION);
                    objAvaluo.FEC_AVALUO = dr.GetDateTime(3);
                    objAvaluo.NUM_PERITO = dr.GetString(4);
                    objAvaluo.NOM_PROFESIONAL = dr.GetString(5);
                    objAvaluo.MON_AVALUO = dr.GetDecimal(6);
                    objAvaluo.MON_TERRENO = dr.GetDecimal(7);
                    objAvaluo.MON_CONSTRUCCION = dr.GetDecimal(8);
                    objAvaluo.MON_VEHICULO = dr.GetDecimal(9);
                    objAvaluo.ESTADO = dr.GetString(10);
                    objAvaluo.GENREG = dr.GetString(11);
                    objAvaluo.COD_TIPOBIEN = dr.GetString(12);
                    objAvaluo.IND_BIENADJUDICADO = dr.GetString(13);
                    ListadoAvaluos.Add(objAvaluo);

                }

                //Query.ExecuteNonQuery();
                //adp.Fill(dt);
                DgAvaluos.DataSource = ListadoAvaluos;


                              
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void Limpiar()
        {
            TxtOperacion.Text = "";
            TxtGaranPS.Text = "";
            TxtGaranSIC.Text = "";
            TxtMntAvaluo.Text = "";
            TxtMntConst.Text = "";
            TxtMntTerreno.Text = "";
            CmbTipoBien.SelectedIndex = 0;
            CmbEstado.SelectedIndex = 0;
            CmbGene.SelectedIndex = 0;
            CmbBinAdj.SelectedIndex = 0;

          
        }
        
        
        private string ConsultarGarantiaPS(string NUM_OPERACION)
        {
            string operacion = "";
            try
            {
                using (OracleConnection connORA = new OracleConnection(cadena))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("Select NUM_GARANTIA FROM CREDITO.CR_GARANTIA_SOLICITUD A JOIN CREDITO.CR_OPERACIONES B ON A.NUM_SOLICITUD = B.NUM_SOLICITUD  WHERE B.NUM_OPERACION = '" + NUM_OPERACION + "'", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 0;
                    operacion = Convert.ToString(Query.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            return operacion;

            
 
           
        }


        private void ConsultaProfesionales()
        {
            using (OracleConnection connORA = new OracleConnection(cadena))
            {
                DataTable dt = new DataTable();
                connORA.Open();
                OracleCommand Query = new OracleCommand("SELECT distinct COD_PROFESIONAL,NOM_PROFESIONAL FROM CREDITO.CR_PROFESIONALES order by COD_PROFESIONAL ASC", connORA);
                Query.CommandType = CommandType.Text;
                Query.CommandTimeout = 0;
                Query.ExecuteNonQuery();
                OracleDataAdapter adp = new OracleDataAdapter(Query);
                Query.ExecuteNonQuery();
                adp.Fill(dt);
                CmbProfesional.DataSource = dt;
                CmbProfesional.ValueMember = "COD_PROFESIONAL";
                CmbProfesional.DisplayMember = "NOM_PROFESIONAL";
                CmbProfesional.SelectedIndex = 0;
            }

        }

        private void ConsultaTipoBienes()
        {
            using (OracleConnection connORA = new OracleConnection(cadena))
            {
                DataTable dt = new DataTable();
                connORA.Open();
                OracleCommand Query = new OracleCommand("Select cast(COD_BIEN as integer) COD_BIEN,DES_BIEN from CREDITO.CR_TIPOS_BIENES UNION Select 999,'N/R'from DUAL", connORA);
                Query.CommandType = CommandType.Text;
                Query.CommandTimeout = 0;
                Query.ExecuteNonQuery();
                OracleDataAdapter adp = new OracleDataAdapter(Query);
                Query.ExecuteNonQuery();
                adp.Fill(dt);
                CmbTipoBien.DataSource = dt;
                CmbTipoBien.ValueMember = "COD_BIEN";
                CmbTipoBien.DisplayMember = "DES_BIEN";
                CmbTipoBien.SelectedIndex = 0;                
            }

        }

        private void LimpiarControles()
        {
         
            TxtOperacion.Text = string.Empty;
            TxtGaranSIC.Text = string.Empty;
            TxtGaranPS.Text = string.Empty;
            TxtMntAvaluo.Text = string.Empty;
            TxtMntConst.Text = string.Empty;
            TxtMntTerreno.Text = string.Empty;
            CmbBinAdj.SelectedIndex = 0;
            CmbTipoBien.SelectedValue = "999";
            CmbProfesional.SelectedIndex = 0;
            CmbGene.SelectedIndex = 0;
            
        }

        private void SoloLectura(bool bandera)
        {
            TxtOperacion.ReadOnly = bandera;
            CmbTipoBien.Enabled = !bandera;
            DtFeAvaluo.Enabled = !bandera;
            //TxtProfesional.ReadOnly = bandera;
            TxtMntAvaluo.ReadOnly = bandera;
            TxtMntTerreno.ReadOnly = bandera;
            TxtMntConst.ReadOnly = bandera;
            CmbEstado.Enabled = !bandera;
            CmbGene.Enabled = !bandera;
            CmbBinAdj.Enabled = !bandera;
            CmbProfesional.Enabled = !bandera;

           
        }
        
        public FrmAvaluos()
        {
            InitializeComponent();
        }

        private void FrmAvaluos_Load(object sender, EventArgs e)
        {
            AccionBoton = 'G'; //se inicializa la accion de los botones, este representa que no hay ninguno activado
            ConsultaTipoBienes();
            ConsultarAvaluos();
            ConsultaProfesionales();
            CmbTipoBien.SelectedIndex = 0;
            CmbProfesional.SelectedIndex = 0;
            CmbGene.SelectedIndex = 0;
            CmbEstado.SelectedIndex = 0;
            CmbBinAdj.SelectedIndex = 0;
            DgAvaluos.Focus();
            SoloLectura(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void DgAvaluos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TxtOperacion.Text = DgAvaluos.CurrentRow.Cells["DgOperacion"].Value.ToString();
            TxtGaranPS.Text = DgAvaluos.CurrentRow.Cells["DgGarantiaPS"].Value.ToString();
            TxtGaranSIC.Text = DgAvaluos.CurrentRow.Cells["DgGarantiaSIC"].Value.ToString();
            DtFeAvaluo.Value = Convert.ToDateTime(DgAvaluos.CurrentRow.Cells["DgFechaAvaluo"].Value);
           // TxtProfesional.Text = DgAvaluos.CurrentRow.Cells["DgProfesional"].Value.ToString();
            TxtMntAvaluo.Text = DgAvaluos.CurrentRow.Cells["DgMntAvaluo"].Value.ToString();
            TxtMntTerreno.Text = DgAvaluos.CurrentRow.Cells["DgMntTerreno"].Value.ToString();
            TxtMntConst.Text = DgAvaluos.CurrentRow.Cells["DgMntConstr"].Value.ToString();
            CmbEstado.SelectedIndex = DgAvaluos.CurrentRow.Cells["DgEstado"].Value.ToString().Equals("A") ? 0 : 1;
            CmbGene.SelectedIndex = DgAvaluos.CurrentRow.Cells["DgGenReg"].Value.ToString().Equals("M") ? 0 : 1;
            Console.Write(DgAvaluos.CurrentRow.Cells["DgTipoBien"].Value.ToString());
            CmbTipoBien.SelectedValue = Convert.ToInt32(DgAvaluos.CurrentRow.Cells["DgTipoBien"].Value.ToString());
            CmbBinAdj.SelectedIndex = DgAvaluos.CurrentRow.Cells["DgAdjudicado"].Value.ToString().Equals("S") ? 0 : 1;
            CmbProfesional.SelectedValue = DgAvaluos.CurrentRow.Cells["DgNum_Perito"].Value.ToString();
            
        }

        private void CargarObjAvaluo()
        {
            try
            {
                objAvaluo = new Avaluo();
                if (AccionBoton == 'E')
                {
                    objAvaluo.NUM_GARANTIA_MADRE = Convert.ToInt32(DgAvaluos.CurrentRow.Cells["DgGarantiaPS"].Value.ToString());
                    return;
                }

                if (AccionBoton == 'M')
                {
                    objAvaluo.COD_COMPANIA = DgAvaluos.CurrentRow.Cells["DgCompania"].Value.ToString();
                    objAvaluo.NUM_GARANTIA_MADRE = Convert.ToInt32(DgAvaluos.CurrentRow.Cells["DgGarantiaPS"].Value.ToString());
                }
                else
                {
                    objAvaluo.COD_COMPANIA = opeNueva.COD_COMPANIA;
                    objAvaluo.NUM_GARANTIA_MADRE = Convert.ToInt32(opeNueva.NUM_GARANTIA);
                }
                
                objAvaluo.FEC_AVALUO = DtFeAvaluo.Value;
                objAvaluo.NUM_PERITO = CmbProfesional.SelectedValue.ToString();
                objAvaluo.MON_AVALUO = Convert.ToDecimal(TxtMntAvaluo.Text);
                objAvaluo.MON_TERRENO = Convert.ToDecimal(TxtMntTerreno.Text);
                objAvaluo.MON_CONSTRUCCION = Convert.ToDecimal(TxtMntConst.Text);
                objAvaluo.MON_VEHICULO = 0.00M;
                objAvaluo.ESTADO = CmbEstado.Text.Equals("Activo") ? "A" : "R";
                objAvaluo.GENREG = CmbGene.Text.Equals("Manual") ? "M" : "K";
                objAvaluo.COD_TIPOBIEN = "00"+CmbTipoBien.SelectedValue.ToString();
                objAvaluo.IND_BIENADJUDICADO = CmbBinAdj.Text.Equals("SI") ? "S" : "N";
            }
            catch (Exception ex)
            {

                throw new Exception("Faltan datos por establecer");
            }
           
        
        }

        private void EjecutarAccion(char Tipo)
        {
            if (Tipo == 'C')
            {
                ConsultaTipoBienes();
                ConsultarAvaluos();
                ConsultaProfesionales();
                CmbTipoBien.SelectedIndex = 0;
                CmbProfesional.SelectedIndex = 0;
                CmbGene.SelectedIndex = 0;
                CmbEstado.SelectedIndex = 0;
                CmbBinAdj.SelectedIndex = 0;
                DgAvaluos.Focus();
                SoloLectura(true);
                button3.Text = "Eliminar";
                button2.Enabled = true;
                button1.Text = "Nuevo";
                AccionBoton = 'G';
                return;
            }
            if (Tipo == 'M')
            {
                BtnBusOpe.Visible = false;
                button2.Enabled = false;
                button3.Text = "Cancelar";
                SoloLectura(false);
                button1.Text = "Guardar";
                return;
            }
            
            if (Tipo == 'N')
            {
                BtnBusOpe.Visible = true;
                LimpiarControles();
                button1.Text = "Guardar";
                button3.Text = "Cancelar";
                button2.Enabled = false;
                return;
            }

            if (Tipo == 'E')
            {
                DialogResult dr = MessageBox.Show(null, "Confirmación de borrado del Avaluo: " + DgAvaluos.CurrentRow.Cells["DgGarantiaPS"].Value.ToString()+ "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CargarObjAvaluo();
                    objCapaLogica = new Logica.CapaLogica();
                    objCapaLogica.EliminarAvaluo(objAvaluo);
                    ConsultarAvaluos();
                    AccionBoton = 'G';
                }
                return;
            }

            if (Tipo == 'G')
            {
                string Accion = "Registro exitoso ";
                DialogResult dr = MessageBox.Show(null, "Realizar confimación de gestión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CargarObjAvaluo();
                    objCapaLogica = new Logica.CapaLogica();
                    if (AccionBoton == 'M')
                    {
                        Accion = "Modificación exitosa ";
                        objCapaLogica.ModificarAvaluo(objAvaluo);
                    }
                    else
                    {
                        objCapaLogica.RegistrarAvaluo(objAvaluo);
                    }
                   
                    ConsultarAvaluos();
                    SoloLectura(true);
                    button1.Text = "Nuevo";
                    BtnBusOpe.Visible = false;
                    button3.Text = "Eliminar";
                    button2.Enabled = true;
                    AccionBoton = 'G';
                }
                MessageBox.Show(null, Accion+"de avaluo para garantia", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

         

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "Nuevo")
                {
                    AccionBoton = 'G';
                    EjecutarAccion('N');
                    BtnBusOpe.PerformClick();
                    
                    return;
                }

                if (button1.Text == "Guardar")
                {
                    EjecutarAccion('G');
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(null, "Se presento un error registrando el avaluo ["+ex.Message+"]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


            
        }

        private void TxtOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) && AccionBoton.Equals('N'))
            {
                
                Avaluo aux = ListadoAvaluos.Where(x => x.NUM_OPERACION.ToUpper().Equals(TxtOperacion.Text.ToUpper())).FirstOrDefault() ;
                if (aux != null)
                {
                    MessageBox.Show("Esta Operación ya se encuentra registrada, solo puede modificarla o eliminarla.");
                    return;
                }

                if (ConsultarOperacionSIC(TxtOperacion.Text.ToUpper().Trim()).Length<=0)
                {
                    MessageBox.Show("La operación consultada no se encuentra registra en el sistema SIC, debe estar registrada para poder registrala en PSBANK");
                    return;
                }    
           
               

                if (ConsultarGarantiaPS(TxtOperacion.Text.ToUpper().Trim()).Length<=0)
                {
                    MessageBox.Show("Actualmente no se encuentra registrada garantia correspondiente a esta operación en PSBANK, puede continuar con el registro y vincularla posteriormente");
                }

                TxtGaranSIC.Text = ConsultaGarantiaSIC(TxtOperacion.Text.ToUpper().Trim());

            }
        }

        private void TxtOperacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccionBoton = 'M';
            EjecutarAccion('M');
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Cancelar")
            {
                EjecutarAccion('C');
                return;
            }
            AccionBoton = 'E';
            EjecutarAccion('E');
        }

        private void CargaDatosControles()
        {
            try
            {
                if (opeNueva != null && opeNueva.NUM_OPERACION.Length > 0)
                {
                    TxtOperacion.Text = opeNueva.NUM_OPERACION;
                    TxtGaranPS.Text = opeNueva.NUM_GARANTIA.ToString();
                    TxtGaranSIC.Text = opeNueva.GARANTIASIC.ToString();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void BtnBusOpe_Click(object sender, EventArgs e)
        {
            try
            {

               
                opeNueva = new Operacion();
                //opeNueva = null;
                FrmBuscarOperacion ObjFrmBuscarOperacion = new FrmBuscarOperacion();
                //ObjFrmBuscarOperacion.MdiParent = this;
                ObjFrmBuscarOperacion.ShowDialog();
                CargaDatosControles();
                SoloLectura(false);
                
               
              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void TxtBusqOpe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ListadoAvaluos.Count <= 0)
            {
                TxtBusqOpe.Text = string.Empty;
                return;
            }
            if (TxtBusqOpe.Text.Length > 0 || (TxtBusqOpe.Text.Length > 0 && (e.KeyChar == (char)Keys.Back)))
            {
                DgAvaluos.DataSource = ListadoAvaluos.Where(x => ((x.NUM_OPERACION.Trim()+x.NUM_GARANTIA_MADRE.ToString().Trim()).Trim().ToUpper().Contains(TxtBusqOpe.Text.Trim().ToUpper()))).ToList();
                
            }
            else
            {
                DgAvaluos.DataSource = ListadoAvaluos.ToList();
            }
        }

        private void TxtBusqOpe_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgAvaluos_Validated(object sender, EventArgs e)
        {
            
        }

        private void DgAvaluos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void DgAvaluos_DataSourceChanged(object sender, EventArgs e)
        {
            LblRegistros.Text = DgAvaluos.Rows.Count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string CadenaSql = @"Data Source=rin\MIGRACION;Initial Catalog=TraceCore;User ID=CaseData;Password=Coopecaja1";
            SqlCommand cmd;
            SqlConnection conn;
            conn = new SqlConnection(CadenaSql);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into tablacgr values ('Pr100')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
    }
}
