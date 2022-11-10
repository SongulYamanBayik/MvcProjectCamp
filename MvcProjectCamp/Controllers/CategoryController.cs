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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        // GET: Category
        public ActionResult Index()
        {
            var value = categoryManager.TList(x=>x.Status==true);
            return View(value);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                categoryManager.TInsert(category);
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

        public ActionResult DeleteCategory(int id)
        {
            var value = categoryManager.GetByID(id);
            value.Status = false;
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var value = categoryManager.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                categoryManager.TUpdate(category);
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