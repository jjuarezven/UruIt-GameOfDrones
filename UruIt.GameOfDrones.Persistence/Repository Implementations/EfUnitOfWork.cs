using System;
using System.Data.SqlClient;
using UruIt.GameOfDrones.Models;
using UruIt.GameOfDrones.Persistence.Repository_Interfaces;

namespace UruIt.GameOfDrones.Persistence.Repository_Implementations
{
	public class EfUnitOfWork : IUnitOfWork, IDisposable
	{
		private bool disposed = false;

		public GameOfDronesContext context;
		private readonly EfGenericRepository<Statistic> StatisticRepo;
		public EfUnitOfWork(GameOfDronesContext context)
		{
			this.context = context;
			StatisticRepo = new EfGenericRepository<Statistic>(context.Statistics);
		}

		public IGenericRepository<Statistic> StatisticRepository
		{
			get { return StatisticRepo; }
		}

		public bool Commit()
		{
			return context.SaveChanges() != 0;
		}

		#region IDisposable
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				context.Dispose();
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

			context.Database.ExecuteSqlCommand(sqlQuery, p1, p2);
		}
	}
}
