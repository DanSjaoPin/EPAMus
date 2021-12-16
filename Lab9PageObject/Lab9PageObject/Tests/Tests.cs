using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using Lab9PageObject.Pages;
using System.Threading;

namespace Lab9PageObject
{
    public class Tests
    {
        private IWebDriver driver;
        private const string Email = "dymar02@mail.ru";
        private const string Password = "TestPassword!23";
        //private const string actualInputValue = "1";
        //private const string testInputValue = "-1";

        private string[] actualInputValue = new string[9] {"1", "0.1", "0.001", "0.1", "0.1",  "10", "100", "100000000", "99.999" };
        private string[] testInputValue = new string[9] { "1", "0.1", "0.001", "0,1", ",1", "-10", "100", "100000000", "99.999" };

        private string[] actualInputValueBalance = new string[4] { "54.11", "135.29", "270.58", "541.16" };

        MainPage mainPage;
        SimpleTraiding simpleTraiding;
        ProfessionalTraiding professionalTraiding;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("https://whitebit.com/ru");

            mainPage = new MainPage(driver);
            mainPage.LogIn();
            mainPage.InputEmail(Email);
            mainPage.InputPassword(Password);
            mainPage.SubmitAuthorization();
            Thread.Sleep(20000); //Capcha
           
        }
    
        
        [Test]
        public void InputNegativeCost()
        {
            simpleTraiding = new SimpleTraiding(driver);

            simpleTraiding.SubmitNotifications();
            simpleTraiding.SubmitKYC();
            simpleTraiding.SubmitCookies();

            simpleTraiding.ChooseDEMO();
            simpleTraiding.ChooseDemoBirja();
            //mainPage.InputSumm(testInputValue);

            //String expectedInputValue = mainPage.GetInputedSumm();

            //Assert.AreEqual(expectedInputValue, actualInputValue);

            for(int i = 0; i < testInputValue.Length; i++)
            {
                simpleTraiding.InputSumm(testInputValue[i]);               

                String expectedInputValue = simpleTraiding.GetInputedSumm();

                Assert.AreEqual(expectedInputValue, actualInputValue[i]);
            }

        }

        [Test]
        public void InputOrdersForPercentOfBalance()
        {
            professionalTraiding = new ProfessionalTraiding(driver);

            driver.Navigate().GoToUrl("https://whitebit.com/ru/trade-pro/BTC-USDT?type=spot");

            professionalTraiding.OpenCurrenyList();
            professionalTraiding.ChooseDemoMarket();
            professionalTraiding.ChooseDemoBirjaProf();

            professionalTraiding.SubmitCookies();

            professionalTraiding.ChoosePercent10();
            String expectedInputValue = professionalTraiding.GetInputedSummProf();

            Assert.AreEqual(expectedInputValue, actualInputValueBalance[0]);

            professionalTraiding.ChoosePercent25();
            expectedInputValue = professionalTraiding.GetInputedSummProf();

            Assert.AreEqual(expectedInputValue, actualInputValueBalance[1]);


            professionalTraiding.ChoosePercent50();
            expectedInputValue = professionalTraiding.GetInputedSummProf();

            Assert.AreEqual(expectedInputValue, actualInputValueBalance[2]);

            professionalTraiding.ChoosePercentMAX();
            expectedInputValue = professionalTraiding.GetInputedSummProf();

            Assert.AreEqual(expectedInputValue, actualInputValueBalance[3]);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}