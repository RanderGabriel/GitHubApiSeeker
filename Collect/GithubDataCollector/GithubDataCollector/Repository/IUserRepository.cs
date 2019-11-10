using GithubDataCollector.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GithubDataCollector.Repository
{
    interface IUserRepository
    {
        void Salvar(User user);
        void SalvarLista(IEnumerable<User> users);
        void Excluir(User user);
        IEnumerable RecuperarTodos();
        int GetLastSaved();
    }
}
