namespace UruIt.GameOfDrones.Persistence
{
	using System.Data.Entity;
	using UruIt.GameOfDrones.Models;

	public class GameOfDronesContext : DbContext
	{
		// Your context has been configured to use a 'GameOfDronesContext' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'UruIt.GameOfDrones.Persistence.GameOfDronesContext' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'GameOfDronesContext' 
		// connection string in the application configuration file.
		public GameOfDronesContext()
			: base("name=GameOfDronesContext")
		{
			Database.SetInitializer(new GameOfDronesInitializer());
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Statistic> Statistics { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}