using MVCImageUpload_1.DesignPatterns.SingletonPattern;
using MVCImageUpload_1.Models.Context;
using MVCImageUpload_1.Models.Entities;
using MVCImageUpload_1.Tools;
using MVCImageUpload_1.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCImageUpload_1.Controllers
{
    public class HomeController : Controller
    {
        MyContext _db;

        public HomeController()
        {
            _db = DBTool.DBInstance;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestClass testClass, HttpPostedFileBase resim)
        {
            testClass.ImagePath = ImageUploader.UploadImage("/Images/", resim);
            _db.TestClasses.Add(testClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListTestClasses()
        {
            TestClassVM tvm = new TestClassVM
            {
                TestClasses = _db.TestClasses.ToList()
            };

            return View(tvm);
        }
    }
}