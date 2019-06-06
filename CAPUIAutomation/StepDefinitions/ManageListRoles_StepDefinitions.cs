using CAPUIAutomation.PageObjects;
using CAPUIAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace CAPUIAutomation.StepDefinitions
{
    [Binding]
    public class ManageListRoles_StepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;

        public ManageListRoles_StepDefinitions(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }

        [Given(@"Navigate to list roles page by clicking on list Roles Tab.")]
        public void GivenNavigateToListRolesPageByClickingOnListRolesTab_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.listRoles.Click();
        }

        [When(@"User Clicks on the Add Button in the list Roles page\.")]
        public void WhenUserClicksOnTheAddButtonInTheListRolesPage_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.addRoleButton.Click();
        }

        [Then(@"pop up window to add roles Should be displayed\.")]
        public void ThenPopUpWindowToAddRolesShouldBeDisplayed_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            Assert.True(managelistRoles.addRoleButton_dialogBox.Displayed);
        }

        [Given(@"User Clicks on the Add Button in the list Roles page\.")]
        public void GivenUserClicksOnTheAddButtonInTheListRolesPage_()
        {
            Thread.Sleep(1000);
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.addRoleButton.Click();
        }

        [Given(@"Enter the role name as any Random String in enter role name field")]
        public void GivenEnterTheRoleNameAsAnyRandomStringInenterrolenameField()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            Hooks hooks = new Hooks();
            ScenarioContext.Current["Role Name"] = hooks.RandomString(5);
            managelistRoles.roleName_Input.SendKeys(ScenarioContext.Current["Role Name"].ToString());
        }

        [When(@"User enter existing role name  in enter role name field")]
        public void WhenEnterTheRoleNameAsAnyRandomStringInenterrolenameField()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.roleName_Input.SendKeys("QA Manager");
        }
        [When(@"Click Apply button in the Add role Pop up\.")]
        public void WhenClickApplyButtonInTheAddRolePopUp_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.addRoledialog_applyButton.Click();
        }
        [When(@"Click cancel button in the Add role Pop up\.")]
        public void WhenClickCancelButtonInTheAddRolePopUp_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            managelistRoles.addRoledialog_cancelButton.Click();
        }

        [Then(@"New Role Should be added in the Role Grid in the left pane\.")]
        public void ThenNewRoleShouldBeAddedInTheRoleGridInTheLeftPane_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            Thread.Sleep(1000);
            string roleName = ScenarioContext.Current["Role Name"].ToString();
            Assert.True(managelistRoles.RoleGridElement(roleName).Displayed);
        }
        [Then(@"pop up window to add roles Should not be displayed\.")]
        public void ThenPopUpWindowToAddRolesShouldNotBeDisplayed_()
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            Assert.False(managelistRoles.addRoleButton_dialogBox.Displayed);
        }

        [Then(@"Error Message should be thrown as (.*) in the Add role Pop up\.")]
        public void ThenErrorMessageShouldBeThrownAsInTheAddRolePopUp_(string errorMsg)
        {
            Manage_ListRoles managelistRoles = new Manage_ListRoles(webDriver);
            string errorMessage_PopUp = managelistRoles.duplicateRole_ErrorMessage.Text;
            Assert.AreEqual(errorMessage_PopUp, errorMsg);
            managelistRoles.addRoledialog_cancelButton.Click();
        }
    }
}
