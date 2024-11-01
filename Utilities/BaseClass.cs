using System;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TFL.PageObjects;
using WebDriverManager.DriverConfigs.Impl;

namespace TFL.Utilities
{
	public class BaseClass
    {
        public IWebDriver driver;
        ExtentReports extentReports;
        [OneTimeSetUp]
        public void Setup()
        {

            String BrowserName = ConfigurationManager.AppSettings["Browser"]!;
            SelectBrowser(BrowserName);
            //driver.Url = "https://tfl.gov.uk/plan-a-journey";
            driver.Url = getTestDataParser().extractData("URL"); //Gets data from Json file using parser reader.
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
       
        [OneTimeTearDown]
        public void Clean()
        {
           
            Thread.Sleep(2000);
            driver.Quit();
        }
        //Gets data from Json file using parser reader.
        public static JsonReader getTestDataParser()
        {
            return new JsonReader();
        }
         
        public IWebDriver InitializeNewDriver()
        {
            String BrowserName = ConfigurationManager.AppSettings["Browser"]!;
            SelectBrowser(BrowserName);
            //driver.Url = "https://tfl.gov.uk/plan-a-journey";
            driver.Url = getTestDataParser().extractData("URL");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Replace with the actual URL
            return driver;
        }
        public void ExplicitWaitByXpath(string Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
        }

        public int GetIntValueFromTimeInMinutes(string Time)
        {
            Match match = Regex.Match(Time, @"(\d+)\s*min");
            int IntValue = int.Parse(match.Groups[1].Value);

            return IntValue;
        }
        public void ScrollToElementUsingXpath(IWebElement Element)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
        }
       public void SelectBrowser(string BrowserName)
        {
            switch(BrowserName)
            {
                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Edge":

                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }

       
    }
}

