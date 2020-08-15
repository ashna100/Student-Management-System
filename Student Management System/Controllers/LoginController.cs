using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class LoginController : Controller
    {
        StudentMSEntities db = new StudentMSEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User obj1)
        {
            if (ModelState.IsValid)
            {
                using (StudentMSEntities db = new StudentMSEntities())
                {
                    var obj = db.Users.Where(a => a.Username.Equals(obj1.Username) && a.Password.Equals(obj1.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");
                    }
                }
            }

            return View(obj1);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}