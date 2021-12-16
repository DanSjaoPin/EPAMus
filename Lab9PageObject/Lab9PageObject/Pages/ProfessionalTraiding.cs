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
    class ProfessionalTraiding : Page
    {
        private By dropСurrencyList = By.CssSelector(".Igjk");
        private By demoMarketButt = By.CssSelector("div._28v6:nth-child(5)");
        private By demoBirjaButtProf = By.CssSelector(".mB2N");

        private By cookiesSubmitLocator = By.CssSelector(".bRNp > button:nth-child(1)");

        private By[] percentVal = {By.CssSelector("button.PercentButtons__button:nth-child(1)"),
            By.CssSelector("button.PercentButtons__button:nth-child(2)"),
            By.CssSelector("button.PercentButtons__button:nth-child(3)"),
            By.CssSelector("button.PercentButtons__button:nth-child(4)") };

        private By sumValBar = By.CssSelector("div.StepInput:nth-child(4) > div:nth-child(1) > input:nth-child(2)");

        public ProfessionalTraiding(IWebDriver driver) : base(driver)
        {
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

        public void SubmitCookies()
        {
            IWebElement submitCookiesBtn = FindElement(cookiesSubmitLocator);
            submitCookiesBtn.Click();
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
