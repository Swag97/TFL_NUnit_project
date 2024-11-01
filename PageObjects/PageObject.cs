using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TFL.PageObjects
{
	public class PageObject
	{
		private IWebDriver driver;
		public PageObject(IWebDriver driver)
		{

           this.driver = driver;
		   PageFactory.InitElements(driver, this);
		}

		//driver.FindElement(By.Id("cb-cookiebanner")
		// Page Object for Cookies banner
		[FindsBy(How = How.Id, Using = "cb-cookiebanner")]
		private IWebElement cookies;
		public IWebElement Cookies()
		{
			return cookies;
		}

		//driver.FindElement(By.XPath("//button[@class='cb-button cb-left cb-buttons-grid-2']"))
		//Page object for Accept cookies button
		[FindsBy(How = How.XPath, Using = "//button[@class='cb-button cb-left cb-buttons-grid-2']")]
		private IWebElement accept_cookies;

		public IWebElement AcceptCookies()
		{
			return accept_cookies;
		}

		//driver.FindElement(By.Id("InputFrom")).SendKeys("Lei");
		//Page object for from input field
		[FindsBy(How = How.Id, Using = "InputFrom")]
		private IWebElement from;
		public IWebElement FromLocation()
		{
			return from;
		}

		//driver.FindElements(By.XPath("//span[@class='stop-name']"))
		//Page object for list of locations( dynamic dropdown)
		[FindsBy(How = How.XPath, Using = "//span[@class='stop-name']")]
		private IList<IWebElement> from_list;
		public IList<IWebElement> FromList()
		{
			return from_list;
		}

		//driver.FindElement(By.XPath("//input[@class='jpTo tt-input']")).SendKeys("Cov");
		//Page Object for TO location input field
		[FindsBy(How = How.XPath, Using = "//input[@class='jpTo tt-input']")]
		private IWebElement to;
		public IWebElement ToLocation()
		{
			return to;
		}

		//driver.FindElements(By.XPath("//span[@class='stop-name']"))
		//Page object for To location list ( dynamic dropdown )
		[FindsBy(How = How.XPath, Using = "//span[@class='stop-name']")]
		private IList<IWebElement> to_list;
		public IList<IWebElement> ToList()
		{
			return to_list;
		}

		//driver.FindElement(By.Id("plan-journey-button"))
		//Page object for Plan Journey burron on home page
		[FindsBy(How = How.Id, Using = "plan-journey-button")]
		private IWebElement planJourneyButton;
		public IWebElement PlanJourneyButton()
		{
			return planJourneyButton;
		}

		//By.XPath("//a[@class='journey-box cycling']//div[2]//div[2]")
		//Page object for Cycling journey time
		[FindsBy(How = How.XPath, Using = "//a[@class='journey-box cycling']//div[2]//div[2]")]
		private IWebElement cycleJourneyTimeBeforeUpdateJourney;
		public IWebElement CycleJourneyTimeBeforeUpdateJourney()
		{
			return cycleJourneyTimeBeforeUpdateJourney;
		}

        //a[@class='journey-box cycling']//div[2]//div[2]
        private string Xpath_CycleDuration = "//a[@class='journey-box cycling']//div[2]//div[2]";
		public string XPATH_CyclinDuration()
		{
			return Xpath_CycleDuration;
		}

		//driver.FindElement(By.XPath("//a[@class='journey-box walking']//div[2]//div[2]"))
		//Page Object for Walking Journey time
		[FindsBy(How = How.XPath, Using = "//a[@class='journey-box walking']//div[2]//div[2]")]
		private IWebElement walkJourneyTimeBeforeUpdateJourney;
		public IWebElement WalkJourneyTImeBeforeUpdateJourney()
		{
			return walkJourneyTimeBeforeUpdateJourney;
		}

		//driver.FindElement(By.XPath("//div[@class='edit-preferences clearfix']"))
		//Page Object for Edit preferences button
		[FindsBy(How = How.XPath, Using = "//div[@class='edit-preferences clearfix']")]
		private IWebElement editPrefButton;
		public IWebElement EditPreferencesButton()
		{
			return editPrefButton;
		}

		// driver.FindElement(By.XPath("//label[contains(text(), 'Routes with least walking')]")).Click();
		// Page Object for Routes with least walking button
		[FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Routes with least walking')]")]
		private IWebElement routesWithLeastWalkingButton;
		public IWebElement RoutesWithLeastWalkingButton()
		{
			return routesWithLeastWalkingButton;
		}

		//driver.FindElement(By.XPath("(//input[@value='Update journey'])[2]")
		//Page Object for Update journey
		[FindsBy(How = How.XPath, Using = "(//input[@value='Update journey'])[2]")]
		private IWebElement updateJourney;
		public IWebElement UpdateJourneyButton()
		{
			return updateJourney;
		}

		//By.XPath("(//div[@class='journey-time no-map'])[1]
		//Page Object for updated journey time
		[FindsBy(How = How.XPath, Using = "(//div[@class='journey-time no-map'])[1]")]
		private IWebElement updatedJourneyDuration;
		public IWebElement UpdatedJourneyDuration()
		{
			return updatedJourneyDuration;
		}
        private string xpath_updatedJourneyTime = "(//div[@class='journey-time no-map'])[1]";
        public string XPATH_UpdatedJourneyTime()
        {
            return xpath_updatedJourneyTime;
        }
		//(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//p[@class='duration']
		[FindsBy(How = How.XPath, Using = "(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//p[@class='duration']")]
		private IList<IWebElement> detailedJourneyTimes;
		public IList<IWebElement> DetailedJourneyTimes()
		{
			return detailedJourneyTimes;
		}




        //driver.FindElement(By.XPath("(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')][1]//p[@class='duration']"))
        [FindsBy(How = How.XPath, Using = "(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')][1]//p[@class='duration']")]
		private IWebElement journeyDetailedStepDuration1;
		public IWebElement JourneyDetailedStepDuration1()
		{
			return journeyDetailedStepDuration1;
		}
        [FindsBy(How = How.XPath, Using = "(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')][2]//p[@class='duration']")]
        private IWebElement journeyDetailedStepDuration2;
        public IWebElement JourneyDetailedStepDuration2()
        {
            return journeyDetailedStepDuration2;
        }
        [FindsBy(How = How.XPath, Using = "(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')][3]//p[@class='duration']")]
        private IWebElement journeyDetailedStepDuration3;
		public IWebElement JourneyDetailedStepDuration3()
		{ 
            return journeyDetailedStepDuration3;
        }

		//driver.FindElement(By.XPath("(//button[text()='View details'])[1]")).Click();
		//page object for view details button on journey details page
		[FindsBy(How = How.XPath, Using = "(//button[text()='View details'])[1]")]
		private IWebElement viewDetailsButton;
		public IWebElement ViewDetailsButton()
		{
			return viewDetailsButton;
		}

		//By.XPath("(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]"))
		//page object for Number of steps 
		//[FindsBy(How = How.XPath, Using = "(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//span[@class='stop-location-and-time']//span[@class='location-name notranslate']")]
		//private IList<IWebElement> journeyDetailSteps;
		/*public IList<IWebElement> JourneyDetailSteps(string station)
		{
			return journeyDetailSteps;
		}*/
        public IList<IWebElement> JourneyDetailSteps(string station)
        {
            // Create a dynamic XPath by inserting the station name in the XPath expression
            string dynamicXPath = $"(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//span[@class='stop-location-and-time']//span[@class='location-name notranslate' and contains(text(), '{station}')]";

            // Use driver.FindElements to locate the elements with the dynamic XPath
            return driver.FindElements(By.XPath(dynamicXPath));
        }

        //By.XPath("((//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')])[3]//div[@class='access-information']//a"))
        [FindsBy(How = How.XPath, Using = "((//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//span[@class='stop-location-and-time']//span[@class='location-name notranslate'])[3]//ancestor::div[contains(@class, 'journey-detail-step')]//div[@class='access-information']//a")]
		private IList<IWebElement> stepsToDo;
		public IList<IWebElement> StepsToDo(string input)
		{
            //return stepsToDo;
            string dynamicXPath = $"(//div[@class='journey-details'])[1]//div[contains(@class, 'journey-detail-step')]//span[@class='stop-location-and-time']//span[@class='location-name notranslate' and contains(text(), '{input}')]//ancestor::div[contains(@class, 'journey-detail-step')]//div[@class='access-information']//a";

            // Use driver.FindElements to locate the elements with the dynamic XPath
            return driver.FindElements(By.XPath(dynamicXPath));
        }

		//By.XPath("//li[@class='field-validation-error']"))
		// Page object for error when invalid input is given
		[FindsBy(How = How.XPath, Using = "//li[@class='field-validation-error']")]
		private IWebElement validationErrorForInvalidInputs;
		public IWebElement ValidationErrorForInvalidInputs()
		{
			return validationErrorForInvalidInputs;
		}
		private string validationErroXpath = "//li[@class='field-validation-error']";
		public string ValidationErrorXpath()
		{
			return validationErroXpath;
		}
        //driver.FindElement(By.XPath("//driver.FindElement(By.XPath("//span[@id='InputFrom-error']"))
        //Page object for error thrown when no input is given
        [FindsBy(How = How.XPath, Using = "//span[@id='InputFrom-error']")]
        private IWebElement inputFromError;
        public IWebElement InputFromError()
        {
            return inputFromError;
        }

        //driver.FindElement(By.XPath("//span[@id='InputTo-error']"))
        //Page object for error thrown when no input is given
        [FindsBy(How = How.XPath, Using = "//span[@id='InputTo-error']")]
        private IWebElement inputToError;
        public IWebElement InputToError()
        {
            return inputToError;
        }


    }
}

