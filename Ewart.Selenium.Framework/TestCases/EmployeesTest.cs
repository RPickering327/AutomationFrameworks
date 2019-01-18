using Ewart.UI.Tests.Objects.UserCreation;
using System;
using Xunit;

namespace Ewart.UI.Tests
{
    public class EmployeesTest : IDisposable
    {

        private BaseUser Employee = new BaseUser();



        //Smoke test to ensure the page loads. 
        [Fact]
        public void HomePageShouldLoad_Smoke()
        {

            Employee.NavigateTo();
            Assert.Equal("Employees - Ewart", Employee.PageTitle);

        }


        [Fact]
        public void CreateValidTeacher()
        {

            //Navigate to and check the title is correct.
            Employee.NavigateTo();
            Assert.Equal("Employees - Ewart", Employee.PageTitle);

            //Create the new teacher
            Employee.FirstName("Richard");
            Employee.LastName("Pickering");
            Employee.Birthdate("01/01/1993");
            Employee.Email("rpickering327@gmail.com");
            Employee.Address("99 Long lane Rd");
            Employee.JobRole("Teacher");
            Employee.SalaryPerWeek("502");

            //Submit the form
            Employee.SubmitForm();

            //Check the newly insert teacher has been inserted.
            Employee.CheckRowMatches();

        }



        [Fact]
        public void CreateInvalidTeacher()
        {

            Employee.NavigateTo();

            Employee.SubmitForm();

            Assert.Equal("Employees - Ewart", Employee.PageTitle);

            Employee.ValidationMessagesDisplayed();

        }

        [Fact]
        public void EditTeacher()
        {

            Employee.NavigateTo();
            Employee.EditOrDeleteProfile("Edit");

            //Edit employee
            Employee.FirstName("Richard");
            Employee.LastName("Pickering");
            Employee.Birthdate("01/01/1993");
            Employee.Email("edited@gmail.com");
            Employee.Address("893 Long lane Rd");
            Employee.JobRole("Teacher");
            Employee.SubmitForm();


            Employee.CheckRowMatches();

        }



        [Fact]
        public void DeleteNewTeacher()
        {

            Employee.NavigateTo();

            //Create the new teacher
            Employee.FirstName("DeletedUser");
            Employee.LastName("DeletedSirname");
            Employee.Birthdate("01/01/1993");
            Employee.Email("rpickering327@gmail.com");
            Employee.Address("99 Long lane Rd");
            Employee.JobRole("Teacher");
            Employee.SalaryPerWeek("502");

            //Submit the form
            Employee.SubmitForm();

            //Delete the newly created employee
            Employee.EditOrDeleteProfile("Delete");
            Employee.SubmitForm();

            //Check they've been deleted.
            Employee.CheckRowHasBeenDeleted();


        }



        //Cleans up after each test
        public void Dispose()
        {

            Employee.Driver.Quit();
        }

    }
}
