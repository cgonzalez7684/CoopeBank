using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Globalization;
using System.IO;
using Microsoft.SqlServer;

namespace AppEscritorio.Captacion
{
    public partial class FrmCertiCredito : Form
    {

        //Dim stringConexion As String = "Data Source=coope-ti04;Initial Catalog=MIGRACION;Integrated Security=True"
        //string stringConexion = "Data Source=rin\MIGRACION;Initial Catalog=TraceCore;Integrated Security=True";
        string stringConexion = "Data Source=rin\\MIGRACION;Initial Catalog=TraceCore;User ID=CaseData;Password=Coopecaja1";
        List<CertiCredito> ListaCerti = null;
        int? idActual = null;
        string cidasociant = "";



        public FrmCertiCredito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var confirmResult = System.Windows.Forms.MessageBox.Show("Desea guardar los datos??",
                                     "Confirmar",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            
            if (this.txtAsociado.Text.Trim() == "" || this.txtNombre.Text.Trim() == "" || this.txtOperacion.Text.Trim() == "" || this.txtLinea.Text.Trim() == "" || this.txtTitulo.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Datos Incompletos ", "Debe digitar todos los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.txtNombre.Text.Trim() == "El asociado no existe" || this.txtLinea.Text.Trim() == "No existe el crédito o no corresponde al asociado seleccionado" || this.txtTitulo.Text.Trim() == "Número de certificado incorrecto o no pertenece al asociado")
            {
                System.Windows.Forms.MessageBox.Show("Datos incorrectos ", "Algunos datos digitados son incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string cAsociado = this.txtAsociado.Text.Trim();
            string cNombre = this.txtNombre.Text.Trim();
            string cOperacion = this.txtOperacion.Text.Trim();
            string cLinea = this.txtLinea.Text.Trim();
            int nTitulo = Int32.Parse(this.txtTitulo.Text.Trim());

            if (idActual == null)
            {
                this.insertarDatos(cAsociado, cNombre, cOperacion, cLinea, nTitulo);
            }
            else
            {
                this.actualizarDatos(cAsociado, cNombre, cOperacion, cLinea, nTitulo, idActual);
            }

            
        }

        private List<CertiCredito> listaC()
        {
            List<CertiCredito> lista = new List<CertiCredito>();
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("SELECT * FROM TraceCore..certicredito order by Titulo", conn);
                    Query.CommandType = CommandType.Text;
                    SqlDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {
                            CertiCredito CertiCreditoN = new CertiCredito()
                            {
                                Operacion = (String)SqlDR["Operacion"],
                                Linea = (String)SqlDR["Linea"],
                                Asociado = (String)SqlDR["Asociado"],
                                Asociado1 = (String)SqlDR["Asociado1"],
                                Titulo = (Int32)SqlDR["Titulo"],
                                id = (Int32)SqlDR["id"]
                            };
                            lista.Add(CertiCreditoN);
                        }
                    }
                    else

                    SqlDR.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ERROR EN LISTA: " + e.Message, "Error obteniendo el listado de certificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }



        private void getNombre(string cidasociad)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("SELECT cnombrecom FROM covi001..asmaestras where cidasociad = @cidasociad", conn);
                    Query.CommandType = CommandType.Text;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@cidasociad";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = cidasociad;
                    Query.Parameters.Add(parameter);


                    SqlDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {

                            this.txtNombre.Text = (String)SqlDR["cnombrecom"];

                           
                        }
                    }
                    else { 
                        this.txtNombre.Text = "El asociado no existe";
                        SqlDR.Close();
                    }
                }

                this.txtTitulo.Text = "0";
                this.txtOperacion.Text = "";
                this.txtLinea.Text = "";
                this.txtCerti.Text = "";
                this.txtCerti.Visible = false;
                this.txtOperacion.Focus();
            }
            catch (Exception e)
            {
                this.txtNombre.Text = "error";
                System.Windows.Forms.MessageBox.Show("nombre asociado: " + e.Message, "Error obteniendo el nombre del asociado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void getLinea(string cnumoperac, string cidasociad)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("select cdetalleli from covi001..crprestamo inner join covi001..crcodlinea on crprestamo.ccodigolin = crcodlinea.ccodigolin where crprestamo.cnumoperac = @cnumoperac and crprestamo.cidasociad = @cidasociad", conn);
                    Query.CommandType = CommandType.Text;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@cnumoperac";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = cnumoperac;
                    Query.Parameters.Add(parameter);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@cidasociad";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = cidasociad;
                    Query.Parameters.Add(parameter2);


                    SqlDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {

                            this.txtLinea.Text = (String)SqlDR["cdetalleli"];

                        }
                    }
                    else
                    {
                        this.txtLinea.Text = "No existe el crédito o no corresponde al asociado seleccionado";
                        SqlDR.Close();
                    }
                }
            }
            catch (Exception e)
            {
                this.txtLinea.Text = "error";
                System.Windows.Forms.MessageBox.Show("Linea de credito: " + e.Message, "Error obteniendo la linea de credito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void verificaCerti(int titulo, string cidasociad)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("select * from covi001..ivcerdeppl where convert(int,cnuminvers) = @titulo and cidasociad = @cidasociad", conn);
                    Query.CommandType = CommandType.Text;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@titulo";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = titulo;
                    Query.Parameters.Add(parameter);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@cidasociad";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = cidasociad;
                    Query.Parameters.Add(parameter2);


                    SqlDataReader SqlDR = Query.ExecuteReader();

                    if (SqlDR.HasRows)
                    {
                        while (SqlDR.Read())
                        {

                            this.txtCerti.Text = "";
                            this.txtCerti.Visible = false;

                        }
                    }
                    else
                    {
                        SqlDR.Close();
                        this.txtCerti.Text = "Número de certificado incorrecto o no pertenece al asociado";
                        this.txtCerti.Visible = true;
                        
                    }
                }
            }
            catch (Exception e)
            {
                this.txtCerti.Text = "ERROR EN LA CONSULTA";
                this.txtCerti.Visible = true;
            }

        }

        private void insertarDatos(string cidasociad,string nombre, string credito,string linea, int titulo)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("insert into TraceCore..certicredito (Operacion,Asociado,Linea,Asociado1,Titulo) values (@Operacion,@Asociado,@Linea,@Asociado1,@Titulo)", conn);
                    Query.CommandType = CommandType.Text;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@Operacion";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = credito;
                    Query.Parameters.Add(parameter);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@Asociado";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = cidasociad;
                    Query.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@Linea";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = linea;
                    Query.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter();
                    parameter4.ParameterName = "@Asociado1";
                    parameter4.SqlDbType = SqlDbType.VarChar;
                    parameter4.Direction = ParameterDirection.Input;
                    parameter4.Value = nombre;
                    Query.Parameters.Add(parameter4);

                    SqlParameter parameter5 = new SqlParameter();
                    parameter5.ParameterName = "@Titulo";
                    parameter5.SqlDbType = SqlDbType.Int;
                    parameter5.Direction = ParameterDirection.Input;
                    parameter5.Value = titulo;
                    Query.Parameters.Add(parameter5 );

                    Query.ExecuteNonQuery();

                    ListaCerti = listaC();
                    dtgCerti.DataSource = ListaCerti;


                    System.Windows.Forms.MessageBox.Show("Datos" , "Datos Insertados Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            catch (Exception e)
            {
                this.txtNombre.Text = "error";
                System.Windows.Forms.MessageBox.Show("Insercion de datos: " + e.Message, "Error insertando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void actualizarDatos(string cidasociad, string nombre, string credito, string linea, int titulo,int? id)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("update TraceCore..certicredito set Operacion = @Operacion,Asociado = @Asociado, Linea = @Linea, Asociado1 = @Asociado1,Titulo = @Titulo where id = @id", conn);
                    Query.CommandType = CommandType.Text;
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@Operacion";
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = credito;
                    Query.Parameters.Add(parameter);

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@Asociado";
                    parameter2.SqlDbType = SqlDbType.VarChar;
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = cidasociad;
                    Query.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@Linea";
                    parameter3.SqlDbType = SqlDbType.VarChar;
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = linea;
                    Query.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter();
                    parameter4.ParameterName = "@Asociado1";
                    parameter4.SqlDbType = SqlDbType.VarChar;
                    parameter4.Direction = ParameterDirection.Input;
                    parameter4.Value = nombre;
                    Query.Parameters.Add(parameter4);

                    SqlParameter parameter5 = new SqlParameter();
                    parameter5.ParameterName = "@Titulo";
                    parameter5.SqlDbType = SqlDbType.Int;
                    parameter5.Direction = ParameterDirection.Input;
                    parameter5.Value = titulo;
                    Query.Parameters.Add(parameter5);

                    SqlParameter parameter6 = new SqlParameter();
                    parameter6.ParameterName = "@id";
                    parameter6.SqlDbType = SqlDbType.Int;
                    parameter6.Direction = ParameterDirection.Input;
                    parameter6.Value = id;
                    Query.Parameters.Add(parameter6);

                    Query.ExecuteNonQuery();

                    ListaCerti = listaC();
                    dtgCerti.DataSource = ListaCerti;

                    System.Windows.Forms.MessageBox.Show("Datos", "Datos modificados Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception e)
            {
                this.txtNombre.Text = "error";
                System.Windows.Forms.MessageBox.Show("modificacion de datos: " + e.Message, "Error modificando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void eliminarDatos(int? id)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(stringConexion))
                {
                    conn.Open();
                    SqlCommand Query = new SqlCommand("delete from  TraceCore..certicredito where id = @id", conn);
                    Query.CommandType = CommandType.Text;
                    
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@id";
                    parameter.SqlDbType = SqlDbType.Int;
                    parameter.Direction = ParameterDirection.Input;
                    parameter.Value = id;
                    Query.Parameters.Add(parameter);

                    Query.ExecuteNonQuery();

                    ListaCerti = listaC();
                    dtgCerti.DataSource = ListaCerti;
                    dtgCerti.Refresh();

                    System.Windows.Forms.MessageBox.Show("Datos", "Datos eliminados Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception e)
            {
                this.txtNombre.Text = "error";
                System.Windows.Forms.MessageBox.Show("eliminando datos: " + e.Message, "Error eliminando los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmCertiCredito_Load(object sender, EventArgs e)
        {
            ListaCerti = listaC();
            dtgCerti.DataSource = ListaCerti;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.txtOperacion.Text = "";
            this.txtLinea.Text = "";
            this.txtAsociado.Text = "";
            this.txtNombre.Text = "";
            this.txtTitulo.Text = "";
            idActual = null;
            this.btnGuardar.Text = "Guardar";
        }

        private void dtgCerti_SelectionChanged(object sender, EventArgs e)
        {

            
            int indice = dtgCerti.CurrentCell.RowIndex;

            if (indice <= ListaCerti.Count-1)
            {
                idActual = ListaCerti[indice].id;
                this.txtAsociado.Text = ListaCerti[indice].Asociado;
                this.txtNombre.Text = ListaCerti[indice].Asociado1;
                this.txtOperacion.Text = ListaCerti[indice].Operacion;
                this.txtLinea.Text = ListaCerti[indice].Linea;
                this.txtTitulo.Text = ListaCerti[indice].Titulo.ToString();
                this.btnGuardar.Text = "Actualizar";
                cidasociant = this.txtAsociado.Text.Trim();
            }
            else
            {
                this.btnAgregar_Click(sender,e);
            }

            

        }

        private void txtAsociado_Validated(object sender, EventArgs e)
        {
            if (cidasociant == this.txtAsociado.Text.Trim()){
                return;
            }

            if (this.txtAsociado.Text.Trim() != "")
            {
                this.getNombre(this.txtAsociado.Text.Trim());
            }
            cidasociant = this.txtAsociado.Text.Trim();
        }

        private void txtAsociado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOperacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string cidasociad = this.txtAsociado.Text.Trim();
            if (this.txtOperacion.Text.Trim() != "")
            {
                this.getLinea(this.txtOperacion.Text.Trim(), cidasociad);
            }
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idActual == null)
            {

                return;
            }
            var confirmResult = System.Windows.Forms.MessageBox.Show("Desea eliminar los datos??",
                                    "Confirmar",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
            this.eliminarDatos(idActual);
        }

        private void dtgCerti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgCerti_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if (dtgCerti.Columns[e.ColumnIndex].HeaderText.Trim() == "Operación")
            {
                ListaCerti.Sort(delegate(CertiCredito x, CertiCredito y)
                {
                    return x.Operacion.CompareTo(y.Operacion);
                });

                dtgCerti.DataSource = ListaCerti;
                dtgCerti.Refresh();
            }
            if (dtgCerti.Columns[e.ColumnIndex].HeaderText.Trim() == "Línea")
            {
                ListaCerti.Sort(delegate(CertiCredito x, CertiCredito y)
                {
                    return x.Linea.CompareTo(y.Linea);
                });

                dtgCerti.DataSource = ListaCerti;
                dtgCerti.Refresh();
            }
            if (dtgCerti.Columns[e.ColumnIndex].HeaderText.Trim() == "Asociado")
            {
                ListaCerti.Sort(delegate(CertiCredito x, CertiCredito y)
                {
                    return x.Asociado.CompareTo(y.Asociado);
                });

                dtgCerti.DataSource = ListaCerti;
                dtgCerti.Refresh();
            }
            if (dtgCerti.Columns[e.ColumnIndex].HeaderText.Trim() == "Nombre")
            {
                ListaCerti.Sort(delegate(CertiCredito x, CertiCredito y)
                {
                    return x.Asociado1.CompareTo(y.Asociado1);
                });

                dtgCerti.DataSource = ListaCerti;
                dtgCerti.Refresh();
            }

            if (dtgCerti.Columns[e.ColumnIndex].HeaderText.Trim() == "Título")
            {
                ListaCerti.Sort(delegate(CertiCredito x, CertiCredito y)
                {
                    return x.Titulo.CompareTo(y.Titulo);
                });

                dtgCerti.DataSource = ListaCerti;
                dtgCerti.Refresh();
            }



        }

        private void txtTitulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string cidasociad = this.txtAsociado.Text.Trim();
            int titulo = Int32.Parse( this.txtTitulo.Text.Trim());
            if (this.txtTitulo.Text.Trim() != "")
            {
                this.verificaCerti(titulo, cidasociad);
            }

        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }
        

    }
}
