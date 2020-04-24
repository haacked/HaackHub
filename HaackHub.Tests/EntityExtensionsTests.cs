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
                Creator = new User()
            };

            var description = issue.GetLogDescription();
            
            Assert.Equal("Issue with ID: 42", description);
        }
    }
}
