using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using Xunit;

namespace Ewart.UI.Tests.Objects.UserCreation
{
    public class BaseUser
    {

        public readonly IWebDriver Driver;
        private string _firstName = "";
        private string _lastName = "";
        private string _birthDate = "";
        private string _email = "";
        private string _address = "";
        private string _role = "";
        private string _salary = "";

        public BaseUser()
        {
            Driver = new ChromeDriver("D:\\Desktop\\Ewart.UI.Tests\\bin\\Debug\\netcoreapp2.1\\");

        }


        public string PageTitle => Driver.Title;



        public void NavigateTo()
        {

            Driver.Navigate().GoToUrl("https://localhost:44379/BaseUsers");
        }

        public void FirstName(string firstName)
        {

            Driver.FindElement(By.Id("FirstName")).Clear();
            Driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _firstName = firstName;

        }


        public void LastName(string lastName)
        {
            Driver.FindElement(By.Id("LastName")).Clear();
            Driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            _lastName = lastName;

        }


        public void Birthdate(string birthDate)
        {

            Driver.FindElement(By.Id("DateOfBirth")).Clear();
            Driver.FindElement(By.Id("DateOfBirth")).SendKeys(birthDate);
            _birthDate = birthDate;

        }


        public void Email(string email)
        {
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys(email);
            _email = email;




        }

        public void Address(string address)
        {
            Driver.FindElement(By.Id("Address")).Clear();
            Driver.FindElement(By.Id("Address")).SendKeys(address);

            _address = address;

        }


        public void JobRole(string role)
        {
            Driver.FindElement(By.XPath("//select[@id='sel1']/option[contains(.,'" + role + "')]")).Click();

            _role = role;
        }


        public void SalaryPerWeek(string salary)
        {

            Driver.FindElement(By.Id("CostPerWeek")).Clear();
            Driver.FindElement(By.Id("CostPerWeek")).SendKeys(salary);

            _salary = salary;

        }


        public void SubmitForm()
        {

            Driver.FindElement(By.Id("submit")).Click();
        }


        public void CheckRowMatches()
        {

            //Get the text from the last row of data
            var text = Driver.FindElement(By.XPath("//table/tbody/tr[last()]")).Text;

            Assert.Equal($"{_firstName} {_lastName} {_birthDate} 00:00:00 {_email} {_address} {_role} Edit | Details | Delete", text);
        }


        public void CheckRowHasBeenDeleted()
        {

            //Get the text from the last row of data
            var text = Driver.FindElement(By.XPath("//table/tbody/tr[last()]")).Text;

            Assert.NotEqual($"{_firstName} {_lastName} {_birthDate} 00:00:00 {_email} {_address} {_role} Edit | Details | Delete", text);
        }


        public void EditOrDeleteProfile(string option)
        {

            //Click the last edit in the list to get the user created above.
            IList<IWebElement> lastEdit = Driver.FindElements(By.PartialLinkText(option));

            //Click the last edit link
            lastEdit[lastEdit.Count - 1].Click();

        }


        public void ValidationMessagesDisplayed()
        {

            var firstNameErrorMessage = Driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[1]/div[1]/div/span"));
            Assert.Equal("First name is required", firstNameErrorMessage.Text);

            var lastNameErrorMessage = Driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[1]/div[2]/div/span"));
            Assert.Equal("Last name is required", lastNameErrorMessage.Text);


            var dateOfBirth = Driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[2]/span"));
            Assert.Equal("The value '' is invalid.", dateOfBirth.Text);


            var emailErrorMessage = Driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/span"));
            Assert.Equal("Email is required", emailErrorMessage.Text);


            var costPerWeek = Driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[6]/span"));
            Assert.Equal("The value '' is invalid.", costPerWeek.Text);

        }


    }
}
