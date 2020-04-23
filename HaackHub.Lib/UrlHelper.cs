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
                return "/issue/" + issue.Id;
            }

            var comment = content as Comment;
            if (comment != null)
            {
                return "/issue/" + comment.Issue.Id + "#comment_" + comment.Id;
            }

            throw new ArgumentException("Don't know anything about content.");
        }
    }
}