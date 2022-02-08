using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Data.Interface
{
    public interface ILogArquivoMateriaData
    {
        List<Dto.LogArquivoMateria> Obter(string codCliente, DateTime dataEnvio);
        Dto.LogArquivoMateria Obter(int codigo);
        void Inserir(Dto.LogArquivoMateria logArquivo);
        void Estornar(Dto.LogArquivoMateria logArquivo);
    }
}
