using System;

namespace HaackHub
{
    /// <summary>
    /// Used to generate URLs for <see cref="Content" /> types.
    /// </summary>
    public class UrlHelper
    {
        public string GetUrl(Content content)
        {
            return content switch
            {
                Issue issue                         => $"/issue/{issue.Id}",
                Comment comment                     => $"/issue/{comment.Issue.Id}#comment_{comment.Id}",
                IssueAnnotation issueAnnotation     =>
                    $"{GetUrl(issueAnnotation.Issue)}#{GetRangeFragment(issueAnnotation)}",
                CommentAnnotation commentAnnotation =>
                    $"{GetUrl(commentAnnotation.Comment)}&{GetRangeFragment(commentAnnotation)}",
                _ => throw new ArgumentException("Don't know anything about that content.")
            };
        }

        string GetRangeFragment(Annotation annotation)
        {
            return annotation switch {
                var (start, end) when start == end => $"L{start}",
                var (start, end) when start < end => $"L{start}-L{end}",
                var (start, end) when start > end => $"L{end}-L{start}",
                _ => throw new InvalidOperationException("You are in an alternate universe where nothing is impossible.")
            };
        }
    }
}