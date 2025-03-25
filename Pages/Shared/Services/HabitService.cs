using HabitTracker.Models;

namespace HabitTracker.Services
{
    public class HabitService
    {
        private List<Habit> _habits = new();
        private int _nextId = 1;

        public void AddHabit(Habit habit)
        {
            habit.Id = _nextId++;
            _habits.Add(habit);
        }

        public List<Habit> GetHabitsByDate(DateTime date)
        {
            return _habits.Where(h => h.Date.Date == date.Date).ToList();
        }

        public void ToggleHabitStatus(int id)
        {
            var habit = _habits.FirstOrDefault(h => h.Id == id);
            if (habit != null)
                habit.IsCompleted = !habit.IsCompleted;
        }
    }
}
