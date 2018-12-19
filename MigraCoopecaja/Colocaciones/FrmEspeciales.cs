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


namespace AppEscritorio.Colocaciones
{
    public partial class FrmEspeciales : Form
    {
        public FrmEspeciales()
        {
            InitializeComponent();
        }


        private string connectionStringO()
        {
            ////return "user id=sys;password=Neo369OraServ;data source=(DESCRIPTION=(ADDRESS=" + "(PROTOCOL=tcp)(HOST= " + host + ")" + "(PORT=" + puerto + "))(CONNECT_DATA=" + "(SERVICE_NAME= " + server + ")));DBA PRIVILEGE=sysdba";
            // return "User Id=SYS;Password=Oracle01;Data Source=UATUNO;DBA PRIVILEGE=sysdba;";
            return "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        }


        private void validaOperacion(string cnumoperac)
        {

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("select B.COD_CLIENTE,B.NOM_CLIENTE from CREDITO.CR_OPERACIONES A JOIN CLIENTES.CL_CLIENTES B ON A.COD_CLIENTE = B.COD_CLIENTE WHERE A.NUM_OPERACION = :NUMOPERAC", connORA);
                    Query.Parameters.Add(new OracleParameter("NUMOPERAC", cnumoperac));
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            this.txtCodCliente.Text = ((Int32)SqlDR["COD_CLIENTE"]).ToString();
                            this.txtNomCliente.Text = (String)SqlDR["NOM_CLIENTE"].ToString();
                        }
                    }
                    else
                    {
                        this.txtCodCliente.Text = "";
                        this.txtNomCliente.Text = "";
                        this.txtOperacion.Text = "";
                        MessageBox.Show("Error","Error: No existe la operacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SqlDR.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodCliente.Text = "";
                this.txtNomCliente.Text = "";
                this.txtOperacion.Text = "";
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            validaOperacion(this.txtOperacion.Text);
        }

        private int EjecutarOracle(string cnumoperac,string sentencia)
        {
            int resultado;
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand(sentencia, connORA);
                    Query.Parameters.Add(new OracleParameter("NUMOPERAC", cnumoperac));
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 0;
                    int SqlR = Query.ExecuteNonQuery();
                    resultado = SqlR;
                    Query.CommandText = "commit";
                    SqlR = Query.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                resultado = 0;
                MessageBox.Show("error al eliminar de la bitacora de apunto de ser especial" + ex.Message);
            }
            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commando = null;
            int resultado = 0;
            string operacion = this.txtOperacion.Text.Trim();
            if (operacion == "")
            {
                return;
            }


            var confirmResult = MessageBox.Show("Desea ejecutar el proceso??",
                                     "Confirmar proceso",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            if (rdbApunto.Checked)
            {
                commando = "DELETE FROM CREDITO.CR_BIT_ESPECIALES WHERE NUM_OPERACION = :NUMOPERAC";
            }
            if (rdbEspecial.Checked)
            {
                commando = "UPDATE CREDITO.CR_OPERACIONES SET IND_ESPECIAL = 'S' WHERE NUM_OPERACION = :NUMOPERAC";
            }
            if (rdbNoEspecial.Checked)
            {
                commando = "UPDATE CREDITO.CR_OPERACIONES SET IND_ESPECIAL = 'N' WHERE NUM_OPERACION = :NUMOPERAC";
            }

            resultado = EjecutarOracle(operacion,commando);
            if (resultado <= 0)
            {
                MessageBox.Show("Error al actualizar los datos", "ACTUALIAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Datos actuliazados correctamente", "ACTUALIAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void FrmEspeciales_Load(object sender, EventArgs e)
        {

        }



    }


   
}
