using SchoolApp_EFCore.Models;
using SchoolApp_EFCore.Repositories;
using SchoolApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFStudent = SchoolApp_EFCore.Models.Student;
using EFTeacher = SchoolApp_EFCore.Models.Teacher;

namespace SchoolApp2.Helpers
{
    public static class DataProvider
    {
        public static List<GroupModel> GetDBGroupModels(RepoPack repoPack)
        {
            var groupsList = new List<GroupModel>();
            foreach (var item in repoPack.GruRepo.GetAll())
            {
                groupsList.Add(new GroupModel()
                {
                    SCode = item.SCode,
                    ActivityForm = item.ActivityForm,
                    ID = item.ID
                });
            }
            return groupsList;
        }

        public static List<GroupModel> GetStudentGroupModels(EFStudent stud)
        {
            var groups = new List<GroupModel>();

            if (stud.Groups == null)
            {
                return groups;
            }
            foreach (var item in stud.Groups)
            {
                groups.Add(new GroupModel()
                {
                    SCode = item.SCode,
                    ActivityForm = item.ActivityForm,
                    ID = item.ID
                });
            }
            return groups;
        }

        public static List<GroupModel> GetTeacherGroupModels(EFTeacher tea)
        {
            var groups = new List<GroupModel>();
            foreach (var item in tea.Groups)
            {
                groups.Add(new GroupModel()
                {
                    SCode = item.SCode,
                    ActivityForm = item.ActivityForm,
                    ID = item.ID
                });
            }
            return groups;
        }
    }
}
