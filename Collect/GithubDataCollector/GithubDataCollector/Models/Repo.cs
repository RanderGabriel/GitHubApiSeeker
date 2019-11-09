using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GithubDataCollector.Models
{
    class Repo
    {
        public virtual int repos_id { get; set; }
        public virtual int id { get; set; }
        public virtual string node_id { get; set; }
        public virtual string name { get; set; }
        public virtual string full_name { get; set; }
        [JsonIgnore]
        public virtual User owner { get; set; }
        [JsonProperty(PropertyName = "private")]
        public virtual bool is_private { get; set; }
        public virtual string html_url { get; set; }
        public virtual string description { get; set; }
        public virtual bool fork { get; set; }
        public virtual string url { get; set; }
        public virtual string archive_url { get; set; }
        public virtual string assignees_url { get; set; }
        public virtual string blobs_url { get; set; }
        public virtual string branches_url { get; set; }
        public virtual string collaborators_url { get; set; }
        public virtual string comments_url { get; set; }
        public virtual string commits_url { get; set; }
        public virtual string compare_url { get; set; }
        public virtual string contents_url { get; set; }
        public virtual string contributors_url { get; set; }
        public virtual string deployments_url { get; set; }
        public virtual string downloads_url { get; set; }
        public virtual string events_url { get; set; }
        public virtual string forks_url { get; set; }
        public virtual string git_commits_url { get; set; }
        public virtual string git_refs_url { get; set; }
        public virtual string git_tags_url { get; set; }
        public virtual string git_url { get; set; }
        public virtual string issue_comment_url { get; set; }
        public virtual string issue_events_url { get; set; }
        public virtual string issues_url { get; set; }
        public virtual string keys_url { get; set; }
        public virtual string labels_url { get; set; }
        public virtual string languages_url { get; set; }
        public virtual string merges_url { get; set; }
        public virtual string milestones_url { get; set; }
        public virtual string notifications_url { get; set; }
        public virtual string pulls_url { get; set; }
        public virtual string releases_url { get; set; }
        public virtual string ssh_url { get; set; }
        public virtual string stargazers_url { get; set; }
        public virtual string statuses_url { get; set; }
        public virtual string subscribers_url { get; set; }
        public virtual string subscription_url { get; set; }
        public virtual string tags_url { get; set; }
        public virtual string teams_url { get; set; }
        public virtual string trees_url { get; set; }
        public virtual string clone_url { get; set; }
        public virtual string mirror_url { get; set; }
        public virtual string hooks_url { get; set; }
        public virtual string svn_url { get; set; }
        public virtual string homepage { get; set; }
        public virtual string language { get; set; }
        public virtual int forks_count { get; set; }
        public virtual int stargazers_count { get; set; }
        public virtual int watchers_count { get; set; }
        public virtual int size { get; set; }
        public virtual string default_branch { get; set; }
        public virtual int open_issues_count { get; set; }
        public virtual bool is_template { get; set; }
        public virtual string[] topics { get; set; }
        public virtual List<Topics> repo_topics { get; set; }
        public virtual bool has_issues { get; set; }
        public virtual bool has_projects { get; set; }
        public virtual bool has_wiki { get; set; }
        public virtual bool has_pages { get; set; }
        public virtual bool has_downloads { get; set; }
        public virtual bool archived { get; set; }
        public virtual bool disabled { get; set; }
        public virtual DateTime? pushed_at { get; set; }
        public virtual DateTime? created_at { get; set; }
        public virtual DateTime? updated_at { get; set; }
        public virtual Dictionary<string, bool> permissions { get; set; }
        public virtual bool perm_can_push { get; set; }
        public virtual bool perm_is_admin { get; set; }
        public virtual bool perm_can_pull { get; set; }
        public virtual string template_repository { get; set; }
        public virtual int subscribers_count { get; set; }
        public virtual int network_count { get; set; }
    }
}
