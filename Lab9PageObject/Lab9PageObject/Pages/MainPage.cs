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
    class MainPage : Page
    {
        private By logInButt = By.CssSelector(".x1jm");
        private By emailInputLocator = By.CssSelector("#email");
        private By passwordInputLocator = By.CssSelector("#password");
        private By submitButtLocator = By.CssSelector("button.fuOS:nth-child(3)");

        private By notificationsSubmitLocator = By.CssSelector(".PyYK");
        private By kycCloseLocator = By.CssSelector(".TwoFactorAlert__close ");
        private By cookiesSubmitLocator = By.CssSelector(".fuOS ");

        private By demoMarketList = By.CssSelector("div.MarketTabs__tab:nth-child(4)");
        private By demoBirjaButt = By.CssSelector(".MarketRow__pair");
        private By inputSummBar = By.CssSelector("#BaseInputId-4");

        private By dropСurrencyList = By.CssSelector(".Igjk");
        private By demoMarketButt = By.CssSelector("div._28v6:nth-child(5)");
        private By demoBirjaButtProf = By.CssSelector(".mB2N");

        private By[] percentVal = {By.CssSelector("button.PercentButtons__button:nth-child(1)"),
            By.CssSelector("button.PercentButtons__button:nth-child(2)"),
            By.CssSelector("button.PercentButtons__button:nth-child(3)"),
            By.CssSelector("button.PercentButtons__button:nth-child(4)") };

        private By sumValBar = By.CssSelector("div.StepInput:nth-child(4) > div:nth-child(1) > input:nth-child(2)");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void LogIn()
        {
            IWebElement logInBtn = FindElement(logInButt);
            logInBtn.Click();
        }

        public void InputEmail(string testEmail)
        {
            IWebElement inputEmail = FindElementWithWaitElementToBeClickable(emailInputLocator, 10);
            inputEmail.SendKeys(testEmail);
        }

        public void InputPassword(string testPassword)
        {
            IWebElement inputPassword = FindElement(passwordInputLocator);
            inputPassword.SendKeys(testPassword);
        }

        public void SubmitAuthorization()
        {
            IWebElement submitBtn = FindElement(submitButtLocator);
            submitBtn.Click();
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


        public void OpenCurrenyList()
        {
            IWebElement currensyList = FindElement(dropСurrencyList);
            currensyList.Click();
        }

        public void ChooseDemoMarket()
        {
            IWebElement demoMarket = FindElement(demoMarketButt);
            demoMarket.Click();
        }

        public void ChooseDemoBirjaProf()
        {
            IWebElement demoBirjaProf = FindElement(demoBirjaButtProf);
            demoBirjaProf.Click();
        }

        public void ChoosePercent10()
        {
            IWebElement choosePerscent = FindElement(percentVal[0]);
            choosePerscent.Click();
        }

        public void ChoosePercent25()
        {
            IWebElement choosePerscent = FindElement(percentVal[1]);
            choosePerscent.Click();
        }

        public void ChoosePercent50()
        {
            IWebElement choosePerscent = FindElement(percentVal[2]);
            choosePerscent.Click();
        }

        public void ChoosePercentMAX()
        {
            IWebElement choosePerscent = FindElement(percentVal[3]);
            choosePerscent.Click();
        }

        public string GetInputedSummProf()
        {
            IWebElement inputSumm = FindElement(sumValBar);
            String expectedInputValue = inputSumm.GetAttribute("value");

            return expectedInputValue;
        }
    }
}
