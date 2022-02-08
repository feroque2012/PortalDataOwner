using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Business.Interface
{
    public interface IMateriaBusiness
    {
        List<Dto.Materia> Obter(string codCliente, DateTime dataAnuncio);
        Dto.Materia Obter(string codAnuncio);
        void Inserir(Dto.Materia materia);
        void Atualizar(Dto.Materia materia);
        void Excluir(string codAnuncio);
    }
}
