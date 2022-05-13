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
            modelBuilder.Entity<StudentGroups>().HasKey(ck => new { ck.StudentId, ck.GroupId });
            modelBuilder.Entity<TeacherSubjects>().HasKey(ck => new { ck.TeacherId, ck.SubjectId });
            modelBuilder.Entity<TeacherGroups>().HasKey(ck => new { ck.TeacherId, ck.GroupId });
        }

    }
}
