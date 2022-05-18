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
            var dbCtx = new InMemoryDbContext();
            var sqlRepo = new SqlRepository<Student>(dbCtx);

            var expStud = new Student { ID = 9, Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 };
            sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });

            Assert.IsNotNull(sqlRepo.GetById(9));
            Assert.AreEqual(expStud.ID, sqlRepo.GetById(9).ID);
        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_GetByID()
        {
            var dbCtx = new InMemoryDbContext();
            var sqlRepo = new SqlRepository<Student>(dbCtx);

            var expStud1 = new Student { ID = 1, Name = "Stud9", Surname = "Sur9", 
                Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 };
            var expStud2 = new Student { ID = 5, Name = "Stud1", Surname = "Sur9", 
                Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 };

            sqlRepo.Add(new Student { Name = "Stud9", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
            sqlRepo.Add(new Student { Name = "Stud5", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
            sqlRepo.Add(new Student { Name = "Stud3", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
            sqlRepo.Add(new Student { Name = "Stud2", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
            sqlRepo.Add(new Student { Name = "Stud1", Surname = "Sur9", Course = "ddd", DateOfBirth = "55/55/5555", Year = 1 });
            sqlRepo.Save();

            Assert.AreEqual(expStud1.ID, sqlRepo.GetById(1).ID);
            Assert.AreEqual(expStud2.ID, sqlRepo.GetById(5).ID);
        }

        [TestMethod]
        [TestCategory("Repository")]
        public void SqlRepository_GetAll()
        {
            var dbCtx = new InMemoryDbContext();
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
        }
    }
}