using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class AccountController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: Account
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            var data = db.Users.Where(X => X.Email == users.Email && X.Password == users.Password).FirstOrDefault();
            if(data != null)
            {
                Session["Userid"] = data.Id;
                Session["UserName"] = data.Name;
                Session["MobileNo"] = data.MobileNo;
                Session["Email"] = data.Email;
                Session["Address"] = data.Address;



                return RedirectToAction("Dashbord");
            }
            else
            {
                ViewBag.msg = "Plz enter valid Email And Password";
                return View();
            }
           

           
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");


        }
        public ActionResult Signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Users users)
        {
            var data = db.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            if(data== null)
            {
                db.Users.Add(users);
                db.SaveChanges();
                ViewBag.msg = "Signup Completed";
                ModelState.Clear();
                return View();

            }
            else
            {
                ViewBag.msg = "Email Allready Exist";
            }
            return View();
        }

        public ActionResult Dashbord()
        {
            if(Session["Userid"] != null)
            {
                ViewBag.msg = "Well Come :" + Session["UserName"];
                return View();
            }
            else
            {
                ViewBag.msg = "First Login";
                return RedirectToAction("Login", "Account");
               
            }

        }


        public ActionResult MyProfile()
        {
            if (Session["Userid"] != null)
            {
                var email = Convert.ToString(Session["Email"]);
                var user = db.Users.Where(x=> x.Email== email).FirstOrDefault();
               
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }

    }
}