using ImageWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ImageWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult view()
        {
            var list = imageList();
            return View(list);
        }

        public List<ContentViewModel> imageList()
        {
            List<ContentViewModel> List = new List<ContentViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var dv = db.imageContent.ToList();
                foreach (var item in dv)
                {
                    List.Add(new ContentViewModel() { Title = item.Title, ImagePath = item.ImagePath });
                }
            }

            return List;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}