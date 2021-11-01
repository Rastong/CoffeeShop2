using CoffeeShop2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            List<Customer> result = null;
            using(CoffeeRegisteryContext context = new CoffeeRegisteryContext())
            {
                result = context.Customers.ToList();
            }
            
            return View(result);
        }

        public IActionResult SaveSignUp(Customer c)
        {
            using(CoffeeRegisteryContext context = new CoffeeRegisteryContext())
            {
                context.Customers.Add(c);
                context.SaveChanges();
            }

            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            List<Customer> result = null;
            using (CoffeeRegisteryContext context = new CoffeeRegisteryContext())
            {
                result = context.Customers.ToList();
            }

            return View(result);
        }

        public IActionResult Detailed(int id)
        {
            Customer c = null;
            using(CoffeeRegisteryContext context = new CoffeeRegisteryContext())
            {
                c = context.Customers.Find(id);
            }
            return View(c);
        }
    }
}
