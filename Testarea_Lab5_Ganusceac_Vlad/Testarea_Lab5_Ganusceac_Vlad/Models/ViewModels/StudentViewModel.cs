using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels
{
    public class StudentViewModel : Student
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }
    }
}