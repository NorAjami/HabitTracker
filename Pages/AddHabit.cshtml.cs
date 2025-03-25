using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;
using HabitTracker.Services;

namespace HabitTracker.Pages
{
    public class AddHabitModel : PageModel
    {
        private readonly MongoHabitService _habitService;

        public AddHabitModel(MongoHabitService habitService)
        {
            _habitService = habitService;
        }

        [BindProperty]
        public Habit NewHabit { get; set; } = new Habit();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _habitService.AddHabitAsync(NewHabit);
            return RedirectToPage("/Today");
        }
    }
}
