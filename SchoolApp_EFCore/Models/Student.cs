﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Models
{
    public class Student 
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string CourseName { get; set; }

        public Course? Course { get; set; }

        public string DateOfBirth { get; set; }

        public int Year { get; set; }

        public ICollection<Group> Groups { get; set; }
        public List<GroupStudent> StudentGroups { get; set; }

    }
}
