Feature: InvalidLocation

As a TfL website user, I want to verify that the widget does not provide results when an invalid
journey is planned by entering 1 or more invalid locations

@tag4
Scenario: Verify that a user cannot plan a journey by entering 1 or more invalid locations
	Given that the user has navigated to TfL website journey planner
	When a user types "tttt" in the From field
	And the User types "zzzz" in the To field
	And the User Clicks on "Plan my journey"
	Then no journey should be displayed on the Jouney results page.
