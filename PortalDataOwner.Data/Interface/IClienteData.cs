using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Data.Interface
{
    public interface IClienteData
    {
        List<Dto.Cliente> Obter();
    }
}
