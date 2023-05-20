using Eticaret01.Context;
using Eticaret01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret01.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
    }
}