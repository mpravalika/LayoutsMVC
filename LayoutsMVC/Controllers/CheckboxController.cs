using LayoutsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutsMVC.Controllers
{
    public class CheckboxController : Controller
    {
        List<EMPDATA> List = null;
        // GET: Checkbox
        public ActionResult Index()
        {
            ViewBag.L = DBOperations.Getall();
            return View();
        }
        public ActionResult Check()
        {
            var empno = Request.Form.Get("chk");
            List = DBOperations.Getall();
            List<EMPDATA> newlist = new List<EMPDATA>();
            foreach (var i in List)
            {
               if(empno.Contains(i.EMPNO.ToString()))
                {
                    newlist.Add(i);
                }
            }
            return View(newlist);
        }
    }
}