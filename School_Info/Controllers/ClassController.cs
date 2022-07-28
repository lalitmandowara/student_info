using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class ClassController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Class
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Class.ToList();
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

        public ActionResult Create(Class Class)
        {
            if (Session["userid"] != null)
            {
                var data = db.Class.Where(C => C.ClassName == Class.ClassName).FirstOrDefault();
                if (data == null)
                {



                    db.Class.Add(Class);
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
                var data = db.Class.Where(C => C.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Class Class)
        {
            if (Session["userid"] != null)
            {
                var data = db.Class.Where(C => C.Id == Class.Id).FirstOrDefault();
                data.ClassName = Class.ClassName;
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
                var data = db.Class.Where(C => C.Id == id).FirstOrDefault();
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
                var data = db.Class.Where(C => C.Id == id).FirstOrDefault();

                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Class Class)
        {
            if (Session["userid"] != null)
            {
                var data = db.Class.Where(C => C.Id == Class.Id).FirstOrDefault();
                db.Class.Remove(data);
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