using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Security.Cryptography;
using System.Configuration;
using Logica;
using Datos;
using System.Data.SqlClient;
using System.IO;

namespace AppEscritorio
{
    public partial class FrmLogin : Form
    {

       
        String dominio;
        PrincipalContext context1;       
        public static int UsuarioSistema;
        CapaLogica objCapaLogica;
        public static bool UsuarioValidado;
        public static string NomUsuario;
        
        public FrmLogin()
        {
            InitializeComponent();
            UsuarioValidado = false;
        }

        public int ObtenerUsuarioSistema(string pUsuario)
        {
            objCapaLogica = new CapaLogica();
            return objCapaLogica.ConsultarUsuarios().Where(x => x.Usuario.ToUpper().Equals(pUsuario.ToUpper())).FirstOrDefault().IdUsuario;
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
        public bool ValidarUsuarioLocal(string pUsuario,string pClave){

            bool UsrValido = false;
            string auxUsuario = string.Empty;
            string auxClave = string.Empty;
            objCapaLogica = new CapaLogica();
            Usuarios auxUsr = objCapaLogica.ConsultarUsuarios().Where(x => x.Usuario.ToUpper().Equals(pUsuario.ToUpper())).FirstOrDefault();
            if ((auxUsr != null) && ((Decrypt(auxUsr.Clave, true).Equals(pClave))))
            {
                UsrValido = true;

            }
            return UsrValido;
            
        }

        private bool ValidarIngreso()
        {
            UsuarioValidado = false;
            try
            {
                if (ChkUsrDominio.Checked)
                {
                    if (context1.ValidateCredentials(Environment.UserName, TxtClave.Text.Trim()))
                    {
                        UsuarioSistema = ObtenerUsuarioSistema(Environment.UserName);
                        NomUsuario = Environment.UserName;
                        UsuarioValidado = true;
                        
                    }
                    else
                    {
                        MessageBox.Show(null, "El usuario o la clave no corresponden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        UsuarioValidado = false;
                    }
                }
                else
                {
                    if (ValidarUsuarioLocal(TxtUsuario.Text.Trim(), TxtClave.Text.Trim()))
                    {
                        UsuarioSistema = ObtenerUsuarioSistema(TxtUsuario.Text.Trim());
                        NomUsuario = TxtUsuario.Text.Trim();
                        UsuarioValidado = true;
                    }
                    else
                    {
                        MessageBox.Show(null, "El usuario o la clave no corresponden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TxtClave.Text = string.Empty;
                        TxtClave.Focus();
                        UsuarioValidado = false;
                    }
                }

                
            }
            catch (Exception ex)
            {
                UsuarioValidado = false;
                MessageBox.Show(ex.ToString());

            }
            return UsuarioValidado;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarIngreso())
            {
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            ChkUsrDominio.Checked = true;
            TxtUsuario.Focus();                
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ChkUsrDominio_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (ChkUsrDominio.Checked)
                {

                    //Se inicializa el contexto de dominio
                    context1 = new PrincipalContext(ContextType.Domain);
                    dominio = context1.ConnectedServer; //Se obtiene el dominio
                    if (dominio.Contains("coopecaja"))
                    {
                        TxtUsuario.Text = Environment.UserDomainName + @"\" + Environment.UserName;
                        TxtUsuario.Enabled = false;
                        TxtClave.Focus();
                    }
                    else
                    {
                        //Si no se encuentra usuario de dominio
                        TxtUsuario.Text = "";
                        TxtUsuario.Enabled = true;
                        TxtUsuario.Focus();
                    }
                }
                else
                {
                    TxtUsuario.Text = "";
                    TxtUsuario.Enabled = true;
                    TxtUsuario.Focus();
                }
            }
            catch (Exception)
            {
                
                context1 = new PrincipalContext(ContextType.Machine);
                dominio = context1.ConnectedServer;
                TxtUsuario.Text = String.Empty;
                TxtUsuario.Enabled = true;
                TxtUsuario.Focus();
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            try
            {
              // string cadenta = "Data Source=NEPTUNO;Initial Catalog=CoopeBank;User ID=Coopebank;Password = C00p38Ank*8D;";
               string cadenta = @"Data Source=RIN\MIGRACION;Initial Catalog=CoopeBank;User ID=Coopebank;Password = Coopecaja1;";
                SqlConnection conn = new SqlConnection(cadenta);
                conn.Open();
                MessageBox.Show(((ConnectionState)conn.State).ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            

        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
           
           
            
            
        }

        private void LblVersion_MouseEnter(object sender, EventArgs e)
        {
            
            
            string linea = "";
            string Mensaje = "";
            StreamReader lectura = new StreamReader("VersionAplicativo.txt");
            while ((linea = lectura.ReadLine()) != null)
            {
                Mensaje += linea + Environment.NewLine;
            };

            lectura.Close();

            toolTipMensajesVersion.SetToolTip(LblVersion, Mensaje);
        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
