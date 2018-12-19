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
    public partial class FrmBuscaVendedor : Form
    {
        string Cod_compania = "";
        string connectionStringO = "";
        List<estructuras.vendedores> listaVendedor;
        public FrmBuscaVendedor(string codcompania,string ConnectionString)
        {
            InitializeComponent();
            Cod_compania = codcompania;
            connectionStringO = ConnectionString;
            listaVendedor = ListaVendedores(Cod_compania,"","");
            dtgVendedores.DataSource = listaVendedor;

            

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try 
            {
                Colocaciones.FrmCambVend.Cod_vendedor = listaVendedor[dtgVendedores.CurrentCell.RowIndex].cod_vendedor;
                Colocaciones.FrmCambVend.Nombre_Vendedor = listaVendedor[dtgVendedores.CurrentCell.RowIndex].nombre_vendedor;
               
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se seleccionó ningún vendedor", "VENDEDORES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<estructuras.vendedores> ListaVendedores(string cod_compania,string cod_vendedor,string nom_vendedor)
        {
            List<estructuras.vendedores> listav = new List<estructuras.vendedores>();
            estructuras.vendedores vendedor = null;
            string sentencia = "SELECT COD_VENDEDOR,NOMBRE_VENDEDOR FROM FVENTAS.FV_VENDEDORES WHERE COD_COMPANIA = :1 ";

            if (cod_vendedor.Trim() != "")
            {
                sentencia = sentencia + " AND COD_VENDEDOR = " + cod_vendedor.Trim();
            }
            if (nom_vendedor.Trim() != "")
            {
                sentencia = sentencia + " AND NOMBRE_VENDEDOR LIKE '" + nom_vendedor.ToUpper().Trim() + "'";
            }
            sentencia = sentencia + " ORDER BY COD_VENDEDOR";
            
            try
            {
                using (OracleConnection connORA = new OracleConnection(connectionStringO))
                {
                    connORA.Open();
                    OracleCommand Query = new OracleCommand(sentencia, connORA);
                    Query.CommandType = CommandType.Text;
                    Query.Parameters.Add(new OracleParameter("COD_COMPANIA", cod_compania));
                    Query.CommandTimeout = 10000;

                    OracleDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            vendedor = new estructuras.vendedores();
                            vendedor.cod_vendedor = (Int32)SqlDR["COD_VENDEDOR"];
                            vendedor.nombre_vendedor = (String)SqlDR["NOMBRE_VENDEDOR"].ToString();
                            listav.Add(vendedor);
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
                MessageBox.Show("Error: " + ex.Message, "SOLICITUDES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listav;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Colocaciones.FrmCambVend.Cod_vendedor = 0;
            Colocaciones.FrmCambVend.Nombre_Vendedor = "";
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listaVendedor = ListaVendedores(Cod_compania, this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim());
            dtgVendedores.DataSource = listaVendedor;
        }

    }
}
