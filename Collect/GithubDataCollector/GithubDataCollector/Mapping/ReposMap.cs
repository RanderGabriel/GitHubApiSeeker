using FluentNHibernate.Mapping;
using GithubDataCollector.Models;

namespace GithubDataCollector.Mapping
{
    class ReposMap : ClassMap<Repo>
    {
        public ReposMap()
        {
            Table("Repos");
            Id(x => x.repos_id);
            Map(x => x.id);
            Map(x => x.node_id);
            Map(x => x.name);
            Map(x => x.full_name);
            Map(x => x.is_private);
            Map(x => x.html_url);
            Map(x => x.description);
            Map(x => x.fork);
            Map(x => x.url);
            Map(x => x.archive_url);
            Map(x => x.assignees_url);
            Map(x => x.blobs_url);
            Map(x => x.branches_url);
            Map(x => x.collaborators_url);
            Map(x => x.comments_url);
            Map(x => x.commits_url);
            Map(x => x.compare_url);
            Map(x => x.contents_url);
            Map(x => x.contributors_url);
            Map(x => x.deployments_url);
            Map(x => x.downloads_url);
            Map(x => x.events_url);
            Map(x => x.forks_url);
            Map(x => x.git_commits_url);
            Map(x => x.git_refs_url);
            Map(x => x.git_tags_url);
            Map(x => x.git_url);
            Map(x => x.issue_comment_url);
            Map(x => x.issue_events_url);
            Map(x => x.issues_url);
            Map(x => x.keys_url);
            Map(x => x.labels_url);
            Map(x => x.languages_url);
            Map(x => x.merges_url);
            Map(x => x.milestones_url);
            Map(x => x.notifications_url);
            Map(x => x.pulls_url);
            Map(x => x.releases_url);
            Map(x => x.ssh_url);
            Map(x => x.stargazers_url);
            Map(x => x.statuses_url);
            Map(x => x.subscribers_url);
            Map(x => x.subscription_url);
            Map(x => x.tags_url);
            Map(x => x.teams_url);
            Map(x => x.trees_url);
            Map(x => x.clone_url);
            Map(x => x.mirror_url);
            Map(x => x.hooks_url);
            Map(x => x.svn_url);
            Map(x => x.homepage);
            Map(x => x.language);
            Map(x => x.forks_count);
            Map(x => x.stargazers_count);
            Map(x => x.watchers_count);
            Map(x => x.size);
            Map(x => x.default_branch);
            Map(x => x.open_issues_count);
            Map(x => x.is_template);
            Map(x => x.has_issues);
            Map(x => x.has_projects);
            Map(x => x.has_wiki);
            Map(x => x.has_pages);
            Map(x => x.has_downloads);
            Map(x => x.archived);
            Map(x => x.disabled);
            Map(x => x.pushed_at);
            Map(x => x.created_at);
            Map(x => x.updated_at);
            Map(x => x.perm_can_push);
            Map(x => x.perm_is_admin);
            Map(x => x.perm_can_pull);
            Map(x => x.template_repository);
            Map(x => x.subscribers_count);
            Map(x => x.network_count);
            References(x => x.owner)
                .Column("owner");
            HasManyToMany(x => x.repo_topics)
                .Table("ReposTopics");
        }

    }
}
