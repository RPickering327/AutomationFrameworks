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
        private IWebElement _loginButton => driver.FindElement(By.XPath("/html/body/div/div/div/section/form/div[5]/button"));
        private IWebElement _usernameDisplay => driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li[1]/a"));


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
    }
}
