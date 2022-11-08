using BusinessLayer.Concrete;
using DAL.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class TitleController : Controller
    {
        TitleManager titleManager = new TitleManager(new EFTitleDal());
        CategoryManager caregoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        // GET: Title
        public ActionResult Index()
        {
            var value = titleManager.TList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddTitle()
        {
            List<SelectListItem> selectListCategory = (from x in caregoryManager.TList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            List<SelectListItem> selectListWriter = (from y in writerManager.TList()
                                                     select new SelectListItem
                                                     {
                                                         Text = y.Name + " " + y.Surname,
                                                         Value = y.ID.ToString()
                                                     }).ToList();
            ViewBag.slc = selectListCategory;
            ViewBag.slw = selectListWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddTitle(Title title)
        {
            title.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            titleManager.TInsert(title);
            return RedirectToAction("Index");
        }
    }
}