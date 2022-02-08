using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Data
{
    public class Base
    {
        protected readonly IConfiguration _configuration;
        public Base(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Conexao
        {
            get
            {
                return _configuration.GetConnectionString("PortalDO");
            }
        }
    }
}
