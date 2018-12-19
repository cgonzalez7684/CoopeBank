using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Datos.EntidadesAux;
using System.IO;

namespace Datos
{
    public class CapaDatos
    {

        OracleCommand cmd;
        OracleConnection conn;
        string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
        OracleTransaction transaction;

        #region "MetodosOracle"


        #region "Pantalla cancelacion creditos incobrables"

        public List<OpeIncob> ConsultarCreditosIncobrables()
        {
            try
            {

                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select B.DES_IDENTIFICACION,B.COD_CLIENTE,B.NOM_CLIENTE,A.NUM_OPERACION,A.FEC_ULTPINT,ABS(C.MON_CREDITO - C.MON_DEBITO) SALDO from CREDITO.CR_OPERACIONES A " +
                                  " INNER JOIN CLIENTES.CL_CLIENTES B " +
                                  "     ON A.COD_CLIENTE = B.COD_CLIENTE " +
                                  " INNER JOIN CREDITO.CR_SALDOS C " +
                                  "     ON A.NUM_OPERACION = C.NUM_OPERACION " +
                                  "WHERE A.IND_INCOBRABLE = 'S' AND C.COD_TIPOSALDO = 1 AND ABS(C.MON_CREDITO - C.MON_DEBITO)>0 AND ROWNUM <= 9" +
                                  "ORDER BY A.FEC_ULTPINT DESC ";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<OpeIncob> ListaOpeIncob = new List<OpeIncob>();
                while (dr.Read())
                {
                    OpeIncob objOpeIncob = new OpeIncob();
                    objOpeIncob.DES_IDENTIFICACION = dr.GetString(0);
                    objOpeIncob.COD_CLIENTE = dr.GetInt32(1);
                    objOpeIncob.NOM_CLIENTE = dr.GetString(2);
                    objOpeIncob.NUM_OPERACION = dr.GetString(3);
                    objOpeIncob.FEC_ULTPINT = dr.GetDateTime(4);
                    objOpeIncob.Saldo = dr.GetDecimal(5);
                    objOpeIncob.CancelarSaldo = 0; //La encontradas estarian en cero
                    ListaOpeIncob.Add(objOpeIncob);
                }

                conn.Close();
                conn.Dispose();
                return ListaOpeIncob;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Func_ConseReciboCredito() 
        {

            try
            {
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.Connection = conn;              
                cmd.CommandText = "CREDITO.Cr_pagos02.consecutivo_recibo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new OracleParameter("p_compania", OracleDbType.Varchar2, 32767, "01001001", ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_compania_orig", OracleDbType.Varchar2, 32767, "01001001", ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_ind_todo_deposito", OracleDbType.Varchar2, 2, "SI", ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("SalidaNula", OracleDbType.Int64, DBNull.Value, ParameterDirection.Output)); //al paracer ejecutar una funcion de oracle con mas de dos parametros tipo output no es valido, maximo dos
                cmd.Parameters.Add(new OracleParameter("p_consecutivo", OracleDbType.Int64, DBNull.Value, ParameterDirection.Output));
                cmd.Parameters.Add(new OracleParameter("p_recibo_control", OracleDbType.Varchar2, 32767, DBNull.Value, ParameterDirection.Output));
                cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Int64, DBNull.Value, ParameterDirection.ReturnValue));   
                conn.Open();
                cmd.ExecuteNonQuery();
                int Recibo = -1;
                Recibo = Convert.ToInt32(cmd.Parameters["p_consecutivo"].Value.ToString());               
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                return Recibo;


            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public void RegistrarCancelacionCredito(List<OpeIncob> ListadoIncobrables)
        {
            try
            {
                OracleTransaction transaction;

                foreach (OpeIncob item in ListadoIncobrables)
                {

                    conn = new OracleConnection(cadena);
                    cmd = new OracleCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Connection = conn;
                    conn.Open();                    
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);  //SE ABRE LA TRANSACCION                    
                    cmd.Transaction = transaction;


                    //************************************SE OBTIENEN DATOS PARA REGISTRAR LA CANCELACION DEL CREDITO********************************//

                    //SE OBTIENE EL CONSECUTIVO DEL RECIBO
                    int Recibo = Func_ConseReciboCredito(); 

                    if (Recibo <= 0){
                        throw new Exception();
                    }


                    //SE OBTIENE EL SALDO ACTUAL DE LA OPERACION
                    cmd.CommandText = "Select NVL(ABS(MON_CREDITO-MON_DEBITO),0) from CREDITO.CR_SALDOS Where NUM_OPERACION = :NUM_OPERACION AND COD_TIPOSALDO = 1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("NUM_OPERACION", OracleDbType.Varchar2, 20, item.NUM_OPERACION, ParameterDirection.Input));
                    double P_SALDOANT = Convert.ToDouble(cmd.ExecuteScalar());


                    int rs = -1; //Bandera para control transaccional


                    cmd.CommandText = "Select NVL(ABS(MON_CREDITO-MON_DEBITO),0) from CREDITO.CR_SALDOS Where NUM_OPERACION = :NUM_OPERACION AND COD_TIPOSALDO = 1";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("NUM_OPERACION", OracleDbType.Varchar2, 20, item.NUM_OPERACION, ParameterDirection.Input));
                    cmd.ExecuteNonQuery();


                    //SE DEJA EL SALDO EN CERO
                    cmd.CommandText = "Update CREDITO.CR_SALDOS SET MON_CREDITO = MON_DEBITO WHERE NUM_OPERACION = :NUM_OPERACION AND COD_TIPOSALDO = 1";
                    cmd.Parameters.Add(new OracleParameter("NUM_OPERACION", OracleDbType.Varchar2, 20, item.NUM_OPERACION, ParameterDirection.Input));
                    rs = cmd.ExecuteNonQuery();
                    

                    if (rs <= 0)
                    {
                        throw new Exception();
                    }

                    //SE CAMBIA EL ESTADO DE LA OPERACION A 6 (CANCELADA) Y SE ESTABLECE LA FECHA DE CANCELACION
                    cmd.CommandText = "Update CREDITO.CR_OPERACIONES SET IND_ESTADO = 6, FEC_CANCELACION = TO_DATE(SYSDATE,'DD/MM/YYYY') WHERE NUM_OPERACION = :NUM_OPERACION";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("NUM_OPERACION", OracleDbType.Varchar2, 20, item.NUM_OPERACION, ParameterDirection.Input));
                    rs = -1;
                    rs = cmd.ExecuteNonQuery();

                    if (rs <= 0)
                    {
                        throw new Exception();
                    }

                    //SI EXISTIESEN PAGOS PARCIALES PENDIENTES SE PROCEDE A DEJARLOS EN CERO Y A ESTABLECER EL REGISTRO COMO CANCELADO
                    cmd.CommandText = " UPDATE CREDITO.CR_PAGOS_PARC_PEND " +
                                      " SET INTERES_CORRIENTE = 0, INTERES_MORATORIO = 0, FONDO_MUTUAL = 0, MON_NBCR = 0, MON_POLIZAS = 0, MON_PRINCIPAL = 0, ESTADO ='C'" +
                                      " WHERE  num_operacion = NUM_OPERACION AND ESTADO = 'A'";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("NUM_OPERACION", OracleDbType.Varchar2, 20, item.NUM_OPERACION, ParameterDirection.Input));
                    rs = -1;
                    rs = (cmd.ExecuteNonQuery() == 0) ? 1 : 2; //ESTE UPDATE PUEDE QUE SE DE A COMO PUEDE QUE NO POR LO QUE LA REGLA DE TRANSACCION NO APLICA                  
                  
                    if (rs <= 0)
                    {
                        throw new Exception();
                    }


                    

                    //SE REALIZA EL REGISTRO EN 
                    cmd.CommandText = "CREDITO.CR_TABLAS.INSERTA_HISTREC";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add(new OracleParameter("P_COMPANIA", OracleDbType.Varchar2, 8, "01001001", ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_OPERAICON", OracleDbType.Varchar2, 12, item.NUM_OPERACION, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_RECIBO", OracleDbType.Varchar2, 14, Recibo.ToString().Trim(), ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PRINCIPAL", OracleDbType.Double,item.Saldo, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_INTERES", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_MORA", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_CHEQUES", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_DEPOSITO", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_EFECTIVO", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_MONEDA", OracleDbType.Varchar2, 5, "COL", ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_SALDOANT", OracleDbType.Double, 0, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_SALDOACT", OracleDbType.Double, 0, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_CLIENTE", OracleDbType.Double, 0, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_PROXPAGO", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_INTHASTA", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_VENCIMIEMTO", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_NUMCUOTA", OracleDbType.Double, -1, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("FEC_CUOTA", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_RECONOCIDO", OracleDbType.Double, -1, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_VENCPOLIZA", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_INDRECIBO", OracleDbType.Double,-1, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_FECCOMISION", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_MONCOMISION", OracleDbType.Double, -1, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_FECABONO", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_FECTASA", OracleDbType.Date, DBNull.Value, ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_TIPRECIBO", OracleDbType.Varchar2, 1, "C", ParameterDirection.Input)); //Validar si C es cancelado
                    cmd.Parameters.Add(new OracleParameter("P_CONTROL", OracleDbType.Double, -1, "01001001", ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_USUARIO", OracleDbType.Varchar2, 15, "HayQuePonerUsuario", ParameterDirection.Input)); //??
                    cmd.Parameters.Add(new OracleParameter("P_COD_CENTRO", OracleDbType.Varchar2, 5, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_IND_ENVIO", OracleDbType.Varchar2, 1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_COMPANIA_CANCELA", OracleDbType.Varchar2, 8, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_TASAINT", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_TASAMORA", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_DIASINT", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_DIASMORA", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_INTVENCIDO", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_INTANTICIPADO", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOPRINC", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOINT", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOMORA", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOCOMIS", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOVENC", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_PAGADOANTI", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_NUM_RECIBO_CAJAS", OracleDbType.Double, -1, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_DES_ERROR", OracleDbType.Varchar2, 32767, "", ParameterDirection.Input));
                    
                    


    //                   var_RetVal               NUMBER;
    //var_P_COMPANIA           VARCHAR2 (8);
    //var_P_OPERACION          VARCHAR2 (12);
    //var_P_RECIBO             VARCHAR2 (14);
    //var_P_PRINCIPAL          NUMBER;
    //var_P_INTERES            NUMBER;
    //var_P_MORA               NUMBER;
    //var_P_OTROS              NUMBER;
    //var_P_CHEQUES            NUMBER;
    //var_P_DEPOSITO           NUMBER;
    //var_P_EFECTIVO           NUMBER;
    //var_P_MONEDA             VARCHAR2 (5);
    //var_P_SALDOANT           NUMBER;
    //var_P_SALDOACT           NUMBER;
    //var_P_CLIENTE            NUMBER;
    //var_P_PROXPAGO           DATE;
    //var_P_INTHASTA           DATE;
    //var_P_VENCIMIEMTO        DATE;
    //var_P_NUMCUOTA           NUMBER;
    //var_P_FEC_CUOTA          DATE;
    //var_P_RECONOCIDO         NUMBER;
    //var_P_VENCPOLIZA         DATE;
    //var_P_INDRECIBO          NUMBER;
    //var_P_FECCOMISION        DATE;
    //var_P_MONCOMISION        NUMBER;
    //var_P_FECABONO           DATE;
    //var_P_FECTASA            DATE;
    //var_P_TIPRECIBO          VARCHAR2 (1);
    //var_P_CONTROL            NUMBER;
    //var_P_USUARIO            VARCHAR2 (15);
    //var_P_COD_CENTRO         VARCHAR2 (5);
    //var_P_IND_ENVIO          VARCHAR2 (1);
    //var_P_COMPANIA_CANCELA   VARCHAR2 (8);
    //var_P_TASAINT            NUMBER;
    //var_P_TASAMORA           NUMBER;
    //var_P_DIASINT            NUMBER;
    //var_P_DIASMORA           NUMBER;
    //var_P_INTVENCIDO         NUMBER;
    //var_P_INTANTICIPADO      NUMBER;
    //var_P_PAGADOPRINC        NUMBER;
    //var_P_PAGADOINT          NUMBER;
    //var_P_PAGADOMORA         NUMBER;
    //var_P_PAGADOCOMIS        NUMBER;
    //var_P_PAGADOVENC         NUMBER;
    //var_P_PAGADOANTI         NUMBER;
    //var_P_NUM_RECIBO_CAJAS   NUMBER;
    //var_P_DES_ERROR          VARCHAR2 (32767)

                    //(p_compania         IN cr_histrec.cod_compania%TYPE,
                    //       p_operacion        IN cr_histrec.num_operacion%TYPE,
                    //       p_recibo           IN cr_histrec.num_recibo%TYPE,
                    //       p_principal        IN cr_histrec.mon_principal%TYPE,
                    //       p_interes          IN cr_histrec.mon_intereses%TYPE,
                    //       p_mora             IN cr_histrec.mon_moratorios%TYPE,
                    //       p_otros            IN cr_histrec.mon_otros%TYPE,
                    //       p_cheques          IN cr_histrec.mon_cheque%TYPE,
                    //       p_deposito         IN cr_histrec.mon_deposito%TYPE,
                    //       p_efectivo         IN cr_histrec.mon_efectivo%TYPE,
                    //       p_moneda           IN cr_histrec.cod_moneda%TYPE,
                    //       p_saldoant         IN cr_histrec.mon_saldoant%TYPE,
                    //       p_saldoact         IN cr_histrec.mon_saldoact%TYPE,
                    //       p_cliente          IN cr_histrec.cod_cliente%TYPE,
                    //       p_proxpago         IN cr_histrec.fec_proxpago%TYPE,
                    //       p_inthasta         IN cr_histrec.fec_inthasta%TYPE,
                    //       p_vencimiemto      IN cr_histrec.fec_vencoperacion%TYPE,
                    //       p_numcuota         IN cr_histrec.num_cuotacanc%TYPE,
                    //       p_fec_cuota        IN cr_histrec.fec_cuota%TYPE,
                    //       p_reconocido       IN cr_histrec.mon_intrec%TYPE,
                    //       p_vencpoliza       IN cr_histrec.fec_vencpoliza%TYPE,
                    //       p_indrecibo        IN cr_histrec.ind_recibo%TYPE,
                    //       p_feccomision      IN cr_histrec.fec_comision%TYPE,
                    //       p_moncomision      IN cr_histrec.mon_comision%TYPE,
                    //       p_fecabono         IN cr_histrec.fec_abono%TYPE,
                    //       p_fectasa          IN cr_histrec.fec_tasaint%TYPE,
                    //       p_tiprecibo        IN cr_histrec.tip_recibo%TYPE,
                    //       p_control          IN cr_histrec.num_recibo_control%TYPE,
                    //       p_usuario          IN cr_histrec.cod_usuario%TYPE,
                    //       p_cod_centro       IN cr_histrec.cod_centro%TYPE,
                    //       p_ind_envio        IN cr_histrec.ind_envio%TYPE,
                    //       p_compania_cancela IN cr_histrec.cod_compania_cancelo%TYPE,
                    //       p_tasaint          IN cr_histrec.por_tasa%TYPE,
                    //       p_tasamora         IN cr_histrec.por_tasamora%TYPE,
                    //       p_diasint          IN cr_histrec.num_diasint%TYPE,
                    //       p_diasmora         IN cr_histrec.num_diasmora%TYPE,
                    //       p_intvencido       IN cr_histrec.mon_interes_vencido%TYPE,
                    //       p_intanticipado    IN cr_histrec.mon_interes_anticipado%TYPE,
                    //       p_pagadoprinc      IN cr_histrec.mon_pagado_principal%TYPE,
                    //       p_pagadoint        IN cr_histrec.mon_pagado_interes%TYPE,
                    //       p_pagadomora       IN cr_histrec.mon_pagado_moratorios%TYPE,
                    //       p_pagadocomis      IN cr_histrec.mon_pagado_comision%TYPE,
                    //       p_pagadovenc       IN cr_histrec.mon_pagado_intvencido%TYPE,
                    //       p_pagadoanti       IN cr_histrec.mon_pagado_intanticipado%TYPE,
                    //       p_num_recibo_cajas IN cr_histrec.num_recibo_cajas%TYPE,
                    //       p_des_error        IN OUT varchar2,
                    //       p_fondo_mutual     IN cr_histrec.mon_fondo_mutual%TYPE := 0,
                    //       p_fec_mutual       IN cr_histrec.fec_ultpfm%TYPE   := NULL,
                    //       p_mon_polizas      IN cr_histrec.mon_polizas%TYPE  := 0,
                    //       p_modulo_recibo    IN cr_histrec.cod_modulo%TYPE   := NULL,
                    //       p_mon_difer_escal  IN cr_histrec.mon_difer_escal%TYPE := 0,
                    //       p_cod_cliente_paga IN NUMBER DEFAULT NULL,
                    //       p_Quien_Paga       IN VARCHAR2 DEFAULT NULL,
                    //       p_moncargos        IN cr_histrec.mon_cargo_per%TYPE := 0,
                    //       p_pagadomoncargos  IN cr_histrec.mon_cargo_per_pagado%TYPE := 0,
                    //       p_mon_principal_or  IN cr_histrec.mon_principal_or%TYPE := 0,
                    //       p_mon_interes_cor_or  IN cr_histrec.mon_interes_cor_or%TYPE := 0,
                    //       p_mon_cargos_or    IN cr_histrec.mon_cargos_or%TYPE := 0
                    //       )



                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }


        #endregion


        public void ModificarAvaluo(Avaluo objAv)
        {
            try
            {
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "UPDATE CREDITO.CR_AVALUOS_MAD "+
                                  "SET FEC_AVALUO = :FEC_AVALUO, "+
                                  "    NUM_PERITO = :NUM_PERITO, "+
                                  "    MON_AVALUO = :MON_AVALUO, "+
                                  "    MON_TERRENO = :MON_TERRENO,"+
                                  "    MON_CONSTRUCCION = :MON_CONSTRUCCION, "+
                                  "    MON_VEHICULO = :MON_VEHICULO, "+
                                  "    ESTADO = :ESTADO, "+
                                  "    GENREG = :GENREG, "+
                                  "    COD_TIPOBIEN = :COD_TIPOBIEN, "+
                                  "    IND_BIENADJUDICADO = :IND_BIENADJUDICADO "+
                                  "Where NUM_GARANTIA_MADRE = :NUM_GARANTIA_MADRE";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;                
                cmd.Parameters.Add(new OracleParameter("FEC_AVALUO", objAv.FEC_AVALUO));
                cmd.Parameters.Add(new OracleParameter("NUM_PERITO", objAv.NUM_PERITO));
                cmd.Parameters.Add(new OracleParameter("MON_AVALUO", objAv.MON_AVALUO));
                cmd.Parameters.Add(new OracleParameter("MON_TERRENO", objAv.MON_TERRENO));
                cmd.Parameters.Add(new OracleParameter("MON_CONSTRUCCION", objAv.MON_CONSTRUCCION));
                cmd.Parameters.Add(new OracleParameter("MON_VEHICULO", objAv.MON_VEHICULO));
                cmd.Parameters.Add(new OracleParameter("ESTADO", objAv.ESTADO));
                cmd.Parameters.Add(new OracleParameter("GENREG", objAv.GENREG));
                cmd.Parameters.Add(new OracleParameter("COD_TIPOBIEN", objAv.COD_TIPOBIEN));
                cmd.Parameters.Add(new OracleParameter("IND_BIENADJUDICADO", objAv.IND_BIENADJUDICADO));
                cmd.Parameters.Add(new OracleParameter("NUM_GARANTIA_MADRE", objAv.NUM_GARANTIA_MADRE));               
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
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
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Delete from CREDITO.CR_AVALUOS_MAD WHERE NUM_GARANTIA_MADRE = :NUM_GARANTIA_MADRE";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("NUM_GARANTIA_MADRE", objAv.NUM_GARANTIA_MADRE));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
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
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Insert into CREDITO.CR_AVALUOS_MAD (COD_COMPANIA, NUM_GARANTIA_MADRE, FEC_AVALUO, NUM_PERITO, MON_AVALUO, "+
                    "MON_TERRENO, MON_CONSTRUCCION, MON_VEHICULO, ESTADO, GENREG, COD_TIPOBIEN, IND_BIENADJUDICADO) "+
                    "Values (:COD_COMPANIA, :NUM_GARANTIA_MADRE,:FEC_AVALUO, :NUM_PERITO, :MON_AVALUO, " +
                    ":MON_TERRENO, :MON_CONSTRUCCION, :MON_VEHICULO, :ESTADO, :GENREG, :COD_TIPOBIEN, :IND_BIENADJUDICADO)";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objAv.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_GARANTIA_MADRE", objAv.NUM_GARANTIA_MADRE));
                cmd.Parameters.Add(new OracleParameter("FEC_AVALUO", objAv.FEC_AVALUO));
                cmd.Parameters.Add(new OracleParameter("NUM_PERITO", objAv.NUM_PERITO));
                cmd.Parameters.Add(new OracleParameter("MON_AVALUO", objAv.MON_AVALUO));
                cmd.Parameters.Add(new OracleParameter("MON_TERRENO", objAv.MON_TERRENO));
                cmd.Parameters.Add(new OracleParameter("MON_CONSTRUCCION", objAv.MON_CONSTRUCCION));
                cmd.Parameters.Add(new OracleParameter("MON_VEHICULO", objAv.MON_VEHICULO));
                cmd.Parameters.Add(new OracleParameter("ESTADO", objAv.ESTADO));
                cmd.Parameters.Add(new OracleParameter("GENREG", objAv.GENREG));
                cmd.Parameters.Add(new OracleParameter("COD_TIPOBIEN", objAv.COD_TIPOBIEN));
                cmd.Parameters.Add(new OracleParameter("IND_BIENADJUDICADO", objAv.IND_BIENADJUDICADO));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<MoviBanco> ConsultarMovimientosBancos()
        {
            try
            {      

                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "SELECT COD_COMPANIA, NUM_CUENTA, TIP_MOVIM, NUM_MOVIM,  FEC_MOVIM, COD_ESTADO, " +
                                  "NVL(COD_AJUSTE,' '), NVL(NUM_MOVIM_AJU,' '), NVL(IND_DIFERENCIA,' '), NVL(NOM_BENEFICIARIO,' '), NVL(DOC_CONCILIAR,' '), NVL(DESCRIPCION,' '), NVL(IND_ENVIO_NOTA,' '),NVL(MON_MOVIM,0) FROM CONCILIACION.BC_CONCI_MOVIM_BANCOS";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<MoviBanco> ListadoMovimientos = new List<MoviBanco>();
                while (dr.Read())
                {
                    MoviBanco objMoviBanco = new MoviBanco();
                    objMoviBanco.COD_COMPANIA = dr.GetString(0);
                    objMoviBanco.NUM_CUENTA = dr.GetString(1);
                    objMoviBanco.TIP_MOVIM = dr.GetString(2);
                    objMoviBanco.NUM_MOVIM = dr.GetString(3);
                    objMoviBanco.FEC_MOVIM = dr.GetDateTime(4);
                    objMoviBanco.COD_ESTADO = dr.GetString(5);
                    objMoviBanco.COD_AJUSTE = dr.GetString(6);
                    objMoviBanco.NUM_MOVIM_AJU = dr.GetString(7);
                    objMoviBanco.IND_DIFERENCIA = dr.GetString(8);
                    objMoviBanco.NOM_BENEFICIARIO = dr.GetString(9);
                    objMoviBanco.DOC_CONCILIAR = dr.GetString(10);
                    objMoviBanco.DESCRIPCION = dr.GetString(11);
                    objMoviBanco.IND_ENVIO_NOTA = dr.GetString(12);
                    objMoviBanco.MON_MOVIM = dr.GetDecimal(13);
                    ListadoMovimientos.Add(objMoviBanco);
                }

                conn.Close();
                conn.Dispose();
                return ListadoMovimientos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
       

        public List<TipMoviBanco> ConsultarMoviBanco()
        {
            try
            {
                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "SELECT COD_COMPANIA,COD_TPMOV,DES_TPMOV FROM BANCOS.BC_TIPO_MOV WHERE GENERA_ASIENTO = 'S'";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<TipMoviBanco> ListadoTipMoviBanco = new List<TipMoviBanco>();
                while (dr.Read())
                {
                    TipMoviBanco objTipMoviBanco = new TipMoviBanco();
                    objTipMoviBanco.COD_COMPANIA = dr.GetString(0);
                    objTipMoviBanco.COD_TPMOV = dr.GetString(1);
                    objTipMoviBanco.DES_TPMOV = dr.GetString(2);
                    ListadoTipMoviBanco.Add(objTipMoviBanco);
                }

                conn.Close();
                conn.Dispose();
                return ListadoTipMoviBanco;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<BcEstados> ConsultarEstadosMovimientos()
        {
            try
            {
                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select DISTINCT B.* from CONCILIACION.BC_CONCI_MOVIM_BANCOS A " +
                                  " INNER JOIN BANCOS.BC_ESTADO B ON A.COD_ESTADO = B.COD_ESTADO Order by B.COD_ESTADO ASC";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<BcEstados> ListadoBcEstados = new List<BcEstados>();
                while (dr.Read())
                {
                    BcEstados objBcEstados = new BcEstados();
                    objBcEstados.COD_ESTADO = dr.GetString(0);
                    objBcEstados.ESTADO = dr.GetString(1);
                    ListadoBcEstados.Add(objBcEstados);
                }

                conn.Close();
                conn.Dispose();
                return ListadoBcEstados;
            }
            catch (Exception)
            {

                throw;
            }
        }


   public List<Banco> ConsultarBancos()
        {
            try
            {
                OracleDataReader dr;

                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select COD_COMPANIA,COD_CUENTA,COD_MONEDA,NOM_CUENTA from BANCOS.BC_CUENTA_CORRIENTE order BY COD_COMPANIA ASC";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<Banco> ListadoBancos = new List<Banco>();
                while (dr.Read())
                {
                    Banco objBanco = new Banco();
                    objBanco.COD_COMPANIA = dr.GetString(0);
                    objBanco.COD_CUENTA = dr.GetString(1);
                    objBanco.COD_MONEDA = dr.GetString(2);
                    objBanco.NOM_CUENTA = dr.GetString(3);
                    ListadoBancos.Add(objBanco);
                }

                conn.Close();
                conn.Dispose();
                return ListadoBancos;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //REGISTRO MOVIMIENTO CONCILIADO EN BANCOS
        public void RegistarMoviBanco(MoviBanco objMoviBanco)
        {
            try
            {
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO CONCILIACION.BC_CONCI_MOVIM_BANCOS (COD_COMPANIA, NUM_CUENTA, TIP_MOVIM, " +
                              "NUM_MOVIM, MON_MOVIM, FEC_MOVIM, COD_ESTADO, COD_AJUSTE, NUM_MOVIM_AJU, IND_DIFERENCIA, NOM_BENEFICIARIO, DOC_CONCILIAR, " +
                              "DESCRIPCION, IND_ENVIO_NOTA) VALUES (:COD_COMPANIA, :NUM_CUENTA, :TIP_MOVIM, :NUM_MOVIM, :MON_MOVIM, :FEC_MOVIM, :COD_ESTADO, :COD_AJUSTE, " +
                              ":NUM_MOVIM_AJU, :IND_DIFERENCIA, :NOM_BENEFICIARIO, :DOC_CONCILIAR, :DESCRIPCION, :IND_ENVIO_NOTA)";                
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objMoviBanco.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", objMoviBanco.NUM_CUENTA));
                cmd.Parameters.Add(new OracleParameter("TIP_MOVIM", objMoviBanco.TIP_MOVIM));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM", objMoviBanco.NUM_MOVIM));
                cmd.Parameters.Add(new OracleParameter("MON_MOVIM", objMoviBanco.MON_MOVIM));
                cmd.Parameters.Add(new OracleParameter("FEC_MOVIM", objMoviBanco.FEC_MOVIM));
                cmd.Parameters.Add(new OracleParameter("COD_ESTADO", objMoviBanco.COD_ESTADO));
                cmd.Parameters.Add(new OracleParameter("COD_AJUSTE", objMoviBanco.COD_AJUSTE));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM_AJU", objMoviBanco.NUM_MOVIM_AJU));
                cmd.Parameters.Add(new OracleParameter("IND_DIFERENCIA", objMoviBanco.IND_DIFERENCIA));
                cmd.Parameters.Add(new OracleParameter("NOM_BENEFICIARIO", objMoviBanco.NOM_BENEFICIARIO));
                cmd.Parameters.Add(new OracleParameter("DOC_CONCILIAR", objMoviBanco.DOC_CONCILIAR));
                cmd.Parameters.Add(new OracleParameter("DESCRIPCION", objMoviBanco.DESCRIPCION));
                cmd.Parameters.Add(new OracleParameter("IND_ENVIO_NOTA", objMoviBanco.IND_ENVIO_NOTA));                
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO CT.CT_CONCI_MOVIM_BANCOS (COD_COMPANIA, NUM_CUENTA, TIP_MOVIM, NUM_MOVIM, MON_MOVIM, FEC_MOVIM, COD_ESTADO, COD_AJUSTE, " +
                                  "NUM_MOVIM_AJU, IND_DIFERENCIA, NOM_BENEFICIARIO, DOC_CONCILIAR, TIPO_COONCILIACION, DETALLE) VALUES (:COD_COMPANIA, :NUM_CUENTA, :TIP_MOVIM, " +
                                  ":NUM_MOVIM, :MON_MOVIM, :FEC_MOVIM, :COD_ESTADO, :COD_AJUSTE, :NUM_MOVIM_AJU, :IND_DIFERENCIA, :NOM_BENEFICIARIO, :DOC_CONCILIAR, :TIPO_COONCILIACION, :DETALLE)";

                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objMoviBanco.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", objMoviBanco.NUM_CUENTA));
                cmd.Parameters.Add(new OracleParameter("TIP_MOVIM", objMoviBanco.TIP_MOVIM));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM", objMoviBanco.NUM_MOVIM));
                cmd.Parameters.Add(new OracleParameter("MON_MOVIM", objMoviBanco.MON_MOVIM));
                cmd.Parameters.Add(new OracleParameter("FEC_MOVIM", objMoviBanco.FEC_MOVIM));
                cmd.Parameters.Add(new OracleParameter("COD_ESTADO", objMoviBanco.COD_ESTADO));
                cmd.Parameters.Add(new OracleParameter("COD_AJUSTE", objMoviBanco.COD_AJUSTE));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM_AJU", objMoviBanco.NUM_MOVIM_AJU));
                cmd.Parameters.Add(new OracleParameter("IND_DIFERENCIA", objMoviBanco.IND_DIFERENCIA));
                cmd.Parameters.Add(new OracleParameter("NOM_BENEFICIARIO", objMoviBanco.NOM_BENEFICIARIO));
                cmd.Parameters.Add(new OracleParameter("DOC_CONCILIAR", objMoviBanco.DOC_CONCILIAR));
                cmd.Parameters.Add(new OracleParameter("TIPO_COONCILIACION", ""));
                cmd.Parameters.Add(new OracleParameter("DETALLE", objMoviBanco.DESCRIPCION));

                cmd.ExecuteNonQuery();        
                            




                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //REGISTRO MOVIMIENTO CONCILIADO EN BANCOS
        public void ActualizarMoviBanco(MoviBanco objMoviBanco)
        {
            try
            {
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = " UPDATE CONCILIACION.BC_CONCI_MOVIM_BANCOS " +
                    " SET    COD_COMPANIA     = :COD_COMPANIA, " +
                    "       NUM_CUENTA       = :NUM_CUENTA, " +
                    "       TIP_MOVIM        = :TIP_MOVIM, " +
                    "       NUM_MOVIM        = :NUM_MOVIM, " +
                    "       MON_MOVIM        = :MON_MOVIM, " +
                    "       FEC_MOVIM        = TO_DATE('" + objMoviBanco.FEC_MOVIM.Date.ToString("dd/MM/yyyy") + "','DD/MM/YYYY'), " +
                    "       COD_ESTADO       = :COD_ESTADO, " +
                    "       COD_AJUSTE       = :COD_AJUSTE, " +
                    "       NUM_MOVIM_AJU    = :NUM_MOVIM_AJU, " +
                    "       IND_DIFERENCIA   = :IND_DIFERENCIA, " +
                    "       NOM_BENEFICIARIO = :NOM_BENEFICIARIO, " +
                    "       DOC_CONCILIAR    = :DOC_CONCILIAR, " +
                    "       DESCRIPCION      = :DESCRIPCION, " +
                    "       IND_ENVIO_NOTA   = :IND_ENVIO_NOTA " +
                    "WHERE  COD_COMPANIA     = :COD_COMPANIA " +
                    "AND    NUM_CUENTA       = :NUM_CUENTA " +
                    "AND    TIP_MOVIM        = :TIP_MOVIM " +
                    "AND    NUM_MOVIM        = :NUM_MOVIM ";
                  //  "AND    FEC_MOVIM        = TO_DATE('" + objMoviBanco.FEC_MOVIM.Date.ToString("dd/MM/yyyy") + "','DD/MM/YYYY') ";

                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objMoviBanco.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", objMoviBanco.NUM_CUENTA));
                cmd.Parameters.Add(new OracleParameter("TIP_MOVIM", objMoviBanco.TIP_MOVIM));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM", objMoviBanco.NUM_MOVIM));
                cmd.Parameters.Add(new OracleParameter("MON_MOVIM", objMoviBanco.MON_MOVIM));
                //cmd.Parameters.Add(new OracleParameter("FEC_MOVIM", objMoviBanco.FEC_MOVIM));
                cmd.Parameters.Add(new OracleParameter("COD_ESTADO", objMoviBanco.COD_ESTADO));
                cmd.Parameters.Add(new OracleParameter("COD_AJUSTE", objMoviBanco.COD_AJUSTE));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM_AJU", objMoviBanco.NUM_MOVIM_AJU));
                cmd.Parameters.Add(new OracleParameter("IND_DIFERENCIA", objMoviBanco.IND_DIFERENCIA));
                cmd.Parameters.Add(new OracleParameter("NOM_BENEFICIARIO", objMoviBanco.NOM_BENEFICIARIO));
                cmd.Parameters.Add(new OracleParameter("DOC_CONCILIAR", objMoviBanco.DOC_CONCILIAR));
                cmd.Parameters.Add(new OracleParameter("DESCRIPCION", objMoviBanco.DESCRIPCION));
                cmd.Parameters.Add(new OracleParameter("IND_ENVIO_NOTA", objMoviBanco.IND_ENVIO_NOTA));
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText =   " UPDATE CT.CT_CONCI_MOVIM_BANCOS " +           
                                    " SET   MON_MOVIM          = :MON_MOVIM, " +                                    
                                    "       COD_ESTADO         = :COD_ESTADO, " +
                                    "       COD_AJUSTE         = :COD_AJUSTE, " +
                                    "       NUM_MOVIM_AJU      = :NUM_MOVIM_AJU, " +
                                    "       IND_DIFERENCIA     = '', " +
                                    "       NOM_BENEFICIARIO   = :NOM_BENEFICIARIO, " +
                                    "       DOC_CONCILIAR      = :DOC_CONCILIAR, " +
                                    "       TIPO_COONCILIACION = '', " +
                                    "       DETALLE            = :DESCRIPCION "  +
                                    " WHERE  COD_COMPANIA       = :COD_COMPANIA " +
                                    " AND    NUM_CUENTA         = :NUM_CUENTA " +
                                    " AND    TIP_MOVIM          = :TIP_MOVIM " +
                                    " AND    NUM_MOVIM          = :NUM_MOVIM " +
                                    " AND    FEC_MOVIM        = :FEC_MOVIM ";
                                    

                //cmd.CommandType = CommandType.Text;
                //cmd.CommandTimeout = 0;
                //cmd.Connection = conn;
                


                cmd.Parameters.Add(new OracleParameter("MON_MOVIM", objMoviBanco.MON_MOVIM));
                cmd.Parameters.Add(new OracleParameter("COD_ESTADO", objMoviBanco.COD_ESTADO));
                cmd.Parameters.Add(new OracleParameter("COD_AJUSTE", objMoviBanco.COD_AJUSTE));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM_AJU", objMoviBanco.NUM_MOVIM_AJU));                
                cmd.Parameters.Add(new OracleParameter("NOM_BENEFICIARIO", objMoviBanco.NOM_BENEFICIARIO));
                cmd.Parameters.Add(new OracleParameter("DOC_CONCILIAR", objMoviBanco.DOC_CONCILIAR));
                cmd.Parameters.Add(new OracleParameter("DESCRIPCION", objMoviBanco.DESCRIPCION));                
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objMoviBanco.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", objMoviBanco.NUM_CUENTA));
                cmd.Parameters.Add(new OracleParameter("TIP_MOVIM", objMoviBanco.TIP_MOVIM));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM", objMoviBanco.NUM_MOVIM));              
                cmd.Parameters.Add(new OracleParameter("FEC_MOVIM", objMoviBanco.FEC_MOVIM));
                
               
               
                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                cmd.Dispose();
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
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Delete from CONCILIACION.BC_CONCI_MOVIM_BANCOS  WHERE  COD_COMPANIA = :COD_COMPANIA "+
                                  " AND    NUM_CUENTA         = :NUM_CUENTA "+
                                  " AND    TIP_MOVIM          = :TIP_MOVIM "+
                                  " AND    NUM_MOVIM          = :NUM_MOVIM "+
                                  " AND    FEC_MOVIM          = :FEC_MOVIM ";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objMoviBanco.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", objMoviBanco.NUM_CUENTA));
                cmd.Parameters.Add(new OracleParameter("TIP_MOVIM", objMoviBanco.TIP_MOVIM));
                cmd.Parameters.Add(new OracleParameter("NUM_MOVIM", objMoviBanco.NUM_MOVIM));          
                cmd.Parameters.Add(new OracleParameter("FEC_MOVIM", objMoviBanco.FEC_MOVIM));
                conn.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "Delete from CT.CT_CONCI_MOVIM_BANCOS  WHERE  COD_COMPANIA = :COD_COMPANIA " +
                                  " AND    NUM_CUENTA         = :NUM_CUENTA " +
                                  " AND    TIP_MOVIM          = :TIP_MOVIM " +
                                  " AND    NUM_MOVIM          = :NUM_MOVIM " +
                                  " AND    FEC_MOVIM          = :FEC_MOVIM ";

                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

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
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Insert into FV_VENTAS.FV_VENDEDORES (COD_COMPANIA, COD_VENDEDOR, COD_USUARIO, IND_ESTADO, NOMBRE_VENDEDOR, " +
                                  "  MTO_META_CAPTACION, MTO_META_CREDITO, MTO_META_SEGURO, IND_ORIGEN, TELEFONO, FAX, IND_FORMA_PAGO) " +
                                  " Values (:COD_COMPANIA,:COD_VENDEDOR, :COD_USUARIO, :IND_ESTADO, :NOMBRE_VENDEDOR, :MTO_META_CAPTACION, "+
                                  " :MTO_META_CREDITO, :MTO_META_SEGURO, :IND_ORIGEN, :TELEFONO,  :FAX, :IND_FORMA_PAGO); ";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", objAv.COD_COMPANIA));
                cmd.Parameters.Add(new OracleParameter("COD_VENDEDOR", objAv.COD_VENDEDOR));
                cmd.Parameters.Add(new OracleParameter("COD_USUARIO", objAv.COD_USUARIO));
                cmd.Parameters.Add(new OracleParameter("IND_ESTADO", objAv.IND_ESTADO));
                cmd.Parameters.Add(new OracleParameter("NOMBRE_VENDEDOR", objAv.NOMBRE_VENDEDOR));
                cmd.Parameters.Add(new OracleParameter("MTO_META_CAPTACION", objAv.MTO_META_CAPTACION));
                cmd.Parameters.Add(new OracleParameter("MTO_META_CREDITO", objAv.MTO_META_CREDITO));
                cmd.Parameters.Add(new OracleParameter("MTO_META_SEGURO", objAv.MTO_META_SEGURO));
                cmd.Parameters.Add(new OracleParameter("IND_ORIGEN", objAv.IND_ORIGEN));
                cmd.Parameters.Add(new OracleParameter("TELEFONO", objAv.TELEFONO));
                cmd.Parameters.Add(new OracleParameter("FAX", objAv.FAX));
                cmd.Parameters.Add(new OracleParameter("IND_FORMA_PAGO", objAv.IND_FORMA_PAGO));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ConsultarSiguienteVendendedor()
        {
            try
            {
                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select max(COD_VENDEDOR) from FVENTAS.FV_VENDEDORES";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());            


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
                OracleDataReader dr;

                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select distinct * from FVENTAS.FV_VENDEDORES where COD_COMPANIA = '01001001' ORDER BY COD_VENDEDOR ASC";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<Vendedor> ListadoVendedores = new List<Vendedor>();
                while (dr.Read())
                {
                    Vendedor objVend = new Vendedor();
                    objVend.COD_COMPANIA = dr.GetString(0);
                    objVend.COD_VENDEDOR = dr.GetInt32(1);
                    objVend.COD_USUARIO = dr.GetString(2);
                    objVend.IND_ESTADO = dr.GetString(3)=="A"?"1":"0";
                    objVend.NOMBRE_VENDEDOR = dr.GetString(4);
                    objVend.MTO_META_CAPTACION = dr.GetDecimal(5);
                    objVend.MTO_META_CREDITO = dr.GetDecimal(6);
                    objVend.MTO_META_SEGURO = dr.GetDecimal(7);
                    objVend.IND_ORIGEN = dr.GetString(8);
                    objVend.TELEFONO = dr.IsDBNull(9) == true ? "" : dr.GetString(9);
                    objVend.FAX = dr.IsDBNull(10) == true ? "" : dr.GetString(10);
                    objVend.IND_FORMA_PAGO = dr.IsDBNull(11) == true ? "" : dr.GetString(11);
                    ListadoVendedores.Add(objVend);

                }

                conn.Close();
                conn.Dispose();
                return ListadoVendedores;


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
                OracleDataReader dr;
                
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText =
                 "Select " +
                 " B.COD_COMPANIA, " +
                 " (SELECT DES_IDENTIFICACION FROM CLIENTES.CL_CLIENTES WHERE COD_CLIENTE = B.COD_CLIENTE) DES_IDENTIFICACION, " +
                 " B.COD_CLIENTE, " +
                 "(SELECT NOM_CLIENTE FROM CLIENTES.CL_CLIENTES WHERE COD_CLIENTE = B.COD_CLIENTE) NOM_CLIENTE, " +
                 " B.NUM_OPERACION, " +
                 " B.FEC_CONSTITUCION," +
                 " B.FEC_VENCIMIENTO, " +
                 " B.MON_ORIGINAL, " +
                 " ABS(C.MON_CREDITO - C.MON_DEBITO) SALDO, " +
                 " A.NUM_GARANTIA, " +
                 " NVL((SELECT NUM_GARANTIA_ORIGINAL FROM CREDITO.CR_GARANTIA_MADRE WHERE NUM_GARANTIA_MADRE = A.NUM_GARANTIA),'NO REGISTRA') GARANTIASIC," +
                 "(SELECT C.DES_ESTADO FROM CREDITO.CR_ESTADOS_OPER C WHERE IND_ESTADO = B.IND_ESTADO) ESTADO " +
                 " From CREDITO.CR_GARANTIA_SOLICITUD A " +
                 "  INNER JOIN CREDITO.CR_OPERACIONES B " +
                 "       ON A.NUM_SOLICITUD = B.NUM_SOLICITUD " +
                 "   INNER JOIN CREDITO.CR_SALDOS C " +
                 "       ON B.NUM_OPERACION = C.NUM_OPERACION " +
                 " Where C.COD_TIPOSALDO = 1 AND A.NUM_GARANTIA NOT IN (SELECT NUM_GARANTIA_MADRE FROM CREDITO.CR_AVALUOS_MAD)" +
                 " ORDER BY B.FEC_CONSTITUCION DESC ";
               
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<Operacion> ListadoOperaciones = new List<Operacion>();
                while (dr.Read())
                {
                    Operacion Ope = new Operacion();
                    Ope.COD_COMPANIA = dr.GetString(0);
                    Ope.DES_IDENTIFICACION = dr.GetString(1);
                    Ope.COD_CLIENTE = dr.GetInt32(2);
                    Ope.NOM_CLIENTE = dr.GetString(3);
                    Ope.NUM_OPERACION = dr.GetString(4);
                    Ope.FEC_CONSTITUCION = dr.GetDateTime(5);
                    Ope.FEC_VENCIMIENTO = dr.GetDateTime(6);
                    Ope.MON_ORIGINAL = dr.GetDecimal(7);
                    Ope.SALDO = dr.GetDecimal(8);
                    Ope.NUM_GARANTIA = dr.GetDecimal(9);
                    Ope.GARANTIASIC = dr.GetString(10);
                    Ope.ESTADO = dr.GetString(11);
                    ListadoOperaciones.Add(Ope);     
                }

                conn.Close();
                conn.Dispose();
                return ListadoOperaciones;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UsuarioPS> ConsultarUsuarioPS()
        {
            try
            {
                OracleDataReader dr;

                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select COD_USUARIO,DES_NOMBRE from GENERAL.GL_USUARIOS";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<UsuarioPS> ListadoUsuariosPS = new List<UsuarioPS>();
                while (dr.Read())
                {
                    UsuarioPS UsPS = new UsuarioPS();
                    UsPS.COD_USUARIO = dr.GetString(0);
                    UsPS.DES_NOMBRE = dr.GetString(1);
                    ListadoUsuariosPS.Add(UsPS);
                }

                conn.Close();
                conn.Dispose();
                return ListadoUsuariosPS;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Producto> ConsultarTipoProductos()
        {
            try
            {

                
                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select COD_INVERSION,DES_INVERSION from INVERSIONES.IN_TIPOS_INV WHERE IND_ALAVISTA = 'S' OR COD_INVERSION = '103' ORDER BY IN_TIPOS_INV.COD_INVERSION ASC";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<Producto> ListadoProductos = new List<Producto>();
                while (dr.Read())
                {
                    Producto objProducto = new Producto();
                    objProducto.COD_INVERSION = dr.GetString(0);
                    objProducto.DES_INVERSION = dr.GetString(1);
                    ListadoProductos.Add(objProducto);
                }
                conn.Close();
                conn.Dispose();
                return ListadoProductos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ConsultarClienteContrato(string DES_IDENTIFICACION,string IND_INVERSION, string COD_COMPANIA)
        {
            try
            {


                
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandText = "Select ltrim(rtrim(B.COD_CLIENTE))||'>'||ltrim(rtrim(B.NUM_CONTRATO))||'>'||ltrim(rtrim(TO_CHAR(MON_SALDO_REAL,'999999999D99'))) CODIGO " +
                                   " from CLIENTES.CL_CLIENTES A INNER JOIN INVERSIONES.IN_CINVERSION B " +
                                   " on A.COD_CLIENTE = B.COD_CLIENTE  " +
                                   " WHERE A.DES_IDENTIFICACION = :DES_IDENTIFICACION AND B.IND_INVERSION = :IND_INVERSION AND COD_COMPANIA = :COD_COMPANIA AND ROWNUM = 1";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("DES_IDENTIFICACION", DES_IDENTIFICACION));
                cmd.Parameters.Add(new OracleParameter("IND_INVERSION", IND_INVERSION));
                cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", COD_COMPANIA));
                conn.Open();                
                string Resultado = string.Empty;
                object Resul = cmd.ExecuteScalar();
                if (Resul == null)
                {
                    Resultado = "-1>-1>-1";
                }
                else
                {
                    Resultado = Convert.ToString(Resul);
                }                
                conn.Close();
                conn.Dispose();
                return Resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<LiqProduct> ConsultarProductosLiquidaciones(int tipo,DateTime Fec_Carga)
        {
            try
            {


                OracleDataReader dr;
                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                //cmd.CommandText = "Select * from DB_UTILIDADES.UT_LIQUIDACIONSOBRANTES order by FEC_CARGA desc";
                if (tipo == 1)
                {
                    cmd.CommandText = "Select DES_IDENTIFICACION, MON_APLICADO, COD_CUENTA,COD_INVERSION, COD_USUARIO_CARGA, FEC_CARGA, FEC_LIQUIDA, COD_USUARIO_LIQUIDA, COD_COMPANIA, NUM_CONTRATO from DB_UTILIDADES.UT_LIQUIDACIONSOBRANTES where FEC_LIQUIDA = to_date('01/01/1900','DD/MM/YYYY') order by FEC_CARGA desc";
                }
                else
                {
                    cmd.CommandText = "Select DES_IDENTIFICACION, MON_APLICADO, COD_CUENTA,COD_INVERSION, COD_USUARIO_CARGA, FEC_CARGA, FEC_LIQUIDA, COD_USUARIO_LIQUIDA, COD_COMPANIA, NUM_CONTRATO " +
                                      "from DB_UTILIDADES.UT_LIQUIDACIONSOBRANTES Where to_char(FEC_CARGA,'DD/MM/YYYY') = to_char(:FEC_CARGA,'DD/MM/YYYY') and FEC_LIQUIDA = to_date('01/01/1900','DD/MM/YYYY')";
                    cmd.Parameters.Add(new OracleParameter("FEC_CARGA", Convert.ToDateTime(Fec_Carga.ToString("dd/MM/yyyy"))));
                    
                    
                }
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                dr = cmd.ExecuteReader();
                List<LiqProduct> ListadoProductosLiq = new List<LiqProduct>();
                
                while (dr.Read())
                {
                    LiqProduct objLiqProduct = new LiqProduct();
                    objLiqProduct.DES_IDENTIFICACION = dr.GetString(0);
                    objLiqProduct.MON_APLICADO = dr.GetDecimal(1);
                    objLiqProduct.COD_CUENTA = dr.GetString(2);
                    objLiqProduct.COD_INVERSION = dr.GetString(3);
                    objLiqProduct.COD_USUARIO_CARGA = dr.GetString(4);
                    objLiqProduct.FEC_CARGA = dr.GetDateTime(5);
                    objLiqProduct.FEC_LIQUIDA = dr.GetDateTime(6);
                    objLiqProduct.COD_USUARIO_LIQUIDA = dr.GetString(7);
                    objLiqProduct.COD_COMPANIA = dr.GetString(8);
                    objLiqProduct.NUM_CONTRATO = dr.GetInt64(9);
                    objLiqProduct.COD_CLIENTE = Convert.ToInt32(ConsultarClienteContrato(objLiqProduct.DES_IDENTIFICACION, objLiqProduct.COD_INVERSION, objLiqProduct.COD_COMPANIA).Split('>')[0]);
                    
                    ListadoProductosLiq.Add(objLiqProduct);
                }
                conn.Close();
                conn.Dispose();
                return ListadoProductosLiq;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object [] AplicarLiquidacion(List<LiqProduct> ListoAplicar)
        {
            
            string CadenaError = string.Empty;
            string ErrorBitacora = string.Empty;
            object[] ArregloRespuesta = new object[3]; 
            int Resultado = -1; //Para dar respuesta al proceso.
            List<string> ListadoNoLiquidados = new List<string>();
            try
            { 
                
                

                OracleTransaction transaction;


                foreach (LiqProduct item in ListoAplicar)
                {

                    //SE VALIDA QUE AUN EL MON_SALDO_REAL TENGA DINERO SINO SE CONTINUA CON EL SIGUIENTE REGISTRO

                   
                   
                    string MON_SALDO_ANT = "-1";
                    MON_SALDO_ANT = ConsultarClienteContrato(item.DES_IDENTIFICACION,item.COD_INVERSION,item.COD_COMPANIA).Split('>')[2];
                    Decimal MON_SALDO_ANTBD = -1;
                    MON_SALDO_ANTBD = Convert.ToDecimal(MON_SALDO_ANT);

                    CadenaError = "Contrato: "+item.NUM_CONTRATO.ToString()+" > Cliente: "+item.COD_CLIENTE.ToString()+" > MontoLiquidar: "+MON_SALDO_ANTBD.ToString();

                    if (MON_SALDO_ANTBD <= 0 || MON_SALDO_ANTBD < item.MON_APLICADO)
                    {
                        ListadoNoLiquidados.Add(item.DES_IDENTIFICACION + "-> Monto por liquidar: " + Convert.ToString(item.MON_APLICADO) + ", Monto actual saldo producto: " + Convert.ToString(MON_SALDO_ANTBD)); //Se guarda que personas no se lograron liquidar
                        continue;
                    }

                    DateTime FEC_MOVT = DateTime.Now;
                   

                    conn = new OracleConnection(cadena);
                    cmd = new OracleCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Connection = conn;
                    conn.Open();
                    //
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);  //SE ABRE LA TRANSACCION

                    
                   
                    //SE RESTA EL SALDO AL PRODUCTO
                    cmd.Transaction = transaction;

                    //Tuve que agregar este alter ya que el dato TO_DATE(SYSDATE,'DD/MM/YYYY') lo estaba guardando en 
                    //base de datos como 13/08/0018 el año lo estaba mandando mal                    
                    cmd.CommandText = "alter session set nls_date_format = 'DD/MM/YYYY'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Update INVERSIONES.IN_CINVERSION " +
                                       "set MON_SALDO_REAL = MON_SALDO_REAL - :RESTAR, " +
                                       "    MON_SALDO = MON_SALDO - :RESTAR2  " +
                                       "Where NUM_CONTRATO = :NUM_CONTRATO AND COD_COMPANIA = :COD_COMPANIA AND COD_CLIENTE = :COD_CLIENTE";

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("RESTAR", item.MON_APLICADO));
                    cmd.Parameters.Add(new OracleParameter("RESTAR2", item.MON_APLICADO));
                    cmd.Parameters.Add(new OracleParameter("NUM_CONTRATO", item.NUM_CONTRATO));
                    cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", item.COD_COMPANIA));
                    cmd.Parameters.Add(new OracleParameter("COD_CLIENTE", item.COD_CLIENTE));
                    cmd.ExecuteNonQuery();

                    //SE OBTIENE EL CONSECUTIVO DE MOVIMIENTO
                    cmd.CommandText = "select IN_SEC_ND.NEXTVAL from dual";
                    int NumeroMovimiento = Convert.ToInt32(cmd.ExecuteScalar());

                    //SE REGISTRA LA NOTA DE DEBITO
                    cmd.CommandText = "INSERT INTO INVERSIONES.IN_NDBCR (COD_COMPANIA, NUM_CUENTA, NUM_MOVIMIENTO, " +
                                      " COD_TIPOMOV, NUM_DOCUMENTO, TIPO_DOCUM, COD_MONEDA, COD_CLIENTE, FEC_MOV, " +
                                      "  FEC_VALOR, MON_MOVIMIENTO, COD_ESTADO, "+
                                      "  MON_SALDO_ANT, MON_SALDO_ACT, COD_USR_SOLICITA, "+
                                      " COD_USR_APRUEBA, COD_USR_ANULA, OBSERVACIONES1, "+
                                      " OBSERVACIONES2, CTA_CONTABLE, CTA_CORRIENTE, "+
                                      " COD_COMPANIA_GENERA, COD_UBICACION_USR_SOLICITA, COD_UBICACION_USR_APRUEBA, " +
                                      " COD_UBICACION_USR_ANULA, COD_MODULO, IND_SENTINEL) "+
                                      " VALUES ( :COD_COMPANIA, :NUM_CUENTA, :NUM_MOVIMIENTO, :COD_TIPOMOV, :NUM_DOCUMENTO, :TIPO_DOCUM, " +
                                      " :COD_MONEDA, :COD_CLIENTE, :FEC_MOV, TO_DATE(SYSDATE,'DD/MM/YYYY'), :MON_MOVIMIENTO, :COD_ESTADO, :MON_SALDO_ANT, :MON_SALDO_ACT, " +
                                      " :COD_USR_SOLICITA, :COD_USR_APRUEBA, :COD_USR_ANULA, :OBSERVACIONES1, :OBSERVACIONES2, :CTA_CONTABLE, :CTA_CORRIENTE, "+
                                      " :COD_COMPANIA_GENERA, :COD_UBICACION_USR_SOLICITA, :COD_UBICACION_USR_APRUEBA, :COD_UBICACION_USR_ANULA, :COD_MODULO, :IND_SENTINEL)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", item.COD_COMPANIA));
                    cmd.Parameters.Add(new OracleParameter("NUM_CUENTA", Convert.ToInt32(item.NUM_CONTRATO)));
                    cmd.Parameters.Add(new OracleParameter("NUM_MOVIMIENTO", NumeroMovimiento)); 
                    cmd.Parameters.Add(new OracleParameter("COD_TIPOMOV", "ND"));
                    cmd.Parameters.Add(new OracleParameter("NUM_DOCUMENTO", NumeroMovimiento));
                    cmd.Parameters.Add(new OracleParameter("TIPO_DOCUM", "ND"));
                    cmd.Parameters.Add(new OracleParameter("COD_MONEDA", "COL"));
                    cmd.Parameters.Add(new OracleParameter("COD_CLIENTE", item.COD_CLIENTE));
                    cmd.Parameters.Add(new OracleParameter("FEC_MOV", FEC_MOVT));

                   // DateTime dtt = new DateTime(FEC_MOVT.Year, FEC_MOVT.Month, FEC_MOVT.Day);
                    //cmd.Parameters.Add(new OracleParameter("FEC_VALOR", dtt.ToString("dd/M/yyyy")));
                    //cmd.Parameters.Add(new OracleParameter("FEC_VALOR", FEC_MOVT.ToString("M/dd/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))));
                    //cmd.Parameters.Add(new OracleParameter("FEC_VALOR", "08-13-2018"));
                    //cmd.Parameters.Add(new OracleParameter("FEC_VALOR", FEC_MOVT));
                    cmd.Parameters.Add(new OracleParameter("MON_MOVIMIENTO", item.MON_APLICADO));
                    cmd.Parameters.Add(new OracleParameter("COD_ESTADO", "03"));
                    cmd.Parameters.Add(new OracleParameter("MON_SALDO_ANT", MON_SALDO_ANTBD));
                    cmd.Parameters.Add(new OracleParameter("MON_SALDO_ACT", MON_SALDO_ANTBD - item.MON_APLICADO));
                    cmd.Parameters.Add(new OracleParameter("COD_USR_SOLICITA", item.COD_USUARIO_LIQUIDA.ToUpper()));
                    cmd.Parameters.Add(new OracleParameter("COD_USR_APRUEBA", item.COD_USUARIO_LIQUIDA.ToUpper()));
                    cmd.Parameters.Add(new OracleParameter("COD_USR_ANULA", ""));
                    cmd.Parameters.Add(new OracleParameter("OBSERVACIONES1", "LIQUIDACION DE PRODUCTO "+item.COD_INVERSION+" para cliente"+item.DES_IDENTIFICACION+" desde COOPEBANK"));
                    cmd.Parameters.Add(new OracleParameter("OBSERVACIONES2", "LIQUIDACION DE PRODUCTO " + item.COD_INVERSION + " para cliente" + item.DES_IDENTIFICACION + " desde COOPEBANK"));
                    cmd.Parameters.Add(new OracleParameter("CTA_CONTABLE", ""));
                    cmd.Parameters.Add(new OracleParameter("CTA_CORRIENTE",""));
                    cmd.Parameters.Add(new OracleParameter("COD_COMPANIA_GENERA", item.COD_COMPANIA));
                    cmd.Parameters.Add(new OracleParameter("COD_UBICACION_USR_SOLICITA", "001"));
                    cmd.Parameters.Add(new OracleParameter("COD_UBICACION_USR_APRUEBA", "001"));
                    cmd.Parameters.Add(new OracleParameter("COD_UBICACION_USR_ANULA", ""));
                    cmd.Parameters.Add(new OracleParameter("COD_MODULO", "IN"));
                    cmd.Parameters.Add(new OracleParameter("IND_SENTINEL", "S"));

                    

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = " UPDATE DB_UTILIDADES.UT_LIQUIDACIONSOBRANTES " +
                                      " SET FEC_LIQUIDA = :FEC_LIQUIDA," +
                                      "     COD_USUARIO_LIQUIDA = :COD_USUARIO_LIQUIDA " +
                                      " Where NUM_CONTRATO = :NUM_CONTRATO AND FEC_CARGA = :FEC_CARGA AND COD_COMPANIA = :COD_COMPANIA AND DES_IDENTIFICACION = :DES_IDENTIFICACION";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("FEC_LIQUIDA", FEC_MOVT));
                    cmd.Parameters.Add(new OracleParameter("COD_USUARIO_LIQUIDA", item.COD_USUARIO_LIQUIDA.ToUpper()));
                    cmd.Parameters.Add(new OracleParameter("NUM_CONTRATO", item.NUM_CONTRATO));
                    cmd.Parameters.Add(new OracleParameter("FEC_CARGA", item.FEC_CARGA));
                    cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", item.COD_COMPANIA));                   
                    cmd.Parameters.Add(new OracleParameter("DES_IDENTIFICACION", item.DES_IDENTIFICACION));
                    cmd.ExecuteNonQuery();


                    transaction.Commit();
              }

                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                Resultado = 1;

            }
            catch (Exception ex)
            {

                ErrorBitacora = DateTime.Now.ToString() + "->" + Environment.UserName + "->" + Environment.MachineName + Environment.NewLine + "[(CapaDatos)_AplicarLiquidacion]" + "->[" + ex.Message + "] ->[" + CadenaError + "]";
                using (System.IO.FileStream fs = new System.IO.FileStream(@"\\hefesto\CoopeBan\Bitacora.txt", FileMode.Append))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Environment.NewLine+ErrorBitacora);
                    fs.Write(info, 0, info.Length);
                    
                }
                throw new Exception("[(CapaDatos)_AplicarLiquidacion]", ex);             
              
                
            }

            ArregloRespuesta[0] = Resultado;
            ArregloRespuesta[1] = ErrorBitacora;
            ArregloRespuesta[2] = ListadoNoLiquidados;
            return ArregloRespuesta;

        }

        public int RegistrarUT_LIQUIDACIONSOBRANTES(List<LiqProduct> ListadoProductosLiquidar)
        {
            try
            {

                //conn = new OracleConnection(cadena);
                //cmd = new OracleCommand();
                //cmd.CommandText = "Update INVERSIONES.IN_CINVERSION "+
                //                  "set MON_SALDO_REAL = :MON_SALDO_REAL, "+
                //                  "  MON_SALDO = :MON_SALDO_REAL,  "+
                //                  "Where "     

                conn = new OracleConnection(cadena);
                cmd = new OracleCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "Insert into DB_UTILIDADES.UT_LIQUIDACIONSOBRANTES (DES_IDENTIFICACION, MON_APLICADO, COD_CUENTA, COD_INVERSION, COD_USUARIO_CARGA, FEC_CARGA,FEC_LIQUIDA, COD_USUARIO_LIQUIDA, COD_COMPANIA, NUM_CONTRATO) " +
                                      "Values (:DES_IDENTIFICACION, :MON_APLICADO, :COD_CUENTA, :COD_INVERSION, :COD_USUARIO_CARGA, :FEC_CARGA, :FEC_LIQUIDA, :COD_USUARIO_LIQUIDA, :COD_COMPANIA, :NUM_CONTRATO)";                    
                foreach (LiqProduct item in ListadoProductosLiquidar)
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("DES_IDENTIFICACION", item.DES_IDENTIFICACION));
                    cmd.Parameters.Add(new OracleParameter("MON_APLICADO", item.MON_APLICADO));
                    cmd.Parameters.Add(new OracleParameter("COD_CUENTA", item.COD_CUENTA));
                    cmd.Parameters.Add(new OracleParameter("COD_INVERSION", item.COD_INVERSION));
                    cmd.Parameters.Add(new OracleParameter("COD_USUARIO_CARGA", item.COD_USUARIO_CARGA));
                    cmd.Parameters.Add(new OracleParameter("FEC_CARGA", item.FEC_CARGA));
                    cmd.Parameters.Add(new OracleParameter("FEC_LIQUIDA", item.FEC_LIQUIDA));
                    cmd.Parameters.Add(new OracleParameter("COD_USUARIO_LIQUIDA", item.COD_USUARIO_LIQUIDA));
                    cmd.Parameters.Add(new OracleParameter("COD_COMPANIA", item.COD_COMPANIA));
                    cmd.Parameters.Add(new OracleParameter("NUM_CONTRATO", item.NUM_CONTRATO));                      
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                conn.Dispose();
                cmd.Dispose();

                return 1;


            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        #endregion
        #region "Metodos"

        public List<Modulos> ConsultarModulos()
        {
         
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.Modulos.ToList();
            }
        }

        public List<SubOpciones> ConsultarSubOpciones()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.SubOpciones.ToList();
            }
        }

        public List<Permisos> ConsultarPermisos()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.Permisos.ToList();
            }
        }

        public List<Pantallas> ConsultarPantallas()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.Pantallas.ToList();
            }
        }

        public List<Usuarios> ConsultarUsuarios()
        {
            try
            {
                using (CoopeBankEntities bd = new CoopeBankEntities())
                {

                   
                    return bd.Usuarios.ToList();
                   
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public void AgregarUsuario(Usuarios objUsuario)
        {


           
            string ErrorBitacora = string.Empty;
           
            try
            {

                using (CoopeBankEntities bd = new CoopeBankEntities())
                {
                    bd.Usuarios.Add(objUsuario);
                    bd.SaveChanges();
                }

              


            }
            catch (Exception ex)
            {

                //ErrorBitacora = DateTime.Now.ToString() + "->" + Environment.UserName + "->" + Environment.MachineName + Environment.NewLine + "[(CapaDatos)_AgregarUsuario]" + "->[" + ex.Message + "]";
                //using (System.IO.FileStream fs = new System.IO.FileStream(@"\\hefesto\CoopeBan\Bitacora.txt", FileMode.Append))
                //using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\archvivo\Bitacora.txt", FileMode.Append))
                //{
                //    byte[] info = new UTF8Encoding(true).GetBytes(Environment.NewLine + ErrorBitacora);
                //    fs.Write(info, 0, info.Length);

                //}
                throw new Exception("[(CapaDatos)_AgregarUsuario]", ex);


            }
            
           

            

        }

        public void ModificarUsuario(Usuarios objUsuario)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                Usuarios aux = bd.Usuarios.SingleOrDefault(x => x.IdUsuario == objUsuario.IdUsuario);
                if (aux != null)
                {
                     //bd.Usuarios.Attach(objUsuario);
                    aux.Usuario = objUsuario.Usuario;
                    aux.Nombre = objUsuario.Nombre;
                    aux.Apellido1 = objUsuario.Apellido1;
                    aux.Apellido2 = objUsuario.Apellido2;
                    aux.CambiarClave = objUsuario.CambiarClave;
                    aux.Clave = objUsuario.Clave;
                    aux.Correo = objUsuario.Correo;
                    aux.Estado = objUsuario.Estado;
                    
                     
                    
                   // bd.Entry(objUsuario).State = System.Data.Entity.EntityState.Modified;
                    //bd.Usuarios.Add(objUsuario);
                    bd.Entry(aux).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
            }
        }

        public void EliminarUsuario(Usuarios objUsuario)
        {
             using (CoopeBankEntities bd = new CoopeBankEntities())
             {
                Usuarios aux = bd.Usuarios.SingleOrDefault(x => x.IdUsuario == objUsuario.IdUsuario);
                if (aux != null)
                {
                    bd.Usuarios.Remove(aux);
                    bd.SaveChanges();
                }
             }
        }

        public void AgregarPermiso(Permisos objPermisos)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                bd.Permisos.Add(objPermisos);
                bd.SaveChanges();
            }
        }

        public void ModificarPermisos(Permisos objPermisos)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                Permisos aux = bd.Permisos.SingleOrDefault(x => x.IdUsuario == objPermisos.IdUsuario && x.IdObjeto == objPermisos.IdObjeto);
                if (aux != null)
                {
                    //bd.Usuarios.Attach(objUsuario);
                    aux.Visible = objPermisos.Visible;
                    aux.Lectura = objPermisos.Lectura;
                    aux.Borrado = objPermisos.Borrado;
                    aux.Escritura = objPermisos.Escritura;



                    // bd.Entry(objUsuario).State = System.Data.Entity.EntityState.Modified;
                    //bd.Usuarios.Add(objUsuario);
                    bd.Entry(aux).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
            }
        }

        public void EliminarPermiso(Permisos objPermiso)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                Permisos aux = bd.Permisos.Where(x=>x.IdUsuario == objPermiso.IdUsuario && x.IdObjeto == objPermiso.IdObjeto).FirstOrDefault();
                bd.Permisos.Remove(aux);
                bd.SaveChanges();
            }
        }

        public void AgregarBitaAhorro(AHORROS_BIT_TRAS ahorroBit)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                bd.AHORROS_BIT_TRAS.Add(ahorroBit);
                bd.SaveChanges();
            }
        }

        //Mostrar los datos de la nomina seleccionada. Creado machaves
        public IEnumerable<consultarNominaPago_Result> listarNominaPorTipo(DateTime fecPago, string tipoNomina)
        {
            using (var context = new CoopeBankEntities())
            {
                IEnumerable<consultarNominaPago_Result> detalleNom = context.consultarNominaPago(fecPago, tipoNomina).ToArray();
                return detalleNom;
            }
        }
        //Listar el tipo de nominas que existen. Creado machaves
        public List<vTipoNomina> ConsultarTipoNomina()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.vTipoNomina.ToList();
            }
        }

        //Actualizar los consecutivos en la tabla parametros. Creado machaves
        public void ActualizarParametrosCGP(ParametrosArcCGP ObjModif)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                ParametrosArcCGP aux = bd.ParametrosArcCGP.SingleOrDefault(x => x.IdRegistro == 1);
                if (aux != null)
                {
                    aux.IdNumEnvio = ObjModif.IdNumEnvio;
                    aux.IdConsecutivo = ObjModif.IdConsecutivo;
                    aux.FecGeneracion = ObjModif.FecGeneracion;
                   // aux.CodServicio = ObjModif.CodServicio;
                    aux.FecModificacion = ObjModif.FecModificacion;
                    bd.Entry(aux).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
            }
        }
        //Mostrar los parametros existentes. Creado machaves
        public List<ParametrosArcCGP> ConsultarParametrosArcCGP()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.ParametrosArcCGP.ToList();
            }
        }
        //Mostrar los servicios sinpe. Creado machaves
        public List<TipoServicioSinpe> ConsultarServiciosSinpe()
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                return bd.TipoServicioSinpe.ToList();
            }
        }

        //guardar los registros del grid en la tabla cargaPagosCGP machaves
        public void RegistroTablaPago(CargaPagosCGP cargaPagosCGP)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                bd.CargaPagosCGP.Add(cargaPagosCGP);
                bd.SaveChanges();
            }
        }

        //Mostrar los datos de los pagos cgp. Creado machaves
        public IEnumerable<consultarPagosCGP_Result> listarPagosCGP(string tipoMoneda)
        {
            using (var context = new CoopeBankEntities())
            {
                IEnumerable<consultarPagosCGP_Result> detallePago = context.consultarPagosCGP(tipoMoneda).ToArray();
                return detallePago;
            }
        }

        //Eliminar datos tabla pagos cgp machaves
        public void EliminarDatosPagoCGP(CargaPagosCGP objPagos)
        {
            using (CoopeBankEntities bd = new CoopeBankEntities())
            {
                CargaPagosCGP aux = bd.CargaPagosCGP.Where(x => x.IdUsuario == objPagos.IdUsuario).FirstOrDefault();
                bd.CargaPagosCGP.Remove(aux);
                bd.SaveChanges();
            }
        }

        #endregion

    }
}
