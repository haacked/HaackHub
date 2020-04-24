using System;
using HaackHub;
using Xunit;


public class UrlHelperTests
{
    public class TheGetUrlMethod
    {
        [Fact]
        public void ReturnsCorrectUrlForIssue()
        {
            var issue = new Issue { Id = 42 };
            var urlHelper = new UrlHelper();

            var url = urlHelper.GetUrl(issue);

            Assert.Equal("/issue/42", url);
        }
        
        [Fact]
        public void ReturnsCorrectUrlForComment()
        {
            var comment = new Comment
            {
                Id = 75,
                Issue = new Issue { Id = 42 }
            };
            var urlHelper = new UrlHelper();

            var url = urlHelper.GetUrl(comment);

            Assert.Equal("/issue/42#comment_75", url);
        }

        [Fact]
        public void ThrowsArgumentExceptionForUnknownContent()
        {
            var unknownContent = new UnknownContent();
            var urlHelper = new UrlHelper();

            var ex = Assert.Throws<ArgumentException>(() => urlHelper.GetUrl(unknownContent));

            Assert.Equal("Don't know anything about that content.", ex.Message);
        }

        class UnknownContent : Content
        {
        }
        
        [Fact]
        public void ReturnsCorrectUrlForIssueAnnotation()
        {
            var issueAnnotation = new IssueAnnotation
            {
                Issue = new Issue {Id = 42},
                LineNumberRange = 3..10
            };
            var urlHelper = new UrlHelper();

            var url = urlHelper.GetUrl(issueAnnotation);

            Assert.Equal("/issue/42#L3-L10", url);
        }
        
        [Fact]
        public void ReturnsCorrectUrlForCommentAnnotation()
        {
            var commentAnnotation = new CommentAnnotation
            {
                Comment = new Comment
                {
                    Id = 75,
                    Issue = new Issue { Id = 42 }
                },
                LineNumberRange = 5..6
            };
            
            var urlHelper = new UrlHelper();

            var url = urlHelper.GetUrl(commentAnnotation);

            Assert.Equal("/issue/42#comment_75&L5-L6", url);
        }
    }
}
