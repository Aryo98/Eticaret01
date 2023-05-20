using Eticaret01.Context;
using Eticaret01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret01.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        public ActionResult Index()
        {
            var model = _context.Products
                                 .Where(i => i.IsApproved && i.IsHome)
                                 .Select(i => new ProductModel()
                                 {
                                     Id = i.Id,
                                     Name = i.Name,
                                     Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                                     Price = i.Price,
                                     Stock = i.Stock,
                                     Image = i.Image,
                                     CategoryId = i.CategoryId
                                 }).ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _context.Products.Where(i => i.Id == id).FirstOrDefault();
            return View(model);
        }

        public ActionResult List(int? id) 
        {
            var model = _context.Products
                                 .Where(i => i.IsApproved)
                                 .Select(i => new ProductModel()
                                 {
                                     Id = i.Id,
                                     Name = i.Name,
                                     Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                                     Price = i.Price,
                                     Stock = i.Stock,
                                     Image = i.Image == null ? "1.jpg" : i.Image,
                                     CategoryId = i.CategoryId
                                 }).AsQueryable();
            if (id != null)
            {
               
                model = model.Where(i => i.CategoryId == id);
            }

            return View(model.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }

}