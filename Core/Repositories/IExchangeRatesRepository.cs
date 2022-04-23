using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
	public interface IExchangeRatesRepository : IGenericRepository<ExchangeRate>
	{
		public IEnumerable<int> GetHighestNCurrencies(int n);
		public IEnumerable<int> GetLowesttNCurrencies(int n);
		public ExchangeRate GetLastDatedCurrencyRate(int currencyId);


	}
}
