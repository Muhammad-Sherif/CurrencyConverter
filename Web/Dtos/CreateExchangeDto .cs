using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Dtos
{
	public class CreateExchangeRateDto 
	{
		public int CurrencyId { get; set; }
		public double Rate { get; set; }

	}
}
