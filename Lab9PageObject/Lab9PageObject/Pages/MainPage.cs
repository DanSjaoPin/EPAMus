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

    }
}
