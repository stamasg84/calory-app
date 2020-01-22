using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFDataAccess
{
    public class CaloryDbContext : DbContext
    {
        public CaloryDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Meal> Meals { get; set; }
    }
}
