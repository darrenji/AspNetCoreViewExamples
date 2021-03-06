﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreViewsExamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    ViewBag.Message = "Hello, World";
        //    ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
        //    return View("DebugData");
        //}

        public ViewResult Index()
        {
            return View("MyView", new string[] { "Apple", "Orange", "Pear"});
        }

        public ViewResult List() => View();
    }
}
