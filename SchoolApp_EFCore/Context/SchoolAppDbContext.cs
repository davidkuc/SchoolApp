using Microsoft.EntityFrameworkCore;

namespace SchoolApp_EFCore.Context
{
    public class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}