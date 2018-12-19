using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using AppEscritorio.estructuras;
using Logica;
using Datos;



namespace AppEscritorio.General
{
   


    public partial class FrmCargarPagosCGP : Form
    {
        #region "Propiedades"
        CapaLogica objLogica;
        List<datosXmlNominas> datosList = new List<datosXmlNominas>();
        private List<ParametrosArcCGP> ListarParametrosArc;
        private string IdNegocio = "";
        private string NomNegocio ="";
        private string CodMoneda = "";
        private string CuentaClienteOrigen = "";

        #endregion

        #region "Metodos"
        //Metodo para consultar los tipos de servicio sinpe
        private void ConsultarTipoServSinpe()
        {
            try
            {
                objLogica = new CapaLogica();
                cmbTiposServSinpe.DisplayMember = "DescServicio";
                cmbTiposServSinpe.ValueMember = "codServicio";
                cmbTiposServSinpe.DataSource = objLogica.ConsultarTipoServicioSinpe().ToList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //Metodo para actualizar los consecutivos del archivo
        private void actualizarParametrosCGP()
        {
            try
            {
                ParametrosArcCGP param = new ParametrosArcCGP();

                // param.CodServicio = Convert.ToInt32(cmbTiposServSinpe.SelectedValue.ToString());
                param.FecGeneracion = DateTime.Now;
                param.IdConsecutivo = Convert.ToInt32(txtConsecutivo.Text);
                param.IdNumEnvio = Convert.ToInt32(txtNumEnvio.Text);
                param.FecModificacion = DateTime.Now;
                objLogica.ModificarParametroCGP(param);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al actualizar parametros" + ex.Message.ToString());
            }



        }

        //Metodo para guardar los datos en la tabla de pagos
        private void registrarDatosPago(string IdDestino, string TitularServicio, string CuentaClienteDestino, decimal Monto)
        {
            try
            {
                CargaPagosCGP param = new CargaPagosCGP();

                
                param.IdDestino = IdDestino;
                param.TitularServicio = TitularServicio;
                param.CuentaClienteDestino = CuentaClienteDestino;
                param.Monto =Monto;
                param.IdUsuario = Environment.UserName;
                objLogica.RegistroTablaPago(param);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al registrar los datos" + ex.Message.ToString());
            }
        }


        //Metodo para consultar los datos de la nomina
        private void ConsultaDatosPago(string tipoMoneda)
        {
            try
            {
                objLogica = new CapaLogica();
                dtDatos.DataSource = objLogica.consultarPagosCGP(tipoMoneda);
                this.dtDatos.Columns["Monto"].DefaultCellStyle.Format = "#,0.00;- #,0.00;'0.00'";
              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //Metodo para eliminar los datos ya generados del xml de la tabla machaves
        private void EliminarInfoPagoCGP()
        {
            try
            {

                foreach (DataGridViewRow row in dtDatos.Rows)
                {
                    CargaPagosCGP objCGP = new CargaPagosCGP();
                    objCGP.IdUsuario = Environment.UserName;
                    objLogica = new CapaLogica();
                    objLogica.EliminarDatosPagoCGP(objCGP);
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

      
        #endregion

        public FrmCargarPagosCGP()
        {
            InitializeComponent();
        }

        private void FrmCargarPagosCGP_Load(object sender, EventArgs e)
        {
            try
            {
                objLogica = new CapaLogica();
                ListarParametrosArc = objLogica.ConsultarParametrosArcCGP();
                txtDetallePago.Text = "PAGOS CGP";

                //Mostrar los consecutivos del archivo   
                foreach (var item in ListarParametrosArc)
                {
                    txtNumEnvio.Text = (item.IdNumEnvio + 1).ToString();
                    txtConsecutivo.Text = (item.IdConsecutivo + 1).ToString();
                    txtCodEntidad.Text = item.CodEntidad.ToString();
                    IdNegocio = item.IdNegocio.ToString();
                    NomNegocio = item.NomNegocio.ToString();
                   // CodMoneda = item.CodMoneda.ToString();
                   // CuentaClienteOrigen = item.CuentaClienteOrigen.ToString();
                }

             
                //Cargamos los tipos de servicio que existen
                ConsultarTipoServSinpe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la pantalla " + ex.Message.ToString());
            }
        }

      

        private void btnCargar_Click(object sender, EventArgs e)
        {

            if (rbDolares.Checked == true || rbColones.Checked == true)
            {


                pbAvance.Value = 0;
                string archivo = "";   //localizacion del archivo Excel
                System.Data.DataTable dt = new System.Data.DataTable();  //datatable que contendra los datos del Excel
                DataRow fila;
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    archivo = openFile.FileName; //buscamos el nombre del archivo a cargar
                    txtCargaArc.Text = archivo.ToString();
                    try
                    {
                        //creamos los objetos de Microsoft.Office.Interop.Excel que usaremos para leer el archivo

                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(archivo);
                        Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;


                        int filaConta = excelRange.Rows.Count;  //obtenemos la cantidad de filas del archivo

                        int colConta = excelRange.Columns.Count; // Obtenemos la cantidad de columnas del archivo

                        //Obtenemos la primera columna del excel                

                        for (int i = 1; i <= filaConta; i++)
                        {
                            for (int j = 1; j <= colConta; j++)
                            {
                                dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                            }
                            break;
                        }

                        //Obtengo los datos de las filas             
                        int contadorFilas;  //numero de index
                        for (int i = 2; i <= filaConta; i++) //Loop for available row of excel data
                        {
                            fila = dt.NewRow();  //asignamos nuevas filas al datatable
                            contadorFilas = 0;
                            for (int j = 1; j <= colConta; j++) //Loop for available column of excel data
                            {
                                //ver si la celda esta vacio
                                if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                                {
                                    fila[contadorFilas] = excelRange.Cells[i, j].Value2.ToString();
                                }
                                else
                                {
                                    fila[i] = "";
                                }

                                contadorFilas++;

                            }
                            dt.Rows.Add(fila); //add fila al datatable


                            pbAvance.Value += 1;
                            lbContador.Text = pbAvance.Value.ToString();

                        }

                        foreach (DataRow rows in dt.Rows)
                        {

                            string IdDestino = rows[0].ToString();
                            string TitularServicio = rows[1].ToString();
                            string CuentaClienteDestino = rows[2].ToString();
                            string Monto = rows[3].ToString();
                            registrarDatosPago(IdDestino, TitularServicio, CuentaClienteDestino, Convert.ToDecimal(Monto));

                        }

                        if (rbColones.Checked == true)
                        {
                            ConsultaDatosPago("COL");

                        }
                        else if (rbDolares.Checked == true)
                        {
                            ConsultaDatosPago("DOL");
                        }


                        pbAvance.Maximum = dt.Rows.Count;
                        dtDatos.AllowUserToAddRows = false;

                        //cerramos y limpiamos los procesos de Excel
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(excelRange);
                        Marshal.ReleaseComObject(excelWorksheet);
                        excelWorkbook.Close();
                        Marshal.ReleaseComObject(excelWorkbook);

                        //cerramos  
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } //if validar moneda
            else {
                MessageBox.Show("Debe de elegir el tipo de moneda a utilizar para la generación.");
            } //fin if validacion 

        }

       
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {   // verificamos que hayan datos para exportar
            if (dtDatos.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para generar, favor revisar los parametros ingresados.");
            }
            else
            {
                saveFile.Filter = "Xml files (*.xml)|*.xml";
                saveFile.FilterIndex = 2;

                saveFile.FileName = "PagosCGP";
                saveFile.Title = "Exportar archivo";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dtDatos.Rows)
                    {
                        datosXmlNominas dato = new datosXmlNominas();
                        dato.CodMoneda = (string)Convert.ToString(row.Cells["CodMoneda"].Value);
                        dato.Servicio = (string)row.Cells["Servicio"].Value;
                        dato.IdNegocio = (string)row.Cells["IdNegocio"].Value;
                        dato.NomNegocio = (string)row.Cells["NomNegocio"].Value;
                        dato.CuentaClienteOrigen = (string)row.Cells["CuentaClienteOrigen"].Value;
                        dato.IdDestino = (string)row.Cells["IdDestino"].Value;
                        dato.TitularServicio = (string)row.Cells["TitularServicio"].Value;
                        dato.CuentaClienteDestino = (string)row.Cells["CuentaClienteDestino"].Value;
                        dato.Monto = (string)row.Cells["Monto"].Value.ToString();
                        dato.DesGeneral = (string)txtDetallePago.Text;
     
                        datosList.Add(dato);
                    }

                    using (XmlTextWriter Writer = new XmlTextWriter(this.saveFile.FileName, Encoding.UTF8))
                    {
                        int contadorRows = 0;// contador de número de registros para pago
                        decimal montoTotal = 0;//monto total a pagar
                        //Declaración inicial del Xml.
                        Writer.WriteStartDocument();

                        ////Configuración.
                        Writer.Formatting = Formatting.Indented;
                        Writer.Indentation = 3;

                        //Escribimos el nodo principal.
                        Writer.WriteStartElement("SINPEDOCUMENTOXML");

                        //Inicio del encabezado
                        Writer.WriteStartElement("ENCABEZADO");

                        //Inicio del elemento CICLO
                        Writer.WriteStartElement("CICLO");
                        Writer.WriteAttributeString("Fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                        Writer.WriteAttributeString("CodServicio", cmbTiposServSinpe.SelectedValue.ToString());
                        Writer.WriteAttributeString("NumeroEnvio", txtNumEnvio.Text);
                        Writer.WriteAttributeString("EstadoTransacciones", "Todos");
                        Writer.WriteEndElement();
                        //Fin Elemento CICLO 

                        //Inicio del elemento ENTIDAD
                        Writer.WriteStartElement("ENTIDAD");
                        Writer.WriteAttributeString("CodEntidad", txtCodEntidad.Text);
                        Writer.WriteAttributeString("Consecutivo", txtConsecutivo.Text);
                        Writer.WriteEndElement();
                        //Fin Elemento ENTIDAD 

                        Writer.WriteEndElement();  //Fin del Encabezado


                        //Escribimos el nodo secundario Creditos.
                        Writer.WriteStartElement("CREDITOS");

                        foreach (datosXmlNominas item in datosList)
                        {
                            decimal montoNeto = Convert.ToDecimal(item.Monto.ToString());
                            string monNeto = montoNeto.ToString("#,0.00;- #,0.00;'0.00'");

                            //Inicio del elemento CREDITO
                            Writer.WriteStartElement("CREDITO");
                            Writer.WriteAttributeString("CodMoneda", item.CodMoneda.ToString());
                            Writer.WriteAttributeString("Servicio", item.Servicio.ToString());
                            Writer.WriteAttributeString("IdNegocio", item.IdNegocio.ToString());
                            Writer.WriteAttributeString("NomNegocio", item.NomNegocio.ToString());
                            Writer.WriteAttributeString("CuentaClienteOrigen", item.CuentaClienteOrigen.ToString());
                            Writer.WriteAttributeString("IdDestino", item.IdDestino.ToString());
                            Writer.WriteAttributeString("TitularServicio", item.TitularServicio.ToString());
                            Writer.WriteAttributeString("CuentaClienteDestino", item.CuentaClienteDestino.ToString());
                            Writer.WriteAttributeString("Monto", monNeto);
                            //Writer.WriteAttributeString("DesGeneral", item.DesGeneral.ToString());
                            Writer.WriteAttributeString("DesGeneral", txtDetallePago.Text);
                            Writer.WriteEndElement();
                            //Fin Elemento CREDITO 


                            contadorRows++;
                            montoTotal = montoTotal + montoNeto;
                        }

                        //Inicio del RESUMEN
                        Writer.WriteStartElement("RESUMEN");
                        Writer.WriteAttributeString("CantidadDatos", contadorRows.ToString());
                        Writer.WriteAttributeString("SumatoriaMontos", montoTotal.ToString("#,0.00;- #,0.00;'0.00'"));
                        Writer.WriteEndElement();
                        //Fin del RESUMEN
                        datosList.Clear();
                    }

                }

            }//fin if else

            MessageBox.Show("Archivo generado correctamente en " + this.saveFile.FileName.ToString());
            datosList.Clear();

           // actualizamos el consecutivo del siguiente archivo 
            actualizarParametrosCGP();
           //eliminamos los datos de el archivo generado
            EliminarInfoPagoCGP();



            } //fin try
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo" + ex.Message.ToString());
            }//fin catch
       
        }

        private void dtDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
      
    }
}
