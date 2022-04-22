using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		public IGenericRepository<Currency> Currencies { get; private set; }
		public IGenericRepository<ExchangeRate> ExchangeRatesHistory { get; private set; }

		public UnitOfWork(AppDbContext  context)
		{
			_context = context;
			Currencies = new GenericRepository<Currency>(_context);
			ExchangeRatesHistory = new GenericRepository<ExchangeRate>(_context);

		}
		public void Dispose()
		{
			_context.Dispose();
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

	}
}
