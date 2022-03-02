using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Selenium.DTOs
{
    public class CurrencyUpdateRequest
    {
		public string ISOCode { get; set; }

		public string Name { get; set; }

		public string NumericISOCode { get; set; }

		public string Symbol { get; set; }

		public string SystemCode { get; set; }

		public string Units { get; set; }
	}
}
