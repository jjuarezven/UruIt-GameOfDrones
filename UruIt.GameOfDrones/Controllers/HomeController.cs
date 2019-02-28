using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UruIt.GameOfDrones.Services_Interfaces;

namespace UruIt.GameOfDrones.Controllers
{
	public class HomeController : Controller
	{
		private readonly IStatisticService StatisticService;

		public HomeController(IStatisticService statisticService)
		{
			StatisticService = statisticService;
		}
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

		[AllowAnonymous]
		public JsonResult GetStatistic()
		{
			try
			{
				var statistics = StatisticService.GetAll();
				return Json(new { data = statistics }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace.ToString());
				return Json(new { Message = "No Data" }, JsonRequestBehavior.AllowGet);
			}
		}
	}
}