using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;
using HabitTracker.Services;

namespace HabitTracker.Pages
{
    public class TodayModel : PageModel
    {
        private readonly MongoHabitService _habitService;

        public TodayModel(MongoHabitService habitService)
        {
            _habitService = habitService;
        }

        // 🧠 Här lagras alla vanor för idag som visas på sidan
        public List<Habit> HabitsToday { get; set; } = new();

        // 🔁 När sidan laddas via GET (visas i webbläsaren)
        public async Task OnGetAsync()
        {
            HabitsToday = await _habitService.GetHabitsByDateAsync(DateTime.Today);
        }

        // ✅ När användaren klickar på "Mark as done"-knappen
        public async Task<IActionResult> OnPostToggleAsync(string id)
        {
            await _habitService.ToggleHabitStatusAsync(id);
            return RedirectToPage();
        }
    }
}
