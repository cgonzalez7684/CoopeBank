
using Microsoft.VisualBasic;
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
//using Microsoft.SqlServer.Management.Common;

namespace AppEscritorio
{
    public partial class FrmOrdenScripts : Form
    {
        SqlCommand cmd = default(SqlCommand);
        SqlConnection conn = default(SqlConnection);
        string stringConexion = "Data Source=ajax,6293;Initial Catalog=TraceCore;Integrated Security=True";
        Dictionary<string, string> Tabla = default(Dictionary<string, string>);
        List<EScript> ListaScripts = default(List<EScript>);
        List<EScript> ListaOrdenBorrado = default(List<EScript>);
        int IdScriptRecBorrado = 0;
        int CantMaxBorrado = 0;





        public FrmOrdenScripts()
        {
            InitializeComponent();
        }


        private void Metodo2()
        {
            SqlDataAdapter adp = default(SqlDataAdapter);
            DataTable tbl = new DataTable("Scripts");
            conn = new SqlConnection(stringConexion);
            conn.Open();

            cmd = new SqlCommand("Select IdScript,NombreScripts,Motor,case when TipoBorrado = 0 then 'Delete' when TipoBorrado = 1 then 'Truncate' else 'No aplica' end as 'TipoBorrado',OrdenBorrado,AplicaMigracion,NombreSP from SecuenciaScripts");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            adp = new SqlDataAdapter(cmd);
            adp.Fill(tbl);
            DataGridView1.DataSource = tbl;
        }

        private void CargaDiccionario()
        {
            SqlDataAdapter adp = default(SqlDataAdapter);
            DataTable tbl = new DataTable("Scripts");
            SqlDataReader reader = default(SqlDataReader);
            EScript pivote = default(EScript);

            ListaScripts = new List<EScript>();


            conn = new SqlConnection(stringConexion);
            conn.Open();

            cmd = new SqlCommand("Select IdScript,NombreScripts,Motor,case when TipoBorrado = 0 then 'Delete' when TipoBorrado = 1 then 'Truncate' else 'No aplica' end as 'TipoBorrado',OrdenBorrado,AplicaMigracion,NombreSP from SecuenciaScripts");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pivote = new EScript();
                    pivote.IdScript = reader.GetInt32(0);
                    pivote.NombreScript = reader.GetString(1);
                    pivote.Motor = reader.GetString(2);
                    pivote.TipoBorrado = reader.GetString(3) == "Delete" ? 0 : reader.GetString(3) == "Truncate" ? 1 : 2;
                    pivote.OrdenBorrado = reader.GetInt32(4);
                    pivote.AplicaMigracion = reader.GetString(5);
                    pivote.NombreSP = reader.GetString(6);
                    ListaScripts.Add(pivote);
                }
            }

        }


        private void EstablecerMaximoIndiceBorrado()
        {
            SqlDataReader reader = default(SqlDataReader);
            int CantidadMaxima = 0;

            conn = new SqlConnection(stringConexion);
            conn.Open();
            cmd = new SqlCommand("Select count(IdScript) from SecuenciaScripts where TipoBorrado in (0,1,2)");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CantidadMaxima = reader.GetInt32(0);
                }

            }
            CantMaxBorrado = CantidadMaxima;
            IndiceBorrado.Maximum = CantidadMaxima;
        }


        private void ReacomodarScript2()
        {

            if (Convert.ToInt32(TxtCambio.Text) == Convert.ToInt32(TxtIdScript.Text))
            {
                System.Windows.Forms.MessageBox.Show("El indice de script a reubicar es el mismo, favor verificar");
                return;
            }


            if (Convert.ToInt32(TxtCambio.Text) < Convert.ToInt32(TxtIdScript.Text))
            {

                int inc = Convert.ToInt32(TxtIdScript.Text) - 1;

                EScript pv = default(EScript);
                EScript pvAux = new EScript
                {
                    IdScript = Convert.ToInt32(TxtCambio.Text),
                    NombreScript = TxtScript.Text.Trim(),
                    Motor = ComboBox1.Text.Trim(),
                    TipoBorrado = CbxTipoBorrado.SelectedIndex,
                    OrdenBorrado = Convert.ToInt32(IndiceBorrado.Value),
                    AplicaMigracion = chkAplicaM.Checked ? "S" : "N",
                    NombreSP = "PROC_" + TxtScript.Text.Trim().Substring(0, TxtScript.Text.Trim().Length - 4).ToUpper()
                };

                pv = ListaScripts.Find(x => x.IdScript == Convert.ToInt32(TxtIdScript.Text.Trim()));
                ListaScripts.Remove(pv);


                while ((inc >= Convert.ToInt32(TxtCambio.Text)))
                {

                    pv = ListaScripts.Find(x => x.IdScript == inc);

                    if ((pv == null))
                    {
                        inc = inc - 1;
                        continue;
                    }

                    pv.IdScript = inc + 1;


                    //Tabla(IdScript) = Convert.ToString(maximo + 1)
                    inc = inc - 1;
                }

                ListaScripts.Add(pvAux);

            }


            if (Convert.ToInt32(TxtCambio.Text) > Convert.ToInt32(TxtIdScript.Text))
            {
                int inc = Convert.ToInt32(TxtIdScript.Text) + 1;

                EScript pv = default(EScript);
                EScript pvAux = new EScript
                {
                    IdScript = Convert.ToInt32(TxtCambio.Text),
                    NombreScript = TxtScript.Text.Trim(),
                    Motor = ComboBox1.Text.Trim(),
                    TipoBorrado = CbxTipoBorrado.SelectedIndex,
                    OrdenBorrado = Convert.ToInt32(IndiceBorrado.Value)
                };

                pv = ListaScripts.Find(x => x.IdScript == Convert.ToInt32(TxtIdScript.Text.Trim()));
                ListaScripts.Remove(pv);


                while ((inc <= Convert.ToInt32(TxtCambio.Text)))
                {

                    pv = ListaScripts.Find(x => x.IdScript == inc);

                    if ((pv == null))
                    {
                        inc = inc - 1;
                        continue;
                    }

                    pv.IdScript = inc - 1;


                    //Tabla(IdScript) = Convert.ToString(maximo + 1)
                    inc = inc + 1;
                }

                ListaScripts.Add(pvAux);
            }

        }



        private void ReacomodarScript()
        {
            string IdScript = "";
            int nIdScript = -1;
            int maximo = 0;

            if (ListaScripts.Count <= 0)
            {
                return;
            }

            nIdScript = Convert.ToInt32(TxtIdScript.Text.Trim());
            maximo = ListaScripts.Count;

            if ((nIdScript > maximo))
            {
                // Tabla.Add(TxtIdScript.Text.Trim, TxtScript.Text.Trim)
                ListaScripts.Add(new EScript
                {
                    IdScript = Convert.ToInt32(TxtIdScript.Text.Trim()),
                    NombreScript = TxtScript.Text.Trim(),
                    Motor = ComboBox1.Text.Trim(),
                    TipoBorrado = CbxTipoBorrado.SelectedIndex,
                    OrdenBorrado = Convert.ToInt32(IndiceBorrado.Value),
                    AplicaMigracion = chkAplicaM.Checked ? "S" : "N",
                    NombreSP = "PROC_" + TxtScript.Text.Trim().Substring(0, TxtScript.Text.Trim().Length - 4).ToUpper()
                });

                return;
            }


            if ((ListaScripts.Exists(x => x.IdScript == Convert.ToInt32(TxtIdScript.Text.Trim()))))
            {


                EScript pv = default(EScript);



                while ((maximo >= nIdScript))
                {
                    IdScript = Convert.ToString(maximo);

                    pv = ListaScripts.Find(x => x.IdScript == maximo);

                    if ((pv == null))
                    {
                        maximo = maximo - 1;
                        continue;
                    }

                    pv.IdScript = maximo + 1;


                    //Tabla(IdScript) = Convert.ToString(maximo + 1)
                    maximo = maximo - 1;
                }

                ListaScripts.Add(new EScript
                {
                    IdScript = Convert.ToInt32(TxtIdScript.Text.Trim()),
                    NombreScript = TxtScript.Text.Trim(),
                    Motor = ComboBox1.Text.Trim(),
                    TipoBorrado = CbxTipoBorrado.SelectedIndex,
                    OrdenBorrado = Convert.ToInt32(IndiceBorrado.Value),
                    AplicaMigracion = chkAplicaM.Checked ? "S" : "N",
                    NombreSP = "PROC_" + TxtScript.Text.Trim().Substring(0, TxtScript.Text.Trim().Length - 4).ToUpper()
                });



            }
        }


        private void RecargarTabla()
        {

            conn = new SqlConnection(stringConexion);
            conn.Open();

            cmd = new SqlCommand("Truncate Table SecuenciaScripts");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();



            int contador = 1;
            EScript PV = default(EScript);
            while ((contador <= ListaScripts.Count))
            {
                PV = ListaScripts.Find(x => x.IdScript == contador);
                if ((PV == null))
                {
                    contador = contador + 1;
                    continue;
                }
                cmd = new SqlCommand("Insert into SecuenciaScripts (NombreScripts,Motor,TipoBorrado,OrdenBorrado,AplicaMigracion,NombreSP) values('" + PV.NombreScript + "','" + PV.Motor + "'," + PV.TipoBorrado.ToString() + "," + PV.OrdenBorrado.ToString() + ",'" + PV.AplicaMigracion + "','" + PV.NombreSP + "')");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                contador = contador + 1;
            }
        }



        private void CambioScripts()
        {
            EScript PVAnt = default(EScript);
            EScript PVDes = default(EScript);
            int Antes = 0;
            int Despues = 0;

            Antes = Convert.ToInt32(TxtIdScript.Text);
            Despues = Convert.ToInt32(TxtCambio.Text);

            if ((ListaScripts.Exists(x => x.IdScript == Despues)))
            {
                PVAnt = ListaScripts.Find(x => x.IdScript == Antes);
                PVDes = ListaScripts.Find(x => x.IdScript == Despues);
                PVAnt.IdScript = Despues;
                PVDes.IdScript = Antes;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No existe el indice de script indicado, favor verificar");
                TxtCambio.Text = "";
                TxtCambio.Focus();
                return;
            }

            RecargarTabla();
            Metodo2();

            TxtCambio.Text = "";
            TxtCambio.Visible = false;
            CheckBox1.Checked = false;

            TxtIdScript.Enabled = false;
            TxtScript.Enabled = false;
            CheckBox1.Visible = true;
            TxtIdScript.Focus();
            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1;
            DataGridView1.ClearSelection();
            DataGridView1.Rows[DataGridView1.RowCount - 1].Selected = true;
            TxtIdScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[0].Value.ToString();
            TxtScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[1].Value.ToString();
            BtnNuevo.Text = "Incorporar";
        }


        private void ModicarIndiceBorrado()
        {
            //  IndiceBorrado.Value esta vinculado a un IdScript, el mismo lo tenemos que obter ya que es un cambio

            int IndiceBorradoActual = 0;
            int IndiceBorradoRemplazar = 0;
            int IndiceScriptActual = Convert.ToInt32(DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[0].Value);
            IndiceBorradoActual = Convert.ToInt32(DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[4].Value);
            IndiceBorradoRemplazar = Convert.ToInt32(IndiceBorrado.Value);



            if ((IndiceBorradoActual != IndiceBorradoRemplazar))
            {
                //Obtenemos el indice de borrado del script que tiene el indice de borrado a remplazar
                int IdScriptRemplazar = 0;
                SqlDataReader reader = default(SqlDataReader);
                conn = new SqlConnection(stringConexion);
                conn.Open();
                cmd = new SqlCommand("Select IdScript from SecuenciaScripts where OrdenBorrado =" + IndiceBorradoRemplazar.ToString());
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IdScriptRemplazar = reader.GetInt32(0);
                    }

                    //Actualizamos del script us indice de orden de borrado
                    conn = new SqlConnection(stringConexion);
                    conn.Open();
                    cmd = new SqlCommand("Update SecuenciaScripts set OrdenBorrado = " + IndiceBorradoActual.ToString() + " Where IdScript = " + IdScriptRemplazar.ToString());
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    //Actualizamo el script con el nuevo indice de borrado
                    conn = new SqlConnection(stringConexion);
                    conn.Open();
                    cmd = new SqlCommand("Update SecuenciaScripts set OrdenBorrado = " + IndiceBorradoRemplazar.ToString() + " Where IdScript = " + IndiceScriptActual.ToString());
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
            }

        }


        private void CargaListaBorrado()
        {
            SqlDataReader dr = default(SqlDataReader);
            //conn = New SqlConnection("Data Source=coope-ti04;Initial Catalog=Migracion;Integrated Security=True")
            conn = new SqlConnection("Data Source=ajax,6293;Initial Catalog=TraceCore;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("Select IdScript,OrdenBorrado,case when TipoBorrado = 0 then 'Delete' when TipoBorrado = 1 then 'Truncate' else 'No aplica' end as 'TipoBorrado',NombreScripts,0 as 'Cant','' as 'HoraInicio','' as 'HoraFin' from SecuenciaScripts order by OrdenBorrado asc");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            ListaOrdenBorrado = new List<EScript>();

            while ((dr.Read()))
            {
                ListaOrdenBorrado.Add(new EScript
                {
                    IdScript = dr.GetInt32(0),
                    OrdenBorrado = dr.GetInt32(1),
                    NombreScript = dr.GetString(3)
                });
            }
        }


        private void ActualizarOrdenBorrado()
        {
            //Hago una copia del elemento al que se le va a cambiar el IndiceBorrado
            EScript pv = default(EScript);
            int idx = 0;
            pv = ListaOrdenBorrado.Find(x => x.IdScript == IdScriptRecBorrado);
            idx = pv.OrdenBorrado;
            if ((idx == IndiceBorrado.Value))
            {
                return;
            }
            //Remuevo el elemento de la lista de borrado
            ListaOrdenBorrado.Remove(pv);
            //Reedito la copia para que tenga el nuevo indice de borrado
            pv.OrdenBorrado = Convert.ToInt32(IndiceBorrado.Value);





            if ((idx > IndiceBorrado.Value))
            {
                foreach (EScript sr in ListaOrdenBorrado)
                {
                    if ((sr.OrdenBorrado < IndiceBorrado.Value))
                    {
                        continue;
                    }
                    sr.OrdenBorrado = sr.OrdenBorrado + 1;
                }
            }

            if ((idx < IndiceBorrado.Value))
            {
                foreach (EScript sr in ListaOrdenBorrado)
                {
                    if ((sr.OrdenBorrado > idx & sr.OrdenBorrado <= IndiceBorrado.Value))
                    {
                        sr.OrdenBorrado = sr.OrdenBorrado - 1;
                    }
                }
            }

            ListaOrdenBorrado.Add(pv);
            ListaOrdenBorrado.Sort((EScript a, EScript b) => { return a.OrdenBorrado.CompareTo(b.OrdenBorrado); });
        }

        private void ActualizarIdBorrado()
        {
            conn = new SqlConnection(stringConexion);
            conn.Open();


            foreach (EScript sr in ListaOrdenBorrado)
            {
                cmd = new SqlCommand("Update SecuenciaScripts set OrdenBorrado = " + sr.OrdenBorrado.ToString() + " Where IdScript = " + sr.IdScript.ToString());
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            TxtIdScript.Text = DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            TxtScript.Text = DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            ComboBox1.SelectedIndex = DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[2].Value.ToString() == "SQL" ? 0 : 1;
            CbxTipoBorrado.SelectedIndex = DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[3].Value.ToString() == "Delete" ? 0 : DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[3].Value.ToString() == "Truncate" ? 1 : 2;
            chkAplicaM.Checked = DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[5].Value.ToString() == "S" ? true : false;
            IndiceBorrado.Value = Convert.ToInt32(DataGridView1.Rows[this.DataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
        }

        private void BtnModificar_Click(System.Object sender, System.EventArgs e)
        {
            TxtIdScript.Enabled = true;
            TxtScript.Enabled = true;
        }

        private void BtnNuevo_Click(System.Object sender, System.EventArgs e)
        {
            if ((BtnNuevo.Text == "Reubicar"))
            {
                CargaDiccionario();
                ReacomodarScript2();
                RecargarTabla();
                Metodo2();

                LblCambio.Text = "Indice Script a cambiar";
                LblCambio.Visible = false;

                TxtCambio.Text = "";
                TxtCambio.Visible = false;
                CheckBox1.Checked = false;

                TxtIdScript.Enabled = false;
                TxtScript.Enabled = false;
                CheckBox1.Visible = true;
                TxtIdScript.Focus();
                CheckBox2.Checked = false;
                BtnModificar.Enabled = true;

                BtnNuevo.Text = "Incorporar";
                return;
            }


            if ((BtnNuevo.Text == "Cambio"))
            {
                CargaDiccionario();
                CambioScripts();
                BtnModificar.Enabled = true;

                return;
            }

            if ((BtnNuevo.Text == "Incorporar"))
            {
                BtnNuevo.Text = "Registrar";
                TxtIdScript.Enabled = true;
                TxtScript.Enabled = true;
                ComboBox1.Enabled = true;
                CbxTipoBorrado.Enabled = true;
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                CheckBox1.Visible = false;
                CheckBox1.Checked = false;
                TxtIdScript.Focus();
                BtnModificar.Enabled = false;
                IndiceBorrado.Maximum = CantMaxBorrado + 1;
                IndiceBorrado.Value = CantMaxBorrado + 1;
                return;

            }


            if (((TxtIdScript.Text.Length <= 0) | (TxtScript.Text.Length <= 0)))
            {
                System.Windows.Forms.MessageBox.Show("Debe completar los datos");
                return;
            }

            if (((Convert.ToInt32(TxtIdScript.Text) > DataGridView1.RowCount) & ((Convert.ToInt32(TxtIdScript.Text) - DataGridView1.RowCount) >= 2)))
            {
                System.Windows.Forms.MessageBox.Show("El indice del script por ingresar debe ser consecutivo al ultimo registrado");
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                TxtIdScript.Focus();
                return;
            }


            if ((Convert.ToInt32(TxtIdScript.Text) < 1))
            {
                System.Windows.Forms.MessageBox.Show("Id Script no valido");
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                TxtIdScript.Focus();
                return;
            }


            CargaDiccionario();
            ReacomodarScript();
            RecargarTabla();
            Metodo2();
            TxtIdScript.Text = "";
            TxtScript.Text = "";

            BtnModificar.Enabled = true;
            TxtIdScript.Enabled = false;
            TxtScript.Enabled = false;
            ComboBox1.Enabled = false;
            CbxTipoBorrado.Enabled = false;
            CheckBox1.Visible = true;
            TxtIdScript.Focus();
            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1;
            DataGridView1.ClearSelection();
            DataGridView1.Rows[DataGridView1.RowCount - 1].Selected = true;
            TxtIdScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[0].Value.ToString();
            TxtScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[1].Value.ToString();
            BtnNuevo.Text = "Incorporar";


        }


        

        

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            if ((BtnModificar.Text == "Modificar"))
            {
                IdScriptRecBorrado = int.Parse(TxtIdScript.Text.Trim());
                TxtScript.Enabled = true;
                ComboBox1.Enabled = true;
                CbxTipoBorrado.Enabled = true;
                IndiceBorrado.Enabled = true;
                CheckBox1.Visible = false;
                CheckBox2.Visible = false;
                BtnModificar.Text = "Guardar";
                BtnNuevo.Enabled = false;
                return;
            }


            //ModicarIndiceBorrado() 'Se actualiza el indice de borrado

            CargaListaBorrado();
            ActualizarOrdenBorrado();
            ActualizarIdBorrado();

            conn = new SqlConnection(stringConexion);
            conn.Open();

            cmd = new SqlCommand("Update SecuenciaScripts set NombreScripts = '" + TxtScript.Text + "', Motor = '" + ComboBox1.Text.Trim() + "', TipoBorrado = " + CbxTipoBorrado.SelectedIndex.ToString().Trim() + ",AplicaMigracion = '" + (chkAplicaM.Checked == true ? "S" : "N") + "', NombreSP = '" + "PROC_" + TxtScript.Text.Trim().Substring(0, TxtScript.Text.Trim().Length - 4).ToUpper() + "' Where IdScript = " + TxtIdScript.Text.Trim());
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            TxtScript.Enabled = false;
            ComboBox1.Enabled = false;
            IndiceBorrado.Enabled = false;
            CbxTipoBorrado.Enabled = false;
            CheckBox1.Visible = true;
            CheckBox2.Visible = true;
            BtnNuevo.Enabled = true;
            BtnModificar.Text = "Modificar";

            Metodo2();
        }







        private void FrmOrdenScripts_Load_1(object sender, EventArgs e)
        {
            // Metodo1()
            EstablecerMaximoIndiceBorrado();
            Metodo2();
            ComboBox1.SelectedIndex = 1;
            CbxTipoBorrado.SelectedIndex = 0;
        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {
            if ((BtnNuevo.Text == "Reubicar"))
            {
                CargaDiccionario();
                ReacomodarScript2();
                RecargarTabla();
                Metodo2();

                LblCambio.Text = "Indice Script a cambiar";
                LblCambio.Visible = false;

                TxtCambio.Text = "";
                TxtCambio.Visible = false;
                CheckBox1.Checked = false;

                TxtIdScript.Enabled = false;
                TxtScript.Enabled = false;
                CheckBox1.Visible = true;
                TxtIdScript.Focus();
                CheckBox2.Checked = false;
                BtnModificar.Enabled = true;
                //DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
                //DataGridView1.ClearSelection()
                //DataGridView1.Rows(DataGridView1.RowCount - 1).Selected = True
                //TxtIdScript.Text = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(0).Value.ToString()
                //TxtScript.Text = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(1).Value.ToString()
                BtnNuevo.Text = "Incorporar";
                return;
            }


            if ((BtnNuevo.Text == "Cambio"))
            {
                CargaDiccionario();
                CambioScripts();
                BtnModificar.Enabled = true;

                return;
            }

            if ((BtnNuevo.Text == "Incorporar"))
            {
                BtnNuevo.Text = "Registrar";
                TxtIdScript.Enabled = true;
                TxtScript.Enabled = true;
                ComboBox1.Enabled = true;
                CbxTipoBorrado.Enabled = true;
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                CheckBox1.Visible = false;
                CheckBox1.Checked = false;
                TxtIdScript.Focus();
                BtnModificar.Enabled = false;
                IndiceBorrado.Maximum = CantMaxBorrado + 1;
                IndiceBorrado.Value = CantMaxBorrado + 1;
                return;

            }

            //Dim pv As Script
            //While (maximo >= nIdScript)
            //    IdScript = Convert.ToString(maximo)

            //    pv = ListaScripts.Find(Function(x) x.IdScript = maximo)
            //    pv.IdScript = Convert.ToString(maximo + 1)


            if (((TxtIdScript.Text.Length <= 0) | (TxtScript.Text.Length <= 0)))
            {
                System.Windows.Forms.MessageBox.Show("Debe completar los datos");
                return;
            }

            if (((Convert.ToInt32(TxtIdScript.Text) > DataGridView1.RowCount) & ((Convert.ToInt32(TxtIdScript.Text) - DataGridView1.RowCount) >= 2)))
            {
                System.Windows.Forms.MessageBox.Show("El indice del script por ingresar debe ser consecutivo al ultimo registrado");
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                TxtIdScript.Focus();
                return;
            }


            if ((Convert.ToInt32(TxtIdScript.Text) < 1))
            {
                System.Windows.Forms.MessageBox.Show("Id Script no valido");
                TxtIdScript.Text = "";
                TxtScript.Text = "";
                TxtIdScript.Focus();
                return;
            }


            CargaDiccionario();
            ReacomodarScript();
            RecargarTabla();
            Metodo2();
            TxtIdScript.Text = "";
            TxtScript.Text = "";

            BtnModificar.Enabled = true;
            TxtIdScript.Enabled = false;
            TxtScript.Enabled = false;
            ComboBox1.Enabled = false;
            CbxTipoBorrado.Enabled = false;
            CheckBox1.Visible = true;
            TxtIdScript.Focus();
            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1;
            DataGridView1.ClearSelection();
            DataGridView1.Rows[DataGridView1.RowCount - 1].Selected = true;
            TxtIdScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[0].Value.ToString();
            TxtScript.Text = DataGridView1.Rows[DataGridView1.RowCount - 1].Cells[1].Value.ToString();
            //DataGridView1.Refresh()

            BtnNuevo.Text = "Incorporar";
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                TxtCambio.Visible = true;
                LblCambio.Visible = true;
                LblCambio.Text = "Indice Script a reubicar";
                BtnNuevo.Text = "Reubicar";
                BtnModificar.Enabled = false;
            }
            else
            {
                TxtCambio.Visible = false;
                LblCambio.Visible = false;
                BtnNuevo.Text = "Incorporar";
            }
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                TxtCambio.Visible = true;
                LblCambio.Visible = true;
                BtnNuevo.Text = "Cambio";
                BtnModificar.Enabled = false;
            }
            else
            {
                TxtCambio.Visible = false;
                LblCambio.Visible = false;
                BtnNuevo.Text = "Incorporar";
            }
        }






    }
}
