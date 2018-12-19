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
using System.IO;
using System.Configuration;


namespace AppEscritorio.Colocaciones
{
    public partial class FrmPlanillas : Form
    {
        List<CamposEnvio> ListadoCamposEnvio;
        List<GlCentro> ListadoCentros;
        List<PersonaCargaTexto> ListadoCargaTexto;
        double SumatoriaTotal;
        int ConteoLineas;
        //string cadena = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        string cadena = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
        public FrmPlanillas()
        {
            InitializeComponent();
            ListadoCargaTexto = new List<PersonaCargaTexto>();
            DgCargaTexto.DataSource = null;
        }

        private void CargarInstitucionesPS()
        {
            try
            {
                using (OracleConnection connORA = new OracleConnection(cadena))
                {
                    DataTable dt = new DataTable();
                    OracleDataReader dr;
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("Select NVL(COD_CENTRO,'0'),DES_CENTRO from GENERAL.GL_CENTROS Where COD_CENTRO IN (1,3) AND TIPO_ENVIO = 'A'  ORDER BY TO_NUMBER(COD_CENTRO) ASC", connORA);

                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 0;
                    Query.ExecuteNonQuery();
                    OracleDataAdapter adp = new OracleDataAdapter(Query);
                    dr = Query.ExecuteReader();

                    ListadoCentros = new List<GlCentro>();
                    while (dr.Read())
                    {

                        GlCentro obj = new GlCentro();
                        obj.COD_CENTRO = Convert.ToInt32(dr.GetString(0));
                        obj.DES_CENTRO = dr.GetString(1);
                        ListadoCentros.Add(obj);

                    }

                    CmbCentro.DataSource = ListadoCentros;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //private void ConsultarCampos(string pCod_Centro)
        //{
        //    string centro = string.Empty;
        //    try
        //    {
        //        using (OracleConnection connORA = new OracleConnection(cadena))
        //        {
        //            DataTable dt = new DataTable();
        //            OracleDataReader dr;
        //            connORA.Open();
        //            OracleCommand Query = new OracleCommand("SELECT COD_CENTRO, ID_CAMPO, NOM_COLUMNA, TIP_DATO, NVL(LON_DATO,0), " +
        //                                                   "NUM_ORDEN_INICIO,NVL(VAL_DEFECTO,'X'),NVL(RELLENO_IZQ_DER,'X'),NVL(CARACTER_RELLENO,'X') " +
        //                                                   "FROM   DEDUCCIONES.De_Campos_Envio " +
        //                                                   "WHERE   Cod_Centro =" + pCod_Centro + " AND NUM_CONSECUTIVO = 1  and NVL(VAL_DEFECTO,'X') = 'X'" +
        //                                                   "order by ID_CAMPO ASC", connORA);

        //            Query.CommandType = CommandType.Text;
        //            Query.CommandTimeout = 0;
        //            Query.ExecuteNonQuery();
        //            OracleDataAdapter adp = new OracleDataAdapter(Query);
        //            dr = Query.ExecuteReader();
                    
        //            ListadoCamposEnvio = new List<CamposEnvio>();
        //            while (dr.Read())
        //            {
        //                centro = dr.GetString(0) + ' ' + dr.GetString(2);
        //                CamposEnvio objCampoEnvio = new CamposEnvio();
        //                objCampoEnvio.COD_CENTRO = dr.GetString(0);
        //                objCampoEnvio.ID_CAMPO = dr.GetInt32(1);
        //                objCampoEnvio.NOM_COLUMNA = dr.GetString(2);
        //                objCampoEnvio.TIP_DATO = dr.GetString(3);
        //                objCampoEnvio.LON_DATO = (int)(dr.GetOracleDecimal(4));
        //                objCampoEnvio.NUM_ORDEN_INICIO = (int)(dr.GetOracleDecimal(5));
        //                objCampoEnvio.VAL_DEFECTO = dr.GetString(6);
        //                objCampoEnvio.RELLENO_IZQ_DER = Convert.ToChar(dr.GetValue(7));
        //                objCampoEnvio.CARACTER_RELLENO = Convert.ToChar(dr.GetValue(8));
        //                ListadoCamposEnvio.Add(objCampoEnvio);                     

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(centro);
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void CargaDatosArchivo()
        {
            try
            {
                Stream myStream = null;
                //OpenFileDialog oFdBuscarArchivo = new OpenFileDialog();
                oFdBuscarArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                oFdBuscarArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                oFdBuscarArchivo.FilterIndex = 2;
                oFdBuscarArchivo.RestoreDirectory = true;
                if (!(oFdBuscarArchivo.ShowDialog() == DialogResult.OK))
                {
                    return;
                }

                int counter = 0;
                string line;

                //LECTURA DEL ARCHIVO 
                System.IO.StreamReader file =
                    new System.IO.StreamReader(oFdBuscarArchivo.OpenFile());            
                
                //SE RECORREN TODAS LAS LINEAS DEL ARCHIVO Y SE CARGAN EN UNA LISTA DE STRINGS
                List<string> ListadoLineas = new List<string>();
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length <= 0)
                    {
                        break;
                    }
                    ListadoLineas.Add(line);                   
                }

                if (ListadoLineas.Count <= 0)
                {
                    MessageBox.Show("El archivo no cuenta con lineas para procesar");
                    return;
                }
               
                //TOMANDO COMO LA LISTA DE LINEAS CARGADAS, SE PROCEDE A TRANSFORMAR ESTAS PARA CARGAR UNA LISTA DE OBJETOS TIPO PERSONACARGATEXTO
                GestorEstructuraPlanillas objGestor = new GestorEstructuraPlanillas(CmbCentro.SelectedValue.ToString());
                ListadoCargaTexto = new List<PersonaCargaTexto>();
                objGestor.CargaDatosCentro(ListadoLineas, ref ListadoCargaTexto);

                
                file.Close();
                DgCargaTexto.DataSource = ListadoCargaTexto;
                CargaPartidas();

                //ConteoLineas = ListadoCargaTexto.Count;
                //SumatoriaTotal = ListadoCargaTexto.Sum(x => x.Monto);
                //TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal); 
                //TxtConteo.Text = ConteoLineas.ToString();
                //MessageBox.Show(counter.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show("Favor verificar que el archivo cargado corresponde a la insitucion seleccionada");
            }
        }

        public void CargaPartidas()
        {
            var Lista = ListadoCargaTexto.GroupBy(x => x.Partida).Select(y => y.First());

            List<string> Listado = new List<string>();
            Listado.Add("Todo");
            foreach (PersonaCargaTexto item in Lista)
            {
                Listado.Add(item.Partida.ToString());
            }

            cmbPartida.DataSource = Listado;
                                           
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargaDatosArchivo();
            textBox1.Focus();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

 
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ConsultarCampos(CmbCentro.ValueMember.ToString());

            ListadoCargaTexto = new List<PersonaCargaTexto>();
            DgCargaTexto.DataSource = ListadoCargaTexto;
            TxtConteo.Text = string.Empty;
            TxtTotal.Text = string.Empty;
            cmbPartida.DataSource = null;
            //for (int i = 0; i < cmbPartida.Items.Count - 1; i++)
            //{
            //    cmbPartida.Items.RemoveAt(i);
            //}
            //DgCargaTexto.Rows.Clear();
        }

        private void FrmPlanillas_Load(object sender, EventArgs e)
        {
            SumatoriaTotal = 0;
            ConteoLineas = 0;
            CmbCentro.ValueMember = "COD_CENTRO";
            CmbCentro.DisplayMember = "DES_CENTRO";
            CargarInstitucionesPS();
           
        }

        private void CmbCentro_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length <= 0 || ListadoCargaTexto.Count <=0)
            {
                ConteoLineas = ListadoCargaTexto.Count;
                SumatoriaTotal = ListadoCargaTexto.Sum(x => x.Monto);
                TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal);
                TxtConteo.Text = ConteoLineas.ToString();
                DgCargaTexto.DataSource = ListadoCargaTexto;
                return;
            }

            ConteoLineas = ListadoCargaTexto.Where(x => (x.Cedula.ToUpper().Contains(textBox1.Text.ToUpper()))).ToList().Count;
            SumatoriaTotal = ListadoCargaTexto.Where(x => (x.Cedula.ToUpper().Contains(textBox1.Text.ToUpper()))).ToList().Sum(x => x.Monto);
            TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal);
            TxtConteo.Text = ConteoLineas.ToString();
            DgCargaTexto.DataSource = ListadoCargaTexto.Where(x => (x.Cedula.ToUpper().Contains(textBox1.Text.ToUpper()))).ToList();

        }

        private void TotalizarDatos()
        {

        }

        private void cmbPartida_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ListadoCargaTexto.Count <= 0)
            {
                return;
            }

            if (cmbPartida.Text.Equals(string.Empty) || cmbPartida.SelectedIndex == 0)
            {
                ConteoLineas = ListadoCargaTexto.Count;
                SumatoriaTotal = ListadoCargaTexto.Sum(x => x.Monto);
                TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal);
                TxtConteo.Text = ConteoLineas.ToString();
                DgCargaTexto.DataSource = ListadoCargaTexto;
                return;
            }

            ConteoLineas = ListadoCargaTexto.Where(x => x.Partida == Convert.ToInt32(cmbPartida.Text)).ToList().Count;
            SumatoriaTotal = ListadoCargaTexto.Where(x => x.Partida == Convert.ToInt32(cmbPartida.Text)).ToList().Sum(x => x.Monto);
            TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal);
            TxtConteo.Text = ConteoLineas.ToString();
            DgCargaTexto.DataSource = ListadoCargaTexto.Where(x => x.Partida == Convert.ToInt32(cmbPartida.Text)).ToList();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
