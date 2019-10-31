using FluentNHibernate.Mapping;
using GithubDataCollector.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GithubDataCollector.Mapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Usuario");
            Id(x => x.user_id, "id");
            Map(x => x.login);
        }
    }
}
