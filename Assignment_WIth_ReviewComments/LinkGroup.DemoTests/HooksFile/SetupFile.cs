using LinkGroup.DemoTests.Helpers;
using LinkGroup.DemoTests.ReusableFile;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.HooksFile
{
    class SetupFile
    {
        
        public static string _status = "Pass";
        public static string _tcDescription = "";
        public static string _statusMessage = "Test case failed due to expected and actual differs";
        public static IWebDriver driver = null;
        public static string basePath = "";

        [Binding]
        public class Setup
        {
            
            public static string BrowserdriverPath = ConfigurationManager.AppSettings["BrowserdriverPath"];
            public static IWebDriver driver = null;
            private static ReusableMethods reusableMethods = new ReusableMethods();
            [BeforeTestRun]
            public static void BeforeTestRun()
            {

                basePath = reusableMethods.BasePath;
   
            }
            [BeforeFeature]
            public static void BeforeFeature()
            {

            }
            [BeforeScenario]
            public static void BeforeScenario()
            {

                reusableMethods.LaunchBrowser();

                var _tcDescription = ScenarioContext.Current.ScenarioInfo.Title;
                string name = _tcDescription.ToString();
                _status = "Pass";
            }

            [AfterScenario]
            public static void AfterScenario()
            {

               reusableMethods.Closedriver();
            }
        }
    }
}