using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web;
using System.Web.Mvc;
using VkWeb.Models;

namespace VkWeb.Controllers
{
    public class UserDataController : Controller
    {
        public TopMadel top = null;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDataModel model)
        {
            //model.CorrectDate();
            if (model.ComplianceTest())
            {
                      
                ViewBag.URL = model.URL;
                ViewBag.date = model.date.ToString("dd.MM.yyyy");
                ViewBag.quantity = model.quantity;
                ViewBag.userData = model;
            }
            else
            {
                ViewBag.URL = " ";
            }
            return View();
        }
    }
}
