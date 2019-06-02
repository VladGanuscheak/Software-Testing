using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels
{
    public class StudentCoursesViewModel : Student
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public float? Attestation_first { get; set; }

        public float? Attestation_second { get; set; }

        public float? Exam { get; set; }
    }
}