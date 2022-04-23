using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class ExchangeRatesRepository : GenericRepository<ExchangeRate>, IExchangeRatesRepository
	{
		public ExchangeRatesRepository(AppDbContext context) : base(context)
		{
		}
		public IEnumerable<int> GetHighestNCurrencies(int n)
		{
			var highestN = (from eh in _context.ExchangeRatesHistory
							group eh by eh.CurrencyId into g
							orderby g.Max(g => g.Rate)
							select g.Key).Take(n).ToList();

			return highestN;
		}
		public IEnumerable<int> GetLowesttNCurrencies(int n)
		{
			var lowestN = (from eh in _context.ExchangeRatesHistory
							group eh by eh.CurrencyId into g
							orderby g.Min(g => g.Rate)
							select g.Key).Take(n).ToList();
			return lowestN;
		}
		public ExchangeRate GetLastDatedCurrencyRate(int currencyId )
		{
			return
			_context.ExchangeRatesHistory.Where
			(er => er.CurrencyId == currencyId)
			.OrderBy(er => er.ExchangeDate).FirstOrDefault();



		}


	}
}
