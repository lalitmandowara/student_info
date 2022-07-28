using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class FeesController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Fees
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.fees.ToList();
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

        public ActionResult Create(fees fees)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                var data = db.student.Where(x => x.id == fees.StudentId).FirstOrDefault();
                var data1 = db.Class.Where(x => x.Id == data.ClassId).Select(r => r.Amount).FirstOrDefault();

                fees.Amount = data1;
                fees.FeesDate = DateTime.Now;

                db.fees.Add(fees);
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
                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                var data = db.fees.Where(F => F.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(fees fees)
        {
            if (Session["userid"] != null)
            {
                ViewBag.Studentlist = new SelectList(db.student.ToList(), "Id", "Name");
                var data = db.fees.Where(F => F.Id == fees.Id).FirstOrDefault();
                data.StudentId = fees.StudentId;
                data.Month = fees.Month;


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
                var data = db.fees.Where(F => F.Id == id).FirstOrDefault();
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
                var data = db.fees.Where(F => F.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(fees fees)
        {
            if (Session["userid"] != null)
            {
                var data = db.fees.Where(F => F.Id == fees.Id).FirstOrDefault();
                db.fees.Remove(data);
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