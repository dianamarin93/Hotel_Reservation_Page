using Hotel_Reservation_Project.Data;
using Hotel_Reservation_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Reservation_Project.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
    
        public Informations Info { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Informations.AddAsync(Info);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reservation created successfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
