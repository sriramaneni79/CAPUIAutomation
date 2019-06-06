using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPUIAutomationHelperUtility;
using CAPUIAutomation;
using OpenQA.Selenium.Support.UI;

namespace CAPUIAutomation.Utilities
{
    public class WebDriverHelper : CAPUIAutomationHelperUtility.WebDriverUtility
    {
        protected IWebDriver WebDriver;
        public WebDriverHelper(IWebDriver driver) : base(driver)
        {
            this.WebDriver = driver;
        }
    }
}
