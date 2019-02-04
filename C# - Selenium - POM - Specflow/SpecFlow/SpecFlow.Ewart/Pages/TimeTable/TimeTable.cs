using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Ewart.Base;

namespace SpecFlow.Ewart.Pages.TimeTable
{
    [TestFixture]
    public class TimeTable : DriverSetup
    {


        private string timeTableUrl = "https://localhost:44379/IndividualSubjects/TimeTable";
        private IWebElement _addButton => driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td/form/input[3]"));
        private IWebElement _classDropDown => driver.FindElement(By.XPath("//*[@id='ClassTime_SubjectDetailsSubjectId']"));
        private IWebElement _durationInput => driver.FindElement(By.XPath("//*[@id='ClassTime_Duration']"));
        private IWebElement _classAdded => driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[2]"));
        private IWebElement _deleteButton => driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[2]/p/a[2]"));
        private IWebElement _firstClassList => driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[2]"));
        private IWebElement _monthDropDown => driver.FindElement(By.Id("monthSelection"));
        private IWebElement _firstDateField => driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/th"));


        public void OpenTimeTablePage()
        {
            driver.Navigate().GoToUrl(timeTableUrl);

        }


        public void CorrectDateDisplayed()
        {
            Assert.AreEqual(_firstDateField.Text, "Monday 01 Jul 2019");
        }

        public void MonthDropDownSelection(string month)
        {
            _monthDropDown.SendKeys(month + Keys.Enter);

        }

        public void CheckClassDropDown()
        {
            var isDisplayed = _classDropDown.Displayed;
            Assert.AreEqual(isDisplayed, true);
        }


        public void ClassDurationLength(string length)
        {
            _durationInput.SendKeys(length);

        }

        public void CheckClassIsPresent(string input)
        {

            Assert.AreEqual(_classAdded.Text, input);

        }


        public void CheckFirstDayClassList()
        {
            var text = _firstClassList.Text;
            Assert.AreEqual(text, "");
        }

        public void ClickAddButton()
        {

            _addButton.Click();
        }

        public void DeleteClass()
        {

            _deleteButton.Click();
        }

       
    }
}
