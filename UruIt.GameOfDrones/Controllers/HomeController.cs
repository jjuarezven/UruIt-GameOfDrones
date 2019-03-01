using System.Web.Mvc;

namespace UruIt.GameOfDrones.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}