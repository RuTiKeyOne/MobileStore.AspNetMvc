using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MobileStore.Context;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
       private DbContextPhone ContextPhone { get; set; }
        public HomeController(DbContextPhone dbContextPhone)
        {
            ContextPhone = dbContextPhone;
        }

        public IActionResult Index()
        {
            return View(ContextPhone.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            ContextPhone.Orders.Add(order);
            ContextPhone.SaveChanges();
            return $"Спасибо, {order.User}, за покупку!";
        }
    }
}
