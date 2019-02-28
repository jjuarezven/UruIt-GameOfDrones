using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UruIt.GameOfDrones.Persistence.Repository_Interfaces;

namespace UruIt.GameOfDrones.Persistence.Repository_Implementations
{
	public class EfGenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DbSet<T> dbSet;

		public EfGenericRepository(DbSet<T> dbSet)
		{
			this.dbSet = dbSet;
		}

		public IQueryable<T> AsQueryable()
		{
			return dbSet.AsQueryable();
		}

		public IEnumerable<T> GetAll()
		{
			return dbSet;
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return dbSet.Where(predicate);
		}

		public T Single(Expression<Func<T, bool>> predicate)
		{
			return dbSet.Single(predicate);
		}

		public T SingleOrDefault(Expression<Func<T, bool>> predicate)
		{
			return dbSet.SingleOrDefault(predicate);
		}

		public T First(Expression<Func<T, bool>> predicate)
		{
			return dbSet.First(predicate);
		}

		public T GetById(int id)
		{
			return dbSet.Find(id);
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Attach(T entity)
		{
			dbSet.Attach(entity);
		}
	}
}
