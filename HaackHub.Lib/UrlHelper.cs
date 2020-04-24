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
            var issue = content as Issue;
            if (issue != null)
            {
                return $"/issue/{issue.Id}";
            }

            var comment = content as Comment;
            if (comment != null)
            {
                return $"/issue/{comment.Issue.Id}#comment_{comment.Id}";
            }

            var issueAnnotation = content as IssueAnnotation;
            if (issueAnnotation != null)
            {
                return GetUrl(issueAnnotation.Issue)
                       + "#L" + issueAnnotation.LineNumberRange.Start.Value
                       + "-L" + issueAnnotation.LineNumberRange.End.Value;
            }
            
            var commentAnnotation = content as CommentAnnotation;
            if (commentAnnotation != null)
            {
                return GetUrl(commentAnnotation.Comment)
                       + "&L" + commentAnnotation.LineNumberRange.Start.Value
                       + "-L" + commentAnnotation.LineNumberRange.End.Value;
            }

            throw new ArgumentException("Don't know anything about that content.");
        }
    }
}