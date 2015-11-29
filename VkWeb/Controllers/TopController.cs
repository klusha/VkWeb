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
    public class TopController : Controller
    {
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(String date, int quantity)
        {
            TopMadels top = new TopMadels(date, quantity);
            return View(top);
        }

    }
}
