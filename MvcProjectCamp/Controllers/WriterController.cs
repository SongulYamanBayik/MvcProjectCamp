using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DAL.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();

        // GET: Writer
        public ActionResult Index()
        {
           var value= writerManager.TList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.TInsert(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var value = writerManager.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult validationResult = validationRules.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.TUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}