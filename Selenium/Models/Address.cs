using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Selenium.Models
{
    public class Address
    {
		[Key]
		[Description("Primary Key")]
		public int AddressID { get; set; }

		[StringLength(100)]
		[Description("City")]
		public string City { get; set; }

		[StringLength(50)]
		[Description("Mobile Phone")]
		public string MobilePhone { get; set; }

		[StringLength(50)]
		[Description("Office Email")]
		public string OfficeEmail { get; set; }

		[StringLength(50)]
		[Description("Office Phone")]
		public string OfficePhone { get; set; }

		[StringLength(50)]
		[Description("Other Email")]
		public string OtherEmail { get; set; }

		[StringLength(4000)]
		[Description("Physical Address")]
		public string PhysicalAddress { get; set; }

		[StringLength(4000)]
		[Description("Postal Address")]
		public string PostalAddress { get; set; }
	}
}
