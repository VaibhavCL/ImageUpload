using ImageUplaodApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUplaodApplication.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContentViewModel imageModel, HttpPostedFileBase ImageFile)
        {
            if (imageModel.Title != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);

                string File = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetFileName(ImageFile.FileName));

                string extension = Path.GetExtension(ImageFile.FileName);

                fileName += DateTime.Now.ToString("yymmssfff") + extension;

                imageModel.ImagePath = "~/Upload/" + fileName;

                string targetPath = @"C:\Users\Vaibhav\source\repos\ImageUplaodApplication\ImageUplaodApplication\Upload";
                fileName = Path.Combine(targetPath, fileName);

                ImageFile.SaveAs(fileName);
                
                //string file = fileName+".jpg";
                
                //string destFile = Path.Combine(targetPath, file);
                //if (!Directory.Exists(targetPath))
                //{
                //    Directory.CreateDirectory(targetPath);
                //}
                //System.IO.File.Copy(fileName, destFile, true);
                //ImageFile.SaveAs(fileName);

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.imageContent.Add(imageModel);
                    db.SaveChanges();
                }
                //FileInfo file1 = new FileInfo(File);
                //System.IO.File.Copy(fileName, "Upload", true);
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