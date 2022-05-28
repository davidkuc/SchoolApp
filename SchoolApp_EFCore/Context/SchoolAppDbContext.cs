using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Context
{
    public class SchoolAppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public SchoolAppDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = SchoolApp; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
               new Account { ID = 1, Username = "admin", Password = "admin",
                   Name = "Admin", Surname = "", HasAdminPrivileges = true });

            GroupStudent_ManyToMany(modelBuilder);

            GroupTeacher_ManyToMany(modelBuilder);
        }

        private static void GroupTeacher_ManyToMany(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupTeacher>()
          .HasKey(t => new { t.TeacherId, t.GroupId });

            modelBuilder.Entity<Teacher>()
            .HasMany(p => p.Groups)
            .WithMany(p => p.Teachers)
            .UsingEntity<GroupTeacher>(
        j => j
            .HasOne(x => x.Group)
            .WithMany(x => x.TeacherGroups)
            .HasForeignKey(x => x.GroupId),

          j => j
            .HasOne(x => x.Teacher)
            .WithMany(x => x.TeacherGroups)
            .HasForeignKey(x => x.TeacherId));
        }

        private static void GroupStudent_ManyToMany(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupStudent>()
            .HasKey(t => new { t.StudentId, t.GroupId });

            modelBuilder.Entity<Student>()
            .HasMany(p => p.Groups)
            .WithMany(p => p.Students)
            .UsingEntity<GroupStudent>(
        j => j
            .HasOne(x => x.Group)
            .WithMany(x => x.StudentGroups)
            .HasForeignKey(x => x.GroupId),

          j => j
            .HasOne(x => x.Student)
            .WithMany(x => x.StudentGroups)
            .HasForeignKey(x => x.StudentId));
        }
    }
}
