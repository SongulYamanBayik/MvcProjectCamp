﻿using BusinessLayer.Concrete;
using DAL.EntityFramework;
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

        // GET: Writer
        public ActionResult Index()
        {
           var value= writerManager.TList();
            return View(value);
        }
    }
}