using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class AttendanceController : Controller
    {
        School_Entities db = new School_Entities();
        //GET: Attendance
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Attendance.ToList();
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

                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]

        public ActionResult Create(Attendance attendance)
        {
            if (Session["userid"] != null)
            {
            ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");

                var match = db.Attendance.AsEnumerable().Where(x => x.DateTime.Value.Date == attendance.DateTime.Value.Date && x.StudentId == attendance.StudentId).ToList();
                if (match == null)
                {

                    db.Attendance.Add(attendance);
                    attendance.DateTime = DateTime.Now;

                    db.SaveChanges();

                }
                else
                {
                    ViewBag.msg = "Same Date Attendance AlReady Found";
                }

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
                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                var data = db.Attendance.Where(A => A.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Attendance attendance)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                var data = db.Attendance.Where(A => A.Id == attendance.Id).FirstOrDefault();
                data.StudentId = attendance.StudentId;
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
                var data = db.Attendance.Where(C => C.Id == id).FirstOrDefault();
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
                var data = db.Attendance.Where(A => A.Id == id).FirstOrDefault();

                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Attendance attendance)
        {
            if (Session["userid"] != null)
            {
                var data = db.Attendance.Where(A => A.Id == attendance.Id).FirstOrDefault();
                db.Attendance.Remove(data);
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