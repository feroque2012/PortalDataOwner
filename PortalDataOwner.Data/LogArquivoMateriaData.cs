using Dapper;
using Microsoft.Extensions.Configuration;
using PortalDataOwner.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Data
{
    public class LogArquivoMateriaData : Base, ILogArquivoMateriaData
    {
        public LogArquivoMateriaData(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Dto.LogArquivoMateria> Obter(string codCliente, DateTime dataEnvio)
        {
            try
            {
                string strSql = @$"
                                select
                                    pk_Codigo Codigo, fk_ChaveImportacao ChaveImportacao, fk_Cliente Cliente, fk_Usuario Usuario, st_NomeArquivo NomeArquivo,
                                    nm_Registros Registros, dt_Envio DataEnvio, sn_Estorno Estorno, dt_Estorno DataEstorno
                                from 
                                    dbo.dm_ft_LogArquivoMateria
                                where 
                                    month(dt_Envio) = month(@dataEnvio) 
                                    and year(dt_Envio) = year(@dataEnvio) 
                                    and fk_Cliente=@codCliente
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    return conexaoBD.Query<Dto.LogArquivoMateria>(strSql, new
                    {
                        codCliente = codCliente,
                        dataEnvio = dataEnvio
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Dto.LogArquivoMateria Obter(int codigo)
        {
            try
            {
                string strSql = @$"
                                select
                                    pk_Codigo Codigo, fk_Cliente Cliente, fk_Usuario Usuario, st_NomeArquivo NomeArquivo,
                                    nm_Registros Registros, dt_Envio DataEnvio, sn_Estorno Estorno, dt_Estorno DataEstorno
                                from 
                                    dbo.dm_ft_LogArquivoMateria
                                where
                                    pk_Codigo = @codigo
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    return conexaoBD.Query<Dto.LogArquivoMateria>(strSql, new { codigo = codigo }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Inserir(Dto.LogArquivoMateria logArquivo)
        {
            try
            {
                string strSql = @$"
                                    insert into	dbo.dm_ft_LogArquivoMateria	(fk_Cliente,fk_Usuario,st_NomeArquivo,nm_Registros,dt_Envio,sn_Estorno,dt_Estorno,fk_UsuarioEstorno)
                                    values (@Cliente,@Usuario,@NomeArquivo,@Registros,@DataEnvio,0,null,null)
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    conexaoBD.Execute(strSql, logArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Estornar(Dto.LogArquivoMateria logArquivo)
        {
            try
            {
                string strSql = @$"
                                    update 
                                        dbo.dm_ft_LogArquivoMateria 
                                    set
                                        sn_Estorno = 1,
                                        dt_Estorno = getdate(),
                                        fk_UsuarioEstorno = @UsuarioEstorno
                                    where
                                        pk_Codigo = @codigo
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    conexaoBD.Execute(strSql, logArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

