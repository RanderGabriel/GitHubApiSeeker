using GithubDataCollector.Models;
using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GithubDataCollector.Repository
{
    class RepoRepository : IRepoRepository
    {
        private readonly ISession _session;

        public RepoRepository(ISession session)
        {
            _session = session;
        }
        public void Excluir(Repo repo)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                _session.Delete(repo);
                tran.Commit();
            }
        }

        public IEnumerable RecuperarTodos()
        {
            string sql = "SELECT * FROM Repos";
            var query = _session.CreateSQLQuery(sql);
            var result = query.List();
            return result;
        }

        public void Salvar(Repo repo)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(repo);
                tran.Commit();
            }
        }

        public void SalvarLista(IEnumerable<Repo> repos)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                foreach (var repo in repos)
                {
                    _session.SaveOrUpdate(repo);
                }
                tran.Commit();
            }
        }
    }
}
