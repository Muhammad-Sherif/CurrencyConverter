using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class ExchangeHistory
	{
		public int Id { get; set; }
		public int CurrencyId{ get; set; }
		public DateTime ExchangeDate{ get; set; }	
		public double Rate{ get; set; }

		public Currency Currency { get; set; }

	}
}
