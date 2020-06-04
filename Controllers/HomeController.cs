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
        private static List<Problem> _problem = new List<Problem>
        {
            new Problem {
                Title = "Lorem Ipsum",
                Description = "The quick brown fox jumped",
                Solution = "Don't jump over the moon"
            },
            new Problem {
                Title = "Fast and Furious",
                Description = "Too fast too bad",
                Solution = "Click it or cop it"
            },

        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_problem);
        }

        [HttpGet("[action]", Name = "Problems")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Add(Problem problem)
        {
            if (ModelState.IsValid)
            {
                _problem.Add(problem);
                return RedirectToAction("Index");
            }
            else
            {
                return View(problem);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
