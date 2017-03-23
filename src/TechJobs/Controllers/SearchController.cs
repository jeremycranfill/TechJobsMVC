using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            string selected = "all";
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.selected = selected;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search";
                ViewBag.selected = searchType;
                return View("Views/Search/Index.cshtml");
            }

            else {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search";
                ViewBag.selected = searchType;
                return View("Views/Search/Index.cshtml");



            }



            
        }

    }
}
