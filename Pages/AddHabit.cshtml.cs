using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HabitTracker.Models;

namespace HabitTracker.Pages
{
    public class AddHabitModel : PageModel
    {
        // This will hold the data sent from the form
        [BindProperty]
        public Habit NewHabit { get; set; }

        public void OnGet()
        {
            // This method is called when the page loads (GET request)
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the form is invalid, reload the page
                return Page();
            }

            // Just printing to console for now (replace later with DB/in-memory)
            Console.WriteLine($"New habit added: {NewHabit.Name}");

            // Redirect back to homepage for now
            return RedirectToPage("/Index");
        }
    }
}
