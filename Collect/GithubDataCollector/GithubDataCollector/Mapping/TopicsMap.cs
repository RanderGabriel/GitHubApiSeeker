using FluentNHibernate.Mapping;
using GithubDataCollector.Models;

namespace GithubDataCollector.Mapping
{
    class TopicsMap : ClassMap<Topics>
    {
        public TopicsMap()
        {
            Id(x => x.topics_id);
        }
    }
}
