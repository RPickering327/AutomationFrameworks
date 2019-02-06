using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Ewart.Base;

namespace SpecFlow.Ewart.Pages.Login
{
    public class Login : DriverSetup
    {


        private IWebElement _loginPageLink => driver.FindElement(By.PartialLinkText("Login"));
        private IWebElement _userName => driver.FindElement(By.Id("Input_Email"));
        private IWebElement _password => driver.FindElement(By.Id("Input_Password"));

        private IWebElement _loginButton =>
            driver.FindElement(By.XPath("/html/body/div/div/div/section/form/div[5]/button"));

        private IWebElement _usernameDisplay => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a"));

        private IWebElement _emailValidationMessage =>
            driver.FindElement(By.XPath("/html/body/div/div/div/section/form/div[1]/ul/li"));

        private IWebElement _passwordValidation =>
            driver.FindElement(By.XPath("/html/body/div/div/div/section/form/div[1]/ul/li[2]"));

        private IWebElement _forgotPasswordLink => driver.FindElement(By.PartialLinkText("Forgot your password?"));






        private string _displayUsername = "";

        public void NavigateToLoginPage()
        {

            _loginPageLink.Click();
        }


        public void EnterUsernameAndPassword(string username, string password)
        {
            _displayUsername = username;
            _userName.SendKeys(username);
            _password.SendKeys(password);


        }

        public void PressLoginButton()
        {
            _loginButton.Click();
        }


        public void VerifyUserIsLoggedIn()
        {

            Assert.AreEqual(_usernameDisplay.Text, "Hello " + _displayUsername + "!");

        }


        public void ValidationMessageDisplayed(string errorMessage)
        {


            Assert.AreEqual(_emailValidationMessage.Text, errorMessage);


        }


        public void ClickForgotPasswordLink()
        {
            _forgotPasswordLink.Click();
        }



        public void VerifyOnForgotPasswordPage()
        {

            Assert.AreEqual(driver.Title, "Forgot your password? - Ewart");
        }



    }


}
