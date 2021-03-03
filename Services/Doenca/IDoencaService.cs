using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Doenca
{
    public interface IDoencaService
    {
        void Inserir(DoencaDTO doenca);
        void Alterar(string codigo, string novoNome);
        void Remover(DoencaDTO doenca);
        List<DoencaDTO> ObterDoencas();
    }
}
