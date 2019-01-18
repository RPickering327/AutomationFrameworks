using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Ewart.UI.Tests.PageObjects.SchoolSettings
{
    class SchoolSettingsEdit
    {

        public readonly IWebDriver Driver;

        public SchoolSettingsEdit()
        {
            Driver = new ChromeDriver("D:\\Desktop\\Ewart.UI.Tests\\bin\\Debug\\netcoreapp2.1\\");
        }

        private IWebElement _editButton => Driver.FindElement(By.PartialLinkText("Edit profile"));
        private IWebElement _schoolName => Driver.FindElement(By.Id("OrganizationName"));
        private IWebElement _logoUrl => Driver.FindElement(By.Id("LogoUrl"));
        private IWebElement _phoneNumber => Driver.FindElement(By.Id("PhoneNumber"));
        private IWebElement _email => Driver.FindElement(By.Id("Email"));
        private IWebElement _motto => Driver.FindElement(By.Id("ShortDescription"));
        private IWebElement _longDescription => Driver.FindElement(By.Id("LongDescription"));
        private IWebElement _address => Driver.FindElement(By.Id("Address"));
        private IWebElement _yearlyBudget => Driver.FindElement(By.Id("YearlyBudget"));
        private IWebElement _submitButton => Driver.FindElement(By.CssSelector("input[type=submit]"));




        public void confirmOnPage(string title)
        {

            Assert.Equal(title, Driver.Title);

        }


        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("https://localhost:44379/UserSettings/");
            _editButton.Click();

        }


        public void SchoolName(string schoolName)
        {
            _schoolName.Clear();
            _schoolName.SendKeys(schoolName);

        }



        public void LogoUrl(string logoUrl)
        {
            _logoUrl.Clear();
            _logoUrl.SendKeys(logoUrl);

        }


        public void PhoneNumber(string phoneNumber)
        {
            _phoneNumber.Clear();
            _phoneNumber.SendKeys(phoneNumber);
        }

        public void Email(string email)
        {
            _email.Clear();
            _email.SendKeys(email);
        }


        public void Motto(string motto)
        {
            _motto.Clear();
            _motto.SendKeys(motto);
        }

        public void LongDescription(string longDescription)
        {
            _longDescription.Clear();
            _longDescription.SendKeys(longDescription);
        }

        public void Address(string address)
        {
            _address.Clear();
            _address.SendKeys(address);
        }

        public void YearlyBudget(string budget)
        {
            _yearlyBudget.Clear();
            _yearlyBudget.SendKeys(budget);
        }

        public void SaveChanges()
        {
            _submitButton.Click();

        }

        public void VerifyValidationMessages()
        {

            var schoolName = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/form/div[1]/span"));
            Assert.Equal("Please enter a school name.", schoolName.Text);


            var logoName = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/form/div[2]/span"));
            Assert.Equal("Please select an image to upload.", logoName.Text);


            var contactNumber = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/form/div[3]/span"));
            Assert.Equal("A contact number is required.", contactNumber.Text);


            var emailAddress = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/form/div[4]/span"));
            Assert.Equal("A email address is required.", emailAddress.Text);

            var schoolMoto = Driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/form/div[5]/span"));
            Assert.Equal("A motto or slogan is required.", schoolMoto.Text);
        }
    }
}
