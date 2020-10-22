using System.Linq;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly TflApiHelper tflApiHelper = new TflApiHelper();
        private readonly PostcodeApiHelper postcodeApiHelper = new PostcodeApiHelper();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusInfo(PostcodeSelection selection)
        {
            var coordinate = postcodeApiHelper.GetPostcodeCoordinates(selection.Postcode);
            var stopPoints = tflApiHelper.GetStopPoints(coordinate);
            var stops = stopPoints
                .Take(2)
                .Select(stop => tflApiHelper.GetTopFiveBuses(stop.naptanId));
            var info = new BusInfo(stops);
            
            return View(info);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Information about this site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us!";

            return View();
        }
    }
}