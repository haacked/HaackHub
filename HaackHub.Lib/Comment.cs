namespace HaackHub
{
    /// <summary>
    /// A comment on an <see cref="Issue" /> made by a User.
    /// </summary>
    public class Comment : Content
    {
        public Issue Issue { get; set; } = null!; // Because we expect our ORM to set this.
    }
}