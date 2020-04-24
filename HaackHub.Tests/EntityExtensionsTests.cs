using HaackHub;
using Xunit;

public class EntityExtensionsTests
{
    public class TheGetLogDescriptionMethod
    {
        [Fact]
        public void ReturnsTheCorrectDescriptionForIssue()
        {
            var issue = new Issue
            {
                Id = 42,
                Creator = new User { Name = "haacked" }
            };

            var description = issue.GetLogDescription();
            
            Assert.Equal("Issue 42 created by haacked", description);

            IEntity entity = issue;
            Assert.Equal("Issue 42 created by haacked", entity.GetLogDescription());
        }
        
        [Fact]
        public void ReturnsDefaultDescriptionForComment()
        {
            var comment = new Comment
            {
                Id = 1,
                Issue = new Issue
                {
                    Id = 42,
                    Creator = new User { Name = "haacked" }
                }
            };

            var description = comment.GetLogDescription();
            
            Assert.Equal("Comment with ID: 1", description);
        }
    }
}
