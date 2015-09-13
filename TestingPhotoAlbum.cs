using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PhotoAlbumTests
{
    [TestClass]
    public class TestingPhotoAlbum
    {
        private  IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void SuccessfulLogin_Test()
        {
            Login();

            driver.Quit();
        }

        private void Login()
        {
            driver.Navigate().GoToUrl("http://192.168.111.102/Album55e1af19bd4ff/home/index");

            var loginButton = driver.FindElement(By.XPath("/html/body/div/div[2]/nav/div/div/ul[2]/li/a"));
            loginButton.Click();

            var username = driver.FindElement(By.XPath("/html/body/div/div[3]/div/form/fieldset/div[1]/div/input"));
            username.SendKeys("AndrianoTasev");

            var userPassword = driver.FindElement(By.XPath("/html/body/div/div[3]/div/form/fieldset/div[2]/div/input"));
            userPassword.SendKeys("AndrianoTasev");

            var submitButton = driver.FindElement(By.XPath("/html/body/div/div[3]/div/form/fieldset/div[3]/div/input"));
            submitButton.Click();

            var greetingsField = driver.FindElement(By.XPath("/html/body/div/div[1]/h4"));

            Assert.AreEqual("Welcome, AndrianoTasev", greetingsField.Text);
        }

        [TestMethod]
        public void CommentingAnAlbum_Test()
        {
            Login();

            var commentButton = driver.FindElement(By.XPath("/html/body/div/div[3]/div[1]/div[3]/span[2]/a"));
            commentButton.Click();

            var commentTextField = driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[2]/td[2]/input"));
            commentTextField.SendKeys("Bravo Vanka");

            var actionButton = driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[3]/td[2]/input"));
            actionButton.Click();

            var comment = driver.FindElement(By.XPath("/html/body/div/div[4]/ul/li[1]"));
            Assert.AreEqual(comment.Text, comment.Text);

            driver.Quit();

        }

        [TestMethod]
        public void CommentingPicture_Test()
        {
            Login();

            var albumName = driver.FindElement(By.XPath("/html/body/div/div[3]/div[1]/div[1]/h3/a"));
            albumName.Click();

            var picture = driver.FindElement(By.XPath("/html/body/div/div[3]/div[3]/a/img"));
            picture.Click();

            var commentPicture = driver.FindElement(By.XPath("/html/body/div/div[3]/div/span[2]/a"));
            commentPicture.Click();

            var commentTextField = driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[2]/td[2]/input"));
            commentTextField.SendKeys("Wow cool");

            var createCommentButton = driver.FindElement(By.XPath("/html/body/div/form/table/tbody/tr[3]/td[2]/input"));
            createCommentButton.Click();

            var comment = driver.FindElement(By.XPath("/html/body/div/div[3]/ul/li[2]"));

            Assert.AreEqual(comment.Text, comment.Text);

            driver.Quit();
        }
    }
}
