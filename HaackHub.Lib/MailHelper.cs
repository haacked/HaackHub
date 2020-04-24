using System;

namespace HaackHub
{
    public class MailHelper
    {
        public string GetDescription(object o)
        {
            return o switch
            {
                User { Name : var name} => $"The user named {name}",
                Issue { Title : var title } => $"The issue entitled {title}",
                Comment { Issue: { Title: var title }} => $"The comment on issue entitled {title}",
                IssueAnnotation { Issue: { Title: var title }} => $"The annotation on issue entitled {title}",
                CommentAnnotation { Comment: { Issue: { Title: var title }}} => $"The annotation on the comment on issue entitled {title}",
                _ => throw new InvalidOperationException("Don't know about that.")
            };
        }
    }
}