using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class TeacherController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Teacher
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Teacher.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }


        public ActionResult Create()
        {
            if (Session["userid"] != null)
            {
                ViewBag.Subject = new SelectList(db.Subjects.ToList(), "Id", "SubjectsName");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]

        public ActionResult Create(Teacher teacher)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Subject = new SelectList(db.Subjects.ToList(), "Id", "SubjectsName");
                db.Teacher.Add(teacher);
                db.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }


        public ActionResult Edit(int id)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Subject = new SelectList(db.Subjects.ToList(), "Id", "SubjectsName");
                var data = db.Teacher.Where(T => T.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Subject = new SelectList(db.Subjects.ToList(), "Id", "SubjectsName");
                var data = db.Teacher.Where(T => T.Id == teacher.Id).FirstOrDefault();
                data.TeacherName = teacher.TeacherName;
                data.SubjectId = teacher.SubjectId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

        public ActionResult Details(int id)
        {
            if (Session["userid"] != null)
            {
                var data = db.Teacher.Where(T => T.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {

                return RedirectToAction("Login", "Account");
            }
        }



        public ActionResult Delete(int id)
        {
            if (Session["userid"] != null)
            {
                var data = db.Teacher.Where(T => T.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Teacher teacher)
        {
            if (Session["userid"] != null)
            {
                var data = db.Teacher.Where(C => C.Id == teacher.Id).FirstOrDefault();
                db.Teacher.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

    }
}