namespace HaackHub
{
    /// <summary>
    /// Base type for all user generated content.
    /// </summary>
    public abstract class Content
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}