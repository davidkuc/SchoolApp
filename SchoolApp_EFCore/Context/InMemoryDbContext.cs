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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroups> StudentGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherGroups> TeacherGroups { get; set; }
        public DbSet<TeacherSubjects> TeacherSubjects { get; set; }

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

            modelBuilder.Entity<Account>().HasData(new Account{ ID = 1, Username = "admin", Password = "admin", Name = "Krul", Surname = "Bazy", HasAdminPrivileges = true });
        }

    }
}
