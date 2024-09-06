    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCourseApp.Data;
using StudentCourseApp.Models;

namespace StudentCourseApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Create(Student student)
        {
            
            ModelState.Remove("Course.Id");
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View("Create" , student);  
            
        }

        public ActionResult Edit(int id)
        {   
            
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(u => u.Id == id);
                return View(student);
            }
        }

        [HttpPost]

        public ActionResult Edit(Student student)
        {
            
            ModelState.Remove("Course.Id");
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                    {
                using (var transaction = session.BeginTransaction())
                        {
               
                    student.Course.Student = student;
                    session.Update(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                        }
                    }
            }
           
            return View("Edit" , student);
        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(u => u.Id == id);
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStudent(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Query<Student>().FirstOrDefault(u => u.Id == id);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}