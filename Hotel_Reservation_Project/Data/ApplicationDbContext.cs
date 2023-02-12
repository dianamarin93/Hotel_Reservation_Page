using Hotel_Reservation_Project.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Informations> Informations { get; set; }
    }
}
