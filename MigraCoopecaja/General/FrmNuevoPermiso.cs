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
using Datos.EntidadesAux;

namespace AppEscritorio.General
{

    struct objPan
    {
        public int IdPanta { get; set; }
        public string NomP { get; set; }
    }
    public partial class FrmNuevoPermiso : Form
    {
        CapaLogica objCapaLogica;
        int auxIdUsuario;
        List<PermisosObj> ListadoPermisos;
        public FrmNuevoPermiso()
        {
            InitializeComponent();
        }

        public FrmNuevoPermiso(int pIdUsuario, List<PermisosObj> ListadoAux)
        {
            InitializeComponent();
            this.auxIdUsuario = pIdUsuario;
            ListadoPermisos = ListadoAux;
        }

        private void FrmNuevoPermiso_Load(object sender, EventArgs e)
        {
            CargarModulos();
            CmbModulo.DisplayMember = "pDesModulo";
            CmbModulo.ValueMember = "pIdModulo";
           // CmbModulo.SelectedIndex = 0;
        }

        private void CargarSubOpciones()
        {
            objCapaLogica = new CapaLogica();          
            CmbPan.DataSource = (from x in objCapaLogica.ConsultarSubOpciones()
                                      where x.IdModulo == Convert.ToInt32(CmbModulo.SelectedValue)
                                      let z = objCapaLogica.ConsultarPantallas().Where(y => y.IdSubOp == x.IdSubOp).FirstOrDefault().IdPantalla
                                      select new
                                      {
                                          IdPantalla = z,
                                          NomBoton = x.NomBoton
                                      }).ToList();
        }


        private void CargarModulos()
        {
            //    join f in objCapaLogica.ConsultarSubOpciones() on x.IdModulo equals f.IdModulo
            objCapaLogica = new CapaLogica();
            var aux = (from x in objCapaLogica.ConsultarModulos().ToList()
                       join f in objCapaLogica.ConsultarSubOpciones().ToList() on x.IdModulo equals f.IdModulo
                       where x.EstModulo == 1
                       select new ClsCmbModulo { pIdModulo = x.IdModulo, pDesModulo = x.DesModulo }).ToList();
                             


            List<ClsCmbModulo> ListadoCarga = new List<ClsCmbModulo>();
            foreach (var item in aux)
            {
                if (ListadoCarga.Find(x => x.pIdModulo == item.pIdModulo) != null)
                {
                    continue;
                }
                ClsCmbModulo objClsCmbModulo = new ClsCmbModulo();
                objClsCmbModulo.pIdModulo = item.pIdModulo;
                objClsCmbModulo.pDesModulo = item.pDesModulo;

                ListadoCarga.Add(objClsCmbModulo);
            }

            CmbModulo.DataSource = ListadoCarga;

                               

           
        }

        private void CmbPantalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbModulo_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarSubOpciones();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {     
                       
            Permisos objPermisos = new Permisos();
            objPermisos.IdUsuario = auxIdUsuario;
            objPermisos.IdObjeto = Convert.ToInt32(CmbPan.SelectedValue);
            objPermisos.Visible = Convert.ToInt32(ChkVisible.Checked);
            objPermisos.Escritura = Convert.ToInt32(ChkEscritura.Checked);
            objPermisos.Lectura = Convert.ToInt32(ChkLectura.Checked);
            objPermisos.Borrado = Convert.ToInt32(ChkBorrado.Checked);

            //Determinar si el permiso que desea agregar al usuario, ya no existe
            PermisosObj aux = ListadoPermisos.Where(x => x.aIdUsuario == objPermisos.IdUsuario && x.aIdPantalla == objPermisos.IdObjeto).FirstOrDefault();
            if (aux != null)
            {
                MessageBox.Show(null,"El permiso que desea agregar al usuario ya existe","Validación",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            objCapaLogica = new CapaLogica();
            objCapaLogica.AgregarPermiso(objPermisos);

           


            this.Close();
        }
    }

    public class ClsCmbModulo
    {
        public int pIdModulo { get; set; }
        public string pDesModulo { get; set; }
    }
}
