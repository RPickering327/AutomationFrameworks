using SpecFlow.Ewart.Pages.Login;
using TechTalk.SpecFlow;

namespace SpecFlow.Ewart.Steps
{
    [Binding]
    public class LoginFeatureSteps : Login
    {
        [Given(@"user is at the homepage")]
        public void GivenUserIsAtTheHomepage()
        {
            LoadHomePage();
        }

        [Given(@"the user navigates to the login page")]
        public void GivenTheUserNavigatesToTheLoginPage()
        {
            NavigateToLoginPage();
        }

        [When(@"the user enters (.*) and (.*)")]
        public void WhenTheUserEntersAnd(string username, string password)
        {
            EnterUsernameAndPassword(username, password);
        }

        [When(@"clicks on the login button")]
        public void WhenClicksOnTheLoginButton()
        {
            PressLoginButton();
        }

        [Then(@"the user should be navigated to the homepage and logged in")]
        public void ThenTheUserShouldBeNavigatedToTheHomepageAndLoggedIn()
        {
            VerifyUserIsLoggedIn();
        }

        [Then(@"the validation message should be displayed (.*)")]
        public void ThenTheValidationMessageShouldBeDisplayed(string errormessage)
        {
            ValidationMessageDisplayed(errormessage);
        }


        [When(@"the user clicks on forgot password")]
        public void WhenTheUserClicksOnForgotPassword()
        {
            ClickForgotPasswordLink();
        }

        [Then(@"the forgot password page is displayed")]
        public void ThenTheForgotPasswordPageIsDisplayed()
        {
            VerifyOnForgotPasswordPage();
        }

    }
}
