using BusinessComponents.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testarea_Lab5_Ganusceac_Vlad.Models;
using Testarea_Lab5_Ganusceac_Vlad.Models.ViewModels;

namespace Testarea_Lab5_Ganusceac_Vlad.UnitOfWorkPattern
{
    public class UnitOfWork
    {
        private bool disposed = false;

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        #region Fields
        private Repository<Course> courseRepository;

        private Repository<DateTable> dateTableRepository;

        private Repository<Group> groupRepository;

        private Repository<Professor> professorRepository;

        private Repository<Student> studentRepository;

        private Repository<StudentCourse> studentCourseRepository;

        private Repository<StudentGroup> studentGroupRepository;

        private Repository<StudentProfessor> studentProfessorRepository;
        #endregion

        #region ViewModels
        private Repository<StudentGradesViewModel> studentGradesViewModelRepository;

        private Repository<StudentViewModel> studentViewModelRepository;
        #endregion

        #region Properties
        public Repository<Course> Course
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new Repository<Course>(_context);
                }

                return courseRepository;
            }
        }

        public Repository<DateTable> DateTable
        {
            get
            {
                if (dateTableRepository == null)
                {
                    dateTableRepository = new Repository<DateTable>(_context);
                }

                return dateTableRepository;
            }
        }

        public Repository<Group> Group
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new Repository<Group>(_context);
                }

                return groupRepository;
            }
        }

        public Repository<Professor> Professor
        {
            get
            {
                if (professorRepository == null)
                {
                    professorRepository = new Repository<Professor>(_context);
                }

                return professorRepository;
            }
        }

        public Repository<Student> Student
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new Repository<Student>(_context);
                }

                return studentRepository;
            }
        }

        public Repository<StudentCourse> StudentCourse
        {
            get
            {
                if (studentCourseRepository == null)
                {
                    studentCourseRepository = new Repository<StudentCourse>(_context);
                }

                return studentCourseRepository;
            }
        }

        public Repository<StudentGroup> StudentGroup
        {
            get
            {
                if (studentGroupRepository == null)
                {
                    studentGroupRepository = new Repository<StudentGroup>(_context);
                }

                return studentGroupRepository;
            }
        }

        public Repository<StudentProfessor> StudentProfessor
        {
            get
            {
                if (studentProfessorRepository == null)
                {
                    studentProfessorRepository = new Repository<StudentProfessor>(_context);
                }

                return studentProfessorRepository;
            }
        }
        #endregion

        #region Properties for ViewModels
        public Repository<StudentGradesViewModel> StudentGradesViewModel
        {
            get
            {
                if (studentGradesViewModelRepository == null)
                {
                    studentGradesViewModelRepository = new Repository<StudentGradesViewModel>(_context);
                }

                return studentGradesViewModelRepository;
            }
        }

        public Repository<StudentViewModel> StudentViewModel
        {
            get
            {
                if (studentViewModelRepository == null)
                {
                    studentViewModelRepository = new Repository<StudentViewModel>(_context);
                }

                return studentViewModelRepository;
            }
        }
        #endregion

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public ApplicationDbContext Context
        {
            get
            {
                return _context;
            }
        }
    }
}