using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;
using HabitTracker.Services;

namespace HabitTracker.Pages
{
    public class AddHabitModel : PageModel
    {
        private readonly HabitService _habitService;

        public AddHabitModel(HabitService habitService)
        {
            _habitService = habitService;
        }

        [BindProperty]
        public Habit NewHabit { get; set; } = new Habit();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _habitService.AddHabit(NewHabit);
            return RedirectToPage("/Today");
        }
    }
}
