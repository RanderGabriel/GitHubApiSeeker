using FluentNHibernate.Mapping;
using GithubDataCollector.Models;

namespace GithubDataCollector.Mapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.user_id);
            Map(x => x.login);
            Map(x => x.id);
            Map(x => x.node_id);
            Map(x => x.avatar_url);
            Map(x => x.gravatar_id);
            Map(x => x.url);
            Map(x => x.html_url);
            Map(x => x.followers_url);
            Map(x => x.following_url);
            Map(x => x.gists_url);
            Map(x => x.starred_url);
            Map(x => x.subscriptions_url);
            Map(x => x.organizations_url);
            Map(x => x.repos_url);
            Map(x => x.events_url);
            Map(x => x.received_events_url);
            Map(x => x.type);
            Map(x => x.site_admin);
            HasMany(x => x.repos)
                .KeyColumn("owner");
        }
    }
}
