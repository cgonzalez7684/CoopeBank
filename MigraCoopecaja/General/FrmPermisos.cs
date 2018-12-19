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
using Datos.EntidadesAux;
using Datos;

namespace AppEscritorio.General
{
    public partial class FrmPermisos : Form
    {
        CapaLogica objCapaLogica;
        List<PermisosObj> ListadoPermisos;
        BindingList<PermisosObj> LstPermi;
        BindingSource Fuente;

        public FrmPermisos()
        {
            InitializeComponent();
           
        }

        private void CargaPermisos()
        {
            objCapaLogica = new CapaLogica();
            ListadoPermisos = (from Per in objCapaLogica.ConsultarPermisos().Where(x => x.IdObjeto >= 1000)
                                join Pant in objCapaLogica.ConsultarPantallas()
                                    on Per.IdObjeto equals Pant.IdPantalla
                                let s = objCapaLogica.ConsultarSubOpciones().Where(SubO => SubO.IdSubOp.Equals(Pant.IdSubOp)).FirstOrDefault().IdModulo
                                where Per.IdUsuario == Convert.ToInt32(DgUsuarios.CurrentRow.Cells[0].Value)
                                select new PermisosObj
                                {
                                    aIdUsuario = Per.IdUsuario,
                                    aIdModulo = s,
                                    aIdPantalla = Pant.IdPantalla,
                                    aDesModulo = objCapaLogica.ConsultarModulos().Where(Mdu => Mdu.IdModulo.Equals(s)).FirstOrDefault().DesModulo,
                                    aIdSubOp = Pant.IdSubOp,
                                    aNomBoton = objCapaLogica.ConsultarSubOpciones().Where(SubO => SubO.IdSubOp.Equals(Pant.IdSubOp)).FirstOrDefault().NomBoton,
                                    aVisible = Per.Visible,
                                    aLectura = Per.Lectura,
                                    aEscritura = Per.Escritura,
                                    aBorrado = Per.Borrado
                                }).ToList();
            //LstPermi = new BindingList<PermisosObj>(ListadoPermisos);
            //Fuente = new BindingSource(LstPermi, null);
            //DgPermisos.DataSource = Fuente;

           DgPermisos.DataSource = ListadoPermisos.ToList();
        }

        private void FrmPermisos_Load(object sender, EventArgs e)
        {
            objCapaLogica = new CapaLogica();
            var aux = from x in objCapaLogica.ConsultarUsuarios()
                      select new
                      {
                          IdUsuario = x.IdUsuario,
                          Usuario = x.Usuario,
                          NomUsu = x.Nombre + " " + x.Apellido1 + " " + x.Apellido2
                      };

            DgUsuarios.DataSource = aux.ToList();

            CargaPermisos();
            
            
        }

        private void DgUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CargaPermisos();
        }

        private void DgPermisos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DgPermisos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void ActualizarPermisos()
        {
            Console.Write(ListadoPermisos.Count.ToString());

            objCapaLogica = new CapaLogica();
            foreach (PermisosObj item in ListadoPermisos)
            {
                Permisos obj = new Permisos();
                obj.IdUsuario = item.aIdUsuario;
                obj.IdObjeto = item.aIdPantalla;
                obj.Visible = item.aVisible;
                obj.Lectura = item.aLectura;
                obj.Escritura = item.aEscritura;
                obj.Borrado = item.aBorrado;
                objCapaLogica.ModificarPermiso(obj);

            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            List<PermisosObj> ListadoAux = ListadoPermisos;
            
            DialogResult rs;
            rs = MessageBox.Show("Desea modificar los permiso del usuario " + DgUsuarios.CurrentRow.Cells["colUsuario"].Value.ToString() + " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (rs == System.Windows.Forms.DialogResult.No)
            {
                return;
            }          

            objCapaLogica = new CapaLogica();
            foreach (PermisosObj item in ListadoAux)
            {
                Permisos obj = new Permisos();
                obj.IdUsuario = item.aIdUsuario;
                obj.IdObjeto = item.aIdPantalla;
                obj.Visible = item.aVisible;
                obj.Lectura = item.aLectura;
                obj.Escritura = item.aEscritura;
                obj.Borrado = item.aBorrado;
                objCapaLogica.ModificarPermiso(obj);

                //Modificar subOpcion viculada a la pantalla
                obj.IdObjeto = objCapaLogica.ConsultarPantallas().Where(x => x.IdPantalla == item.aIdPantalla).FirstOrDefault().IdSubOp;
                objCapaLogica.ModificarPermiso(obj);

               


            }

           // ActualizarPermisos();

            CargaPermisos();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoPermiso objFrmNuevoPermiso = new FrmNuevoPermiso(Convert.ToInt32(DgUsuarios.CurrentRow.Cells["colIdUsuario"].Value), ListadoPermisos);
            objFrmNuevoPermiso.ShowDialog();
            CargaPermisos();
        }

        private void FrmPermisos_Activated(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Permisos objPermiso = new Permisos();
            objPermiso.IdObjeto = Convert.ToInt32(DgPermisos.CurrentRow.Cells["colaIdPantalla"].Value);
            objPermiso.IdUsuario = Convert.ToInt32(DgUsuarios.CurrentRow.Cells["colIdUsuario"].Value);
            objCapaLogica = new CapaLogica();
            objCapaLogica.EliminarPermiso(objPermiso);
            CargaPermisos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Write(ListadoPermisos.Count.ToString());
            MessageBox.Show("asdfa");
        }

      
    }
}
