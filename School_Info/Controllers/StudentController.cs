using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class StudentController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Student
        public ActionResult Index()
        {
            var data = db.student.ToList();
            return View(data);
        }


        public ActionResult Create()
        {


            ViewBag.Classlist = new SelectList(db.Class.ToList(), "Id", "ClassName");
      
            return View();
        }

        [HttpPost]

        public ActionResult Create(student students)
        {
            ViewBag.Classlist = new SelectList(db.Class.ToList(), "Id", "ClassName");


            db.student.Add(students);
            db.SaveChanges();
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Classlist = new SelectList(db.Class.ToList(), "Id", "ClassName");
            var data = db.student.Where(S => S.id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(student students)
        {
            ViewBag.Classlist = new SelectList(db.Class.ToList(), "Id", "ClassName");
            var data = db.student.Where(S => S.id == students.id).FirstOrDefault();
            data.Name = students.Name;
            data.MobileNo = students.MobileNo;
            data.FatherName = students.FatherName;
            data.MobileNo = students.MobileNo;
            data.ClassId = students.ClassId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.student.Where(C => C.id == id).FirstOrDefault();
            return View(data);
        }



        public ActionResult Delete(int id)
        {
            var data = db.student.Where(S => S.id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]


        public ActionResult Delete(student Student)
        {
            var data = db.student.Where(S => S.id == Student.id).FirstOrDefault();
            db.student.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}