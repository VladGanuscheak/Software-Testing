using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public float? Attestation_first { get; set; }

        public float? Attestation_second { get; set; }

        public float? Exam { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}