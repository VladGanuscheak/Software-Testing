using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public ICollection<StudentProfessor> StudentProfessors { get; set; }
    }
}