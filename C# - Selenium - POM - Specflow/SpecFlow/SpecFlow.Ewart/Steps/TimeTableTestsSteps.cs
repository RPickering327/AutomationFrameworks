using SpecFlow.Ewart.Pages.TimeTable;
using TechTalk.SpecFlow;

namespace SpecFlow.Ewart
{
    [Binding]
    public class TimeTableTestsSteps : TimeTable
    {

        [Given(@"User is on the timetable page")]
        public void GivenUserIsOnTheTimetablePage()
        {
            OpenTimeTablePage();
        }

        [Given(@"classes dropdown is populated")]
        public void GivenClassesDropdownIsPopulated()
        {
            CheckClassDropDown();
        }

        [Given(@"duration is set to 1:00 hour")]
        public void GivenDurationIsSetToHour()
        {
            ClassDurationLength("01:00");
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ClickAddButton();
        }


        [When(@"I press delete")]
        public void WhenIPressDelete()
        {
            DeleteClass();
        }


        [Given(@"the timetable has a class added")]
        [Then(@"the class should be added to that date")]
        public void ThenTheClassShouldBeAddedToThatDate()
        {
            CheckClassIsPresent(" English - Spellings | 1 hour | View lesson plan | Remove");

        }

        [Then(@"there will be no classes for that day")]
        public void ThenThereWillBeNoClassesForThatDay()
        {
            CheckFirstDayClassList();
        }


        [When(@"month is changed to july")]
        public void WhenMonthIsChangedToJuly()
        {
            MonthDropDownSelection("July");
        }

        [Then(@"july's timetable is displayed")]
        public void ThenJulySTimetableIsDisplayed()
        {

        }


    }
}
