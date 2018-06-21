using ImageWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageWebApplication.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContentViewModel model,HttpPostedFileBase ImageFile)
        {
            if (model.Title != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName +=  extension;
                model.ImagePath = "/Upload/" + fileName;
                string targetPath = @"C:\Users\Vaibhav\source\repos\ImageWebApplication\ImageWebApplication\Upload";
                fileName = Path.Combine(targetPath, fileName);
                ImageFile.SaveAs(fileName);

                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.imageContent.Add(model);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return View();
            }
            else
            {
                return RedirectToAction("Add", "Image");
            }
        }
    }
}