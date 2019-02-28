using System;
using System.Collections.Generic;
using System.Data.Entity;
using UruIt.GameOfDrones.Models;

namespace UruIt.GameOfDrones.Persistence
{
	internal class GameOfDronesInitializer : DropCreateDatabaseIfModelChanges<GameOfDronesContext>
	{
		protected override void Seed(GameOfDronesContext context)
		{
			var statistics = new List<Statistic>
			{
			new Statistic{PlayerName="Carson", WonGames = 2},
			new Statistic{PlayerName="Meredith", WonGames = 4},
			new Statistic{PlayerName="Rex", WonGames = 1}
			};

			statistics.ForEach(s => context.Statistics.Add(s));
			context.SaveChanges();
			base.Seed(context);
		}
	}
}