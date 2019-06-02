using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}