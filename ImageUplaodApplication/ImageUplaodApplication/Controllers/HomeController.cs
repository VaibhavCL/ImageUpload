using ImageUplaodApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ImageUplaodApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult View()
        {
            var list = imageList();
            return View(list);
        }

        public List<ContentViewModel> imageList()
        {
            List<ContentViewModel> tm = new List<ContentViewModel>();

            var cWeather = new List<ContentViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var dv = db.imageContent.ToList();
                foreach (var item in dv)
                {
                    tm.Add(new ContentViewModel() { Title = item.Title, ImagePath = item.ImagePath });
                }
                string fullString = tm.ToArray().ToString();
                byte[] byteArray = Encoding.UTF8.GetBytes(fullString);
            }

            return tm;
        }
    }
}