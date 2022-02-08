using PortalDataOwner.Business.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace PortalDataOwner.Business
{
    public class MateriaBusiness: IMateriaBusiness
    {
        private readonly Data.Interface.IMateriaData _materiaData;

        public MateriaBusiness(Data.Interface.IMateriaData materiaData)
        {
            _materiaData = materiaData;
        }

        public List<Dto.Materia> Obter(string codCliente, DateTime dataAnuncio)
        {
            return _materiaData.Obter(codCliente, dataAnuncio);
        }

        public Dto.Materia Obter(string codAnuncio)
        {
            return _materiaData.Obter(codAnuncio);
        }

        public void Inserir(Dto.Materia materia)
        {
            _materiaData.Inserir(materia);
        }

        public void Atualizar(Dto.Materia materia)
        {
            _materiaData.Atualizar(materia);
        }

        public void Excluir(string codAnuncio)
        {
            _materiaData.Excluir(codAnuncio);
        }
    }
}
