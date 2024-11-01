using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.CommonModels;
using TFL.PageObjects;
using TFL.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TFL;
[TestFixture]
public class Tests : BaseClass
{
    
    
    [Test, Order(1)]
    public void Test1()
    {
        
        Thread.Sleep(1000);
        PageObject PO = new PageObject(driver);
        if (PO.Cookies().Displayed)
        {
            PO.AcceptCookies().Click();
            Thread.Sleep(2000);
        }
        //Console.WriteLine(getTestDataParser().extractData("Input_To_Station"));
        
        PO.FromLocation().SendKeys(getTestDataParser().extractData("Input_To_Station"));
        Thread.Sleep(1000);
        foreach(var station in PO.FromList())
        {
            if ( station.Text.Contains(getTestDataParser().extractData("To_Station")))
            {
                station.Click();
                break;
            }
        }
       
        PO.ToLocation().SendKeys(getTestDataParser().extractData("Input_From_Station"));
        Thread.Sleep(1000);
        foreach ( var station in PO.ToList())
        {
            if(station.Text.Contains(getTestDataParser().extractData("From_Station")))
            {
                station.Click();
                break;
            }
        }
      

        PO.PlanJourneyButton().Click(); // Plan my journey button
        ExplicitWaitByXpath(PO.XPATH_CyclinDuration());

        string cycle_duration = PO.CycleJourneyTimeBeforeUpdateJourney().Text;
        
        TestContext.Progress.WriteLine("Cycling duration is "+cycle_duration);

        string walk_duration = PO.WalkJourneyTImeBeforeUpdateJourney().Text;

        TestContext.Progress.WriteLine("Walking duration is "+walk_duration);
        
        
    }

    [Test, Order(2)]
    public void Test2()
    {

        PageObject PO = new PageObject(driver);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        PO.EditPreferencesButton().Click();

        PO.RoutesWithLeastWalkingButton().Click();
        Thread.Sleep(1000);

        ScrollToElementUsingXpath(PO.UpdateJourneyButton());

        Thread.Sleep(1000);
        PO.UpdateJourneyButton().Click();

        ExplicitWaitByXpath(PO.XPATH_UpdatedJourneyTime());

        string updatedJourneyDuration = PO.UpdatedJourneyDuration().Text;

        int int_total_duration = GetIntValueFromTimeInMinutes(updatedJourneyDuration);

        TestContext.Progress.WriteLine(updatedJourneyDuration);

        int detailed_journey_time = 0;
        foreach ( var time in PO.DetailedJourneyTimes())
        {
            
            string det_jour_time = time.Text;
            detailed_journey_time = detailed_journey_time + GetIntValueFromTimeInMinutes(det_jour_time);
        }
        TestContext.Progress.WriteLine("Consolidated journey time is " + detailed_journey_time + " mins");
        if (int_total_duration == detailed_journey_time)
        {
            TestContext.Progress.WriteLine("Validated Successfully!");
        }

    }

    [Test, Order(3)]
    public void Test3()
    {
        PageObject PO = new PageObject(driver);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        PO.ViewDetailsButton().Click();

        //Thread.Sleep(50000);

        string station_input = getTestDataParser().extractData("Steps_at_Station");
        foreach (var station in PO.JourneyDetailSteps(station_input))
        {
            //Console.WriteLine(station.Text);
            if (station.Text.Equals(station_input))
            {
              
                TestContext.Progress.WriteLine("Steps to follow at "+ station_input +": ");
                foreach(var step in PO.StepsToDo(station_input))
                {
                    TestContext.Progress.WriteLine(step.GetAttribute("aria-label"));
                }
               
            }

        }
        Thread.Sleep(1000);
        driver.Quit();
    }

    [Test, Order(4)]
    public void Test4()
    {
        InitializeNewDriver();
        Thread.Sleep(1000);
        PageObject PO = new PageObject(driver);
        if (PO.Cookies().Displayed)
        {
            PO.AcceptCookies().Click();
            Thread.Sleep(2000);
        }
        PO.FromLocation().SendKeys(getTestDataParser().extractData("Invalid_From_Station"));
        PO.ToLocation().SendKeys(getTestDataParser().extractData("Invalid_To_Station"));
        PO.PlanJourneyButton().Click();

        ExplicitWaitByXpath(PO.ValidationErrorXpath());

        if (PO.ValidationErrorForInvalidInputs().Text.Equals(getTestDataParser().extractData("Expected_Error_Invalid_Input")))
        {
            //TestContext.Progress.WriteLine("ERROR : " + PO.ValidationErrorForInvalidInputs().Text);
            TestContext.Progress.WriteLine("ERROR : " + getTestDataParser().extractData("Expected_Error_Invalid_Input"));
        }
        Thread.Sleep(1000);
        driver.Quit();
    }

    [Test, Order(5)]
    public void Test5()
    {
        InitializeNewDriver();
        Thread.Sleep(1000);
        PageObject PO = new PageObject(driver);
        if (PO.Cookies().Displayed)
        {
            PO.AcceptCookies().Click();
            Thread.Sleep(2000);
        }

        PO.PlanJourneyButton().Click();

        if(PO.InputFromError().Displayed && PO.InputToError().Displayed)
        {
            TestContext.Progress.WriteLine("Error : " + getTestDataParser().extractData("Expected_Error_Blank_From"));
            TestContext.Progress.WriteLine("Error : " + getTestDataParser().extractData("Expected_Error_Blank_To"));
            TestContext.Progress.WriteLine("Therefore, unable to plan a journey!");
        }
        Thread.Sleep(1000);
        driver.Quit();
    }

}
