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
using Datos;


namespace AppEscritorio.Colocaciones
{
    public partial class FrmCambVend : Form
    {

        String Cod_compania = "";
        public static int Cod_vendedor = 0;
        public static string Nombre_Vendedor = "";

        public FrmCambVend()
        {
            InitializeComponent();
        }

        private string connectionStringO()
        {
            return "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        }

        private void validaOperacion(string NUM_SOLICITUD)
        {
            this.btnGuardar.Enabled = false;
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT A.COD_COMPANIA,A.NUM_SOLICITUD,A.COD_CLIENTE, C.NOM_CLIENTE,A.COD_VENDEDOR, B.NOMBRE_VENDEDOR FROM CREDITO.CR_SOLICITUDES  A" +  
                                                            " LEFT JOIN FVENTAS.FV_VENDEDORES B ON A.COD_VENDEDOR = B.COD_VENDEDOR AND A.COD_COMPANIA = B.COD_COMPANIA " +
                                                            " INNER JOIN CLIENTES.CL_CLIENTES C ON A.COD_CLIENTE = C.COD_CLIENTE " + 
                                                            " where NUM_SOLICITUD = :1", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.Parameters.Add(new OracleParameter("NUM_SOLICITUD", NUM_SOLICITUD));
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            Cod_compania = (String)SqlDR["COD_COMPANIA"].ToString();
                            Cod_vendedor = 0;
                            Nombre_Vendedor = "";
                            this.txtCodCliente.Text = (String)SqlDR["COD_CLIENTE"].ToString();
                            this.txtNomCliente.Text = (String)SqlDR["NOM_CLIENTE"].ToString();
                            this.txtCodAsesor.Text = (String)SqlDR["COD_VENDEDOR"].ToString();
                            this.txtNomAsesor.Text = (String)SqlDR["NOMBRE_VENDEDOR"].ToString();
                            this.txtCodAsesorN.Text = "";
                            this.txtNomAsesorN.Text = "";
                        }

                        

                    }
                    else
                    {
                        MessageBox.Show("No se encontró la solicitud digitada","SOLICITUDES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cod_compania = "";
                        this.txtCodCliente.Text = "";
                        this.txtSolicitud.Text = "";
                        this.txtNomCliente.Text = "";
                        this.txtCodAsesor.Text = "";
                        this.txtNomAsesor.Text = "";
                        this.txtCodAsesorN.Text = "";
                        this.txtNomAsesorN.Text = "";
                        Cod_vendedor = 0;
                        Nombre_Vendedor = "";
                    }
                    SqlDR.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "SOLICITUDES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private int guardarVendedor(string NUM_SOLICITUD, int idVendedor)
        {
            int resultado = 0;
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("UPDATE CREDITO.CR_SOLICITUDES SET COD_VENDEDOR = :1  where NUM_SOLICITUD = :2", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.Parameters.Add(new OracleParameter("COD_VENDEDOR", idVendedor));
                    Query.Parameters.Add(new OracleParameter("NUM_SOLICITUD", NUM_SOLICITUD));
                    Query.CommandTimeout = 10000;

                    int SqlR = Query.ExecuteNonQuery();
                    resultado = SqlR;
                    Query.CommandText = "commit";
                    SqlR = Query.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Guardar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;

        }


        private void txtSolicitud_Validating(object sender, CancelEventArgs e)
        {
            string SOLICITUD  = this.txtSolicitud.Text.Trim();
            validaOperacion(SOLICITUD);
        }

        private void btnAsesor_Click(object sender, EventArgs e)
        {
            Cod_vendedor = 0;
            Nombre_Vendedor = "";
            if (Cod_compania.Trim() == "") { return; };
            Colocaciones.FrmBuscaVendedor gestion = new Colocaciones.FrmBuscaVendedor(Cod_compania, connectionStringO());
            gestion.ShowDialog();
            if (Cod_vendedor == 0) 
            {
                this.txtCodAsesorN.Text = "";
                this.txtNomAsesorN.Text = "";
                this.btnGuardar.Enabled = false;
            }
            else
            {
                this.txtCodAsesorN.Text = Cod_vendedor.ToString();
                this.txtNomAsesorN.Text = Nombre_Vendedor.ToString();
                this.btnGuardar.Enabled = true;
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Desea guardar el nuevo vendedor??",
                                     "Confirmar Cambio",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            int resultado = guardarVendedor(this.txtSolicitud.Text.Trim(), Cod_vendedor);
            if (resultado <= 0)
            {
                MessageBox.Show("Error al actualizar el dato del vendedor", "Actualizar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Datos actuliazados correctamente", "Actualizar vendedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cod_compania = "";
                this.txtCodCliente.Text = "";
                this.txtSolicitud.Text = "";
                this.txtNomCliente.Text = "";
                this.txtCodAsesor.Text = "";
                this.txtNomAsesor.Text = "";
                this.txtCodAsesorN.Text = "";
                this.txtNomAsesorN.Text = "";
                Cod_vendedor = 0;
                Nombre_Vendedor = "";

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
               
            List<Permisos> Listado = new List<Permisos>();
           
            MessageBox.Show("Hola");
        }

       

    }
}
