using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Selenium.Models
{
    public class Currency
    {
        [Key]
		[Description("Primary Key")]
		public int CurrencyID { get; set; }

		[Required]
		[StringLength(3)]
		[Description("ISO Code")]
		public string ISOCode { get; set; }

		[Required]
		[StringLength(250)]
		[Description("Name")]
		public string Name { get; set; }

		[Required]
		[StringLength(3)]
		[Description("Numeric ISO Code")]
		public string NumericISOCode { get; set; }

		[Required]
		[StringLength(100)]
		[Description("Symbol")]
        public string Symbol { get; set; }

		[StringLength(100)]
		[Description("System Code")]
		public string SystemCode { get; set; }

		[Required]
		[Description("Units")]
		[StringLength(100)]
		public string Units { get; set; }
    }
}