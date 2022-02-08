using Dapper;
using PortalDataOwner.Data.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Data
{
    public class ClienteData : Base, IClienteData
    {
        public ClienteData(IConfiguration configuration):base(configuration)
        {
        }
        public List<Dto.Cliente> Obter()
        {
            try
            {
                string strSql = @"select  
                                    isnull(fk_Codigo_cs,isnull(fk_Codigo_info4,isnull(fk_Codigo_leitura_digital,isnull(fk_Codigo_portalsinopress,isnull(fk_Codigo_TopClip,isnull(fk_Codigo_Linear,isnull(fk_Codigo_FabricaIdeias,isnull(fk_Codigo_SA,'')))))))) Codigo, 
                                    st_Nome Nome,
                                    st_NomeFantasia NomeFantasia
                                from 
	                                dm_di_Cliente_DP
                                where  
	                                isnull(fk_Codigo_cs,isnull(fk_Codigo_info4,isnull(fk_Codigo_leitura_digital,isnull(fk_Codigo_portalsinopress,isnull(fk_Codigo_TopClip,isnull(fk_Codigo_Linear,isnull(fk_Codigo_FabricaIdeias,isnull(fk_Codigo_SA,'')))))))) !=''
                                order by
                                    st_NomeFantasia";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    return conexaoBD.Query<Dto.Cliente>(strSql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
