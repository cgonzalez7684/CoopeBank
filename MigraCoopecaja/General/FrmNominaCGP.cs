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
using Datos;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using AppEscritorio.estructuras;

namespace AppEscritorio.General
{
    public partial class FrmNominaCGP : Form
    {
        #region "Propiedades"
        CapaLogica objLogica;
        List<datosXmlNominas> datosList = new List<datosXmlNominas>();
        private List<ParametrosArcCGP> ListarParametrosArc;

        #endregion 

        #region "Metodos"
        //Metodo para consultar los tipos de nomina
        private void ConsultarTipoNomina()
        {
            try
            {
                objLogica = new CapaLogica();
                cmbTipoNomina.DisplayMember = "DESCRIPCION";
                cmbTipoNomina.ValueMember = "NOMINA";
                cmbTipoNomina.DataSource = objLogica.ConsultarTipoNomina().ToList();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

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

        //Metodo para consultar los datos de la nomina
        private void ConsultaDatosNomina(String fecPago, string tipoNomina)
        {
            try
            {
                objLogica = new CapaLogica();
                objLogica.consultarNominas(Convert.ToDateTime(fecPago), tipoNomina);
                dtDatos.DataSource = objLogica.consultarNominas(Convert.ToDateTime(fecPago), tipoNomina);
                this.dtDatos.Columns["Monto"].DefaultCellStyle.Format = "#,0.00;- #,0.00;'0.00'";
                DataGridViewCheckBoxColumn columna = new DataGridViewCheckBoxColumn();
                columna.Name = "Pagar";
                dtDatos.Columns.Add(columna);
                columna.Width = 100;
                foreach (DataGridViewRow fila in dtDatos.Rows)
                {
                    fila.Cells["Pagar"].Value = true;
                    this.dtDatos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
             
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
                
                MessageBox.Show("Error al actualizar parametros"+ ex.Message.ToString());
            }
          

        
        }
        #endregion

        public FrmNominaCGP()
        {
            InitializeComponent();
        }

        private void FrmNominaCGP_Load(object sender, EventArgs e)
        {
            try
            {
                chkDesmarcar.Checked = true;
                objLogica = new CapaLogica();
                ListarParametrosArc=  objLogica.ConsultarParametrosArcCGP();
                txtDetallePago.Text = "PAGO DE PLANILLA";

               //Mostrar los consecutivos del archivo   
                foreach (var item in ListarParametrosArc)
                {
                    txtNumEnvio.Text = (item.IdNumEnvio + 1).ToString();
                    txtConsecutivo.Text = (item.IdConsecutivo +1).ToString();
                    txtCodEntidad.Text = item.CodEntidad.ToString();
                }

                //Cargamos los tipos de nomina existentes 
                ConsultarTipoNomina();
                //Cargamos los tipos de servicio que existen
                ConsultarTipoServSinpe();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la pantalla " + ex.Message.ToString());
            }

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

                    saveFile.FileName = "PagoNomina";
                    saveFile.Title = "Exportar archivo";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {

                        foreach (DataGridViewRow row in dtDatos.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[9].Value))
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
                                datosList.Add(dato);
                            }
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
                            Writer.WriteAttributeString("Fecha",DateTime.Now.ToString("yyyy-MM-dd"));
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

                            datosList.Clear();//limpiamos la lista
                        }

                    }

                }//fin if else

                MessageBox.Show("Archivo generado correctamente en " + this.saveFile.FileName.ToString());


                //actualizamos el consecutivo del siguiente archivo 
                actualizarParametrosCGP();


            } //fin try
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo" + ex.Message.ToString());
            }//fin catch
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultaDatosNomina(dtFechaPago.Value.ToShortDateString(), cmbTipoNomina.SelectedValue.ToString());
            }//fin try
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los tipos de planilla"+ ex.Message.ToString());
            }//fin catch
           
        }

        private void dtDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                dtDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dtDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? true : (!(bool)dtDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
            }
        }

        private void dtDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkDesmarcar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDesmarcar.Checked==true)
            {
                foreach (DataGridViewRow fila in dtDatos.Rows)
                {
                    fila.Cells["Pagar"].Value = true;
                }
            }
            else {
                foreach (DataGridViewRow fila in dtDatos.Rows)
                {
                    fila.Cells["Pagar"].Value = false;
                }
            }
           
        }

      
        
    }
}
