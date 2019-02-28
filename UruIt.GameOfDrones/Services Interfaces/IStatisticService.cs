using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UruIt.GameOfDrones.Models;

namespace UruIt.GameOfDrones.Services_Interfaces
{
	public interface IStatisticService
	{
		IEnumerable<Statistic> GetAll();
		IEnumerable<Statistic> GetWhere(Expression<Func<Statistic, bool>> predicate);
		Statistic GetById(int id);
		bool Save(IEnumerable<Statistic> Statistics);
		bool Save(Statistic Statistic);
	}
}
