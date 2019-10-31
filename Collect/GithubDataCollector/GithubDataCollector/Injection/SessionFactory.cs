using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GithubDataCollector.Mapping;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GithubDataCollector.Injection
{
    class SessionFactory
    {
        private static readonly string _connection_string = "Server=localhost;Port=5432;Database=ibd_tp_2;User Id=postgres;Password=teste;";
        private static ISessionFactory _session;

        public static ISessionFactory criarSession()
        {
            if (_session != null)
                return _session;
            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(_connection_string);
            var configMap = Fluently.Configure()
                .Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<UserMap>());
            _session = configMap.BuildSessionFactory();
            return _session;
        }

        public static ISession AbrirSession()
        {
            return criarSession().OpenSession();
        }
    }
}
