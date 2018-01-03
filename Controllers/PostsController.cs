using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPress.Models;

namespace ASPress.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}
