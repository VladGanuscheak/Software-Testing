using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels
{
    public class StudentGradesViewModel : StudentCourse
    {
        public string CourseName { get; set; }

        public float Grade { get; set; }
    }
}