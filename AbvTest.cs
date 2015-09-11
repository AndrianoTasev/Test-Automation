using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AbvTest
{
    [TestClass]
    public class AbvTest
    {
        IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void SuccessfulLogin_Test()
        {
            Login();

            driver.Quit();
        }

        private void Login()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.abv.bg/");

            var username = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[1]"));
            username.SendKeys("jorojoro.jorojoro");

            var userPassword = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[2]"));
            userPassword.SendKeys("jorojoro.jorojoro");

            var entryButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[3]"));
            entryButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var correctUsername =
                driver.FindElement(
                    By.XPath("/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div[1]/div[1]"));

            Assert.AreEqual("jorojoro jorojoro", correctUsername.Text);
        }

        [TestMethod]
        public void MailSending_Test()
        {
            Login();

            var writeMessage =
                driver.FindElement(
                    By.XPath("/html/body/div[1]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[3]/div"));
            writeMessage.Click();

            var receiverField =
                driver.FindElement(
                    By.XPath(
                        "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[2]/div[1]/table/tbody/tr[2]/td[2]/div/input"));
            receiverField.SendKeys("jorojoro.jorojoro@abv.bg");

            var themeField =
                driver.FindElement(
                    By.XPath(
                        "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[2]/div[1]/table/tbody/tr[5]/td[2]/div/input"));
            themeField.SendKeys("Test Mail");

            var messageField = driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/iframe"));
            messageField.SendKeys("Test Mail");

            var sendButton =
                driver.FindElement(
                    By.XPath(
                        "/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div/div[1]/div[1]"));
            sendButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.AreEqual("https://nm20.abv.bg/Mail.html#msgsent:", driver.Url);

            driver.Quit();
        }
    }
}
