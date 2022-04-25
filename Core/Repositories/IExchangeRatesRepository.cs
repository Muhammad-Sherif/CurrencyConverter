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
		public IEnumerable<int> GetHighestNCurrenciesIds(DateTime fromDate , DateTime toDateint , int n);
		public IEnumerable<int> GetLowesttNCurrenciesIds(DateTime fromDate, DateTime toDate , int n);
		public IEnumerable<int> GetLeastImprovedtNCurrenciesIds(DateTime fromDate, DateTime toDate , int n);
		public IEnumerable<int> GetMostImprovedtNCurrenciesIds(DateTime fromDate, DateTime toDate , int n);
		public ExchangeRate GetLastDatedCurrencyRate(int currencyId);


	}
}
