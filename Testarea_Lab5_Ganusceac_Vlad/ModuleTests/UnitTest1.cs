using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testarea_Lab5_Ganusceac_Vlad.Models;
using Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels;
using Testarea_Lab5_Ganusceac_Vlad.Queries;

namespace ModuleTests
{
    [TestClass]
    public class UnitTestStudents
    {
        private StudentsQueries studentsQueries = new StudentsQueries();

        private CourseQueries courseQueries = new CourseQueries();

        [TestMethod]
        public void CreateStudent()
        {
            studentsQueries.CreateStudent(new StudentViewModel
            {
                FirstName = "John",
                SecondName = "Doe",
                MiddleName = "-",
                GroupId = 2
            });

            var student = studentsQueries.GetStudentViewModels()
                .Where(p => p.FirstName == "John")
                .Where(p => p.SecondName == "Doe")
                .Where(p => p.MiddleName == "-")
                .FirstOrDefault();

            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void AddCourse()
        {
            courseQueries.AddCourse(new Course
            {
                CourseName = "TMPS"
            });

            var course = courseQueries.GetCourses()
                .Where(p => p.CourseName == "TMPS")
                .FirstOrDefault();

            Assert.IsNotNull(course);
        }

        [TestMethod]
        public void AddStudentGrade()
        {
            var student = studentsQueries.GetStudentViewModels()
                .Where(p => p.StudentId == 1)
                .First();

            var course = courseQueries.GetCourses()
                .Where(p => p.CourseName == "TMPS")
                .FirstOrDefault();

            if (student != null && course != null)
            {
                studentsQueries.AddStudentGrades(new StudentGradesViewModel
                {
                    StudentId = student.StudentId,
                    CourseId = course.CourseId,
                    Attestation_first = 8,
                    Attestation_second = 9,
                    CourseName = course.CourseName,
                    Exam = 10,
                    Grade = 9.10f
                });

                Assert.IsTrue(true);
            }
        }
    }
}
