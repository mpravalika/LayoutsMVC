using LayoutsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutsMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult Submit(LoginValidations L)
        {
            if (ModelState.IsValid)
            {
                string user = Request.Form["Login"];
                string pwd = Request.Form["password"];
                bool R = DBOperations.Valid(user, pwd);
                if (R == true)
                {
                    return View();
                }
                else
                {
                    return View("LoginPage");
                }
            }
            else
            {
                return View("LoginPage");
            }
        }
    }
}