using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class InsuranceController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Insurance Manager";

            return View();
        }
    }
}
