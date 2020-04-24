using System;
using HaackHub;
using Xunit;

public class AnnotationTests
{
    public class TheDeconstructMethod
    {
        [Fact]
        public void ReturnsAnnotationRange()
        {
            var issueAnnotation = new IssueAnnotation
            {
                LineNumberRange = new Range(0, 3)
            };

            var (start, end) = issueAnnotation;
            
            Assert.Equal(0, start);
            Assert.Equal(3, end);
        }
    }

    public class TheExcerptProperty
    {
        [Fact]
        public void ReturnsRangeOfContent()
        {
            var issueAnnotation = new IssueAnnotation
            {
                LineNumberRange = new Range(1, 4),
                Issue = new Issue
                {
                    Text = "This is the first line\n"
                           + "And this is the second line\n"
                           + "And this is getting boring\n"
                           + "I should be more creative\n"
                           + "But this is what I got."
                }
            };

            var excerpt = issueAnnotation.Excerpt;

            Assert.Equal("And this is the second line\n"
                         + "And this is getting boring\n"
                         + "I should be more creative", excerpt);
        }
    }
}
