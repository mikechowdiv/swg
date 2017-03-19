using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.Repositories;

namespace Exercises.Models.ViewModels
{
    public class EditVM
    {
        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> CourseId { get; set; }

        private IEnumerable<Student> _students = StudentRepository.GetAll();

        public EditVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
           CourseId = new List<int>();
            Student = new Student();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var items in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = items.CourseId.ToString(),
                    Text = items.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var items in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = items.MajorId.ToString(),
                    Text = items.MajorName
                });
            }
        }

        public Student GetStudent(int studentId)
        {
            IEnumerable<Student> _students = StudentRepository.GetAll();
            var selectedStudent = _students.First(s => s.StudentId == studentId);
            return selectedStudent;
        }

        public static void Edit(EditVM editVm)
        {
            IEnumerable<Student> _students = StudentRepository.GetAll();

        }
    }
}