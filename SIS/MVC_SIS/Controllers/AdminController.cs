using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View(major);
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }         
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }




        
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }
       
        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }
       
        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View(state);
            }          
        }
        
        [HttpGet]
        public ActionResult EditState(string stateAbb)
        {
            var state = StateRepository.Get(stateAbb);
            return View(state);
        }
       
        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName) || string.IsNullOrEmpty(state.StateAbbreviation))
            {
               ModelState.AddModelError("StateName", "");
                return View(state);
            }
            if (state.StateAbbreviation.Length != 2)
            {
                ModelState.AddModelError("StateAbbreviation", "The State Abbreviation must be two characters. ");
                return View(state);
            }
            else
            {
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
        }
      
        [HttpGet]
        public ActionResult DeleteState(string stateAbb)
        {
            var state = StateRepository.Get(stateAbb);
            return View(state);
        }
      
        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }
       



        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }
       
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }
        
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");
            }
            else
            {
                return View(course);
            }           
        }
        
        [HttpGet]
        public ActionResult EditCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }
       
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("CoursesName", "");
                return View(course);
            }
            else
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }          
        }
       
        [HttpGet]
        public ActionResult DeleteCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }
      
        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }

    }
}