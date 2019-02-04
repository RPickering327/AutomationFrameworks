Feature: TimeTableTests
Description: This feature will test that users can add and remove classes from the timetable view.

@regression
Scenario: Add one class to the timetable
	Given User is on the timetable page
	And classes dropdown is populated
	And duration is set to 1:00 hour
	When I press add
	Then the class should be added to that date


@regression
Scenario: Delete one class from the timetable
   Given User is on the timetable page
   And the timetable has a class added
   When I press delete
   Then there will be no classes for that day


@regression
Scenario: View another months timetable
	Given User is on the timetable page
	When month is changed to july
	Then july's timetable is displayed