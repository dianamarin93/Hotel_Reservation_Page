using Hotel_Reservation_Project.Data;
using Hotel_Reservation_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Reservation_Project.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
    
        public Informations Info { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Info = _db.Informations.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Informations.Update(Info);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reservation updated successfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
