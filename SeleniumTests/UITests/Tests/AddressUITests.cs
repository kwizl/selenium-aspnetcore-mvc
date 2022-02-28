using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.Controllers;
using Selenium.UITests.Selenium.SeleniumTests.AutoFaker;
using System;
using System.Collections.Generic;
using Xunit;

namespace Selenium.Test.SeleniumTests
{
    public class AddressUITests
    {
        private readonly IWebDriver _driver;

        private Dictionary<Type, object> memo = new();

        public AddressUITests()
        {
            _driver = new FirefoxDriver($@"C:\Program Files\Mozilla Firefox");
        }

        [Fact]
        public void AddressCreateUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusData = new AddressFaker().Generate(memo);
           
            _driver.Navigate().GoToUrl("http://localhost:5001/");

            _driver.FindElement(By.Id("Create-Address")).Click();

            _driver.FindElement(By.Id("Create-Address-City")).SendKeys(autobogusData.City);
            _driver.FindElement(By.Id("Create-Address-MobilePhone")).SendKeys(autobogusData.MobilePhone);
            _driver.FindElement(By.Id("Create-Address-OfficePhone")).SendKeys(autobogusData.OfficePhone);
            _driver.FindElement(By.Id("Create-Address-OfficeEmail")).SendKeys(autobogusData.OfficeEmail);
            _driver.FindElement(By.Id("Create-Address-OtherEmail")).SendKeys(autobogusData.OtherEmail);
            _driver.FindElement(By.Id("Create-Address-PhysicalAddress")).SendKeys(autobogusData.PhysicalAddress);
            _driver.FindElement(By.Id("Create-Address-PostalAddress")).SendKeys(autobogusData.PostalAddress);

            _driver.FindElement(By.Id("Create-Address-Button")).Click();

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
