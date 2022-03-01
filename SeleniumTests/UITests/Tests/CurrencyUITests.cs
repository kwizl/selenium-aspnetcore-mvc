using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.Controllers;
using Selenium.UITests.Selenium.SeleniumTests.AutoFaker;
using System;
using System.Collections.Generic;
using Xunit;

namespace Selenium.Test.SeleniumTests
{
    public class CurrencyUITests
    {
        private readonly IWebDriver _driver;

        private Dictionary<Type, object> memo = new();

        public CurrencyUITests()
        {
            _driver = new FirefoxDriver($@"C:\Program Files\Mozilla Firefox");
        }

        [Fact]
        public void CreatingCurrencyUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusData = new CurrencyFaker().Generate(memo);
           
            _driver.Navigate().GoToUrl("http://localhost:5001/");

            _driver.FindElement(By.Id("Create-Currency")).Click();

            _driver.FindElement(By.Id("Create-Currency-ISOCode")).SendKeys(autobogusData.ISOCode);
            _driver.FindElement(By.Id("Create-Currency-Name")).SendKeys(autobogusData.Name);
            _driver.FindElement(By.Id("Create-Currency-NumericISOCode")).SendKeys(autobogusData.NumericISOCode);
            _driver.FindElement(By.Id("Create-Currency-Symbol")).SendKeys(autobogusData.Symbol);
            _driver.FindElement(By.Id("Create-Currency-SystemCode")).SendKeys(autobogusData.SystemCode);
            _driver.FindElement(By.Id("Create-Currency-Units")).SendKeys(autobogusData.Units);

            _driver.FindElement(By.Id("Create-Currency-Button")).Click();

        }

        [Fact]
        public void UpdatingCurrencyUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusDataOne = new CurrencyFaker().Generate(memo);

            _driver.Navigate().GoToUrl("http://localhost:5001/");
            
            // Create Currency
            _driver.FindElement(By.Id("Create-Currency")).Click();

            _driver.FindElement(By.Id("Create-Currency-ISOCode")).SendKeys(autobogusDataOne.ISOCode);
            _driver.FindElement(By.Id("Create-Currency-Name")).SendKeys(autobogusDataOne.Name);
            _driver.FindElement(By.Id("Create-Currency-NumericISOCode")).SendKeys(autobogusDataOne.NumericISOCode);
            _driver.FindElement(By.Id("Create-Currency-Symbol")).SendKeys(autobogusDataOne.Symbol);
            _driver.FindElement(By.Id("Create-Currency-SystemCode")).SendKeys(autobogusDataOne.SystemCode);
            _driver.FindElement(By.Id("Create-Currency-Units")).SendKeys(autobogusDataOne.Units);

            _driver.FindElement(By.Id("Create-Currency-Button")).Click();

            // Update Currency
            memo.Clear();
            var autobogusDataTwo = new CurrencyFaker().Generate(memo);
            _driver.FindElement(By.Id($"Update-Addres-{autobogusDataTwo.CurrencyID}")).Click();

            _driver.FindElement(By.Id("Update-Currency-ISOCode")).SendKeys(autobogusDataTwo.ISOCode);
            _driver.FindElement(By.Id("Update-Currency-Name")).SendKeys(autobogusDataTwo.Name);
            _driver.FindElement(By.Id("Update-Currency-NumericISOCode")).SendKeys(autobogusDataTwo.NumericISOCode);
            _driver.FindElement(By.Id("Update-Currency-Symbol")).SendKeys(autobogusDataTwo.Symbol);
            _driver.FindElement(By.Id("Update-Currency-SystemCode")).SendKeys(autobogusDataTwo.SystemCode);
            _driver.FindElement(By.Id("Update-Currency-Units")).SendKeys(autobogusDataTwo.Units);

            _driver.FindElement(By.Id("Update-Currency-Button")).Click();
        }

        [Fact]
        public void DeletingCurrencyUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusDataOne = new CurrencyFaker().Generate(memo);

            _driver.Navigate().GoToUrl("http://localhost:5001/");
            
            // Create Currency
            _driver.FindElement(By.Id("Create-Currency")).Click();

            _driver.FindElement(By.Id("Create-Currency-ISOCode")).SendKeys(autobogusDataOne.ISOCode);
            _driver.FindElement(By.Id("Create-Currency-Name")).SendKeys(autobogusDataOne.Name);
            _driver.FindElement(By.Id("Create-Currency-NumericISOCode")).SendKeys(autobogusDataOne.NumericISOCode);
            _driver.FindElement(By.Id("Create-Currency-Symbol")).SendKeys(autobogusDataOne.Symbol);
            _driver.FindElement(By.Id("Create-Currency-SystemCode")).SendKeys(autobogusDataOne.SystemCode);
            _driver.FindElement(By.Id("Create-Currency-Units")).SendKeys(autobogusDataOne.Units);

            _driver.FindElement(By.Id("Create-Currency-Button")).Click();

            // Update Currency
            memo.Clear();
            var autobogusDataTwo = new CurrencyFaker().Generate(memo);
            _driver.FindElement(By.Id($"Update-Addres-{autobogusDataTwo.CurrencyID}")).Click();

            _driver.FindElement(By.Id("Update-Currency-ISOCode")).SendKeys(autobogusDataTwo.ISOCode);
            _driver.FindElement(By.Id("Update-Currency-Name")).SendKeys(autobogusDataTwo.Name);
            _driver.FindElement(By.Id("Update-Currency-NumericISOCode")).SendKeys(autobogusDataTwo.NumericISOCode);
            _driver.FindElement(By.Id("Update-Currency-Symbol")).SendKeys(autobogusDataTwo.Symbol);
            _driver.FindElement(By.Id("Update-Currency-SystemCode")).SendKeys(autobogusDataTwo.SystemCode);
            _driver.FindElement(By.Id("Update-Currency-Units")).SendKeys(autobogusDataTwo.Units);

            _driver.FindElement(By.Id("Update-Currency-Button")).Click();
        }

        [Fact]
        public void ViewingCurrencyDetailUIShouldWorkCorrectly()
        {
            //Generates the data using Autobogus Faker
            var autobogusData = new CurrencyFaker().Generate(memo);

            _driver.Navigate().GoToUrl("http://localhost:5001/");
            
            // Create Currency
            _driver.FindElement(By.Id("Create-Currency")).Click();

            _driver.FindElement(By.Id("Create-Currency-ISOCode")).SendKeys(autobogusData.ISOCode);
            _driver.FindElement(By.Id("Create-Currency-Name")).SendKeys(autobogusData.Name);
            _driver.FindElement(By.Id("Create-Currency-NumericISOCode")).SendKeys(autobogusData.NumericISOCode);
            _driver.FindElement(By.Id("Create-Currency-Symbol")).SendKeys(autobogusData.Symbol);
            _driver.FindElement(By.Id("Create-Currency-SystemCode")).SendKeys(autobogusData.SystemCode);
            _driver.FindElement(By.Id("Create-Currency-Units")).SendKeys(autobogusData.Units);

            _driver.FindElement(By.Id("Create-Currency-Button")).Click();

            // Delete Currency
            _driver.FindElement(By.Id($"Detail-Currency-{autobogusData.CurrencyID}")).Click();

            _driver.FindElement(By.Id("Update-Currency-Button")).Click();
        }
    }
}
