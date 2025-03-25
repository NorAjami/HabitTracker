using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;
using HabitTracker.Services;

namespace HabitTracker.Pages
{
    public class TodayModel : PageModel
    {
        private readonly HabitService _habitService;

        public TodayModel(HabitService habitService)
        {
            _habitService = habitService;
        }

        public List<Habit> HabitsToday { get; set; } = new();

        public void OnGet()
        {
            HabitsToday = _habitService.GetHabitsByDate(DateTime.Today);
        }

        public IActionResult OnPostToggle(int id)
        {
            _habitService.ToggleHabitStatus(id);
            return RedirectToPage();
        }
    }
}
