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
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        // GET: Title
        public ActionResult Index()
        {
            var value = titleManager.TList(x => x.Status == true);
            return View(value);
        }

        [HttpGet]
        public ActionResult AddTitle()
        {
            List<SelectListItem> selectListCategory = (from x in categoryManager.TList(x=>x.Status==true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            List<SelectListItem> selectListWriter = (from y in writerManager.TList(x => x.Status == true)
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
            title.Status = true;
            titleManager.TInsert(title);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTitle(int id)
        {
            var value = titleManager.GetByID(id);
            value.Status = false;
            titleManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTitle(int id)
        {
            List<SelectListItem> selectListCategory = (from x in categoryManager.TList(x => x.Status == true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.ID.ToString()
                                                       }).ToList();
            List<SelectListItem> selectListWriter = (from y in writerManager.TList(x => x.Status == true)
                                                     select new SelectListItem
                                                     {
                                                         Text = y.Name + " " + y.Surname,
                                                         Value = y.ID.ToString()
                                                     }).ToList();
            ViewBag.slc = selectListCategory;
            ViewBag.slw = selectListWriter;
            var value = titleManager.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditTitle(Title title)
        {
            title.Status = true;
            titleManager.TUpdate(title);
            return RedirectToAction("Index");
        }
    }
}