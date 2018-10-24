using System.Web.Mvc;

namespace CustomerManager.MVC.Client.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }
    }
}