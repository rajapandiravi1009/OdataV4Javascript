using EJGrid.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace EJGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var DataSource1 = OrderRepository.GetAllRecords();
            //ViewBag.dataSource1 = DataSource1;
            //var DataSource2 = OrderRepository.GetAllRecords2();
            //ViewBag.dataSource2 = DataSource2;
            return View();
        }

        public JsonResult GetData(int EmployeeID)
        {
            var data = "";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}