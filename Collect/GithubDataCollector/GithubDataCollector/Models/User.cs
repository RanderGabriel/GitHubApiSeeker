using System.Collections.Generic;

namespace GithubDataCollector.Models
{
    class User
    {
        public virtual IList<Repo> repos { get; set; }
        public virtual string login { get; set; }
        public virtual int id { get; set; }
        public virtual int user_id { get; set; }
        public virtual string node_id { get; set; }
        public virtual string avatar_url { get; set; }
        public virtual string gravatar_id { get; set; }
        public virtual string url { get; set; }
        public virtual string html_url { get; set; }
        public virtual string followers_url { get; set; }
        public virtual string following_url { get; set; }
        public virtual string gists_url { get; set; }
        public virtual string starred_url { get; set; }
        public virtual string subscriptions_url { get; set; }
        public virtual string organizations_url { get; set; }
        public virtual string repos_url { get; set; }
        public virtual string events_url { get; set; }
        public virtual string received_events_url { get; set; }
        public virtual string type { get; set; }
        public virtual bool site_admin { get; set; }
    }
}
