using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;

namespace TfLJourneyPlanner.Hooks
{
    [Binding]
    public class ScenarioStartAndEndHooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public ScenarioStartAndEndHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--incognito");
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            _driver = new ChromeDriver(chromeOptions);
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Quit();
        }
    }



}