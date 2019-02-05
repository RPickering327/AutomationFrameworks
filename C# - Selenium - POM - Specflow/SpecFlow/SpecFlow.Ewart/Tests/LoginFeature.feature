Feature: LoginFeature
Description: This feature will test that users can login into the application

@regression
Scenario Outline: Confirm the login scenario works as expected
	Given user is at the homepage
	And the user navigates to the login page
	When the user enters <username> and <password>
	And clicks on the login button
	Then the user should be navigated to the homepage and logged in
	Examples:
| username            | password   |
| o11099171@nwytg.net | Password1@ |
| mfd86432@zwoho.com  | Password2@ |
