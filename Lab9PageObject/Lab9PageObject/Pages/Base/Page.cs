using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace Lab9PageObject.Pages
{
    class Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IWebElement FindElementWithWaitElementToBeClickable(By locator, double seconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

    }
}
