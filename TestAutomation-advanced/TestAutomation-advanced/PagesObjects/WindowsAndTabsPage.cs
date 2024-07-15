using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_advanced.PagesObjects
{
    internal class WindowsAndTabsPage
    {
        private IWebDriver driver;
        public WindowsAndTabsPage(IWebDriver driver)
        {
            this.driver = driver;   
        }
        public void NavigateTo()
        {
            driver.Navigate().GoToUrl(" https://demoqa.com/browser-windows");
        }

        public void SwitchBetweenWindowsAndTabs()
        {
            // HideAds();
            var windowButton = driver.FindElement(By.Id("windowButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", windowButton);
            string originalWindow=driver.CurrentWindowHandle;
            WaitForNewWindow((WebDriver)driver, 2);

            foreach(string windowHandle in driver.WindowHandles)
            {
                if(windowHandle != originalWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
            var newTabHaeding = driver.FindElement(By.Id("sampleHeading"));
            Assert.AreEqual("This is a sample page",newTabHaeding.Text);

            driver.Close();
            driver.SwitchTo().Window(originalWindow);

        }
        public void WaitForNewWindow(WebDriver driver,int expectedWindowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count == expectedWindowCount);
        }
    }
}
