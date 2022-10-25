using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            var value = categoryManager.GetAllBL();
            return View(value);
        }
    }
}