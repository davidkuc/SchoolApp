﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Subject> Subjects { get; set; }
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

            modelBuilder.Entity<Account>().HasData(new Account { ID = "1", Username = "admin", Password = "admin", Name = "Krul", Surname = "Bazy", HasAdminPrivileges = true });


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



            var students = new List<Student>()
            {
             new Student { ID = "1", Name = "Stud1", Surname ="Sur1", CourseName="ddd", DateOfBirth="55/55/5555", Year = 1       },
             new Student { ID = "2", Name = "Stud2", Surname = "Sur2", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = "3", Name = "Stud3", Surname = "Sur3", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = "4", Name = "Stud4", Surname = "Sur4", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = "5", Name = "Stud5", Surname ="Sur5", CourseName="ddd", DateOfBirth="55/55/5555", Year = 1      }    ,
             new Student { ID = "6", Name = "Stud6", Surname = "Sur6", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = "7", Name = "Stud7", Surname = "Sur7", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
             new Student { ID = "8", Name = "Stud8", Surname = "Sur8", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 }
            };

            var groups = new List<Group>()
            {

                new Group { ID = "1", SCode = "MM",  ActivityForm = "EX"  },
                new Group { ID = "2", SCode = "ALG",  ActivityForm = "EX"  },
                new Group { ID = "3", SCode = "ENG", ActivityForm = "EX"  },
                new Group { ID = "4", SCode = "STAT", ActivityForm = "EX"  }
            };



            modelBuilder.Entity<Student>()
                .HasData(students[0], students[1], students[2], students[3]);

            modelBuilder.Entity<Group>()
                .HasData(groups[0], groups[1], groups[2], groups[3]);

            modelBuilder.Entity<GroupStudent>()
                       .HasData(
                new GroupStudent { StudentId = "1", GroupId = "1" },
                    new GroupStudent { StudentId = "1", GroupId = "2" },
                        new GroupStudent { StudentId = "1", GroupId = "3" },
                            new GroupStudent { StudentId = "1", GroupId = "4" }

                       );
            //       modelBuilder.Entity< GroupStudent> ()
            //           .HasOne(pt => pt.Student)
            //           .WithMany(p => p.StudentGroups)
            //           .HasForeignKey(pt => pt.StudentId);

            //       modelBuilder.Entity< GroupStudent> ()
            //           .HasOne(pt => pt.Group)
            //           .WithMany(t => t.StudentGroups)
            //           .HasForeignKey(pt => pt.GroupId);


            //var students = new List<Student>()
            //{
            //new Student { ID = "1", Name = "Stud1", Surname ="Sur1", CourseName="ddd", DateOfBirth="55/55/5555", Year = 1  },
            // new Student { ID = "2", Name = "Stud2", Surname = "Sur2", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
            // new Student { ID = "3", Name = "Stud3", Surname = "Sur3", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
            // new Student { ID = "4", Name = "Stud4", Surname = "Sur4", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
            // new Student { ID = "5", Name = "Stud5", Surname ="Sur5", CourseName="ddd", DateOfBirth="55/55/5555", Year = 1  }    ,
            // new Student { ID = "6", Name = "Stud6", Surname = "Sur6", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
            // new Student { ID = "7", Name = "Stud7", Surname = "Sur7", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
            // new Student { ID = "8", Name = "Stud8", Surname = "Sur8", CourseName = "ddd", DateOfBirth = "55/55/5555", Year = 1 }
            //};

            //var groups = new List<Group>()
            //{

            //    new Group { ID = "1", Code = "MM", Students = new List<Student>() { students[0], students[1], students[5], students[7] }, ActivityForm = "EX"  },
            //    new Group { ID = "2", Code = "ALG", Students = new List<Student>() { students[1], students[3] , students[4], students[5], students[6]}, ActivityForm = "EX"  },
            //    new Group { ID = "3", Code = "ENG", Students = new List<Student>() { students[1], students[3], students[0], students[2], students[5], students[7] }, ActivityForm = "EX"  },
            //    new Group { ID = "4", Code = "STAT", Students = new List<Student>() { students[1], students[3], students[0], students[2] }, ActivityForm = "EX"  }
            //};


        }

    }
}
