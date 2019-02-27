using Newtonsoft.Json.Linq;
using Sito.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sito.Controllers
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
        public ActionResult GetAvgStats()
        {
            string hi = Helper.GetResponseFromUrl("https://api-v3.igdb.com/games/?fields=name,rating&filter[rating][gte]=1&order=rating:desc&limit=10");
            List<GameDetails> gd1 = Custom.Helper.GetGameDetailsFromJSON(hi);

            string low = Helper.GetResponseFromUrl("https://api-v3.igdb.com/games/?fields=name,rating&order=rating:asc&limit=10");
            List<GameDetails> gd2 = Custom.Helper.GetGameDetailsFromJSON(low);
            
            double avg = 0;
            gd1.ForEach(i => avg += i.rating);
            gd2.ForEach(i => avg += i.rating);

            avg = avg / (gd1.Count + gd2.Count);

            return Json(new { lista = avg }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetHighStats()
        {
            string responseString = Helper.GetResponseFromUrl("https://api-v3.igdb.com/games/?fields=name,rating&filter[rating][gte]=1&order=rating:desc&limit=10");
            return Json(new { lista = responseString }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLowStats()
        {
            string responseString = Helper.GetResponseFromUrl("https://api-v3.igdb.com/games/?fields=name,rating&order=rating:asc&limit=10");
            return Json(new { lista = responseString }, JsonRequestBehavior.AllowGet);
        }
    }
}