using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Datos.EntidadesAux;
using Logica;

namespace AppEscritorio.Captacion
{
    public partial class FrmLiquidacion : Form
    {
        CapaLogica objLogica;
        List<LiqProduct> ListadoProductosArchivo;
        List<LiqProduct> ListadoProductos;
        List<string> ListadoNoEncontrados;
        Double SumaCargaArchivo;
        int CantidadPersonaCargaArchivo;

        enum TipoProducto  { Sobrantes,Excedentes};
        
        public FrmLiquidacion()
        {
            
            InitializeComponent();
        }

        public void MostrarMensaje()
        {
            MessageBox.Show("Prueba codigo nuevo");
        }


        # region "Metodos"



        private void ConsultarProductosLiquidaciones(int tipo, DateTime Fec_Carga)
        {
            try
            {
                objLogica = new CapaLogica();
                ListadoProductos = new List<LiqProduct>();
                ListadoProductos = objLogica.ConsultarProductosLiquidaciones(tipo, Fec_Carga).ToList(); //Estos serian los productos por liquidar
                double SumaLiquida = Convert.ToDouble(ListadoProductos.Sum(x=>x.MON_APLICADO));
                TxtSumaLiq.Text = String.Format("{0:C2}", SumaLiquida);
                LblCant.Text = "Cantidad registros por liquidar: " + ListadoProductos.Count.ToString();
                TxtTotPerLiq.Text = ListadoProductos.Count.ToString();
                DgProdLiq.DataSource = ListadoProductos;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ConsultarTipoProductos()
        {
            try
            {
                objLogica = new CapaLogica();                
                CmbProducto.DataSource = objLogica.ConsultarTipoProductos().ToList();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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

        private void CargaSobrantes() 
        {
            try
            {
                SumaCargaArchivo = 0;
                Stream myStream = null;
                //OpenFileDialog oFdBuscarArchivo = new OpenFileDialog();
                oFdBuscarArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                oFdBuscarArchivo.Filter = "txt files (*.csv)|*.csv";
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

                ListadoProductosArchivo = new List<LiqProduct>();
                ListadoNoEncontrados = new List<string>();
                objLogica = new CapaLogica();
                // MessageBox.Show("Ingresa");
                while ((line = file.ReadLine()) != null)
                {
                    // MessageBox.Show(line);
                    LiqProduct objLiqProducto = new LiqProduct();
                    objLiqProducto.COD_COMPANIA = cmbCompania.SelectedIndex == 0 ? "01001001" : "02001001";
                    objLiqProducto.DES_IDENTIFICACION = line.Split(';')[0];
                    objLiqProducto.MON_APLICADO = Convert.ToDecimal(line.Split(';')[1]);
                    objLiqProducto.COD_CUENTA = CmbNUM_CUENTA.SelectedValue.ToString();
                    objLiqProducto.COD_INVERSION = CmbProducto.SelectedValue.ToString();
                    objLiqProducto.COD_USUARIO_CARGA = FrmMain.Usuario.Usuario;
                    objLiqProducto.FEC_CARGA = DateTime.Now;
                    objLiqProducto.FEC_LIQUIDA = new DateTime(1900, 1, 1);
                    objLiqProducto.COD_USUARIO_LIQUIDA = "PSBANKER";
                    // objLiqProducto.DES_IDENTIFICACION = "503740469"; --usar esta linea solo para debug
                    //if (objLiqProducto.DES_IDENTIFICACION.Equals("110120136"))
                    //{
                    //    Console.Write("sdf");
                    //}
                    string[] Codigo = objLogica.ConsultarClienteContrato(objLiqProducto.DES_IDENTIFICACION, objLiqProducto.COD_INVERSION, objLiqProducto.COD_COMPANIA).Split('>');
                    if (Codigo[0] == "-1")
                    {
                        ListadoNoEncontrados.Add(objLiqProducto.DES_IDENTIFICACION + " -> Monto[ " + objLiqProducto.MON_APLICADO.ToString() + " ] , Saldo actual producto[ " + Codigo[2] + " ]");
                        continue;
                    }

                    if (Convert.ToDecimal(Codigo[2]) < objLiqProducto.MON_APLICADO)
                    {
                        ListadoNoEncontrados.Add(objLiqProducto.DES_IDENTIFICACION + " -> Monto[ " + objLiqProducto.MON_APLICADO.ToString() + " ] , Saldo actual producto[ " + Codigo[2] + " ]");
                        objLiqProducto.MON_APLICADO = Convert.ToDecimal(Codigo[2]);
                    }

                    // MessageBox.Show("Pasa" + objLiqProducto.DES_IDENTIFICACION);
                    SumaCargaArchivo = SumaCargaArchivo + Convert.ToDouble(objLiqProducto.MON_APLICADO);
                    CantidadPersonaCargaArchivo = CantidadPersonaCargaArchivo + 1;
                    objLiqProducto.COD_CLIENTE = Convert.ToInt32(Codigo[0]);
                    objLiqProducto.NUM_CONTRATO = Convert.ToInt32(Codigo[1]);

                    ListadoProductosArchivo.Add(objLiqProducto);
                }

                foreach (string item in ListadoNoEncontrados)
                {
                    LstNoEncontrados.Items.Add(item);
                }

                if (ListadoProductosArchivo.Count <= 0)
                {
                    MessageBox.Show("El archivo no cuenta con lineas para procesar");
                    return;
                }

                DgProdCarga.DataSource = ListadoProductosArchivo.ToList();


                ObtenerAsociadosNoEncontrados();

                ListadoProductos = new List<LiqProduct>();
                DgProdLiq.DataSource = ListadoProductos;

                //TOMANDO COMO LA LISTA DE LINEAS CARGADAS, SE PROCEDE A TRANSFORMAR ESTAS PARA CARGAR UNA LISTA DE OBJETOS TIPO PERSONACARGATEXTO
                //GestorEstructuraPlanillas objGestor = new GestorEstructuraPlanillas(CmbCentro.SelectedValue.ToString());
                //ListadoCargaTexto = new List<PersonaCargaTexto>();
                //objGestor.CargaDatosCentro(ListadoLineas, ref ListadoCargaTexto);


                //file.Close();
                //DgCargaTexto.DataSource = ListadoCargaTexto;
                //CargaPartidas();

                //ConteoLineas = ListadoCargaTexto.Count;
                //SumatoriaTotal = ListadoCargaTexto.Sum(x => x.Monto);
                //TxtTotal.Text = String.Format("{0:C2}", SumatoriaTotal); 
                //TxtConteo.Text = ConteoLineas.ToString();
                //MessageBox.Show(counter.ToString());
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Favor verificar que el archivo tenga el formato correcto "+ex.ToString());
            }
        
        }

        private void CargaDatosArchivo()
        {
            try
            {
                CargaSobrantes();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Favor verificar que el archivo tenga el formato correcto "+ex.ToString());
            }
        }


        private void ObtenerAsociadosNoEncontrados()
        {
            if (LstNoEncontrados.Items.Count <= 0)
            {
                return;
            }

            MessageBox.Show(null, "Los clientes no encontrados deben ser guardados en un block de notas, esta información no se puede recuperar", "RESTRINCCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

            for (int i = 0; i < LstNoEncontrados.Items.Count; i++)
            {

                LstNoEncontrados.SetSelected(i, true);
            }
            string s = "LISTADO PERSONAS NO ENCONTRADAS EN BASE DE DATOS PARA LIQUIDAR PRODUCTO TIPO (" + CmbProducto.SelectedValue + ") -> " + CmbProducto.Text + Environment.NewLine;
            foreach (object o in LstNoEncontrados.SelectedItems)
            {
                s += o.ToString() + Environment.NewLine;
            }
            Clipboard.SetText(s);
        }

        private void RegistraUT_LIQUIDACIONSOBRANTES()
        {
            try
            {
                if (ListadoProductosArchivo.Count <= 0)
                {
                    MessageBox.Show(null, "No existen productos por registrar en tabla de liquidaciones", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                objLogica = new CapaLogica();
                int rs = 0;
                rs = objLogica.RegistrarUT_LIQUIDACIONSOBRANTES(ListadoProductosArchivo);
                if (rs == 1)
                {
                    MessageBox.Show("Carga exitosa");
                }
                else
                {
                    MessageBox.Show("Error en carga de datos");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void SumarTotal(List<LiqProduct> Listado, TextBox TxtObj)
        {
            try
            {
                if (Listado.Count <= 0)
                {
                    return;
                }

                Double SumatoriaTotal = 0.00;
                SumatoriaTotal = Convert.ToDouble(Listado.Sum(X => X.MON_APLICADO));
                TxtObj.Text = String.Format("{0:C2}", SumatoriaTotal);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void LimpiarControles()
        {
            //cmbCompania.SelectedIndex = 0;
            //CmbNUM_CUENTA.SelectedIndex = 0;
            //DtFecCarga.Value = DateTime.Now;
            //CmbProducto.SelectedValue = "015";
            TxtBuscar1.Text = string.Empty;
            TxtBuscar2.Text = string.Empty;
            LstNoEncontrados.Items.Clear();
            LstNoLiquidados.Items.Clear();
            TxtMontCarga.Text = string.Empty;
            TxtCantCargArchivo.Text = string.Empty;
            TxtSumaLiq.Text = string.Empty;
            TxtTotPerLiq.Text = string.Empty;
            ListadoProductos = new List<LiqProduct>();
            DgProdLiq.DataSource = ListadoProductos;
            ListadoProductosArchivo = new List<LiqProduct>();
            DgProdCarga.DataSource = ListadoProductosArchivo;
            
        }

        # endregion

        
        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void FrmLiquidacion_Load(object sender, EventArgs e)
        {
            CantidadPersonaCargaArchivo = 0;
            SumaCargaArchivo = 0;
            ConsultarBancos();
            ConsultarTipoProductos();
            CmbProducto.SelectedValue = "015";
            cmbCompania.SelectedIndex = 0;
            ConsultarProductosLiquidaciones(2,DtFecCarga.Value);            
            ListadoProductosArchivo = new List<LiqProduct>();
            if (ListadoProductos.Count > 0)
            {
                SumarTotal(ListadoProductos, TxtSumaLiq);
            }
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            CargaDatosArchivo();
            TxtMontCarga.Text = String.Format("{0:C2}", SumaCargaArchivo);
            TxtCantCargArchivo.Text = Convert.ToString(CantidadPersonaCargaArchivo);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistraUT_LIQUIDACIONSOBRANTES();
            ConsultarProductosLiquidaciones(2, DtFecCarga.Value);
            SumarTotal(ListadoProductos, TxtSumaLiq);
        }

        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            ObtenerAsociadosNoEncontrados();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] RespuestaProceso;
           // Exception ex = null; 

            try
            {

           
                objLogica = new CapaLogica();
                //Se actualiza el dato del usuario del sistema que esta haciendo la actualización
                foreach (LiqProduct item in ListadoProductos)
                {
                    item.COD_USUARIO_LIQUIDA = FrmMain.Usuario.Usuario;
                }
                 RespuestaProceso = objLogica.AplicarLiquidacion(ListadoProductos);
                List<string> ListadoNoLiquidados = new List<string>();
                //int respuesta = -1;
                //respuesta = (int)RespuestaProceso[0];
                //if (respuesta < 0)
                //{
                //    //ex = new Exception("Error en aplicación de liquidacion->[" + RespuestaProceso[1].ToString() + "]");
                //    throw new Exception("Error en aplicación de liquidacion->[" + RespuestaProceso[1].ToString() + "]");
                //   // MessageBox.Show(null, "Error en aplicación de liquidacion->[" + RespuestaProceso[1].ToString() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //   // return;
                //}
                ListadoNoLiquidados = (List<string>)RespuestaProceso[2];
                foreach (string item in ListadoNoLiquidados)
                {
                    LstNoLiquidados.Items.Add(item);

                }

                LimpiarControles();
                ConsultarProductosLiquidaciones(2, DtFecCarga.Value);

                MessageBox.Show(null, "Se realizó la liquidación de forma correcta", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(null, ex.Message+" "+Environment.NewLine+" "+ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }
          

            



        

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (LstNoLiquidados.Items.Count <= 0)
            {
                return;
            }

            MessageBox.Show(null, "Los clientes no liquidados deben ser guardados en un block de notas, esta información no se puede recuperar", "RESTRINCCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);


            for (int i = 0; i < LstNoLiquidados.Items.Count; i++)
            {

                LstNoLiquidados.SetSelected(i, true);
            }
            string s = "LISTADO PERSONAS NO LIQUIDADAS (" + CmbProducto.SelectedValue + ") -> " + CmbProducto.Text + Environment.NewLine;
            foreach (object o in LstNoLiquidados.SelectedItems)
            {
                s += o.ToString() + Environment.NewLine;
            }
            Clipboard.SetText(s);
        }

        private void DtFecCarga_ValueChanged(object sender, EventArgs e)
        {            
            
            LimpiarControles();
            ConsultarProductosLiquidaciones(2, DtFecCarga.Value);
        }

        private void cmbCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            ConsultarProductosLiquidaciones(2, DtFecCarga.Value);
        }

        private void CmbNUM_CUENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            ConsultarProductosLiquidaciones(2, DtFecCarga.Value);
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            ConsultarProductosLiquidaciones(2, DtFecCarga.Value);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgProdCarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
