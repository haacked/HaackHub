namespace HaackHub
{
    public interface IEntity
    {
        int Id { get; set; }

        public string GetLogDescription()
        {
            return $"{GetType().Name} with ID: {Id}";
        }
    }
}