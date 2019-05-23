using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generar_OpenOrder
{
    class Libreria
    {
        public static string generar_openorder(string no_orden)
        {
            string query = string.Empty;
            query = "INSERT INTO FDX_OPENORDER (OPO_DEALERID,OPO_PASSWORD,OPO_OrderID,OPO_FechaApertura,OPO_FechaCierre,OPO_FechaPromesa, OPO_TipoOperacion,OPO_TipoOrden,OPO_TipoServicio,OPO_Seguro,OPO_NombreAsesor,OPO_RFCAsesor,OPO_Clave,OPO_Nombre1, OPO_Nombre2,OPO_Nombre3,OPO_Calle,OPO_Numero,OPO_Colonia,OPO_Municipio,OPO_Estado,OPO_CP,OPO_LadaCasa,OPO_TelefonoCasa, OPO_LadaOficina,OPO_TelefonoOficina,OPO_Celular,OPO_EMail,OPO_RazonSocial,OPO_Flotilla,OPO_VIN,OPO_Placas,OPO_KM, OPO_RESULTADO,OPO_FECHA,OPO_CVEUSU,OPO_ENVIO) SELECT '' AS OPO_DEALERID,'' AS OPO_PASWWORD, ORE_IDORDEN AS OPO_OrdenID, convert(varchar(10),convert(datetime,ore_fechaord,103),120) + ' ' + ore_horaord + ':50'  as OPO_FechaApertura, '0000-00-00 00:00:00' as OPO_FechaCierre, convert(varchar(10),convert(datetime,ore_fechaprom,103),120) + ' ' + ore_horaprom + ':00' As OPO_FechaPromesa, 'hyj' AS OPO_TipoOperacion,'publico' AS OPO_TipoOrden,'paquete' AS OPO_TipoServicio, '' as OPO_Seguro, ASESOR.PAR_DESCRIP1 as OPO_NombreAsesor,ASESOR.PAR_DESCRIP2 AS OPO_RFCAsesor, B.PER_TITULO as OPO_Clave, B.PER_NOMRAZON as OPO_Nombre1,B.PER_PATERNO as OPONombre2,B.PER_MATERNO AS OPO_Nombre3, (SUBSTRING(B.PER_CALLE1,1,29) +'#'+ SUBSTRING(B.PER_NUMEXTER,1,10)) as OPO_Calle, B.PER_NUMINER as OPO_Numero,SUBSTRING(B.PER_COLONIA,1,50) as OPO_Colonia,B.PER_DELEGAC as OPO_Municipio, BB.PAR_DESCRIP2 as OPO_Estado,B.PER_CODPOS AS OPO_CP, B.PER_LADA AS OPO_LadaCasa, ('000'+ B.PER_LADA + B.PER_TELEFONO1) as OPOTelefonoCasa, '' AS OPO_LadaOficina,'' AS OPO_TelefonoOficina, B.per_telcelular as OPO_Celular,B.PER_EMAIL as OPOEMail, (case when B.PER_TIPO <> 'MOR' then '' when B.PER_TIPO='MOR' then B.PER_NOMRAZON end) AS OPO_rAZONsOCIAL,ORE_FLOTILLA AS OPO_Flotilla, ORE_NUMSERIE as OPO_VIN, VEH_NOPLACAS AS OPO_Placas, ORE_KILOMETRAJE as OPO_KM,'DESVIO DE OPENORDER SER_ORDENES' AS OPO_RESULTADO, CONVERT (VARCHAR(10), GETDATE() ,103) AS OPO_FECHA,'GMI' AS OPO_CVEUSU, '' AS OPO_ENVIO FROM SER_ORDEN, PER_PERSONAS as B,PNC_PARAMETR AS BB, PNC_PARAMETR AS ASESOR, SER_VEHICULO WHERE ORE_IDORDEN ='"+no_orden+"' AND ORE_IDCLIENTE = B.PER_IDPERSONA AND ORE_IDASESOR = ASESOR.PAR_IDENPARA AND BB.PAR_TIPOPARA ='EO' AND BB.PAR_IDENPARA = B.PER_ESTADO AND VEH_NUMSERIE = ORE_NUMSERIE AND ASESOR.PAR_TIPOPARA ='AS' ";
            return query;
        }

        public static string consultar_openorder(string no_orden)
        {
            string query = string.Empty;
            query = "select opo_orderid as iden from FDX_OPENORDER where OPO_OrderID = '"+no_orden+"'";
            return query;
        }
    }
}
