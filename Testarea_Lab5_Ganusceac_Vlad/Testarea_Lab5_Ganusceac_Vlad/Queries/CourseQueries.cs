using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testarea_Lab5_Ganusceac_Vlad.Models;
using Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels;
using Testarea_Lab5_Ganusceac_Vlad.UnitOfWorkPattern;

namespace Testarea_Lab5_Ganusceac_Vlad.Queries
{
    public class CourseQueries
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        #region Create
        public void AddCourse(Course course)
        {
            unitOfWork.Course.Add(course);
        }

        public void AddCourseToStudent(StudentCoursesViewModel studentCoursesViewModel)
        {
            unitOfWork.StudentCourse.Add(new StudentCourse
            {
                StudentId = studentCoursesViewModel.StudentId,
                CourseId = studentCoursesViewModel.CourseId,
                Attestation_first = studentCoursesViewModel.Attestation_first,
                Attestation_second = studentCoursesViewModel.Attestation_second,
                Exam = studentCoursesViewModel.Exam
            });
        }
        #endregion

        #region Read
        public IEnumerable<Course> GetCourses()
        {
            return unitOfWork.Course.GetList();
        }

        public Course GetCourseById(int courseId)
        {
            return unitOfWork.Course.GetList()
                .Where(p => p.CourseId == courseId)
                .FirstOrDefault();
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}