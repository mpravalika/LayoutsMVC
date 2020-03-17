using LayoutsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutsMVC.Controllers
{
    public class BindingController : Controller
    {
        // GET: Binding
        [ActionName("Example")]
        public ActionResult Sample()
        {
            return View("Sample");
        }
        public ActionResult Index()
        {
            return View();
        }
        //--------Primitive Type Binding--------
        public ActionResult Update(int id)
        {
            return View("Index", DBOperations.Editall(id));
        }
        //--------Complex Type Binding---------
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    return View();
        //}
        //--------Basic Type-->(NOT Suggestable)------
        //[HttpPost]
        //public ActionResult Update(int EMPNO,string ENAME,string JOB,int MGR,DateTime HIREDATE,int SAL,int COMM,int DEPTNO)
        //{
        //    return View();
        //}
        //-----------FORM Collection----------
        //[HttpPost]
        //public ActionResult Update(FormCollection F)
        //{
        //    int eno = int.Parse(F["EMPNO"]);
        //    string ename = F["ENAME"];
        //    return View();
        //}
        //---------Using BIND----------------
        [HttpPost]
        public ActionResult Update([Bind(Include= "ENAME,JOB,DEPTNO")] EMPDATA E)
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Update([Bind(Exclude = "ENAME,JOB,DEPTNO")] EMPDATA E)
        //{
        //    return View();
        //}
    }
}