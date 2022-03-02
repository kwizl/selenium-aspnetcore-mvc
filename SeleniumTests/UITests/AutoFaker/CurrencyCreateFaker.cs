using AutoBogus;
using Selenium.DTOs;
using Selenium.Models;
using System;
using System.Collections.Generic;

namespace Selenium.UITests.Selenium.SeleniumTests.AutoFaker
{
    public class CurrencyCreateFaker
    {
		public CurrencyCreateRequest Generate(Dictionary<Type, object> memo, CurrencyCreateRequest entity = null)
		{
			if (entity == null && memo.ContainsKey(typeof(CurrencyCreateRequest)))
				return (CurrencyCreateRequest)memo[typeof(CurrencyCreateRequest)];

			var faker = new AutoFaker<CurrencyCreateRequest>();
			faker.RuleFor(x => x.ISOCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Name, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.NumericISOCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Symbol, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.SystemCode, x => x.Lorem.Letter(10));
			faker.RuleFor(x => x.Units, x => x.Lorem.Letter(10));

			var fake = faker.Generate();

			if (!memo.ContainsKey(typeof(CurrencyCreateRequest)))
				memo.Add(typeof(CurrencyCreateRequest), fake);

			return fake;
		}
	}
}
