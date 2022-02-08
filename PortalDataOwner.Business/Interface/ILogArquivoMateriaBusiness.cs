using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Business.Interface
{
    public interface ILogArquivoMateriaBusiness
    {
        List<Dto.LogArquivoMateria> Obter(string codCliente, DateTime dataEnvio);
        Dto.LogArquivoMateria Obter(int codigo);
        void Inserir(Dto.LogArquivoMateria logArquivo);
        void Estornar(Dto.LogArquivoMateria logArquivo);
    }
}
