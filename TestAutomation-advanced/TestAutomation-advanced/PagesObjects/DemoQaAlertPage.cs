using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_advanced.PagesObjects
{
    internal class DemoQaAlertPage
    {
        private IWebDriver driver;
        public DemoQaAlertPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }
        public void HandleAlert()
        {
            var alertButton = driver.FindElement(By.Id("timerAlertButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",alertButton);
            alertButton.Click();
            IAlert alert = WaitForAlert((WebDriver)driver, TimeSpan.FromSeconds(10));
            Assert.IsNotNull(alert);

            alert.Accept();
        }
        public IAlert WaitForAlert(WebDriver driver, TimeSpan timeOut)
        {
            try
            {
                WebDriverWait wait=new WebDriverWait(driver, timeOut);
                return wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch(WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}
