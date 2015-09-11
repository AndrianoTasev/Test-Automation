using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebSiteTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void SuccessfulLogin_Test()
        {
            Login();

            driver.Quit();
        }

        private void Login()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://vbox7.com/");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var entryButton = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[4]/div/a[1]"));
            entryButton.Click();

            var username =
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div[1]/form/ul/li[1]/div/input"));
            username.SendKeys("testprofile");

            var userPassword =
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div[1]/form/ul/li[2]/div/input"));
            userPassword.SendKeys("testprofile99");

            var submitButton =
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div[1]/form/ul/li[4]/input[3]"));
            submitButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var avatar = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[4]/div[1]/div/div/a[2]"));
            avatar.Click();

            var profile =
                driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[4]/div[1]/div/div/div/ul/li[1]/a"));
            profile.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var correctName = driver.FindElement(By.XPath("/html/body/div[2]/div/header/div[2]/h1"));

            Assert.AreEqual("testprofile", correctName.Text);

            var homePage = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a/img"));
            homePage.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            Assert.AreEqual("http://vbox7.com/", driver.Url);
        }

        [TestMethod]
        public void WriteAComment_Test()
        {
            Login();

            var top40Menu = driver.FindElement(By.XPath("/html/body/div[2]/header/div[3]/nav/ul/li[1]/a"));
            top40Menu.Click();

            var top40Number1Video =
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div[3]/div[2]/div[1]/h2/a"));
            top40Number1Video.Click();

            var commentField =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/div[2]/div[1]/div[4]/div[1]/div[1]/div[2]/div/div[2]/textarea"));
            commentField.SendKeys("TestTest");

            var submitCommentButton =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/div[2]/div[1]/div[4]/div[1]/div[1]/div[2]/div/div[3]/div/input"));
            submitCommentButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var checkComment =
                driver.FindElement(
                    By.XPath(
                        "/html/body/div[2]/div[2]/div[1]/div[4]/div[1]/div[1]/div[2]/div/div[2]/div[1]/div/div/div[2]/div[2]/p"));

            //Assert.AreEqual("TestTest", checkComment.Text);

           if ("TestTest" == checkComment.Text)
           {
               driver.Quit();
           }
        }

        [TestMethod]
        public void AddVideoToFavorites_Test()
        {
            Login();

            var popularVideos = driver.FindElement(By.XPath("/html/body/div[2]/header/div[3]/nav/ul/li[7]/a"));
            popularVideos.Click();

            var playVideo =
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/section/div[2]/div[1]/div[1]/div[2]/div/a"));
            playVideo.Click();

            var saveMenu =
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[3]/div[2]/div[2]/a/i"));
            saveMenu.Click();

            var addToFavorites =
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[3]/div[2]/div[2]/div/ul/li[1]/a"));

            var isVideoInFavorites =
                driver.FindElement(
                    By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[3]/div[2]/div[2]/div/ul/li[1]/a/span"));

            if (isVideoInFavorites.Text == "любими")
            {
                addToFavorites.Click();
            }

            else if (isVideoInFavorites.Text == "махни от любими")
            {
                throw new ArgumentException("The video is in the favorites already!");
                
            }

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
           
            var goToProfile =
                driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[4]/div[1]/div/div/a[1]"));
            goToProfile.Click();
           
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            driver.Quit();
        }
    }
}
