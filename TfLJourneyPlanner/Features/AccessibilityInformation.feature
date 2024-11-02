Feature: AccessibilityInformation

As a TfL website user, I want to be able to see complete accesibility information for Covent Garden
Underground Station when planning my journey

@tag3
Scenario: Verify that a user can view complete accesibility Information for Covent Garden underground 
station when planning a journey
	Given that the user has navigated to TfL website journey planner
	When the user types "Leicester Square Underground Station" in the From field
	And the user types “Covent Garden Underground Station” in the To field
	And the User clicks on Plan my journey
	Then the journey results should be displayed with both Cycling and Walking options
	When the User clicks on "Edit Preferences"
	And the journey results for Cycling and other options are loaded showing Walking distance and time of the journey
	And the User Checks the "Routes with Least walking"
	And the User clicks on "Update jouney"
	Then the journey results showing least walking time options should be displayed
	When the User selects the Least walking results displayed
	And the user clicks on View details
	And the User Clicks on Acessibility details
	Then the accessibility details should be displayed (Walking Time, Number of Stairs and direction of stairs(up/down)
	#Number of Escalators and direction of Escalators (up/down) and Number of Level walkways)
