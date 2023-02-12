using Hotel_Reservation_Project.Data;
using Hotel_Reservation_Project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_Reservation_Project.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Informations Info { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Info = _db.Informations.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {


            var categoryFromDb = _db.Informations.Find(Info.Id);
            if (categoryFromDb != null)
            {
                _db.Informations.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reservation deleted successfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
