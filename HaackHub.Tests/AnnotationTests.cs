using System;
using HaackHub;
using Xunit;
using Xunit.Abstractions;

public class AnnotationTests
{
    public class TheDeconstructMethod
    {
        [Fact]
        public void ReturnsAnnotationRange()
        {
            var issueAnnotation = new IssueAnnotation
            {
                LineNumberRange = 0..3
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
                LineNumberRange = 1..4,
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

        [Fact]
        public void OtherCoolRangeStuff()
        {
            var words = new[]
            {
                "zero", "one", "two", "three", "four"
            };

            foreach (var word in words[1..3])
            {
                Console.WriteLine(word);
            }
            Console.Write("---------");
            
            foreach (var word in words[^3..^0])
            {
                Console.WriteLine(word);
            }
            Console.Write("---------");
            foreach (var word in words[2..])
            {
                Console.WriteLine(word);
            }
            Console.Write("---------");

            
            Console.WriteLine(words[^1]); // Write the last word
            Console.Write("---------");

        }
    }
}
