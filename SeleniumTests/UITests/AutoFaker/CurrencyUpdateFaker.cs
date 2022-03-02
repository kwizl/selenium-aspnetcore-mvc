using AutoBogus;
using Selenium.DTOs;
using Selenium.Models;
using System;
using System.Collections.Generic;

namespace Selenium.UITests.Selenium.SeleniumTests.AutoFaker
{
    public class CurrencyUpdateFaker
    {
        public CurrencyUpdateRequest Generate(Dictionary<Type, object> memo, CurrencyUpdateRequest entity = null)
        {
            if (entity == null && memo.ContainsKey(typeof(CurrencyUpdateRequest)))
                return (CurrencyUpdateRequest)memo[typeof(CurrencyUpdateRequest)];

            var faker = new AutoFaker<CurrencyUpdateRequest>();
            faker.RuleFor(x => x.ISOCode, x => x.Lorem.Letter(10));
            faker.RuleFor(x => x.Name, x => x.Lorem.Letter(10));
            faker.RuleFor(x => x.NumericISOCode, x => x.Lorem.Letter(10));
            faker.RuleFor(x => x.Symbol, x => x.Lorem.Letter(10));
            faker.RuleFor(x => x.SystemCode, x => x.Lorem.Letter(10));
            faker.RuleFor(x => x.Units, x => x.Lorem.Letter(10));

            var fake = faker.Generate();

            if (!memo.ContainsKey(typeof(CurrencyUpdateRequest)))
                memo.Add(typeof(CurrencyUpdateRequest), fake);

            return fake;
        }
    }
}
