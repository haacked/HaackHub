#nullable enable

namespace HaackHub
{
    /// <summary>
    /// A bug or feature request made by a user.
    /// </summary>
    public class Issue : Content
    {
        public string Title { get; set; } = null!; // We expect EF Core to set this for us.
    }
}