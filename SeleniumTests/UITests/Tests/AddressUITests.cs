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

        [Fact]
        public void AddressUpdateUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusDataOne = new AddressFaker().Generate(memo);

            _driver.Navigate().GoToUrl("http://localhost:5001/");
            
            // Create Address
            _driver.FindElement(By.Id("Create-Address")).Click();

            _driver.FindElement(By.Id("Create-Address-City")).SendKeys(autobogusDataOne.City);
            _driver.FindElement(By.Id("Create-Address-MobilePhone")).SendKeys(autobogusDataOne.MobilePhone);
            _driver.FindElement(By.Id("Create-Address-OfficePhone")).SendKeys(autobogusDataOne.OfficePhone);
            _driver.FindElement(By.Id("Create-Address-OfficeEmail")).SendKeys(autobogusDataOne.OfficeEmail);
            _driver.FindElement(By.Id("Create-Address-OtherEmail")).SendKeys(autobogusDataOne.OtherEmail);
            _driver.FindElement(By.Id("Create-Address-PhysicalAddress")).SendKeys(autobogusDataOne.PhysicalAddress);
            _driver.FindElement(By.Id("Create-Address-PostalAddress")).SendKeys(autobogusDataOne.PostalAddress);

            _driver.FindElement(By.Id("Create-Address-Button")).Click();

            // Update Address
            memo.Clear();
            var autobogusDataTwo = new AddressFaker().Generate(memo);
            _driver.FindElement(By.Id($"Update-Addres-{autobogusDataTwo.AddressID}")).Click();

            _driver.FindElement(By.Id("Update-Address-City")).SendKeys(autobogusDataTwo.City);
            _driver.FindElement(By.Id("Update-Address-MobilePhone")).SendKeys(autobogusDataTwo.MobilePhone);
            _driver.FindElement(By.Id("Update-Address-OfficePhone")).SendKeys(autobogusDataTwo.OfficePhone);
            _driver.FindElement(By.Id("Update-Address-OfficeEmail")).SendKeys(autobogusDataTwo.OfficeEmail);
            _driver.FindElement(By.Id("Update-Address-OtherEmail")).SendKeys(autobogusDataTwo.OtherEmail);
            _driver.FindElement(By.Id("Update-Address-PhysicalAddress")).SendKeys(autobogusDataTwo.PhysicalAddress);
            _driver.FindElement(By.Id("Update-Address-PostalAddress")).SendKeys(autobogusDataTwo.PostalAddress);

            _driver.FindElement(By.Id("Update-Address-Button")).Click();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
