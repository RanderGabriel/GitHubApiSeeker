using GithubDataCollector.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GithubDataCollector.Repository
{
    interface IRepoRepository
    {

        void Salvar(Repo repo);
        void Excluir(Repo repo);
        void SalvarLista(IEnumerable<Repo> repos);
        IEnumerable RecuperarTodos();
    }
}
