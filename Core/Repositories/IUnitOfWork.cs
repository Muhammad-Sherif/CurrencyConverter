using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		public IGenericRepository<Currency> Currencies { get; }
		public IExchangeRatesRepository ExchangeRatesHistory { get; }
		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
