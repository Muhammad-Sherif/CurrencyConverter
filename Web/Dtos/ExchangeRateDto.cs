using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Dtos
{
	public class ExchangeRateDto 
	{
		public int Id { get; set; }
		public int CurrencyId { get; set; }
		public DateTime ExchangeDate { get; set; }
		public double Rate { get; set; }

	}
}
