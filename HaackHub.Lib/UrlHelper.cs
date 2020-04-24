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
                    $"{GetUrl(issueAnnotation.Issue)}#{GetRangeFragment(issueAnnotation.LineNumberRange)}",
                CommentAnnotation commentAnnotation =>
                    $"{GetUrl(commentAnnotation.Comment)}&{GetRangeFragment(commentAnnotation.LineNumberRange)}",
                _ => throw new ArgumentException("Don't know anything about that content.")
            };
        }

        string GetRangeFragment(Range range)
        {
            return range switch {
                _ when range.Start.Value == range.End.Value => $"L{range.Start.Value}",
                _ when range.Start.Value < range.End.Value => $"L{range.Start.Value}-L{range.End.Value}",
                _ when range.Start.Value > range.End.Value => $"L{range.End.Value}-L{range.Start.Value}",
                _ => throw new InvalidOperationException("You are in an alternate universe where nothing is impossible.")
            };
        }
    }
}