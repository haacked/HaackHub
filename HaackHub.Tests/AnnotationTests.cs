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
}
