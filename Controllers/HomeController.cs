using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeSnippets.Models;

namespace CodeSnippets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Problem _problem = new Problem();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]", Name = "Problems")]
        public IActionResult Add()
        {
            return View(_problem);
        }

        [HttpPost("[action]")]
        public IActionResult Add(Problem problem)
        {
            if (ModelState.IsValid)
            {
                _problem.Title = problem.Title;
                _problem.Description = problem.Description;
                _problem.Solution = problem.Solution;
                return RedirectToAction("Add");
            }
            else
            {
                return View(_problem);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
