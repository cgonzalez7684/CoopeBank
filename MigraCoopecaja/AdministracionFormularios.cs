using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorio
{
    public class AdministracionFormularios
    {

        public AdministracionFormularios()
        {

        }

        public void AbrirFormulario(string Pantalla,Form objMdi)
        {
            try
            {

                //foreach (Form frm in Application.OpenForms)
                //{

                //    if (frm.Name != "FrmMain" && frm.Name != "Frm" + Pantalla)
                //    {
                //        frm.Close();
                //    }


                //}

                ////Si el formulario ya esta abierto, no se vuelve abrir
                //foreach (Form frm in Application.OpenForms)
                //{
                //    if (frm.Name == "Frm" + Pantalla)
                //    {
                //        return;
                //    }

                //}

                switch (Pantalla)
                {
                    case "Usuarios":
                        General.FrmUsuarios objFrmUsuarios = new General.FrmUsuarios();
                        objFrmUsuarios.MdiParent = objMdi;
                        objFrmUsuarios.Show();
                        break;
                    case "Permisos":
                        General.FrmPermisos objFrmPermisos = new General.FrmPermisos();
                        objFrmPermisos.MdiParent = objMdi;
                        objFrmPermisos.Show();
                        break;
                    case "Especiales":
                        Colocaciones.FrmEspeciales objFrmEspeciales = new Colocaciones.FrmEspeciales();
                        objFrmEspeciales.MdiParent = objMdi;
                        objFrmEspeciales.Show();
                        break;
                    case "Vendedores":
                        Colocaciones.FrmCambVend objFrmCambVend = new Colocaciones.FrmCambVend();
                        objFrmCambVend.MdiParent = objMdi;
                        objFrmCambVend.Show();
                        break;
                    case "Traslados":
                        Captacion.FrmAhorros objFrmCertiCredito = new Captacion.FrmAhorros();
                        objFrmCertiCredito.MdiParent = objMdi;
                        objFrmCertiCredito.Show();
                        break;
                    case "Avaluos":
                        Colocaciones.FrmAvaluos objFrmAvaluos = new Colocaciones.FrmAvaluos();
                        objFrmAvaluos.MdiParent = objMdi;
                        objFrmAvaluos.Show();
                        break;
                    case "Planillas":
                        Colocaciones.FrmPlanillas objFrmPlanillas = new Colocaciones.FrmPlanillas();
                        objFrmPlanillas.MdiParent = objMdi;
                        objFrmPlanillas.Show();
                        break;
                    case "MoviBank":
                        Tesoreria.FrmConciBancos objFrmConciBancos  = new Tesoreria.FrmConciBancos();
                        objFrmConciBancos.MdiParent = objMdi;
                        objFrmConciBancos.Show();
                        break;
                    case "Liquidacion":
                        Captacion.FrmLiquidacion objFrmLiquidacion = new Captacion.FrmLiquidacion();
                        objFrmLiquidacion.MdiParent = objMdi;
                        objFrmLiquidacion.Show();
                        break;
                    case "Vendedor":
                        Colocaciones.FrmVendedores objFrmVendedores = new Colocaciones.FrmVendedores();
                        objFrmVendedores.MdiParent = objMdi;
                        objFrmVendedores.Show();
                        break;
                    case "NominaCGP":
                        General.FrmNominaCGP objFrmNominaCGP = new General.FrmNominaCGP();
                        objFrmNominaCGP.MdiParent = objMdi;
                        objFrmNominaCGP.Show();
                        break;
                    case "PagosCGP":
                        General.FrmCargarPagosCGP objFrmPagoCGP = new General.FrmCargarPagosCGP();
                        objFrmPagoCGP.MdiParent = objMdi;
                        objFrmPagoCGP.Show();
                        break;
                    default:
                        MessageBox.Show("No existe formulario");
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("[FrmMain_AbrirFormulario]" + ex.Message + "->" + ex.StackTrace);
            }
        }
    }
}
