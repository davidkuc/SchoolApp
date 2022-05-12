﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Student : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }
    }
}