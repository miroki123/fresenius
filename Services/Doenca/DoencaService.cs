using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Services.Doenca
{
    public class DoencaService : IDoencaService
    {
        private readonly CIDRepository _repository;

        public DoencaService(CIDRepository repository)
        {
            _repository = repository;
        }

        public void Alterar(string codigo, string novoNome)
        {
            var doenca = _repository.First(r => r.Codigo.Equals(codigo));
            if (doenca != null)
            {
                doenca.Nome = novoNome;
                _repository.Update(doenca);
            }
        }

        public void Inserir(DoencaDTO doenca)
        {
            _repository.Insert(new Tb_CID
            {
                Codigo = doenca.Codigo,
                Nome = doenca.Nome,
            });
        }

        public List<DoencaDTO> ObterDoencas()
        {
            var query = _repository.Get();
            var result = new List<DoencaDTO>();
            query.ForEach(q => {
                result.Add(new DoencaDTO { Codigo = q.Codigo, Nome = q.Nome });
            });
            return result;
        }

        public void Remover(DoencaDTO doenca)
        {
            var d = _repository.First(r => r.Codigo.Equals(doenca.Codigo));
            if (d != null)
            {
                _repository.Delete(d);
            }
        }
    }
}
