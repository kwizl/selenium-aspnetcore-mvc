using AutoBogus;
using Selenium.Models;
using System;
using System.Collections.Generic;

namespace Selenium.UITests.Selenium.SeleniumTests.AutoFaker
{
    public class AddressFaker
    {
		public Address Generate(Dictionary<Type, object> memo, Address entity = null)
		{
			if (entity == null && memo.ContainsKey(typeof(Address)))
				return (Address)memo[typeof(Address)];

			var faker = new AutoFaker<Address>();
			faker.RuleFor(x => x.City, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.MobilePhone, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.OfficePhone, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.OfficeEmail, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.OtherEmail, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.PostalAddress, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.PhysicalAddress, x => x.Lorem.Letter(10));

			var fake = faker.Generate();

			if (!memo.ContainsKey(typeof(Address)))
				memo.Add(typeof(Address), fake);

			return fake;
		}
	}
}
