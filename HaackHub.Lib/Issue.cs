namespace HaackHub
{
    /// <summary>
    /// A bug or feature request made by a user.
    /// </summary>
    public class Issue : Content
    {
        public string Title { get; set; } = null!; // We expect EF Core to set this for us.

        public User Creator { get; set; } = null!;
        
        public User? Assigned { get; set; }
        
        public override string GetLogDescription()
        {
            return $"Issue {Id} created by {Creator.Name}";
        }
    }
}