using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Our default route at '/'
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Post request that captures form data
        /// </summary>
        /// <param name="begYear">Form input year beginning</param>
        /// <param name="endYear">Form input year end</param>
        /// <returns>Result view</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Result", new { begYear, endYear});
        }

        /// <summary>
        /// Renders result page with current data.
        /// </summary>
        /// <param name="begYear">Form input year beginning</param>
        /// <param name="endYear">Form input year end</param>
        /// <returns></returns>
        public IActionResult Result(int begYear, int endYear)
        {
            List<PersonOfTheYear> myList = PersonOfTheYear.GetPersons(begYear, endYear);
            return View(myList);
        }
    }
}
