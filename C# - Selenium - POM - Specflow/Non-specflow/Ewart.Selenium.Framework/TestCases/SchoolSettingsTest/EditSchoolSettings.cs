using Ewart.UI.Tests.PageObjects.SchoolSettings;
using System;
using Xunit;

namespace Ewart.UI.Tests.TestCases.SchoolSettingsTest
{
    public class EditSchoolSettings : IDisposable
    {
        private SchoolSettingsEdit Edit = new SchoolSettingsEdit();


        [Fact]
        public void ChangeSchoolSettings()
        {

            Edit.NavigateTo();
            Edit.SchoolName("St Marys of the Cross");
            Edit.Email("maryprimary@sch.edu");
            Edit.Address("90 Long lane, DA8 1O2, Erith, Kent");
            Edit.Motto("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.");
            Edit.LongDescription("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.");
            Edit.PhoneNumber("01322 440753");
            Edit.YearlyBudget("3100000");
            Edit.SaveChanges();
            Edit.confirmOnPage("School Details - Ewart");

        }


        [Fact]
        public void SchoolSettingsValidation()
        {
            Edit.NavigateTo();
            Edit.SchoolName("");
            Edit.Email("");
            Edit.Address("");
            Edit.Motto("");
            Edit.LogoUrl("");
            Edit.LongDescription("");
            Edit.PhoneNumber("");
            Edit.YearlyBudget("");
            Edit.SaveChanges();


            Edit.confirmOnPage("Edit - Ewart");
            Edit.VerifyValidationMessages();
        }




        //Cleans up after each test
        public void Dispose()
        {

            Edit.Driver.Quit();
        }

    }
}
