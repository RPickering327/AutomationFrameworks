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


@regression 
Scenario Outline: Confirm the login displays the correct error message for invalid login
	Given user is at the homepage
	And the user navigates to the login page
	When the user enters <username> and <password>
	And clicks on the login button
	Then the validation message should be displayed <errormessage>


	Examples: 
	| username                  | password | errormessage                    |
	| invalidusername@gmail.com | 11111    | Invalid login attempt.          |
	| nopassword@gmail.com      |          | The Password field is required. |
	|                           | noemail  | The Email field is required.    |


@regression 
Scenario: Confirm the forget password link works
	Given user is at the homepage
	And the user navigates to the login page
	When the user clicks on forgot password
	Then the forgot password page is displayed