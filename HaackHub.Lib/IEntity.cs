namespace HaackHub
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public static class EntityExtensions
    {
        public static string GetLogDescription(this IEntity entity)
        {
            return $"{entity.GetType().Name} with ID: {entity.Id}";
        }
    }
}