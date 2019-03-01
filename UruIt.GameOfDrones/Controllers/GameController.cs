using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UruIt.GameOfDrones.Models;
using UruIt.GameOfDrones.Services_Interfaces;

namespace UruIt.GameOfDrones.Controllers
{
	public class GameController : ApiController
	{
		private readonly IStatisticService StatisticService;

		public GameController()
		{

		}
		public GameController(IStatisticService statisticService)
		{
			StatisticService = statisticService;
		}

		// GET: api/Otro
		public IHttpActionResult Get()
		{
			IEnumerable<Statistic> statistics = null;
			try
			{
				statistics = StatisticService.GetAll();
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace.ToString());
			}

			if (!statistics.Any())
			{
				return NotFound();
			}

			return Ok(statistics);
		}

		// POST: api/Otro
		[HttpPost]
		public IHttpActionResult Post([FromBody]Statistic player)
		{
			try
			{
				StatisticService.Save(player);
				return Ok();
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace.ToString());
				return InternalServerError();
			}

		}
	}
}
