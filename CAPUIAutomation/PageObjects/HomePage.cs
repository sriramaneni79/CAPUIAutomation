using CAPUIAutomation.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CAPUIAutomation.PageObjects
{
    public class HomePage
    {

        private readonly IWebDriver _driver;
        WebDriverHelper Driver;
        public Hooks hooks = new Hooks();


        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Driver = new WebDriverHelper(_driver);
        }

        public IWebElement manageTab => hooks.FindElement(By.XPath("//a/label[text()='manage']"), _driver);

    }
}
