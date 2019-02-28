using System;
using System.Web.Http;
using UruIt.GameOfDrones.Services.Services_Interfaces;

namespace UruIt.GameOfDrones.Services.Controllers
{
	public class GameController : ApiController
	{
		public GameController()
		{

		}

		private readonly IStatisticService StatisticService;

		public GameController(IStatisticService statisticService)
		{
			StatisticService = statisticService;
		}
		
		[HttpGet]
		public IHttpActionResult Get()
		{
			try
			{
				var statistics = StatisticService.GetAll();
				return Ok(statistics);
			}
			catch (Exception)
			{
				return NotFound();
			}			
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}
	}
}
