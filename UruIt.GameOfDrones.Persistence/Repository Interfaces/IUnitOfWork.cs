using UruIt.GameOfDrones.Models;

namespace UruIt.GameOfDrones.Persistence.Repository_Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<Statistic> StatisticRepository { get; }
		void ExecuteSql(string sqlQuery, object parameter1, object parameter2);
		bool Commit();
		GameOfDronesContext Context { get; }
	}
}
