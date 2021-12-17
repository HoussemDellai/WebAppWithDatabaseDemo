
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumUiTests
{
    [TestClass]
    public class EmployeesUiTests
    {
        private string _websiteURL = "https://localhost:7048/";
        //private string _websiteURL = "https://ignite-webapp-test-997.azurewebsites.net/";
        private WebDriver _browserDriver;
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
            _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _browserDriver.Navigate().GoToUrl(_websiteURL + "Employees/Create");
            _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            _browserDriver.FindElement(By.Id("Fullname")).Clear();
            _browserDriver.FindElement(By.Id("Fullname")).SendKeys(fullname);

            _browserDriver.FindElement(By.Id("Department")).Clear();
            _browserDriver.FindElement(By.Id("Department")).SendKeys(department);

            _browserDriver.FindElement(By.Id("Email")).Clear();
            _browserDriver.FindElement(By.Id("Email")).SendKeys(email);

            _browserDriver.FindElement(By.Id("Phone")).Clear();
            _browserDriver.FindElement(By.Id("Phone")).SendKeys(phone);

            _browserDriver.FindElement(By.Id("Address")).Clear();
            _browserDriver.FindElement(By.Id("Address")).SendKeys(address);

            var screenshot = _browserDriver.GetScreenshot();
            var fileName = $"{fullname}.jpg";
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
            TestContext.AddResultFile(fileName);
            
            // Act
            _browserDriver.FindElement(By.Id("SubmitButton")).Click();
            //_browserDriver.FindElement(By.CssSelector("btn btn-primary")).Click();
            //_browserDriver.FindElement(By.CssSelector("input.btn.btn-default")).Click();

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
