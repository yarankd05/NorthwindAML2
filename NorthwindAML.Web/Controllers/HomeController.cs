using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthwindAML.Application.Services;
using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ISARService _sarService;
        private readonly IRiskScoreService _riskScoreService;

        public HomeController(
            ICustomerService customerService,
            ISARService sarService,
            IRiskScoreService riskScoreService)
        {
            _customerService = customerService;
            _sarService = sarService;
            _riskScoreService = riskScoreService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            ViewData["Page"] = "Dashboard";
            var scores = _riskScoreService.GetAll().ToList();
            var sars = _sarService.GetAll().ToList();
            var customers = _customerService.GetAll().ToList();
            ViewBag.TotalCustomers = customers.Count;
            ViewBag.OpenSARs = sars.Count(s => s.Status == "Open");
            ViewBag.HighRisk = scores.Count(s => s.Score >= 50);
            ViewBag.Scores = scores.OrderByDescending(s => s.Score).Take(10).ToList();
            ViewBag.SARs = sars.Take(5).ToList();
            return View();
        }

        public IActionResult Customers()
        {
            ViewData["Title"] = "Customers";
            ViewData["Page"] = "Customers";
            var customers = _customerService.GetAll().ToList();
            return View(customers);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);
            TempData["Message"] = result;
            TempData["IsError"] = result.Contains("blocked");
            return RedirectToAction("Customers");
        }

        [HttpPost]
        public IActionResult DeleteCustomer(string id)
        {
            _customerService.DeleteCustomer(id);
            TempData["Message"] = "customer deleted";
            return RedirectToAction("Customers");
        }

        public IActionResult Watchlist()
        {
            ViewData["Title"] = "Watchlist";
            ViewData["Page"] = "Watchlist";
            return View();
        }

        public IActionResult TransactionMonitor()
        {
            ViewData["Title"] = "TX Monitor";
            ViewData["Page"] = "Monitor";
            return View();
        }

        public IActionResult RiskScores()
        {
            ViewData["Title"] = "Risk Scores";
            ViewData["Page"] = "Risk";
            var scores = _riskScoreService.GetAll().OrderByDescending(s => s.Score).ToList();
            return View(scores);
        }

        public IActionResult SAR()
        {
            ViewData["Title"] = "SAR Records";
            ViewData["Page"] = "SAR";
            var sars = _sarService.GetAll().ToList();
            return View(sars);
        }

        [HttpPost]
        public IActionResult MarkReviewed(string customerId)
        {
            _sarService.MarkAsReviewed(customerId);
            return RedirectToAction("SAR");
        }

        [HttpPost]
        public IActionResult GenerateSARs()
        {
            int count = _riskScoreService.GenerateSARs();
            TempData["Message"] = $"{count} SAR records generated";
            return RedirectToAction("SAR");
        }
    }
}