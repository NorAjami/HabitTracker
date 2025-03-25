using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;

namespace HabitTracker.Pages
{
    public class TodayModel : PageModel
    {
        // Temporary in-memory list of habits
        public List<Habit>? HabitsToday { get; set; }

        public void OnGet()
        {
            // Normally, we'd get this from a database or service
            HabitsToday = new List<Habit>
            {
                new Habit { Id = 1, Name = "Meditate", Date = DateTime.Today, IsCompleted = false },
                new Habit { Id = 2, Name = "Drink Water", Date = DateTime.Today, IsCompleted = true },
                new Habit { Id = 3, Name = "Exercise", Date = DateTime.Today, IsCompleted = false }
            };
        }
    }
}
