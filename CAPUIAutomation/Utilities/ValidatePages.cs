using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPUIAutomation.Utilities
{
    public class ValidatePages
    {
        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;
        
        public ValidatePages(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }
        public void ValidatePage(string pageName)
        {
            var urlList = new[] {
                        Driver.GetCurrentURL()
                    };
            var hasUrl = false;
            switch (pageName.ToLower())
            {
                case "home":
                    hasUrl = urlList.Any(
                        url => url.Contains("/home")
                        );
                    if (!hasUrl)
                        throw new CAPUIAutomationHelperUtility.ConduentUIAutomationException("Home Page URL is not valid. Please check URL.");
                    break;
                case "customer":
                    hasUrl = urlList.Any(
                        url => url.Contains("/customer")
                        );
                    if (!hasUrl)
                        throw new CAPUIAutomationHelperUtility.ConduentUIAutomationException("Customer Management Page URL is not valid. Please check URL.");
                    break;
                case "user":
                    hasUrl = urlList.Any(
                        url => url.Contains("/user")
                        );
                    if (!hasUrl)
                        throw new CAPUIAutomationHelperUtility.ConduentUIAutomationException("User Management Page URL is not valid. Please check URL.");
                    break;
                case "customer profile":
                    hasUrl = urlList.Any(
                        url => url.Contains("/customers")
                        );
                    if (!hasUrl)
                        throw new CAPUIAutomationHelperUtility.ConduentUIAutomationException("Customer Management Page URL is not valid. Please check URL.");
                    break;
                default:
                    throw new NotSupportedException($"{pageName} - is not valid. Please provide valid page name.");

            }
        }
    }
}
