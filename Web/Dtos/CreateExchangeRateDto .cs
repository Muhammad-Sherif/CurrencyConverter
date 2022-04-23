using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Dtos
{
	public class CreateExchangeRateDto 
	{
		[Required]
		public int CurrencyId { get; set; }
		[Required]
		public double Rate { get; set; }

	}
}
