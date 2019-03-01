using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UruIt.GameOfDrones.Models;
using UruIt.GameOfDrones.Persistence.Repository_Interfaces;
using UruIt.GameOfDrones.Services_Interfaces;


namespace UruIt.GameOfDrones.Services_Implementations
{
	public class StatisticBusiness : IStatisticService
	{
		private readonly IUnitOfWork uow;

		public StatisticBusiness(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public EntityState Modified { get; private set; }

		public IEnumerable<Statistic> GetAll()
		{
			return uow.StatisticRepository.GetAll();
		}

		public Statistic GetById(int id)
		{
			return uow.StatisticRepository.GetById(id);
		}

		public IEnumerable<Statistic> GetWhere(Expression<Func<Statistic, bool>> predicate)
		{
			return uow.StatisticRepository.Find(predicate);
		}

		public bool Save(Statistic stat)
		{
			var statistic = GetWhere(p => p.PlayerName == stat.PlayerName).FirstOrDefault();
			if (statistic == null)
			{
				statistic = new Statistic { PlayerName = stat.PlayerName, WonGames = 1 };
				uow.StatisticRepository.Add(statistic);
			}
			else
			{
				statistic.WonGames++;
				uow.StatisticRepository.AddOrUpdate(statistic);
			}
			return uow.Commit();
		}

		public bool Save(IEnumerable<Statistic> statistic)
		{
			foreach (var product in statistic)
			{
				uow.StatisticRepository.Add(product);
			}
			return uow.Commit();
		}
	}
}