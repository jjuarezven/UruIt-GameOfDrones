using System;
using System.Data.SqlClient;
using UruIt.GameOfDrones.Models;
using UruIt.GameOfDrones.Persistence.Repository_Interfaces;

namespace UruIt.GameOfDrones.Persistence.Repository_Implementations
{
	public class EfUnitOfWork : IUnitOfWork, IDisposable
	{
		private bool disposed = false;
		private readonly EfGenericRepository<Statistic> StatisticRepo;
		public EfUnitOfWork(GameOfDronesContext context)
		{
			this.Context = context;
			StatisticRepo = new EfGenericRepository<Statistic>(context.Statistics);
		}

		public IGenericRepository<Statistic> StatisticRepository
		{
			get { return StatisticRepo; }
		}

		public GameOfDronesContext Context { get; }

		public bool Commit()
		{
			return Context.SaveChanges() != 0;
		}

		#region IDisposable
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				Context.Dispose();
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

		public void ExecuteSql(string sqlQuery, object parameter1, object parameter2)
		{
			var p1 = parameter1 as SqlParameter;
			var p2 = parameter2 as SqlParameter;

			Context.Database.ExecuteSqlCommand(sqlQuery, p1, p2);
		}
	}
}
