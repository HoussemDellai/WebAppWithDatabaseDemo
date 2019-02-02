
using System;
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
    public class UnitTest1
    {
        private string websiteURL = @"https://ignite-webapp-prod-984.azurewebsites.net/Employees/";
        private RemoteWebDriver browserDriver;
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void PU_SearchTests_Initialize()
        {
            // nothing for now
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [DataRow("Adam John", "Marketing", "adam.john@email.com", "2423282992", "74 Avenue Tunis")]
        [DataRow("Myriam Doe", "Sales", "myriam.doe@email.com", "2487678679", "89 Avenue Beja")]
        [DataRow("Sam Yasser", "Engineering", "sam.yasser@email.com", "9627656254", "9 Rue Tabarka")]
        public void CreateEmployee(string fullname, string department, string email, string phone, string address)
        {
            browserDriver = new ChromeDriver();
            browserDriver.Manage().Window.Maximize();
            browserDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            browserDriver.Navigate().GoToUrl(websiteURL + "Create");

            browserDriver.FindElementById("Fullname").Clear();
            browserDriver.FindElementById("Fullname").SendKeys(fullname);

            browserDriver.FindElementById("Department").Clear();
            browserDriver.FindElementById("Department").SendKeys(department);

            browserDriver.FindElementById("Email").Clear();
            browserDriver.FindElementById("Email").SendKeys(email);

            browserDriver.FindElementById("Phone").Clear();
            browserDriver.FindElementById("Phone").SendKeys(phone);

            browserDriver.FindElementById("Address").Clear();
            browserDriver.FindElementById("Address").SendKeys(address);

            browserDriver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
        }

        [TestCleanup()]
        public void PU_SearchTests_Cleanup()
        {
            browserDriver.Quit();
        }

    }
}
