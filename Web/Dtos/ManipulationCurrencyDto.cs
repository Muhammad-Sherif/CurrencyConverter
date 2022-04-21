using System.ComponentModel.DataAnnotations;

namespace Web.Dtos
{
	public class ManipulationCurrencyDto
	{
		[Required]
		[StringLength(250)]
		public string Name { get; set; }
		[Required]
		[StringLength(250)]
		public string Sign { get; set; }

	}
}
