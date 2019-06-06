using CAPUIAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPUIAutomation.PageObjects
{
    class Manage_ListRoles
    {

        private readonly IWebDriver _driver;
        WebDriverHelper Driver;

        Hooks hooks = new Hooks();
        public Manage_ListRoles(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Driver = new WebDriverHelper(_driver);
        }
        public IWebElement listRoles => _driver.FindElement(By.XPath("//a[text()='list roles']"));

        public IWebElement addRoleButton => _driver.FindElement(By.XPath("//span[text()='add role']/ancestor::button"));

        //public IWebElement addRoleButton_dialogBox => _driver.FindElement(By.XPath("//span[text()='Add role']/ancestor::mat-dialog-container"));

        public IWebElement addRoleButton_dialogBox => _driver.FindElement(By.XPath("//span[text()='Add role']/ancestor::mat-dialog-container"));

        public IWebElement addRoledialog_cancelButton => _driver.FindElement(By.XPath("//span[text()='cancel']/ancestor::button"));

        public IWebElement addRoledialog_applyButton => _driver.FindElement(By.XPath("//span[text()='apply']/ancestor::button"));

        public IWebElement roleName_Input => _driver.FindElement(By.Name("roleName"));

        public IWebElement duplicateRole_ErrorMessage => hooks.FindElement(By.XPath("//mat-error[contains(text(),'Duplicate Role Name Found')]"),_driver);

        public IWebElement RoleGridElement(string roleName) => hooks.FindElement(By.XPath("//mat-card/descendant::span[text()='" + roleName + "']"),_driver);
    }
}
