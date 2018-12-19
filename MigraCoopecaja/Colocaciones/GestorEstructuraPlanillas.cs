using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.EntidadesAux;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace AppEscritorio.Colocaciones
{
    public class GestorEstructuraPlanillas
    {

        string cadena = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = Persefone)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = CORE)));User Id = MIGRACION; Password = Migra18*;";
        List<CamposEnvio> ListadoCamposEnvio;
        string COD_CENTRO { get; set; }

        private void ConsultarCampos()
        {
            
            if (COD_CENTRO.Equals(string.Empty)){
                return;
            }
            string centro = string.Empty;
            try
            {
                using (OracleConnection connORA = new OracleConnection(cadena))
                {
                    DataTable dt = new DataTable();
                    OracleDataReader dr;
                    connORA.Open();
                    OracleCommand Query = new OracleCommand("SELECT COD_CENTRO, ID_CAMPO, NOM_COLUMNA, TIP_DATO, NVL(LON_DATO,0), " +
                                                           "NUM_ORDEN_INICIO,NVL(VAL_DEFECTO,'X'),NVL(RELLENO_IZQ_DER,'X'),NVL(CARACTER_RELLENO,'X') " +
                                                           "FROM   DEDUCCIONES.De_Campos_Envio " +
                                                           "WHERE   Cod_Centro =" + COD_CENTRO + " AND NUM_CONSECUTIVO = 1  and NVL(VAL_DEFECTO,'X') = 'X'" +
                                                           "order by ID_CAMPO ASC", connORA);

                    Query.CommandType = CommandType.Text;
                    Query.CommandTimeout = 0;
                    Query.ExecuteNonQuery();
                    OracleDataAdapter adp = new OracleDataAdapter(Query);
                    dr = Query.ExecuteReader();

                    ListadoCamposEnvio = new List<CamposEnvio>();
                    while (dr.Read())
                    {
                        centro = dr.GetString(0) + ' ' + dr.GetString(2);
                        CamposEnvio objCampoEnvio = new CamposEnvio();
                        objCampoEnvio.COD_CENTRO = dr.GetString(0);
                        objCampoEnvio.ID_CAMPO = dr.GetInt32(1);
                        objCampoEnvio.NOM_COLUMNA = dr.GetString(2);
                        objCampoEnvio.TIP_DATO = dr.GetString(3);
                        objCampoEnvio.LON_DATO = (int)(dr.GetOracleDecimal(4));
                        objCampoEnvio.NUM_ORDEN_INICIO = (int)(dr.GetOracleDecimal(5));
                        objCampoEnvio.VAL_DEFECTO = dr.GetString(6);
                        objCampoEnvio.RELLENO_IZQ_DER = Convert.ToChar(dr.GetValue(7));
                        objCampoEnvio.CARACTER_RELLENO = Convert.ToChar(dr.GetValue(8));
                        ListadoCamposEnvio.Add(objCampoEnvio);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GestorEstructuraPlanillas(string pCOD_CENTRO)
        {
            this.COD_CENTRO = pCOD_CENTRO;
            ConsultarCampos();
        }

        private void CargaLista(string Linea,ref List<PersonaCargaTexto> ListadoCargaTexto)
        {
            PersonaCargaTexto obj = new PersonaCargaTexto();
            string [] Datos = Linea.Split('>');
            obj.Cedula = Datos[0];
            obj.Partida = Convert.ToInt32(Datos[1]);
            obj.Monto = Convert.ToDouble(Datos[2]);
            ListadoCargaTexto.Add(obj);
        }

        public void CargaDatosCentro(List<string> ListadoLineas,ref List<PersonaCargaTexto> ListadoCargaTexto){
            try 
	        {
                foreach (string item in ListadoLineas)
                {
                    switch (COD_CENTRO)
                    {
                        case "1" :
                            CargaLista(Estructura_CCSS(item), ref ListadoCargaTexto);
                            break;
                        case "3" :
                            CargaLista(Estructura_Gobierno(item), ref ListadoCargaTexto);
                            break;
                        default:
                            break;
                    }
                }
		           
	        }
	        catch (Exception ex)
	        {
		
		        throw ex;
	        }
        }

        private string Estructura_CCSS(string line)
        {
            int i = 0;
            int f = 0;
            string LineaReturn = string.Empty;
            CamposEnvio aux = ListadoCamposEnvio.Where(x => x.ID_CAMPO == 1 && x.COD_CENTRO == COD_CENTRO).FirstOrDefault();
            i = aux.NUM_ORDEN_INICIO;
            f = aux.LON_DATO - 2;
            LineaReturn += line.Substring(i + 1, f)+">";

            aux = ListadoCamposEnvio.Where(x => x.ID_CAMPO == 2 && x.COD_CENTRO == COD_CENTRO).FirstOrDefault();
            i = aux.NUM_ORDEN_INICIO;
            f = aux.LON_DATO - 1;
            LineaReturn += line.Substring(i, f)+">";

            aux = ListadoCamposEnvio.Where(x => x.ID_CAMPO == 3 && x.COD_CENTRO == COD_CENTRO).FirstOrDefault();
            i = aux.NUM_ORDEN_INICIO;
            f = aux.LON_DATO;
            LineaReturn += line.Substring(i, f - 3) + "." + line.Substring(i, f).Substring(line.Substring(i, f).Length - 3, 2);

            return LineaReturn;
        }

        private string Estructura_Gobierno(string line)
        {
            string[] Datos = line.Substring(1).Split('\t');
            return String.Join(">", Datos);
        }



    }
}
