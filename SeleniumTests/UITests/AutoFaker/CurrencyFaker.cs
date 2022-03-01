using AutoBogus;
using Selenium.Models;
using System;
using System.Collections.Generic;

namespace Selenium.UITests.Selenium.SeleniumTests.AutoFaker
{
    public class CurrencyFaker
    {
		public Currency Generate(Dictionary<Type, object> memo, Currency entity = null)
		{
			if (entity == null && memo.ContainsKey(typeof(Currency)))
				return (Currency)memo[typeof(Currency)];

			var faker = new AutoFaker<Currency>();
			faker.RuleFor(x => x.ISOCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Name, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.NumericISOCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Symbol, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.SystemCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Units, x => x.Lorem.Letter(10));

			var fake = faker.Generate();

			if (!memo.ContainsKey(typeof(Currency)))
				memo.Add(typeof(Currency), fake);

			return fake;
		}
	}
}
