namespace HabitTracker.Models
{
    // Represents a habit that the user wants to track
    public class Habit
    {
        public int Id { get; set; }              // Unique identifier
        public string? Name { get; set; }         // Name of the habit (e.g. "Drink water")
        public DateTime Date { get; set; }       // The date this habit is tracked for
        public bool IsCompleted { get; set; }    // Whether the habit was completed on that day
    }
}
