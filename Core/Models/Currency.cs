﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Currency
	{
		public int Id { get; set; }
		public string Name{ get; set; }
		public string Sign { get; set; }
		public bool IsActive { get; set; }

	}
}
