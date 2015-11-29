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
        public TopMadels top = null;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDataModel model)
        {
            model.CorrectDate();
            if (model.ComplianceTest() & model.CorrectDate() & model.CorrectQuantity())
            {
                //if (model.CorrectDate())
                //{
                //    if (model.CorrectQuantity())
                //    {                        
                ViewBag.URL = model.URL;
                ViewBag.date = model.date;
                ViewBag.quantity = model.quantity;
                ViewBag.userData = model;

                //model.top = new TopMadels(model);
                //    }
                //}
            }
            else
            {
                ViewBag.URL = " ";
            }
            return View();
        }
    }
}
