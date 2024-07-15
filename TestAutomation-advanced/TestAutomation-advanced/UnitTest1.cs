using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation_advanced.PagesObjects;

namespace TestAutomation_advanced
{
    [TestFixture]

    public class Tests
    {
        private IWebDriver driver;
        private DemoQaAlertPage demoQaAlertPage;
        private WindowsAndTabsPage windowsAndTabsPage;

        [SetUp]
        public void Setup()
        {
            string path = "C:\\Users\\user1\\Desktop\\Automation\\TestAutomation-advanced\\TestAutomation-advanced\\driver";
            driver = new ChromeDriver(path);
            demoQaAlertPage= new DemoQaAlertPage(driver);
            windowsAndTabsPage= new WindowsAndTabsPage(driver);

        }

        [Test]
        public void TestHandleAlert()
        {
            demoQaAlertPage.NavigateTo();
            demoQaAlertPage.HandleAlert();
        }
        [Test]
        public void TestSwitchBetweenWindowsAndTabs()
        {
            windowsAndTabsPage.NavigateTo();
            windowsAndTabsPage.SwitchBetweenWindowsAndTabs();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}