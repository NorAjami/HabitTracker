using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HabitTracker.Models
{
    public class Habit
    {
        // MongoDB will automatically generate this as a unique identifier
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}