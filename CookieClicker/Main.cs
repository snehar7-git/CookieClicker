using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CookieClicker
{
    public class Main
    {
        IWebDriver driver; //saw var instead of iwebdriver? , also why is green highligh for driver?
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orteil.dashnet.org/cookieclicker/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        }
        [Test]
        public void Test1()
        {
            SelectLanguage();
            ClickBigCookie();
            ClickEnabledCursor();
        }
       

        public void SelectLanguage()
        {
            //IWebElement languageModal = driver.FindElement(By.Id("promptContentChangeLanguage"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            IWebElement langEnglish = wait.Until(ExpectedConditions.ElementIsVisible((By.Id("langSelect-EN"))));
            langEnglish.Click();

        }

        public void ClickBigCookie()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            IWebElement bigCookie = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("bigCookie")));
            for (int i = 0; i < 15; i++)
            {
                bigCookie.Click();
            }
        }

        public void ClickEnabledCursor()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            IWebElement cookieCountE = driver.FindElement(By.Id("cookies"));
            Assert.That(wait.Until(driver => cookieCountE.Text.Contains("15 cookies")), "Captured the cookie count before all the clicks were completed.");
            IWebElement cursor = driver.FindElement(By.Id("product0"));
            cursor.Click();
        }
        
        [TearDown]
        public void TearDown()
        {
             driver.Quit();
        }

    }
}