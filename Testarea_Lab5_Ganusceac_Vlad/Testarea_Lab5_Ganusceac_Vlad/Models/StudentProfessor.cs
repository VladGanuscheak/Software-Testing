using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class StudentProfessor
    {
        public int StudentId { get; set; }

        public int ProfessorId { get; set; }

        public int CourseId { get; set; }

        public Professor Professor { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}