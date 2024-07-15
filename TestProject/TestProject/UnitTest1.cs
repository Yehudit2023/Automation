using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestProject.PagesObjects;
using NUnit.Framework.Interfaces;

namespace TestProject
{


    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private GoogleHomePage googleHomePage;
        private GoogleResultsPage  googleResultsPage;

        public static IEnumerable<TestData> TestCases => XMLDataReader.ReadTestData("C:\\Users\\user1\\Desktop\\Automation\\TestProject\\TestProject\\TestXML.xml");

        public Tests() { }
        [SetUp]
        public void Setup()
        {
            string path = "C:\\Users\\user1\\Desktop\\Automation\\TestProject\\TestProject\\driver";
            driver = new ChromeDriver(path);
            googleHomePage = new GoogleHomePage(driver);    
            googleResultsPage = new GoogleResultsPage(driver);
          //  driver.Manage().Window.Maximize();
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void TestGoogleSearch(TestData testData)
        {
            googleHomePage.NavigateTo();


            Assert.AreEqual("Google",driver.Title);

            googleHomePage.Search(testData.SearchTerm); 

            googleHomePage.Search("Selenium WebDriver");

            //IWebElement searchBox = driver.FindElement(By.Name("q"));
            //searchBox.SendKeys("Selenium WebDriver");
            //searchBox.Submit();

            Assert.IsTrue(googleResultsPage.ResultsDisplayed());

            string firstResultTitle=googleResultsPage.GetFirstResultTitle();

            googleResultsPage.ClickFirstResult();

            Assert.IsFalse(driver.Title.Contains(firstResultTitle));
            driver.Navigate().Back();
            Assert.AreEqual("Selenium WebDriver" ,driver.FindElement(By.Name("q")).GetAttribute("value"));


        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}