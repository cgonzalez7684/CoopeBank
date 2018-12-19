using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.EntidadesAux;
using System.Reflection;
using Oracle.DataAccess;

namespace Logica
{
    public class CapaLogica
    {

    #region "Atributos"

        CapaDatos objCapaDatos; 
    
        
    #endregion

        #region "MetodosOracle"


        #region "Pantalla cancelacion creditos incobrables"

        public List<OpeIncob> ConsultarCreditosIncobrables()
         {

             try
             {
                 objCapaDatos = new CapaDatos();
                 return objCapaDatos.ConsultarCreditosIncobrables();
             }
             catch (Exception)
             {
                 
                 throw;
             }
         
         }

        #endregion


        public List<UsuarioPS> ConsultarUsuarioPS()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarUsuarioPS();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public List<Operacion> ConsultarOperacionesPS()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarOperacionesPS();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        public void RegistrarAvaluo(Avaluo objAv)
        {
            try
            {
                if (objAv.COD_TIPOBIEN == "999")
                {
                    throw new Exception("Debe especificar el tipo de bien del avaluo");
                }

                objCapaDatos = new CapaDatos();
                objCapaDatos.RegistrarAvaluo(objAv);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BcEstados> ConsultarEstadosMovimientos()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarEstadosMovimientos().ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public List<MoviBanco> ConsultarMovimientosBancos()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return (from x in objCapaDatos.ConsultarMovimientosBancos()
                            join z in objCapaDatos.ConsultarEstadosMovimientos()
                                on x.COD_ESTADO equals z.COD_ESTADO
                        select new MoviBanco()
                        {
                            COD_COMPANIA = x.COD_COMPANIA,
                            NUM_CUENTA = x.NUM_CUENTA,
                            TIP_MOVIM = x.TIP_MOVIM,
                            NUM_MOVIM = x.NUM_MOVIM,
                            MON_MOVIM = x.MON_MOVIM,
                            FEC_MOVIM = x.FEC_MOVIM,
                            //COD_ESTADO = x.COD_ESTADO == "01" ? "Activo" : "Conciliado",
                            COD_ESTADO = z.ESTADO,
                            COD_AJUSTE = x.COD_AJUSTE,
                            NUM_MOVIM_AJU = x.NUM_MOVIM_AJU,
                            IND_DIFERENCIA = x.IND_DIFERENCIA,
                            NOM_BENEFICIARIO = x.NOM_BENEFICIARIO,
                            DOC_CONCILIAR = x.DOC_CONCILIAR,
                            DESCRIPCION = x.DESCRIPCION,
                            IND_ENVIO_NOTA = x.IND_ENVIO_NOTA                         
                        }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TipMoviBanco> ConsultarMoviBanco()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarMoviBanco();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Banco> ConsultarBancos()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarBancos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RegistarMoviBanco(MoviBanco objMoviBanco)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                objCapaDatos.RegistarMoviBanco(objMoviBanco);
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void ActualizarMoviBanco(MoviBanco objMoviBanco)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                objCapaDatos.ActualizarMoviBanco(objMoviBanco);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarMoviBanco(MoviBanco objMoviBanco)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                objCapaDatos.EliminarMoviBanco(objMoviBanco);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarAvaluo(Avaluo objAv)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                objCapaDatos.EliminarAvaluo(objAv);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void ModificarAvaluo(Avaluo objAv)
        {
            try
            {
                if (objAv.COD_TIPOBIEN == "999")
                {
                    throw new Exception("Debe especificar el tipo de bien del avaluo");
                }

                objCapaDatos = new CapaDatos();
                objCapaDatos.ModificarAvaluo(objAv);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RegistrarVendedor(Vendedor objAv)
        {
            try
            {                
                objCapaDatos = new CapaDatos();
                objCapaDatos.RegistrarVendedor(objAv);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Vendedor> ConsultarVendedores()
        {
            try
            {

                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarVendedores();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ConsultarSiguienteVendendedor()
        {
            objCapaDatos = new CapaDatos();
            return objCapaDatos.ConsultarSiguienteVendendedor();
        }

        public List<Producto> ConsultarTipoProductos()
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarTipoProductos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LiqProduct> ConsultarProductosLiquidaciones(int tipo,DateTime Fec_Carga)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarProductosLiquidaciones(tipo,Fec_Carga);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ConsultarClienteContrato(string DES_IDENTIFICACION, string IND_INVERSION, string COD_COMPANIA)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.ConsultarClienteContrato(DES_IDENTIFICACION, IND_INVERSION, COD_COMPANIA);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int RegistrarUT_LIQUIDACIONSOBRANTES(List<LiqProduct> ListadoProductosLiquidar)
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.RegistrarUT_LIQUIDACIONSOBRANTES(ListadoProductosLiquidar);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
          
        }

        public object[] AplicarLiquidacion(List<LiqProduct> ListoAplicar) 
        {
            try
            {
                objCapaDatos = new CapaDatos();
                return objCapaDatos.AplicarLiquidacion(ListoAplicar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            

            
        }
       
       
        #endregion 
        #region "Consultas"

        public List<Modulos> ConsultarModulos()
       {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.ConsultarModulos();
       }

       public List<SubOpciones> ConsultarSubOpciones()
       {
           objCapaDatos = new Datos.CapaDatos();
           return objCapaDatos.ConsultarSubOpciones();
       }

       public List<Pantallas> ConsultarPantallas()
       {
           objCapaDatos = new Datos.CapaDatos();
           return objCapaDatos.ConsultarPantallas();
       }

       public List<Permisos> ConsultarPermisos()
       {
           objCapaDatos = new Datos.CapaDatos();
           return objCapaDatos.ConsultarPermisos();
       }

       public List<Usuarios> ConsultarUsuarios()
       {
           objCapaDatos = new Datos.CapaDatos();
           return objCapaDatos.ConsultarUsuarios();
       }

       public void AgregarUsuario(Usuarios objUsuario)
       {
           objCapaDatos = new Datos.CapaDatos();
           objCapaDatos.AgregarUsuario(objUsuario);
       }

       public void EliminarUsuario(Usuarios objUsuario)
       {
           objCapaDatos = new Datos.CapaDatos();
           objCapaDatos.EliminarUsuario(objUsuario);
       }

       public void ModificarUsuario(Usuarios objUsuario)
       {
           objCapaDatos = new Datos.CapaDatos();
           objCapaDatos.ModificarUsuario(objUsuario);
       }

       public void AgregarPermiso(Permisos objPermiso)
       {
           objCapaDatos = new Datos.CapaDatos();
           objCapaDatos.AgregarPermiso(objPermiso);
       }

        public void ModificarPermiso(Permisos objPermiso)
       {
           objCapaDatos = new Datos.CapaDatos();
           objCapaDatos.ModificarPermisos(objPermiso);
       }

        public void EliminarPermiso(Permisos objPermiso)
        {
            objCapaDatos = new Datos.CapaDatos();
            objCapaDatos.EliminarPermiso(objPermiso);
        }

        public void AgregarBitaAhorro(AHORROS_BIT_TRAS ahorroBit)
        {
            objCapaDatos = new Datos.CapaDatos();
            objCapaDatos.AgregarBitaAhorro(ahorroBit);
        }

        //Mostrar los datos de la nomina seleccionada. Creado machaves
        public IEnumerable<consultarNominaPago_Result> consultarNominas(DateTime fechaPago, string nomina)
        {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.listarNominaPorTipo(fechaPago, nomina);
        }

 

        //Listar el tipo de nominas que existen. Creado machaves
        public List<vTipoNomina> ConsultarTipoNomina()
        {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.ConsultarTipoNomina();
        }

        //Listar el tipo de servicio sinpe que existen. Creado machaves
        public List<TipoServicioSinpe> ConsultarTipoServicioSinpe()
        {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.ConsultarServiciosSinpe();
        }

        //Listar los parametros del archivo. Creado machaves
        public List<ParametrosArcCGP> ConsultarParametrosArcCGP()
        {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.ConsultarParametrosArcCGP();
        }
        //Modifcar parametros cgp. Creado machaves
        public void ModificarParametroCGP(ParametrosArcCGP objParametro)
        {
            objCapaDatos = new Datos.CapaDatos();
            objCapaDatos.ActualizarParametrosCGP(objParametro);
        }

        public void RegistroTablaPago(CargaPagosCGP cargaPagosCGP)
        {
            objCapaDatos = new Datos.CapaDatos();
            objCapaDatos.RegistroTablaPago(cargaPagosCGP);
        }

        //Mostrar los datos de el pago cgp mediante archivo. Creado machaves
        public IEnumerable<consultarPagosCGP_Result> consultarPagosCGP(string tipoMoneda)
        {
            objCapaDatos = new Datos.CapaDatos();
            return objCapaDatos.listarPagosCGP(tipoMoneda);
        }
        //eliminar los datos cargados a la tabla. machaves
        public void EliminarDatosPagoCGP(CargaPagosCGP objPagos)
        {
            objCapaDatos = new Datos.CapaDatos();
            objCapaDatos.EliminarDatosPagoCGP(objPagos);
        }

    #endregion


    }
}
