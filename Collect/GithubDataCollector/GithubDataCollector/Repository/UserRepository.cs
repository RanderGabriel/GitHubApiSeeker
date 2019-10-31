using System.Collections;
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

        public IEnumerable RecuperarTodos()
        {
            string sql = "SELECT * FROM User";
            var query = _session.CreateSQLQuery(sql);
            var result = query.List();
            return result;
        }

        public void Salvar(User user)
        {
            using(ITransaction tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(user);
                tran.Commit();
            }
        }
    }
}
