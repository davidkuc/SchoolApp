using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Context
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public InMemoryDbContext()
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().
                HasData(
                new Account() { ID = -1, Username = "admin", Password = "admin", Name = "Krul", Surname = "Bazy", HasAdminPrivileges = true }
                );
        }

    }
}
