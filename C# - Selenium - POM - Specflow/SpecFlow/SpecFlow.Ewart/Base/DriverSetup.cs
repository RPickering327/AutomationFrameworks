using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SpecFlow.Ewart.Base
{

    public class DriverSetup : IDisposable
    {


        public IWebDriver driver;

        public DriverSetup()
        {
            driver = new ChromeDriver("D:\\Desktop\\Ewart.UI.Tests\\bin\\Debug\\netcoreapp2.1\\");
        }


        public void Dispose()
        {

            driver.Close();
        }


    }
}
