using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testarea_Lab5_Ganusceac_Vlad.Models;
using Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels;
using Testarea_Lab5_Ganusceac_Vlad.UnitOfWorkPattern;

namespace Testarea_Lab5_Ganusceac_Vlad.Queries
{
    public class StudentsQueries
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        #region Create
        public void CreateStudent(StudentViewModel studentViewModel)
        {
            unitOfWork.Student.Add(new Student
            {
                FirstName = studentViewModel.FirstName,
                SecondName = studentViewModel.SecondName,
                MiddleName = studentViewModel.MiddleName
            });
        }

        public void AddStudentGrades(StudentGradesViewModel studentGradesViewModel)
        {
            unitOfWork.StudentCourse.Add(new StudentCourse
            {
                StudentId = studentGradesViewModel.StudentId,
                CourseId = studentGradesViewModel.CourseId,
                Attestation_first = studentGradesViewModel.Attestation_first,
                Attestation_second = studentGradesViewModel.Attestation_second,
                Exam = studentGradesViewModel.Exam
            });
        }
        #endregion

        #region Read
        public IEnumerable<StudentViewModel> GetStudentViewModels()
        {
            return unitOfWork.Student.GetList()
                .Join(unitOfWork.StudentGroup.GetList(),
                outer => outer.StudentId,
                inner => inner.StudentId,
                (outer, inner) => new
                {
                    StudentId = outer.StudentId,
                    MiddleName = outer.MiddleName,
                    SecondName = outer.SecondName,
                    FirstName = outer.FirstName,
                    GroupId = inner.GroupId
                }).Join(unitOfWork.Group.GetList(),
                    outer1 => outer1.GroupId,
                    inner1 => inner1.GroupId,
                    (outer1, inner1) => new StudentViewModel
                    {
                        StudentId = outer1.StudentId,
                        GroupId = outer1.GroupId,
                        FirstName = outer1.FirstName,
                        SecondName = outer1.SecondName,
                        MiddleName = outer1.MiddleName,
                        GroupName = inner1.GroupName
                    });
        }
        #endregion

        #region Update

        #endregion

        #region Delete


        #endregion
    }
}