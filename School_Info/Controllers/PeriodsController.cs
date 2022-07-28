using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class PeriodsController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Periods
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Periods.ToList();
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

        public ActionResult Create(Periods periods)
        {
            if (Session["userid"] != null)
            {
                var data = db.Periods.Where(X => X.StartTime == periods.StartTime && X.EndTime == periods.EndTime).FirstOrDefault();
                if(data==null)
                {
                    db.Periods.Add(periods);
                    db.SaveChanges();
                    return View();
                }
                else
                {
                    ViewBag.msg = "PLz Enter Correct Value";
                    return View();
                }



                 
                
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
                var data = db.Periods.Where(P => P.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Periods periods)
        {
            if (Session["userid"] != null)
            {
                var data = db.Periods.Where(P => P.Id == periods.Id).FirstOrDefault();
                data.StartTime = periods.StartTime;
                data.EndTime = periods.EndTime;
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
                var data = db.Periods.Where(P => P.Id == id).FirstOrDefault();
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
                var data = db.Periods.Where(P => P.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Periods periods)
        {
            if (Session["userid"] != null)
            {
                var data = db.Periods.Where(P => P.Id == periods.Id).FirstOrDefault();
                db.Periods.Remove(data);
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