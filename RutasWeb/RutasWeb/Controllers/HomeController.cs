using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RutasWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ruta(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Files/" + file.FileName);
            file.SaveAs(path);
            ViewBag.Path = path;

            string json = string.Empty;
            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(json);
            }

            return View();
        }

    }
}
