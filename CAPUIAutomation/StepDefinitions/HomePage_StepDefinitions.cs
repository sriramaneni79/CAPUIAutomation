using CAPUIAutomation.PageObjects;
using CAPUIAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CAPUIAutomation.StepDefinitions
{
    [Binding]
    class HomePage_StepDefinitions
    {

        private readonly ScenarioContext context;
        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;



        public HomePage_StepDefinitions(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }

        [Given(@"Navigate to the CAP UI Home page\.")]
        public void GivenNavigateToTheCAPUIHomePage_()
        {
            webDriver.Navigate().GoToUrl("https://enterpriseweb.dev.cndt.cf/home");
        }

        [Given(@"Click on manage Tab in the Home Page")]
        public void GivenClickOnManageTab()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.manageTab.Click();
        }

    }
}
