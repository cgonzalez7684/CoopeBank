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
using System.Security.Cryptography;
using System.Text;
using System.Configuration;


namespace AppEscritorio.General
{
    public partial class FrmUsuarios : Form
    {

        #region "Propiedades"
          
            private CapaLogica objCapaLogica;
            private List<Usuarios> ListadoUsuarios;
            private int IdObjeto;
            private string RespuestaValidacion;
         
           
        #endregion

        #region "Metodos propios"


            //Metodo para limipiar los controles de ingreso de datos
            private void InicializarControles()
            {
                TxtNombre.Text = "";
                TxtApellido1.Text = "";
                TxtApellido2.Text = "";
                TxtClave.Text = "";
                TxtCorreo.Text = "";
                TxtUsuario.Text = "";
                DtFechaCreacion.Value = DateTime.Now;
                ChkCambiarClave.Checked = true;
                ChkEstado.Checked = true;
            }
           //Metodos para habilitar los controles
            private void HabilitarControles(bool cEnable)
            {
                TxtNombre.Enabled = cEnable;
                TxtApellido1.Enabled = cEnable;
                TxtApellido2.Enabled = cEnable;
                TxtClave.Enabled = cEnable;
                TxtCorreo.Enabled = cEnable;
                TxtUsuario.Enabled = cEnable;
                DtFechaCreacion.Enabled = cEnable;
                ChkCambiarClave.Enabled = cEnable;
                ChkEstado.Enabled = cEnable;
            }

            public static string Decrypt(string cipherString, bool useHashing)
            {
                byte[] keyArray;
                //get the byte code of the string

                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader =
                                                    new AppSettingsReader();
                //Get your key from config file to open the lock!
                string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));

                if (useHashing)
                {
                    //if hashing was used get the hash code with regards to your key
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //release any resource held by the MD5CryptoServiceProvider

                    hashmd5.Clear();
                }
                else
                {
                    //if hashing was not implemented get the byte code of the key
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                //return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }

            public static string Encrypt(string toEncrypt, bool useHashing)
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file

                string key = (string)settingsReader.GetValue("SecurityKey",
                                                                 typeof(String));
                //System.Windows.Forms.MessageBox.Show(key);
                //If hashing use get hashcode regards to your key
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //Always release the resources and flush data
                    // of the Cryptographic service provide. Best Practice

                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

        private void GestionarUsuario(char Tipo)
        {
            try
            {
                Usuarios objUsuario = new Usuarios();
                //objUsuario.IdUsuario = Convert.ToInt32(DgUsuarios.CurrentRow.Cells[0].Value);
                objUsuario.Usuario = TxtUsuario.Text;
                objUsuario.Nombre = TxtNombre.Text;
                objUsuario.Apellido1 = TxtApellido1.Text;
                objUsuario.Apellido2 = TxtApellido2.Text;
                objUsuario.Correo = TxtCorreo.Text;
                objUsuario.Clave = Encrypt(TxtClave.Text, true);
                objUsuario.FechaCreacion = DtFechaCreacion.Value;
                objUsuario.CambiarClave = ChkCambiarClave.Checked?1:0;
                objUsuario.Estado = ChkEstado.Checked ? 1 : 0;               
                objCapaLogica = new CapaLogica();

                if (Tipo == 'I')
                {
                    
                    objCapaLogica.AgregarUsuario(objUsuario);
                }

                if (Tipo == 'U')
                {
                    objUsuario.IdUsuario = Convert.ToInt32(DgUsuarios.CurrentRow.Cells[0].Value);
                    objCapaLogica.ModificarUsuario(objUsuario);

                }

                if (Tipo == 'E')
                {
                    objUsuario.IdUsuario = Convert.ToInt32(DgUsuarios.CurrentRow.Cells[0].Value);
                    objCapaLogica.EliminarUsuario(objUsuario);
                }

                MessageBox.Show("Gestión correcta");
              



            }
            catch (Exception ex)
            {
                MessageBox.Show("[FrmMain_ObjetoUsuario]" + ex.Message + "->" + ex.StackTrace);
            }
        }

        private void CargaDatosTextBox()
        {
            try
            {
                TxtUsuario.Text = DgUsuarios.CurrentRow.Cells[1].Value.ToString();
                TxtNombre.Text = DgUsuarios.CurrentRow.Cells[6].Value.ToString();
                TxtApellido1.Text = DgUsuarios.CurrentRow.Cells[7].Value.ToString();
                TxtApellido2.Text = DgUsuarios.CurrentRow.Cells[8].Value.ToString();
                TxtCorreo.Text = DgUsuarios.CurrentRow.Cells[3].Value.ToString();
                DtFechaCreacion.Value = Convert.ToDateTime(DgUsuarios.CurrentRow.Cells[4].Value);
                ChkEstado.Checked = Convert.ToBoolean(DgUsuarios.CurrentRow.Cells[5].Value);
                ChkCambiarClave.Checked = Convert.ToBoolean(DgUsuarios.CurrentRow.Cells[10].Value);
                TxtClave.Text = DgUsuarios.CurrentRow.Cells[9].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("[FrmMain_CargaDatosTextBox]" + ex.Message + "->" + ex.StackTrace);
            }

        }

        private void CargarGridUsuarios()
        {
            try
            {
                ConsultarUsuarios();
                if (ListadoUsuarios == null)
                {
                    return;
                }
                DgUsuarios.DataSource = (from Item in ListadoUsuarios
                                        select new { 
                                                IdUsuario = Item.IdUsuario, 
                                                Usuario = Item.Usuario,
                                                NombreCompleto = Item.Nombre+" "+Item.Apellido1+" "+Item.Apellido2,
                                                Correo = Item.Correo,
                                                FechaCreacion = Item.FechaCreacion,
                                                Estado = Item.Estado,
                                                Nombre = Item.Nombre,
                                                Apellido1 = Item.Apellido1,
                                                Apellido2 = Item.Apellido2,
                                                Clave = Item.Clave, 
                                                CambiarClave = Item.CambiarClave
                                        }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("[FrmMain_CargarGridUsuarios]" + ex.Message + "->" + ex.StackTrace);
            }
        }

        private void ConsultarUsuarios()
        {
            try
            {              

                objCapaLogica = new CapaLogica();
                ListadoUsuarios = objCapaLogica.ConsultarUsuarios();

            }
            catch (Exception ex)
            {
                MessageBox.Show("[FrmMain_ConsultarUsuarios]" + ex.Message + "->" + ex.StackTrace);
            }
        }
        #endregion


        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

            HabilitarControles(false);
            CargarGridUsuarios();
            IdObjeto = 1000;
            
        }

        private void DgUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CargaDatosTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BtnEliminar.Text == "&Cancelar")
            {
                HabilitarControles(false);
                InicializarControles();
                BtnEliminar.Text = "&Eliminar";
                BtnNuevo.Text = "&Nuevo";
                BtnModificar.Text = "&Modificar";
                BtnModificar.Visible = true;
                BtnNuevo.Visible = true;
                CargarGridUsuarios();
                TxtNombre.Focus();
                CambioForeColor(false);
                return;
            }

            DialogResult x = MessageBox.Show("Desea eliminar el registro?", "Confirmar", MessageBoxButtons.YesNo);

            if (x == System.Windows.Forms.DialogResult.Yes)
            {
                GestionarUsuario('E');
                CargarGridUsuarios();
            }   

          
            

           
               
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

            if (BtnModificar.Text == "&Modificar")
            {
                BtnModificar.Text = "&Guardar";
                BtnEliminar.Text = "&Cancelar";
                BtnNuevo.Visible = false;
                HabilitarControles(true);
                TxtUsuario.Enabled = false;
                DtFechaCreacion.Enabled = false;                
                TxtNombre.Focus();
                CambioForeColor(true);
                return;

            }

            GestionarUsuario('U');
            CargarGridUsuarios();
            BtnNuevo.Text = "&Nuevo";
            BtnModificar.Text = "&Modificar";
            BtnEliminar.Text = "&Eliminar";
            BtnNuevo.Visible = true;
            HabilitarControles(false);
            CambioForeColor(false);
            BtnNuevo.Focus();
            

          
        }

        private void CambioForeColor(bool pOpcion)
        {
            if (pOpcion)
            {
                BtnNuevo.ForeColor = SystemColors.HotTrack;
                BtnModificar.ForeColor = SystemColors.HotTrack;
                BtnEliminar.ForeColor = SystemColors.HotTrack;
            }
            else
            {
                BtnNuevo.ForeColor = SystemColors.ControlText;
                BtnModificar.ForeColor = SystemColors.ControlText;
                BtnEliminar.ForeColor = SystemColors.ControlText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(FrmMain.ListadoPermisos.Count.ToString());
            RespuestaValidacion = FrmMain.ValidadorPermisos(FrmMain.Usuario.IdUsuario,IdObjeto,'E');
            if (!RespuestaValidacion.Equals(string.Empty))
            {
                MessageBox.Show(null,RespuestaValidacion,"Permisos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            
            if (BtnNuevo.Text == "&Nuevo")
            {
                BtnNuevo.Text = "&Guardar";
                BtnEliminar.Text = "&Cancelar";
                BtnModificar.Visible = false;
                HabilitarControles(true);
                DtFechaCreacion.Enabled = false;
                InicializarControles();
                TxtNombre.Focus();
                CambioForeColor(true);
                return;

            }
            GestionarUsuario('I');
            CargarGridUsuarios();
            BtnNuevo.Text = "&Nuevo";
            BtnEliminar.Text = "&Eliminar";
            BtnModificar.Visible = true;
            HabilitarControles(false);
            CambioForeColor(false);
            BtnNuevo.Focus();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           string palabra = "Carlos";
            string cifrado = Encrypt(palabra, true);
           Console.WriteLine(cifrado);
           Console.WriteLine(Decrypt(cifrado, true));
            
        }
    }
}
