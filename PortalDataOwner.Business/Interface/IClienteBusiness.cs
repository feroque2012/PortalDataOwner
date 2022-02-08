using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Business.Interface
{
    public interface IClienteBusiness
    {
        List<Dto.Cliente> Obter();
    }
}
