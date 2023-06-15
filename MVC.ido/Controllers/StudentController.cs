using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ADO.Controllers
{
    public class StudentController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SchConn"].ToString();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listsStudent()
        {
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return View(dt);
        }

        public ActionResult Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd= new SqlCommand("delete from Student where id="+id+"",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("listsStudent");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(int Id, string name, string address, string city, bool Isactive)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Student values("+Id+",'"+name+ "','" + address + "','" + city + "','" + Isactive + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("listsStudent");
        }
    }
}