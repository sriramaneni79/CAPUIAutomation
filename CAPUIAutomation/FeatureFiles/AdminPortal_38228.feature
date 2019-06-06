Feature: AdminPortal_38228


@Browser_Chrome
@Browser_Firefox
Scenario: Add role Button Functional Verification for cancel.
	Given Navigate to the CAP UI Home page.
	And Click on manage Tab in the Home Page
	And Navigate to list roles page by clicking on list Roles Tab.
	And User Clicks on the Add Button in the list Roles page.
	And Enter the role name as any Random String in enter role name field 
	When Click cancel button in the Add role Pop up.
	Then pop up window to add roles Should not be displayed.
