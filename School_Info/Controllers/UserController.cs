using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Info.Controllers
{
    public class UserController : Controller
    {
        School_Entities db = new School_Entities();
        // GET: User
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var data = db.Users.ToList();
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

        public ActionResult Create(Users users,HttpPostedFileBase Image)
        {
            if (Session["userid"] != null)
            {
                

                var data = db.Users.Where(x => x.Email == users.Email).FirstOrDefault();
                if (data == null)
                {
                    if (Image != null)
                    {
                        string strDateTime = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second;
                        string ImagePath = "/Profile_Images/" + "Img_" + strDateTime + System.IO.Path.GetExtension(Image.FileName);

                        Image.SaveAs(Server.MapPath("~" + ImagePath));

                        users.Profile_Image = ImagePath;


                    }
                    db.Users.Add(users);
                db.SaveChanges();
                return View();
                }
                else
                {
                    ViewBag.msg = "Email Allready Exist";
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
                var data = db.Users.Where(U => U.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public ActionResult Edit(Users users)
        {
            if (Session["userid"] != null)
            {
                var data = db.Users.Where(u => u.Id == users.Id).FirstOrDefault();
                data.Email = users.Email;
                data.Name = users.Name;
                data.Password = users.Password;
                data.MobileNo = users.MobileNo;
                data.Address = users.Address;
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
                var data = db.Users.Where(U => U.Id == id).FirstOrDefault();
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
             
                var data = db.Users.Where(U => U.Id == id).FirstOrDefault();
                return View(data);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]


        public ActionResult Delete(Users users)
        {
            if (Session["Userid"] != null)
            {

                //var ses = Convert.ToInt32(Session["Userid"]);
                //var data1 = db.Users.Where(X => X.Id == ses).FirstOrDefault();
                var data1 = db.Users.Where(U => U.Email == users.Email).FirstOrDefault();
                if (data1 !=Session["Email"])
                {
                    var data = db.Users.Where(U => U.Id == users.Id).FirstOrDefault();
                    db.Users.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "User is Login";
                }
            }
            else
            {

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
