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
        public DbSet<Teacher> Teacher { get; set; }


        public InMemoryDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Account>().HasKey(p => p.)

            modelBuilder.Entity<Account>().HasData(
                new Account { ID = 1, Username = "admin", Password = "admin", Name = "Admin", Surname = "", HasAdminPrivileges = true },
                    new Account
                    {
                        ID = 2,
                        Username = "user",
                        Password = "user",
                        Name = "User",
                        Surname = "",
                        HasAdminPrivileges = false
                    },
                      new Account
                      {
                          ID = 3,
                          Username = "admin2",
                          Password = "admin2",
                          Name = "Admin2",
                          Surname = "drugi",
                          HasAdminPrivileges = true
                      });

            GroupStudent_ManyToMany(modelBuilder);

            GroupTeacher_ManyToMany(modelBuilder);

            SeedData(modelBuilder);

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var teachers = new List<Teacher>()
            {
             new Teacher { ID = 1, Name = "Tea1", Surname = "Sur1"},
              new Teacher { ID = 2, Name = "Tea2", Surname = "Sur2"},
               new Teacher { ID =3, Name = "Tea3", Surname = "Sur3"},

            };

            var students = new List<Student>()
            {
             new Student { ID = 1, Name = "Stud1", Surname ="Sur1", Course="ddd", DateOfBirth="55/55/5555", Year = 1       },
             new Student { ID = 2, Name = "Stud2", Surname = "Sur2",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = 3, Name = "Stud3", Surname = "Sur3",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = 4, Name = "Stud4", Surname = "Sur4",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = 5, Name = "Stud5", Surname ="Sur5", Course="ddd", DateOfBirth="55/55/5555", Year = 1      }    ,
             new Student { ID = 6, Name = "Stud6", Surname = "Sur6",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = 7, Name = "Stud7", Surname = "Sur7",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = 8, Name = "Stud8", Surname = "Sur8",Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 }
            };

            var groups = new List<Group>()
            {
                new Group { ID = 1, SCode = "MM",  ActivityForm = "EX"  },
                new Group { ID = 2, SCode = "ALG",  ActivityForm = "EX"  },
                new Group { ID = 3, SCode = "ENG", ActivityForm = "EX"  },
                new Group { ID = 4, SCode = "STAT", ActivityForm = "EX"  }
            };

            modelBuilder.Entity<Student>()
                .HasData(students[0], students[1], students[2], students[3], students[4], students[5], students[6], students[7]);

            modelBuilder.Entity<Group>()
                .HasData(groups[0], groups[1], groups[2], groups[3]);

            modelBuilder.Entity<Teacher>()
            .HasData(teachers[0], teachers[1], teachers[2]);

            modelBuilder.Entity<GroupStudent>()
                       .HasData(
                new GroupStudent { StudentId = 1, GroupId = 1 },
                    new GroupStudent { StudentId = 1, GroupId = 1 },
                        new GroupStudent { StudentId = 1, GroupId = 3 },
                            new GroupStudent { StudentId = 1, GroupId = 4 }
                       );

            modelBuilder.Entity<GroupTeacher>()
                     .HasData(
              new GroupTeacher { TeacherId = 1, GroupId = 1 },
                      new GroupTeacher { TeacherId = 1, GroupId = 2 },
                              new GroupTeacher { TeacherId = 2, GroupId = 1 },
                                      new GroupTeacher { TeacherId = 2, GroupId = 2 },
                                              new GroupTeacher { TeacherId = 2, GroupId = 3 },
                                                new GroupTeacher { TeacherId = 2, GroupId = 4 },
                                                  new GroupTeacher { TeacherId = 3, GroupId = 3 },
                                                    new GroupTeacher { TeacherId = 3, GroupId = 4}

                     );
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
