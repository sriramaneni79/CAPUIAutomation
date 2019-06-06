Feature: AdminPortal_38227
	05: Admin Portal : User/ Role Management : Roles - Add Role - Popup Screen

@Browser_Chrome
@Browser_Firefox
Scenario: Add role Button PopUp Validation.
	Given Navigate to the CAP UI Home page.
	And Click on manage Tab in the Home Page
	And Navigate to list roles page by clicking on list Roles Tab.
	When User Clicks on the Add Button in the list Roles page.
	Then pop up window to add roles Should be displayed.

@Browser_Chrome
@Browser_Firefox
Scenario: Add role Button Functional Verification.
	Given Navigate to the CAP UI Home page.
	And Click on manage Tab in the Home Page
	And Navigate to list roles page by clicking on list Roles Tab.
	And User Clicks on the Add Button in the list Roles page.
	And Enter the role name as any Random String in enter role name field 
	When Click Apply button in the Add role Pop up.
	Then New Role Should be added in the Role Grid in the left pane.

@Browser_Chrome
@Browser_Firefox
Scenario: Add role Button Error message Validation.
	Given Navigate to the CAP UI Home page.
	And Click on manage Tab in the Home Page
	And Navigate to list roles page by clicking on list Roles Tab.
	And User Clicks on the Add Button in the list Roles page.
	When User enter existing role name  in enter role name field 
	Then Error Message should be thrown as "Duplicate Role Name Found" in the Add role Pop up.
	
