using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolApp_EFCore.Context;
using SchoolApp_EFCore.Models;
using SchoolApp_EFCore.Repositories;

namespace SchoolApp_Tests
{
    [TestClass]
    public class UnitTest1
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
        }
    }
}