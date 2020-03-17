using LayoutsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutsMVC.Controllers
{
    public class EMPController : Controller
    {
        // GET: EMP
        public ActionResult Index()
        {
            List<EMPDATA> L = DBOperations.Getall();
            return View(L);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Insert(EMPDATA E)
        {
            ViewBag.msg = DBOperations.insertdata(E);
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            EMPDATA E = DBOperations.Editall(id);
            return View(E);
        }
        public ActionResult Editbtn(EMPDATA E)
        {
            int empno = int.Parse(Request.Form["EMPNO"]);
            string s = DBOperations.Editdata(empno, E);
            ViewBag.msg = s;
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            string s = DBOperations.Deldata(id);
            ViewBag.msg = s;
            return View();
        }
    }
}