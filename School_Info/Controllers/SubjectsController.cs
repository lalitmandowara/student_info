using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class SubjectsController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Subjects
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Subjects.ToList();
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
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]

        public ActionResult Create(Subjects subjects)
        {
            if (Session["userid"] != null)
            {
                var data = db.Subjects.Where(S => S.SubjectsName == subjects.SubjectsName).FirstOrDefault();
                if (data == null)
                {



                    db.Subjects.Add(subjects);
                    db.SaveChanges();
                    return View();
                }
                else
                {
                    ViewBag.msg = "Class Already Exist";
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            if (Session["userid"] != null)
            {
                var data = db.Subjects.Where(S => S.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Subjects subjects)
        {
            if (Session["userid"] != null)
            {
                var data = db.Subjects.Where(S => S.SubjectsName == subjects.SubjectsName).FirstOrDefault();
                data.SubjectsName = subjects.SubjectsName;
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
                var data = db.Subjects.Where(S => S.Id == id).FirstOrDefault();
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
                var data = db.Subjects.Where(S => S.Id == id).FirstOrDefault();

                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Subjects subjects)
        {
            if (Session["userid"] != null)
            {
                var data = db.Subjects.Where(S => S.SubjectsName == subjects.SubjectsName).FirstOrDefault();
                db.Subjects.Remove(data);
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