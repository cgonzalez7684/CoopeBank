using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Datos;
using Logica;

using System.Runtime.InteropServices;







namespace AppEscritorio
{
   
    public partial class FrmMain : Form
    {

#region "Propiedes"
        public static List<SubOpciones> ListadoSubOpciones;
        public static List<Permisos> ListadoPermisos;
        private CapaLogica objCapaLogica;
        private AdministracionFormularios objAdmFrm;
        public static Usuarios Usuario;
            
#endregion





        #region "Metodos propios"


        public static string ValidadorPermisos(int pIdUsuario, int pIdObjeto,char Accion)
        {

            //ListadoPermisosUsuario();
            string Respuesta = string.Empty;
            Permisos auxPer = ListadoPermisos.Where(x => x.IdUsuario == pIdUsuario && x.IdObjeto == pIdObjeto).FirstOrDefault();
            if (auxPer != null)
            {
                switch (Accion)
                {
                    case 'L' :
                        Respuesta = auxPer.Lectura == 1 ? string.Empty : "El usuario no cuenta con los permisos para leer en base de datos";
                        break;
                    case 'E' :
                        Respuesta = auxPer.Escritura == 1 ? string.Empty : "El usuario no cuenta con los permisos para escribir en base de datos";
                        break;
                    case 'B':
                        Respuesta = auxPer.Borrado == 1 ? string.Empty : "El usuario no cuenta con los permisos para Borrar en base de datos";
                        break;
                    default:
                        break;
                }
            }
            return Respuesta;
        }

            //Metodo para la configuración del control ListView del menu vertical del sistema
            private void ConfigurarLsts(ListView Objeto)
            {
                try
                {
                    ColumnHeader header = new ColumnHeader();
                    header.Name = "col1";
                    header.Width = 70;
                    header.TextAlign = HorizontalAlignment.Center;

                    ColumnHeader header2 = new ColumnHeader();
                    //header2.Name = "col1";
                    header2.Width = 92;
                    header2.TextAlign = HorizontalAlignment.Center;

                    Objeto.FullRowSelect = true;
                    Objeto.Columns.Add(header);
                    Objeto.Columns.Add(header2);
                    Objeto.HeaderStyle = ColumnHeaderStyle.None;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_ConfigurarLsts]" + ex.Message + "->" + ex.StackTrace);
                }
                
                
            }

            //Metodo que obtiene y carga la propiedad global de permisos para el usuario en Sesión.
            private void ListadoPermisosUsuario()
            {
                try
                {

                    objCapaLogica = new CapaLogica();
                    ListadoPermisos = objCapaLogica.ConsultarPermisos();   
                    
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_ListadoPermisosUsuario]" + ex.Message + "->" + ex.StackTrace);
                }
            }

            //Metodo que tiene como objetivo consultar las SubOpciones del sistema
            private void ListadoSubOpcionesUsuario()
            {
                try
                {
                    
                  

                    objCapaLogica = new CapaLogica();
                    ListadoSubOpciones = objCapaLogica.ConsultarSubOpciones();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_ListadoSubOpcionesUsuario]" + ex.Message + "->" + ex.StackTrace);
                }
            }

            //Metodo para visibilizar las opciones de menu y subopciones, según los permisos que tenga el usuario.
            private void AplicarPermisosVisibil()
            {
                try
                {
                    //La siguiente consulta solo carga los permisos de los modulos, excluye subopciones y pantallas
                    List<Permisos> PermisosAux = ListadoPermisos.Where(x => (x.IdUsuario == Usuario.IdUsuario)&&(x.IdObjeto <= 99)).ToList();
                    
                    foreach (Permisos Permiso in PermisosAux)
                    {

                        switch (Permiso.IdObjeto)
                        {
                            case 10 :
                                MnuGeneral.Visible = Permiso.Visible == 1 ? true : false;                               
                                LstGeneral.Visible = Permiso.Visible == 1 ? true : false;
                                break;
                            case 11:
                                MnuBackOffice.Visible = Permiso.Visible == 1 ? true : false;
                                LstBackOffice.Visible = Permiso.Visible == 1 ? true : false;                                
                                break;
                            case 12:
                                MnuCaptacion.Visible = Permiso.Visible == 1 ? true : false;
                                LstCaptacion.Visible = Permiso.Visible == 1 ? true : false;
                                break;
                            case 13:
                                MnuColocaciones.Visible = Permiso.Visible == 1 ? true : false;
                                LstColocaciones.Visible = Permiso.Visible == 1 ? true : false;
                                break;
                            case 14:

                                MnuTesoreria.Visible = Permiso.Visible == 1 ? true : false;
                                LstTesoreria.Visible = Permiso.Visible == 1 ? true : false;
                                break;  
                        }                  
                        
                    }

                    //Se cargan las SubOpciones de los modulos
                    ListadoSubOpcionesUsuario(); //Se consultan todas las subopciones del sistema
                    PermisosAux = ListadoPermisos.Where(x => (x.IdUsuario == Usuario.IdUsuario) && (x.IdObjeto >= 100 && x.IdObjeto <= 999) && (x.Visible == 1)).ToList();
                     
                    foreach (Permisos Permiso in PermisosAux)
                    {
                        //int Modulo = ListadoSubOpciones.Where(x => x.IdSubOp == Permiso.IdObjeto).FirstOrDefault().IdModulo;
                        SubOpciones AuxSub = ListadoSubOpciones.Where(x => x.IdSubOp == Permiso.IdObjeto).FirstOrDefault();
                        switch (AuxSub.IdModulo)
                        {
                            case 10 :
                                CargaIconosSubOpciones(LstGeneral, 10);
                                break;
                            case 12:
                                CargaIconosSubOpciones(LstCaptacion, 12);
                                break;
                            case 11:
                                CargaIconosSubOpciones(LstBackOffice, 11);
                                break;
                            case 13 :
                                CargaIconosSubOpciones(LstColocaciones, 13);
                                break;
                            case 14:
                                CargaIconosSubOpciones(LstTesoreria, 14);
                                break;

                            default:
                                break;
                        }
                    }


                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_AplicarPermisosVisibil]" + ex.Message + "->" + ex.StackTrace);
                }
            }


            private void LimpiarControlesListView(){
                
              
                foreach (Control c in pnMain.Controls) // en vez de this puedes poner el nombre de un panel si es que tus textboxes se encuentran dentro de uno
                {
                    if (c is Panel)
                    {
                        foreach (Control item in ((Panel)c).Controls)
                        {
                            if (item is Panel)
                            {
                                foreach (Control crtl in ((Panel)item).Controls)
                                {
                                   
                                    if (crtl is ListView)
                                    {
                                        ((ListView)crtl).Items.Clear();
                                    }
                                }
                            }
                           
                        }
                    }

                   
                }
            }
            //Este metodo dependiendo del control ListView que entre como parametro y el modulo, se encarga de cargar las SubOpciones
            private void CargaIconosSubOpciones(ListView Objeto,int IdModulo) 
            {
                try
                {
                    Objeto.Items.Clear();
                    //List<SubOpciones> ListAux = ListadoSubOpciones.Where(x => x.IdModulo == IdModulo).ToList();
                    List<SubOpciones> ListAux1 = (from Ls in ListadoSubOpciones
                                                 join Perm in ListadoPermisos
                                                   on Ls.IdSubOp equals Perm.IdObjeto
                                                 where (Perm.IdUsuario == Usuario.IdUsuario) && Perm.Visible == 1 && Ls.IdModulo == IdModulo
                                                 select Ls).ToList();

                    

                    foreach (SubOpciones SOpcion in ListAux1)
                    {
                        ListViewItem item = new ListViewItem();
                        ListViewItem.ListViewSubItem sb = new ListViewItem.ListViewSubItem();
                        sb.Name = SOpcion.NomBoton;
                        sb.Text = SOpcion.NomBoton;
                        sb.Tag = SOpcion.DesSubOp;
                        item.SubItems.Add(sb);
                        item.ImageIndex = Convert.ToInt32(SOpcion.ImgIndex);
                        Objeto.Items.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_CargaIconosSubOpciones]" + ex.Message + "->" + ex.StackTrace);
                }
            }

            //Metodo que see encargar de vincular el fomulario por abrir a la SubOpcion seleccionada por el usario
            private void VincularFormularioLista(ListView LstObj)
            {
                try
                {
                     int i = LstObj.SelectedIndices[0];
                string s = LstObj.Items[i].SubItems[1].Name;
                objAdmFrm = new AdministracionFormularios();
                objAdmFrm.AbrirFormulario(s, this);
                }             
                catch (Exception ex)
                {
                    MessageBox.Show("[FrmMain_VincularFormularioLista]" + ex.Message + "->" + ex.StackTrace);
                }
               
            }

        
         
        #endregion




            private void RedimencionarPanelesMenu()
            {
                pnGeneral.Size = new Size(pnGeneral.Size.Width, 280);
                pnBackOffice.Size = new Size(pnBackOffice.Size.Width, 280);
                pnCaptacion.Size = new Size(pnCaptacion.Size.Width, 280);
                pnColocaciones.Size = new Size(pnColocaciones.Size.Width, 280);
                pnTesoreria.Size = new Size(pnTesoreria.Size.Width, 280);                 

            }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
          //  childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarControlesListView();
            ListadoPermisosUsuario();
            AplicarPermisosVisibil();           
            if (pnGeneral.Visible == false)
            {
               
                pnGeneral.Visible = true;
                pnBackOffice.Visible = false;
                pnCaptacion.Visible = false;
                pnColocaciones.Visible = false;
                pnTesoreria.Visible = false;
            }
            else
            {
                pnGeneral.Visible = false;
            }

                     
          
        

         
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnMain.Visible = false;
            pnGeneral.Visible = false;
            pnBackOffice.Visible = false;
            pnCaptacion.Visible = false;
            pnColocaciones.Visible = false;
            RedimencionarPanelesMenu();
            Usuario = new Usuarios();
            //Usuario.IdUsuario = 1; //Solo para efectos de debug           
            objCapaLogica = new CapaLogica();
            Usuario = objCapaLogica.ConsultarUsuarios().Where(x=>x.IdUsuario==FrmLogin.UsuarioSistema).FirstOrDefault();
            BgEtiquetaUsuario.Text = Usuario.Nombre + " " + Usuario.Apellido1 + " " + Usuario.Apellido2+" ["+Usuario.Usuario+"]";
            ConfigurarLsts(LstGeneral);
            ConfigurarLsts(LstBackOffice);
            ConfigurarLsts(LstCaptacion);
            ConfigurarLsts(LstColocaciones);
            ConfigurarLsts(LstTesoreria);
            ListadoPermisosUsuario();
            AplicarPermisosVisibil();
            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pnMain.Visible == false)
            {
                pnMain.Visible = true;
                button2.Image = AppEscritorio.Properties.Resources.retro;
            }
            else
            {
                pnMain.Visible = false;
                button2.Image = AppEscritorio.Properties.Resources.move;
            }
            
        }

        private object devol(object pdato)
        {
            return Convert.ToInt32(pdato) + 1; ;
            
        }

        private void MnuCaptacion_Click(object sender, EventArgs e)
        {
            LimpiarControlesListView();
            ListadoPermisosUsuario();
            AplicarPermisosVisibil(); 
            if (pnBackOffice.Visible == false)
            {
                pnGeneral.Visible = false;
                pnBackOffice.Visible = true;
                pnCaptacion.Visible = false;
                pnColocaciones.Visible = false;
                pnTesoreria.Visible = false;
            }
            else
            {
                pnBackOffice.Visible = false;
            }
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LimpiarControlesListView();
            ListadoPermisosUsuario();
            AplicarPermisosVisibil(); 
            if (pnCaptacion.Visible == false)
            {
                pnGeneral.Visible = false;
                pnBackOffice.Visible = false;
                pnCaptacion.Visible = true;
                pnColocaciones.Visible = false;
                pnTesoreria.Visible = false;
            }
            else
            {
                pnCaptacion.Visible = false;
            }
        }

        private void FrmMain_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void FrmMain_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
        
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

           
          
           
        }

        private void MnuColocaciones_Click(object sender, EventArgs e)
        {
            LimpiarControlesListView();
            ListadoPermisosUsuario();
            AplicarPermisosVisibil(); 
            if (pnColocaciones.Visible == false)
            {
                pnGeneral.Visible = false;
                pnBackOffice.Visible = false;
                pnCaptacion.Visible = false;                
                pnColocaciones.Visible = true;
                pnTesoreria.Visible = false;
            }
            else
            {
                pnColocaciones.Visible = false;
            }
        }

        private void LstGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LstGeneral_ItemActivate(object sender, EventArgs e)
        {
            
           
        }

       
       

        private void LstGeneral_DoubleClick(object sender, EventArgs e)
        {
            VincularFormularioLista(LstGeneral);
            
        }

        private void LstColocaciones_DoubleClick(object sender, EventArgs e)
        {
            VincularFormularioLista(LstColocaciones);
        }

        private void LstCaptacion_DoubleClick(object sender, EventArgs e)
        {
            VincularFormularioLista(LstCaptacion);
        }

        private void MnuTesoreria_Click(object sender, EventArgs e)
        {
            LimpiarControlesListView();
            ListadoPermisosUsuario();
            AplicarPermisosVisibil();
            if (pnTesoreria.Visible == false)                
            {
                pnGeneral.Visible = false;
                pnBackOffice.Visible = false;
                pnCaptacion.Visible = false;
                pnColocaciones.Visible = false;
                pnTesoreria.Visible = true;
            }
            else
            {
                pnTesoreria.Visible = false;
            }
        }

        private void LstTesoreria_DoubleClick(object sender, EventArgs e)
        {
            VincularFormularioLista(LstTesoreria);
        }

        private void LstBackOffice_DoubleClick(object sender, EventArgs e)
        {
            VincularFormularioLista(LstBackOffice);
        }
    }
}
