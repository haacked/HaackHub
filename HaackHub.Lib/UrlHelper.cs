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
            switch (content)
            {
                case Issue issue:
                    return $"/issue/{issue.Id}";
                case Comment comment:
                    return $"/issue/{comment.Issue.Id}#comment_{comment.Id}";
                case IssueAnnotation issueAnnotation:
                    return GetUrl(issueAnnotation.Issue)
                           + "#L" + issueAnnotation.LineNumberRange.Start.Value
                           + "-L" + issueAnnotation.LineNumberRange.End.Value;
                case CommentAnnotation commentAnnotation:
                    return GetUrl(commentAnnotation.Comment)
                           + "&L" + commentAnnotation.LineNumberRange.Start.Value
                           + "-L" + commentAnnotation.LineNumberRange.End.Value;
                default:
                    throw new ArgumentException("Don't know anything about that content.");
            }
        }
    }
}