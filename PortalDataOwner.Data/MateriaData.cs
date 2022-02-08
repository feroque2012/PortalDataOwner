using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PortalDataOwner.Data.Interface;

namespace PortalDataOwner.Data
{
    public class MateriaData : Base, IMateriaData
    {
        public MateriaData(IConfiguration configuration) : base (configuration)
        {
        }

        public List<Dto.Materia> Obter(string codCliente, DateTime dataAnuncio)
        {
            try
            {
                string strSql = @$"select 
                                    sk_Anuncio skAnuncio,pk_Cliente pkCliente,pk_Anuncio pkAnuncio,dt_Anuncio dtAnuncio,st_Veiculo stVeiculo,st_TipoVeiculo stTipoVeiculo
                                    ,st_TierVeiculo stTierVeiculo,st_Titulo stTitulo,st_Midia stMidia,st_TipoMidia stTipoMidia,st_Provacacao stProvacacao,st_Sentimento stSentimento
                                    ,nm_Audiencia nmAudiencia,st_Assunto stAssunto,st_SubAssunto stSubAssunto,st_Protagonismo stProtagonismo,st_Editora stEditora,st_Link stLink
                                    ,st_UF stUF,st_Cidade stCidade,nm_Interacoes nmInteracoes,nm_Views nmViews,nm_Resultado nmResultado,sn_Foto snFoto,sn_Videos snVideos,
                                    sn_Infografos snInfografos,sn_SubLink snSubLink,sn_Titulo snTitulo,sn_Destaque snDestaque,st_Clipadora stClipadora,Dt_Carga DtCarga
                                from 
                                    dbo.dm_ft_Materia_PR_DO 
                                where 
                                    month(dt_Anuncio) = {dataAnuncio.Month} and year(dt_Anuncio) = {dataAnuncio.Year} and pk_cliente='{codCliente}'
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    return conexaoBD.Query<Dto.Materia>(strSql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Dto.Materia Obter(string codAnuncio)
        {
            try
            {
                string strSql = @$"select 
                                    sk_Anuncio skAnuncio,pk_Cliente pkCliente,pk_Anuncio pkAnuncio,dt_Anuncio dtAnuncio,st_Veiculo stVeiculo,st_TipoVeiculo stTipoVeiculo
                                    ,st_TierVeiculo stTierVeiculo,st_Titulo stTitulo,st_Midia stMidia,st_TipoMidia stTipoMidia,st_Provacacao stProvacacao,st_Sentimento stSentimento
                                    ,nm_Audiencia nmAudiencia,st_Assunto stAssunto,st_SubAssunto stSubAssunto,st_Protagonismo stProtagonismo,st_Editora stEditora,st_Link stLink
                                    ,st_UF stUF,st_Cidade stCidade,nm_Interacoes nmInteracoes,nm_Views nmViews,nm_Resultado nmResultado,sn_Foto snFoto,sn_Videos snVideos,
                                    sn_Infografos snInfografos,sn_SubLink snSubLink,sn_Titulo snTitulo,sn_Destaque snDestaque,st_Clipadora stClipadora,Dt_Carga DtCarga
                                from 
                                    dbo.dm_ft_Materia_PR_DO 
                                where sk_Anuncio = '{codAnuncio}'
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    return conexaoBD.Query<Dto.Materia>(strSql).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Dto.Materia materia)
        {
            try
            {

                

                string strSql = @$"
                                Insert Into
                                dbo.dm_ft_Materia_PR_DO
                                    (
                                        dt_Carga,dt_Anuncio,pk_Cliente,pk_Anuncio,sk_Anuncio,st_Veiculo,st_TipoVeiculo,st_TierVeiculo,st_Titulo,st_Midia,st_TipoMidia,st_Provacacao,st_Sentimento,nm_Audiencia,st_Assunto,st_SubAssunto,st_Protagonismo,
                                        st_Editora,st_Link,st_UF,st_Cidade,nm_Interacoes,nm_Views,nm_Resultado,sn_Foto,sn_Videos,sn_Infografos,sn_SubLink,sn_Titulo,sn_Destaque,st_Clipadora,pk_ChaveImportacao
                                    )
                                values
                                    (
                                        @dtCarga,@dtAnuncio,@pkCliente,@pkAnuncio,@skAnuncio,@stVeiculo,@stTipoVeiculo,@stTierVeiculo,@stTitulo,@stMidia,@stTipoMidia,@stProvacacao,@stSentimento,@nmAudiencia,@stAssunto,@stSubAssunto,@stProtagonismo,
                                        @stEditora,@stLink,@stUF,@stCidade,@nmInteracoes,@nmViews,@nmResultado,@snFoto,@snVideos,@snInfografos,@snSubLink,@snTitulo,@snDestaque,@stClipadora,@pkChaveImportacao
                                    )
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    conexaoBD.Execute(strSql, materia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Dto.Materia materia)
        {
            try
            {
                string strSql = @$"
                                update
                                    dbo.dm_ft_Materia_PR_DO
                                set
                                    st_Veiculo = @stVeiculo, 
                                    st_TipoVeiculo = @stTipoVeiculo ,
                                    st_TierVeiculo = @stTierVeiculo ,
                                    st_Titulo = @stTitulo ,
                                    st_Midia = @stMidia ,
                                    st_TipoMidia = @stTipoMidia ,
                                    st_Provacacao = @stProvacacao ,
                                    st_Sentimento = @stSentimento ,
                                    nm_Audiencia = @nmAudiencia ,
                                    st_Assunto = @stAssunto ,
                                    st_SubAssunto = @stSubAssunto ,
                                    st_Protagonismo = @stProtagonismo ,
                                    st_Editora = @stEditora ,
                                    st_Link = @stLink ,
                                    st_UF = @stUF ,
                                    st_Cidade = @stCidade ,
                                    nm_Interacoes = @nmInteracoes ,
                                    nm_Views = @nmViews ,
                                    nm_Resultado = @nmResultado ,
                                    sn_Foto = @snFoto ,
                                    sn_Videos = @snVideos ,
                                    sn_Infografos = @snInfografos ,
                                    sn_SubLink = @snSubLink ,
                                    sn_Titulo = @snTitulo ,
                                    sn_Destaque = @snDestaque ,
                                    st_Clipadora = @stClipadora 
                                where 
                                    sk_Anuncio = @skAnuncio
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    conexaoBD.Execute(strSql, materia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Excluir(string codAnuncio)
        {
            try
            {
                string strSql = @$"
                                delete from
                                    dbo.dm_ft_Materia_PR_DO
                                where 
                                    sk_Anuncio = @codAnuncio
                                ";

                using (SqlConnection conexaoBD = new SqlConnection(Conexao))
                {
                    conexaoBD.Execute(strSql, new { codAnuncio = codAnuncio });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
