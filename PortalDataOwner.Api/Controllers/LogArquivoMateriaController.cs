using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDataOwner.Api.Controllers
{
    public class LogArquivoMateriaController : Controller
    {
        private readonly Business.Interface.ILogArquivoMateriaBusiness _logArquivoMateria;

        public LogArquivoMateriaController(Business.Interface.ILogArquivoMateriaBusiness logArquivoMateria)
        {
            _logArquivoMateria = logArquivoMateria;
        }

        [HttpGet("{usuario}/{dataEnvio}")]
        public IActionResult Obter(string codCliente, DateTime dataEnvio)
        {
            var ret = _logArquivoMateria.Obter(codCliente, Convert.ToDateTime(dataEnvio));

            return Ok(ret);
        }

        [HttpGet("{codigo}")]
        public IActionResult Obter(int codigo)
        {
            var ret = _logArquivoMateria.Obter(codigo);
            return Ok(ret);
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Dto.LogArquivoMateria logArquivo)
        {
            try
            {
                _logArquivoMateria.Inserir(logArquivo);

                return Ok(new Dto.Result()
                {
                    Mensagem = "Atualização realizada com sucesso"
                });
            }
            catch (Exception ex)
            {
                return Ok(new Dto.Result()
                {
                    Erro = 1,
                    Mensagem = string.Format("Erro: {0}", ex.Message)
                }); ;
            }
        }

        [HttpPut]
        public IActionResult Estorno([FromBody] Dto.LogArquivoMateria logArquivo)
        {
            try
            {
                _logArquivoMateria.Estornar(logArquivo);

                return Ok(new Dto.Result()
                {
                    Mensagem = "Estorno realizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return Ok(new Dto.Result()
                {
                    Erro = 1,
                    Mensagem = string.Format("Erro: {0}", ex.Message)
                }); ;
            }
        }
    }
}
