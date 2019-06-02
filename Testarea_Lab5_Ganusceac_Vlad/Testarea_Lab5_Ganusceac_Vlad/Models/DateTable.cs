using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class DateTable
    {
        public int DateId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}