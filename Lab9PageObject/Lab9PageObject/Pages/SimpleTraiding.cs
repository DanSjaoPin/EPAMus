using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab9PageObject.Pages
{
    class SimpleTraiding : Page
    {
        private By notificationsSubmitLocator = By.CssSelector(".PyYK");
        private By kycCloseLocator = By.CssSelector(".TwoFactorAlert__close ");
        private By cookiesSubmitLocator = By.CssSelector(".fuOS ");

        private By demoMarketList = By.CssSelector("div.MarketTabs__tab:nth-child(4)");
        private By demoBirjaButt = By.CssSelector(".MarketRow__pair");
        private By inputSummBar = By.CssSelector("#BaseInputId-4");

        public SimpleTraiding(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitNotifications()
        {
            IWebElement submitNotiesBtn = FindElement(notificationsSubmitLocator);
            submitNotiesBtn.Click();
        }

        public void SubmitKYC()
        {
            IWebElement submitKYCBtn = FindElement(kycCloseLocator);
            submitKYCBtn.Click();
        }

        public void SubmitCookies()
        {
            IWebElement submitCookiesBtn = FindElement(cookiesSubmitLocator);
            submitCookiesBtn.Click();
        }

        public void ChooseDEMO()
        {
            IWebElement demoMarket = FindElement(demoMarketList);
            demoMarket.Click();
        }

        public void ChooseDemoBirja()
        {
            IWebElement demoBirja = FindElement(demoBirjaButt);
            demoBirja.Click();
        }

        public void InputSumm(string testSumm)
        {
            IWebElement inputSumm = FindElement(inputSummBar);

            inputSumm.SendKeys(Keys.Control + "a");
            inputSumm.SendKeys(Keys.Delete);

            inputSumm.SendKeys(testSumm);
        }

        public string GetInputedSumm()
        {
            IWebElement inputSumm = FindElement(inputSummBar);
            String expectedInputValue = inputSumm.GetAttribute("value");

            return expectedInputValue;
        }
    }
}
