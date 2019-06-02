using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<StudentProfessor> StudentProfessors { get; set; }
    }
}