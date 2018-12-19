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
using Logica;
using Datos;
using System.Configuration;

namespace AppEscritorio.Captacion
{
    public partial class FrmAhorros : Form
    {
        public decimal total;
        List<estructuras.ahorrosP> ListaA;
        CapaLogica objCapaLogica;



        public FrmAhorros()
        {
            InitializeComponent();
        }


        private string connectionStringO()
        {
            return ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            //return "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        }


        private int EjecutaComandoOracle(string sentencia)
        {
            int resultado;
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand(sentencia, connORA);
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
                MessageBox.Show("error al ejecutar sentencia " + ex.Message);
            }
            return resultado;
        }
            

        private void FrmAhorros_Load(object sender, EventArgs e)
        {
            cmbAhorro.DataSource = null;
            cmbAhorros.DataSource = null;
            cmbAhorroP.DataSource = null;
            MostrarAhorros();
            MostrarAhorrosP();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodCliente_Validating(object sender, CancelEventArgs e)
        {
            string id = this.txtCodCliente.Text.Trim();
                if(id == ""){
                    return;
                }
                validaCliente(id);
        }

        private void validaCliente(string id)
        {
            
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT NOM_CLIENTE FROM CLIENTES.CL_CLIENTES WHERE COD_CLIENTE = " + id.Trim() + "", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            this.txtNomCliente.Text = (String)SqlDR["NOM_CLIENTE"].ToString();
                        }
                        validaAhorros(id);
                    }
                    else {
                        this.txtNomCliente.Text = "No existe este cliente";
                    }
                        SqlDR.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNomCliente.Text = "error en la consulta";
            }
            
        }

        private void validaAhorros(string id)
        {
            List<string> lista = new List<string>();

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT (TO_CHAR(NUM_CONTRATO)|| '-' || TO_CHAR(IND_INVERSION)|| '-' || DES_INVERSION) AHORROS FROM INVERSIONES.IN_CINVERSION A " +
                    " JOIN INVERSIONES.IN_TIPOS_INV B ON A.IND_INVERSION = B.COD_INVERSION WHERE A.COD_CLIENTE = " + id, connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            lista.Add((String)SqlDR["AHORROS"].ToString());
                        }
                    }
                    else
                    {
                        this.txtNomCliente.Text = "No existe este cliente";
                    }
                    SqlDR.Close();

                    this.cmbAhorro.DataSource = lista;

                    //MessageBox.Show(this.cmbAhorro.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AHORROS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNomCliente.Text = "error en la consulta";
            }

        }


        private void MostrarAhorros()
        {
            List<string> lista = new List<string>();

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT COD_INVERSION || '-' || DES_INVERSION  AHORRO FROM INVERSIONES.IN_TIPOS_INV ORDER BY COD_INVERSION", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            lista.Add((String)SqlDR["AHORRO"].ToString());
                        }
                    }
                    else
                    {
                        
                    }
                    SqlDR.Close();

                    this.cmbAhorros.DataSource = lista;

                    //MessageBox.Show(this.cmbAhorro.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "CONSULTA DE AHORROS", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

        }


        private void MostrarAhorrosP()
        {
            List<string> lista = new List<string>();

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT COD_INVERSION || '-' || DES_INVERSION  AHORRO FROM INVERSIONES.IN_TIPOS_INV WHERE COD_INVERSION IN ('201','202','206','207') ORDER BY COD_INVERSION", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            lista.Add((String)SqlDR["AHORRO"].ToString());
                        }
                    }
                    else
                    {

                    }
                    SqlDR.Close();

                    this.cmbAhorroP.DataSource = lista;

                    //MessageBox.Show(this.cmbAhorro.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "CONSULTA DE AHORROS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string id = this.txtCodCliente.Text.Trim();
                if(id == ""){
                    return;
                }
                validaCliente(id);
            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbAhorro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.cmbAhorro.SelectedValue.ToString().Split('-')[0]);
            cargarMontos(Convert.ToInt32( this.cmbAhorro.SelectedValue.ToString().Split('-')[0]));
        }

        private void cargarMontos(int contrato)
        {
            total = 0;

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT (MON_SALDO + MON_BLOQUEADO) TOTAL, MON_SALDO, MON_BLOQUEADO FROM INVERSIONES.IN_CINVERSION A WHERE A.NUM_CONTRATO = " + contrato, connORA);
                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            total = (decimal)SqlDR["TOTAL"];
                            //this.txtMontoB.Text = SqlDR["MON_BLOQUEADO"].ToString();
                            this.txtMontoB.Text = string.Format("{0:#,##0.00}", double.Parse(SqlDR["MON_BLOQUEADO"].ToString()));
                            this.txtMontoD.Text = string.Format("{0:#,##0.00}", double.Parse(SqlDR["MON_SALDO"].ToString()));
                            //this.txtMontoD.Text = SqlDR["MON_SALDO"].ToString(); 
                        }
                    }
                    else
                    {
                        this.txtNomCliente.Text = "No existe este cliente";
                    }
                    SqlDR.Close();
                    //MessageBox.Show(this.cmbAhorro.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNomCliente.Text = "error en la consulta";
            }
        }


        private void cargarAhorros(string ahorro, string fecha, string fecha2)
        {
            ListaA = new List<estructuras.ahorrosP>();
            estructuras.ahorrosP ahorroP = null;

            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT A.COD_CLIENTE,B.NOM_CLIENTE,A.NUM_CONTRATO,A.MON_SALDO_REAL,FEC_VENCIMIENTO FROM INVERSIONES.IN_CINVERSION A JOIN CLIENTES.CL_CLIENTES B ON A.COD_CLIENTE = B.COD_CLIENTE WHERE A.IND_INVERSION = :1 AND (TO_DATE(A.FEC_VENCIMIENTO) BETWEEN to_date(:2,'DD/MM/YYYY') and to_date(:3,'DD/MM/YYYY') OR A.FEC_VENCIMIENTO IS NULL) and A.MON_SALDO_REAL > 0  ORDER BY FEC_VENCIMIENTO,NOM_CLIENTE", connORA);
                    Query.CommandType = CommandType.Text;
                    Query.Parameters.Add(new OracleParameter("IND_INVERSION", ahorro));
                    Query.Parameters.Add(new OracleParameter("FEC_VENCIMIENTO", fecha));
                    Query.Parameters.Add(new OracleParameter("FEC_VENCIMIENTO2", fecha2));
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            ahorroP = new estructuras.ahorrosP();
                            ahorroP.cod_cliente = (Int32)SqlDR["COD_CLIENTE"];
                            ahorroP.nom_cliente = (String)SqlDR["NOM_CLIENTE"].ToString();
                            ahorroP.num_contrato = Convert.ToInt32( SqlDR["NUM_CONTRATO"]);
                            ahorroP.mon_saldo_real = Convert.ToDecimal( SqlDR["MON_SALDO_REAL"]);
                            ahorroP.fec_vencimiento = SqlDR["FEC_VENCIMIENTO"] == DBNull.Value ? null : (DateTime?)(Convert.ToDateTime(SqlDR["FEC_VENCIMIENTO"]));
                            ahorroP.seleccionado = 0;
                            ListaA.Add(ahorroP);
                        }
                    }
                   
                    SqlDR.Close();

                    Dgahorros.DataSource = ListaA;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNomCliente.Text = "error en la consulta";
            }
        }

        private void txtMontoB_Validating(object sender, CancelEventArgs e)
        {
            decimal montoB = (decimal)0.00;
            try { montoB = Convert.ToDecimal(this.txtMontoB.Text); }
            catch (Exception ex) { montoB = (decimal)0.00; }
            
            this.txtMontoD.Text = string.Format("{0:#,##0.00}", double.Parse((total - montoB).ToString()));
            this.txtMontoB.Text = string.Format("{0:#,##0.00}", montoB);
        }

        private void txtMontoD_Validating(object sender, CancelEventArgs e)
        {
            decimal montoD = Convert.ToDecimal(0.00);
            try { montoD = Convert.ToDecimal(this.txtMontoD.Text); }
            catch (Exception ex) { montoD = (decimal)0.00; }
            this.txtMontoB.Text = string.Format("{0:#,##0.00}", double.Parse((total - montoD).ToString()));
            this.txtMontoD.Text = string.Format("{0:#,##0.00}", montoD);
        }

        private void txtMontoB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMontoD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Desea hacer el trasalado de saldos??",
                                     "Confirmar el trasaldo",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            string contrato = this.cmbAhorro.SelectedValue.ToString().Split('-')[0].Trim();
            string cliente = this.txtCodCliente.Text.Trim();
            if (Convert.ToDecimal(this.txtMontoB.Text.Trim()) < 0 || Convert.ToDecimal(this.txtMontoD.Text.Trim()) < 0)
            {
                MessageBox.Show("Error: Existen montos negativos.", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string valorb = Convert.ToDecimal(this.txtMontoB.Text.Trim()).ToString();
            string valord = Convert.ToDecimal(this.txtMontoD.Text.Trim()).ToString();
            string sentencia = "update INVERSIONES.IN_CINVERSION SET MON_BLOQUEADO =" + valorb + ",MON_SALDO=" + valord + "  WHERE NUM_CONTRATO = " + contrato + " and COD_CLIENTE = " + cliente;
            int resultado = this.EjecutaComandoOracle(sentencia);
            if (resultado <= 0)
            {
                MessageBox.Show("Error al actualizar los montos" , "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Datos actuliazados correctamente", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validaAhorros(this.txtCodCliente.Text.Trim());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void chkMasivo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMontoB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Desea hacer el trasalado masivo de saldos??",
                                     "Confirmar el trasaldo",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            string ahorro = this.cmbAhorros.SelectedValue.ToString().Split('-')[0].Trim();
            string sentencia;
            if (radioButton1.Checked)
            {
                sentencia = "update INVERSIONES.IN_CINVERSION SET MON_BLOQUEADO = MON_BLOQUEADO + MON_SALDO,MON_SALDO= 0.00  WHERE IND_INVERSION = '" + ahorro + "'";
            }
            else
            {
                sentencia = "update INVERSIONES.IN_CINVERSION SET MON_SALDO = MON_SALDO + MON_BLOQUEADO,MON_BLOQUEADO = 0.00  WHERE IND_INVERSION = '" + ahorro + "'";
                
            }



            int resultado = this.EjecutaComandoOracle(sentencia);
            if (resultado <= 0)
            {
                MessageBox.Show("Error al actualizar los montos", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Datos actuliazados correctamente", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.cargarAhorros(this.cmbAhorroP.SelectedValue.ToString().Split('-')[0], dtFecha.Value.ToShortDateString(), dtFecha2.Value.ToShortDateString());
        }

        private void cmbAhorroP_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbAhorroP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarAhorros(this.cmbAhorroP.SelectedValue.ToString().Split('-')[0], dtFecha.Value.ToShortDateString(), dtFecha2.Value.ToShortDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Desea realizar el traslado de los saldos?",
                                     "Confirmar el trasaldo",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            int tipo = (this.rdb1.Checked ? 1 : 0);
            int error = 0;



            var lista = (from lst in ListaA
                         where lst.seleccionado == 1
                         select new { lst.num_contrato, lst.cod_cliente }).ToList();

            foreach(var a in lista)
            {
                if(EjecutarTraslado(tipo,a.num_contrato,a.cod_cliente) != 1){
                    error = 1;
                    break;
                }
            }

            if (error == 1)
            {
                MessageBox.Show("Error al actualizar los montos. No se actualizaron todos los contratos, favor revisar.", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Datos actuliazados correctamente", "ACTUALIAR MONTOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.cargarAhorros(this.cmbAhorroP.SelectedValue.ToString().Split('-')[0], dtFecha.Value.ToShortDateString(), dtFecha2.Value.ToShortDateString());





        }

        private void chkMarcar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkMarcar.Checked){
                foreach(var ah in ListaA)
                {
                    ah.seleccionado = 1;
                }
            }
            else
            {
                foreach (var ah in ListaA)
                {
                    ah.seleccionado = 0;
                }
            }

            Dgahorros.Refresh();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            estructuras.utilidades.ExportToExcel(Dgahorros,"Ahorros");
        }



        private int EjecutarTraslado(int tipoO,int num_contrato,int cod_cliente)
        {
            int resultado = 1;
            objCapaLogica = new CapaLogica();
            AHORROS_BIT_TRAS AHB;

            
            try
            {
                if (tipoO == 1) {
                    using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                    {
                        connORA.Open();
                        OracleCommand Query = new OracleCommand("UPDATE INVERSIONES.IN_CINVERSION SET MON_SALDO = MON_SALDO + MON_BLOQUEADO ,MON_BLOQUEADO= 0.00,FEC_VENCIMIENTO = (CASE WHEN IND_INVERSION IN ('201','207') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),12) WHEN IND_INVERSION IN ('202') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),6) WHEN IND_INVERSION IN ('206') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),60) ELSE NVL(FEC_VENCIMIENTO,GETDATE) END)  WHERE NUM_CONTRATO = :1 and COD_CLIENTE = :2 ", connORA);
                        Query.CommandType = CommandType.Text;
                        Query.Parameters.Add(new OracleParameter("NUM_CONTRATO", num_contrato));
                        Query.Parameters.Add(new OracleParameter("COD_CLIENTE", cod_cliente));
                        Query.CommandTimeout = 0;
                        int SqlR = Query.ExecuteNonQuery();
                        resultado = SqlR;
                        Query.CommandText = "commit";
                        SqlR = Query.ExecuteNonQuery();
                    }

                    AHB = new AHORROS_BIT_TRAS();
                    AHB.num_contrato = num_contrato;
                    AHB.cod_cliente = cod_cliente;
                    AHB.fecIngreso = DateTime.Now;
                    AHB.codUsuario = FrmLogin.NomUsuario;
                    AHB.accion = "TRASLADO DE SALDO Y MOVER FECHA";
                    objCapaLogica = new CapaLogica();
                    objCapaLogica.AgregarBitaAhorro(AHB);

                }
                else
                {
                    using (OracleConnection connORA = new OracleConnection(connectionStringO()))
                    {
                        connORA.Open();
                        OracleCommand Query = new OracleCommand("UPDATE INVERSIONES.IN_CINVERSION SET FEC_VENCIMIENTO = (CASE WHEN IND_INVERSION IN ('201','207') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),12) WHEN IND_INVERSION IN ('202') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),6) WHEN IND_INVERSION IN ('206') THEN ADD_MONTHS(NVL(FEC_VENCIMIENTO,GETDATE),60) ELSE NVL(FEC_VENCIMIENTO,GETDATE) END)  WHERE NUM_CONTRATO = :1 and COD_CLIENTE = :2 ", connORA);
                        Query.CommandType = CommandType.Text;
                        Query.Parameters.Add(new OracleParameter("NUM_CONTRATO", num_contrato));
                        Query.Parameters.Add(new OracleParameter("COD_CLIENTE", cod_cliente));
                        Query.CommandTimeout = 0;
                        int SqlR = Query.ExecuteNonQuery();
                        resultado = SqlR;
                        Query.CommandText = "commit";
                        SqlR = Query.ExecuteNonQuery();
                    }

                    AHB = new AHORROS_BIT_TRAS();
                    AHB.num_contrato = num_contrato;
                    AHB.cod_cliente = cod_cliente;
                    AHB.fecIngreso = DateTime.Now;
                    AHB.codUsuario = FrmLogin.NomUsuario;
                    AHB.accion = "MOVER FECHA";
                    objCapaLogica = new CapaLogica();
                    objCapaLogica.AgregarBitaAhorro(AHB);
                }

                

            }
            catch (Exception ex)
            {
                resultado = 0;
                MessageBox.Show("error al actualizar in_cinversion " + ex.Message);
            }
            return resultado;
        }


    }
}
