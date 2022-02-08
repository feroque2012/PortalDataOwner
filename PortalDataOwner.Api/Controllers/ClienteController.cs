using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace PortalDataOwner.Api.Controllers
{

    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Business.Interface.IClienteBusiness _clienteBusiness;

        public ClienteController(Business.Interface.IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        public IActionResult Obter()
        {
            var ret = _clienteBusiness.Obter();

            return Ok(ret);
        }
    }
}
