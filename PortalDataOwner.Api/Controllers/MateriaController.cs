using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace PortalDataOwner.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]

    public class MateriaController : ControllerBase
    {
        private readonly Business.Interface.IMateriaBusiness _materia;

        public MateriaController(Business.Interface.IMateriaBusiness materia)
        {
            _materia = materia;
        }

        [HttpGet("{codCliente}/{dataAnuncio}")]
        public IActionResult Obter(string codCliente, DateTime dataAnuncio)
        {
            var ret = _materia.Obter(codCliente, Convert.ToDateTime(dataAnuncio));

            return Ok(ret);
        }

        [HttpGet("{codAnuncio}")]
        public IActionResult Obter(string codAnuncio)
        {
            var ret = _materia.Obter(codAnuncio);
            return Ok(ret);
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] List<Dto.Materia> materias)
        {
            try
            {
                foreach (var materia in materias)
                {
                    _materia.Inserir(materia);
                }

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
        public IActionResult Salvar([FromBody] Dto.Materia materia)
        {
            try
            {
                _materia.Atualizar(materia);

                return Ok(new Dto.Result()
                {
                    Mensagem = "Atualização realizada com sucesso"
                });
            }
            catch (Exception ex)
            {
                return Ok(new Dto.Result()
                {
                    Erro=1,
                    Mensagem = string.Format("Erro: {0}", ex.Message)
                }); ;
            }
        }

        [HttpDelete("{codAnuncio}")]
        public IActionResult Excluir(string codAnuncio)
        {
            try
            {
                _materia.Excluir(codAnuncio);
                return Ok(new Dto.Result()
                {
                    Mensagem = "Exclusão realizada com sucesso"
                });
            }
            catch(Exception ex)
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
