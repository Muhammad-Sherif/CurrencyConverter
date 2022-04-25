using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
	public class CreateExchangeRateDto 
	{
		[Required]
		public int CurrencyId { get; set; }
		[Required]
		public double Rate { get; set; }

	}
}
