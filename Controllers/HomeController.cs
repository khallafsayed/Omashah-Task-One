using Microsoft.AspNetCore.Mvc;
using Omashah_Task_One.Models;
using System.Diagnostics;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Omashah_Task_One.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<Item> Items = new() {
                   new Item { Id = 1,Name = "Ahmed",   Link = "www.google.com", Published_Date_From = DateTime.Parse("13-3-2023"), Published_Date_To = DateTime.Parse("13-4-2023") },
                   new Item { Id = 2,Name = "Mohamed", Link = "www.google.com", Published_Date_From = DateTime.Parse("13-3-2023"), Published_Date_To = DateTime.Parse("13-4-2023") },
                   new Item { Id = 3, Name = "khallad", Link = "www.google.com", Published_Date_From = DateTime.Parse("13-3-2023"), Published_Date_To = DateTime.Parse("13-4-2023") },
                   new Item { Id = 4, Name = "Tamer", Link = "www.google.com", Published_Date_From = DateTime.Parse("13-3-2023"), Published_Date_To = DateTime.Parse("13-4-2023") },
                   new Item { Id = 5, Name = "Waleed", Link = "www.google.com", Published_Date_From = DateTime.Parse("13-3-2023"), Published_Date_To = DateTime.Parse("13-4-2023") },

                   new Item { Id = 6, Name = "sayed", Link = "www.google.com", Published_Date_From = DateTime.Parse("23-7-2023"), Published_Date_To = DateTime.Parse("1-9-2023") },
                   new Item { Id = 7, Name = "salem", Link = "www.google.com", Published_Date_From = DateTime.Parse("25-6-2023"), Published_Date_To = DateTime.Parse("1-8-2023") },
                   new Item { Id = 8, Name = "ayaa", Link = "www.google.com", Published_Date_From = DateTime.Parse("27-5-2023"), Published_Date_To = DateTime.Parse("5-4-2023") },
                   new Item { Id = 9, Name = "walaa", Link = "www.google.com", Published_Date_From = DateTime.Parse("1-4-2023"), Published_Date_To = DateTime.Parse("8-5-2023") },
                   new Item { Id = 10, Name = "may", Link = "www.google.com", Published_Date_From = DateTime.Parse("4-5-2023"), Published_Date_To = DateTime.Parse("6-6-2023") }
                   }; 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         

        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item) { 
            var id = Items.Count + 1;
            item.Id = id;
            if (Regex.IsMatch(item.Link, @"\bhttps://\b"))
            {
                item.Link = item.Link.Replace("https://", "");
            }
                

            var newitemlist = Items.ToList();
            newitemlist.Add(item);
            Items = newitemlist;
            
            // if we use DataBase We Us 
            //if (ModelState.IsValid)
            //{
            //    DB.items.add(item);
            //    DB.SaveChenge();
            //}
            //return View(item);
            
          return RedirectToAction("Create");
        }
        public IActionResult Index()
        {
         

            return View();
        }

        public IActionResult Published_Items()
        {
            var bublished_item = Items.Where(i=>i.Published_Date_From <= DateTime.Now.Date && i.Published_Date_To >= DateTime.Now.Date).ToList();
            return View(bublished_item);
        }
        public IActionResult Nonn_Published_Items()
        {
            var bublished_item = Items.Where(i => i.Published_Date_From > DateTime.Now.Date ).ToList();
            return View(bublished_item);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}