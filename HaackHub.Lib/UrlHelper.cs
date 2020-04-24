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
                IssueAnnotation issueAnnotation     => GetUrl(issueAnnotation.Issue) + "#L" +
                                                       issueAnnotation.LineNumberRange.Start.Value + "-L" +
                                                       issueAnnotation.LineNumberRange.End.Value,
                CommentAnnotation commentAnnotation => GetUrl(commentAnnotation.Comment) + "&L" +
                                                       commentAnnotation.LineNumberRange.Start.Value + "-L" +
                                                       commentAnnotation.LineNumberRange.End.Value,
                _ => throw new ArgumentException("Don't know anything about that content.")
            };
        }
    }
}