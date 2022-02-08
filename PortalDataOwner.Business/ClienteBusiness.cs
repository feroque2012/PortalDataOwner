using PortalDataOwner.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Business
{
    public class ClienteBusiness: IClienteBusiness
    {
        private readonly Data.Interface.IClienteData _clienteData;

        public ClienteBusiness(Data.Interface.IClienteData clienteData)
        {
            _clienteData = clienteData;
        }
        public List<Dto.Cliente> Obter()
        {
            return _clienteData.Obter();
        }
    }
}
