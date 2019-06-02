using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<StudentGroup> StudentGroups { get; set; }

        public ICollection<StudentProfessor> StudentProfessors { get; set; }
    }
}