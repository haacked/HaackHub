using System.Collections.Generic;

namespace HaackHub
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
        public List<Comment> Comments { get; set; } = null!;
    }
}