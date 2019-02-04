
using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumUiTests
{
    [TestClass]
    public class EmployeesUiTests
    {
        private string _websiteURL = "https://ignite-webapp-test-997.azurewebsites.net/";
        private RemoteWebDriver _browserDriver;
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void PU_SearchTests_Initialize()
        {
           _websiteURL = (string) TestContext.Properties["webAppUrl"];
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [DataRow("Adam John", "Marketing", "adam.john@email.com", "2423282992", "74 Avenue Tunis")]
        [DataRow("Myriam Doe", "Sales", "myriam.doe@email.com", "2487678679", "89 Avenue Beja")]
        [DataRow("Sam Yasser", "Engineering", "sam.yasser@email.com", "9627656254", "9 Rue Tabarka")]
        public void CreateEmployee(string fullname, string department, string email, string phone, string address)
        {
            // Arrange
            _browserDriver = new ChromeDriver();
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            _browserDriver.Navigate().GoToUrl(_websiteURL + "Employees/Create");
            _browserDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

            _browserDriver.FindElementById("Fullname").Clear();
            _browserDriver.FindElementById("Fullname").SendKeys(fullname);

            _browserDriver.FindElementById("Department").Clear();
            _browserDriver.FindElementById("Department").SendKeys(department);

            _browserDriver.FindElementById("Email").Clear();
            _browserDriver.FindElementById("Email").SendKeys(email);

            _browserDriver.FindElementById("Phone").Clear();
            _browserDriver.FindElementById("Phone").SendKeys(phone);

            _browserDriver.FindElementById("Address").Clear();
            _browserDriver.FindElementById("Address").SendKeys(address);

            var screenshot = _browserDriver.GetScreenshot();
            var fileName = $"{fullname}.jpg";
            screenshot.SaveAsFile(fileName, ImageFormat.Jpeg);
            TestContext.AddResultFile(fileName);
            
            // Act
            _browserDriver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

            // Assert
            Assert.IsTrue(_browserDriver.PageSource.Contains(fullname));
            Assert.IsTrue(_browserDriver.PageSource.Contains(department));
            Assert.IsTrue(_browserDriver.PageSource.Contains(email));
            Assert.IsTrue(_browserDriver.PageSource.Contains(phone));
            Assert.IsTrue(_browserDriver.PageSource.Contains(address));
        }

        [TestCleanup()]
        public void PU_SearchTests_Cleanup()
        {
            _browserDriver.Quit();
        }

    }
}
