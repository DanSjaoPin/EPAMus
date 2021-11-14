using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Drawing;

namespace NUnitTestProject1
{
    public class Tests
    {
        private IWebDriver _driver;
        private const string Email = "dymar02@mail.ru";
        private const string Password = "TestPassword!23";
        private const string actualInputValue = "1";

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();

            _driver.Manage().Window.Size = new Size(1920, 1080);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            _driver.Navigate().GoToUrl("https://whitebit.com/ru/auth/login");

            _driver.FindElement(By.CssSelector("#email")).SendKeys(Email);
            _driver.FindElement(By.CssSelector("#password")).SendKeys(Password);

            var singUpButt = _driver.FindElement(By.CssSelector("button.fuOS:nth-child(3)"));
            singUpButt.Click();
        }

        [Test]
        public void NegaviveInputValueMustTransformToPositive()
        {
            Thread.Sleep(20000);//Íóæíî äëÿ ââîäà êàï÷è, íó øî ïîäåëàö

            var demoCoins = _driver.FindElement(By.CssSelector("div.MarketTabs__tab:nth-child(4)"));
            demoCoins.Click();

            var birja = _driver.FindElement(By.CssSelector("#__layout > div > main > div > div.Trade > div > div:nth-child(4) > div > div.TabbedBlock__content > div > div.MarketsTable > div.VirtualScroll.MarketsTable__rows > div > div > div"));
            birja.Click();
            
            _driver.FindElement(By.CssSelector(".bRNp")).Click();
            _driver.FindElement(By.CssSelector(".fa-times")).Click();
            _driver.FindElement(By.CssSelector(".TwoFactorAlert__close")).Click();

            var inputBar = _driver.FindElement(By.CssSelector("#BaseInputId-4"));

            inputBar.Click();
            inputBar.SendKeys("-1");

            String expectedInputValue = inputBar.GetAttribute("value");

            Assert.AreEqual(expectedInputValue, actualInputValue);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
