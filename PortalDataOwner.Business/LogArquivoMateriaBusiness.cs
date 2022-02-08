using PortalDataOwner.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalDataOwner.Dto;

namespace PortalDataOwner.Business
{
    public class LogArquivoMateriaBusiness : ILogArquivoMateriaBusiness
    {
        private readonly Data.Interface.ILogArquivoMateriaData _logArquivoMateriaData;

        public LogArquivoMateriaBusiness(Data.Interface.ILogArquivoMateriaData  logArquivoMateriaData)
        {
            _logArquivoMateriaData = logArquivoMateriaData;
        }

        public List<LogArquivoMateria> Obter(string codCliente, DateTime dataEnvio)
        {
            return _logArquivoMateriaData.Obter(codCliente, dataEnvio);
        }

        public LogArquivoMateria Obter(int codigo)
        {
            return _logArquivoMateriaData.Obter(codigo);
        }

        public void Estornar(LogArquivoMateria logArquivo)
        {
            _logArquivoMateriaData.Estornar(logArquivo);
        }

        public void Inserir(LogArquivoMateria logArquivo)
        {
            _logArquivoMateriaData.Inserir(logArquivo);
        }
    }
}
