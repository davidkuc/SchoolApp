using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolApp_EFCore.Context;
using SchoolApp_EFCore.Models;
using SchoolApp_EFCore.Repositories;
using System.Collections.Generic;

namespace SchoolApp_Tests
{
    [TestClass]
    public class RepositoryTests
    {

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_Add()
        {
            using (var dbCtx = new InMemoryDbContext())
            {
                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var expStud = new Student { ID = 1, Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 };
                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Save();

                Assert.IsNotNull(sqlRepo.GetById(1));
                Assert.AreEqual(expStud.ID, sqlRepo.GetById(1).ID);
                dbCtx.Database.EnsureDeleted();
            }

        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_GetByID()
        {
            using (var dbCtx = new InMemoryDbContext())
            {

                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var expStud1 = new Student
                {
                    ID = 1,
                    Name = "Stud9",
                    Surname = "Sur9",
                    Course = "ddd",
                    DateOfBirth = "55/55/5555",
                    Year = 1
                };
                var expStud2 = new Student
                {
                    ID = 5,
                    Name = "Stud1",
                    Surname = "Sur9",
                    Course = "ddd",
                    DateOfBirth = "55/55/5555",
                    Year = 1
                };

                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Save();

                Assert.AreEqual(expStud1.ID, sqlRepo.GetById(1).ID);
                Assert.AreEqual(expStud2.ID, sqlRepo.GetById(5).ID);
                dbCtx.Database.EnsureDeleted();
            }



        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_GetAll()
        {
            using (var dbCtx = new InMemoryDbContext())
            {

                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var studList = new List<Student>()
            {
           new Student {ID = 1, Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 2, Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 3, Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 4, Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 5, Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 }
            };

                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Save();

                var allStuds = (List<Student>)sqlRepo.GetAll();

                Assert.IsNotNull(allStuds);
                Assert.AreEqual(studList.Count, allStuds.Count);
                for (int i = 0; i < studList.Count; i++)
                {
                    Assert.AreEqual(studList[i].ID, allStuds[i].ID);
                    Assert.AreEqual(studList[i].Name, allStuds[i].Name);
                }
                dbCtx.Database.EnsureDeleted();
            }

        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_GetLast()
        {
            using (var dbCtx = new InMemoryDbContext())
            {
                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var studList = new List<Student>()
                        {
                     new Student {ID = 1, Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
                     new Student {ID = 2, Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
                     new Student {ID = 3, Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
                     new Student {ID = 4, Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
                     new Student {ID = 5, Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 }

                      };

                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Save();

                var lastStud = sqlRepo.GetLast();
                Assert.AreEqual(studList[4].ID, lastStud.ID);
                Assert.AreEqual(studList[4].Name, lastStud.Name);
                dbCtx.Database.EnsureDeleted();
            }


        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_Remove()
        {
            using (var dbCtx = new InMemoryDbContext())
            {
                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var studList = new List<Student>()
            {
           new Student {ID = 1, Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 2, Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 3, Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 4, Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 },
           new Student {ID = 5, Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 }

            };

                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Add(new Student { Name = "StudRemove", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
                sqlRepo.Save();

                var removeStud = sqlRepo.GetLast();
                sqlRepo.Remove(removeStud);
                sqlRepo.Save();

                var allStud = (List<Student>)sqlRepo.GetAll();

                Assert.AreEqual(studList.Count, allStud.Count);
                Assert.IsTrue(!allStud.Exists(p => p.ID == 6));
                dbCtx.Database.EnsureDeleted();
            }


         
        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_Update()
        {
            using (var dbCtx = new InMemoryDbContext())
            {

                var sqlRepo = new SqlRepository<Student>(dbCtx);

                var expStud = new Student { ID = 1, Name = "newName", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 };
                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });

                var updStud = sqlRepo.GetById(1);
                updStud.Name = "newName";
                sqlRepo.Update(updStud);

                var updatedStudent = sqlRepo.GetById(1);

                Assert.AreEqual(expStud.Name, updatedStudent.Name);
                dbCtx.Database.EnsureDeleted();
            }

        }

        [TestMethod]
        [TestCategory("Repository_ManyToMany")]
        public void GruStudRepository_ManyToMany()
        {
            using (var dbCtx = new InMemoryDbContext())
            {

                var sqlRepo = new SqlRepository<Student>(dbCtx);
                sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });

                var gruStudRepo = new GruStudRepository(dbCtx);
                gruStudRepo.Add(new GroupStudent { GroupId = 1, StudentId = 1 });
                gruStudRepo.Add(new GroupStudent { GroupId = 1, StudentId = 1 });
                gruStudRepo.Add(new GroupStudent { GroupId = 1, StudentId = 1 });

                dbCtx.Database.EnsureDeleted();
            }

        }
    }
}