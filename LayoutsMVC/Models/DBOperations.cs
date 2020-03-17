using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace LayoutsMVC.Models
{
    public class DBOperations
    {
        static DemoEntities D = new DemoEntities();
        public static bool Valid(string login,string pwd)
        {
            
            var L = (from E in D.LoginTables
                    where E.Login == login && E.password == pwd
                    select E).FirstOrDefault();
            if (L!= null)
            {
                return true;
            }
            else
                return false;
        }
        public static List<EMPDATA> Getall()
        {
            var E = from E1 in D.EMPDATAs
                    select E1;
            return E.ToList();
        }
        public static EMPDATA Editall(int empno)
        {
            var E = (from E1 in D.EMPDATAs
                    where E1.EMPNO==empno
                    select E1).FirstOrDefault();
            return E;
        }
        public static string Editdata(int empno, EMPDATA emp)
        {
            var LE = from L in D.EMPDATAs //for getting original details of empno.
                     where L.EMPNO == empno
                     select L;
            foreach (var item in LE)
            {
                item.JOB = emp.JOB;
                item.MGR = emp.MGR;
                item.SAL = emp.SAL;
                item.COMM = emp.COMM;
                item.DEPTNO = emp.DEPTNO;
            }
            D.SaveChanges();
            return "1 Row Updated";
        }
        public static string Deldata(int empno)
        {
            var LE = (from L1 in D.EMPDATAs
                      where L1.EMPNO == empno
                      select L1).FirstOrDefault();
            D.EMPDATAs.Remove(LE);
            D.SaveChanges();
            return empno + " employee details Deleted";
        }
        public static string insertdata(EMPDATA A)
        {
            try
            {
                D.EMPDATAs.Add(A);
                D.SaveChanges();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK__EMPDATA__DEPTNO__3587F3E0"))
                {
                    return "no proper detno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return "empno cannot be same";
                }
                else
                {
                    return "Error occured";
                }
            }
            return "Row inserted";
        }
    }
}