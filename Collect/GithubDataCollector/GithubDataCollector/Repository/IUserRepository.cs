using GithubDataCollector.Models;
using System;
using System.Collections;

namespace GithubDataCollector.Repository
{
    interface IUserRepository
    {
        void Salvar(User user);
        void Excluir(User user);
        IEnumerable RecuperarTodos();
    }
}
