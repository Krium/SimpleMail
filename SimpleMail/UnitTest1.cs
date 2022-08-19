using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SimpleMail
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        private readonly string email = "testtestovych01082022@gmail.com";
        private readonly string password = "Soncesvityt1822";
        private readonly string letterText = "hello";
        private readonly string testUserEmail = "k.yurii02@gmail.com";

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.gmail.com/");
        }

        [TestMethod]
        public void TestMethod1()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));


            driver.FindElement(By.CssSelector("input[type='email']")).SendKeys(email);
            driver.FindElement(By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 qIypjc TrZEUc lw1w4b']")).Click();

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='password']"))).SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            driver.FindElement(By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 qIypjc TrZEUc lw1w4b']")).Click();
            driver.FindElement(By.XPath("//div[@class='T-I T-I-KE L3']")).Click();

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@name='to']"))).SendKeys(testUserEmail);
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='Am Al editable LW-avf tS-tW']"))).SendKeys(letterText);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.Id(":78"))).Click();
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@role='link' and @class='ag a8k']"))).Click();

        }

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
