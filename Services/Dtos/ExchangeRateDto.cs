
namespace Services.Dtos
{
	public class ExchangeRateDto 
	{
		public int Id { get; set; }
		public int CurrencyId { get; set; }
		public DateTime ExchangeDate { get; set; }
		public double Rate { get; set; }

	}
}
