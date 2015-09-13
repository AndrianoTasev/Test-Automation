using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MobileTesting
{
    [TestClass]
    public class MobileTesting
    {
        IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void SearchForMercedes_Test()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.mobile.de/");

            var changeLanguageToEnglish =
                driver.FindElement(
                    By.XPath(
                        "/html/body/header/div[2]/nav/div/ul[1]/li[3]/span"));
            changeLanguageToEnglish.Click();

            var chooseEnglish = driver.FindElement(By.XPath("/html/body/header/div[2]/nav/div/ul[1]/li[3]/ul/li[2]/a"));
            chooseEnglish.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var detailedSearch = driver.FindElement(By.XPath("/html/body/div[4]/section[1]/form/div[1]/div[6]/div[1]/div/a"));
            detailedSearch.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            //var makeMenu =
            //    driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/span/div[1]/div/div[2]/div[1]/div/select"));
            //makeMenu.Click();

           // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var chooseMercedes =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/form/div[2]/div/span/div[1]/div/div[2]/div[1]/div/select/option[70]"));
            chooseMercedes.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

           //var choseModel =
           //    driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/span/div[1]/div/div[2]/div[2]/div/select"));
           //choseModel.Click();

            var modelGl63Amg =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/form/div[2]/div/span/div[1]/div/div[2]/div[2]/div/select/option[195]"));
            modelGl63Amg.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var searchButton =
                driver.FindElement(By.XPath("/html/body/div[2]/form/div[1]/div/article/section/div/div[2]/button"));
            searchButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var chosenCar =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/div[4]/div[2]/div[1]/div[23]/a/div/div[2]/div[1]/div[1]/div/span[1]"));
            chosenCar.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var currentCarProductNumber =
                driver.FindElement(
                    By.XPath("/html/body/div[4]/div[2]/div/div[1]/div[2]/section/section[1]/article[4]/div/ul[1]/li[1]"));

            Assert.AreEqual("Fahrzeug-Nummer: 65227GD068", currentCarProductNumber.Text);

            driver.Quit();

        }
    }
}
