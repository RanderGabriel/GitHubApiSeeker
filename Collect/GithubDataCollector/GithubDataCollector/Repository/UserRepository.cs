using System.Collections;
using System.Collections.Generic;
using GithubDataCollector.Models;
using NHibernate;

namespace GithubDataCollector.Repository
{
    class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }
        public void Excluir(User user)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                _session.Delete(user);
                tran.Commit();
            }
        }

        public int GetLastSaved()
        {
            string sql = "SELECT id FROM Users ORDER BY id DESC LIMIT 1";
            var query = _session.CreateSQLQuery(sql);
            int result = (int) (query.UniqueResult() != null ? query.UniqueResult() : 0);
            return result;
        }

        public IEnumerable RecuperarTodos()
        {
            string sql = "SELECT * FROM Users";
            var query = _session.CreateSQLQuery(sql);
            var result = query.List();
            return result;
        }

        public void Salvar(User user)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(user);
                tran.Commit();
            }
        }

        public void SalvarLista(IEnumerable<User> users)
        {
            using (ITransaction tran = _session.BeginTransaction())
            {
                foreach(var user in users) {
                    _session.SaveOrUpdate(user);
                }
                tran.Commit();
            }
        }

    }
}
