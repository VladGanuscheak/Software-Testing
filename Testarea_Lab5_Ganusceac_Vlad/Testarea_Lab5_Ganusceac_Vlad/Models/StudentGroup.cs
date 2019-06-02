using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class StudentGroup
    {
        public int StudentId { get; set; }

        public int GroupId { get; set; }

        public int DateId { get; set; }

        public Student Student { get; set; }

        public Group Group { get; set; }

        public DateTable DateTable { get; set; }
    }
}