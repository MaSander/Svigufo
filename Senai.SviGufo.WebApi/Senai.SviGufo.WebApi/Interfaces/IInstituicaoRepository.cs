using Senai.SviGufo.WebApi.Domais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        void Cadastrar(InstituicaoDomain instituicao);

        void Deletar(int id);

        void Alterar(InstituicaoDomain instituicao);
    }
}
