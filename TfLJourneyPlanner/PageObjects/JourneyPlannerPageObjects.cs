using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TfLJourneyPlanner.PageObjects
{
    public class JourneyPlannerPageObjects
    {
        private readonly IWebDriver _driver;
        //private readonly string? baseUrl = TestContext.Parameters["Environment"];
        private readonly string? baseUrl = "https://tfl.gov.uk/plan-a-journey/?cid=plan-a-journey";
        public JourneyPlannerPageObjects(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void NavigateToTflWebSite()
        {
            _driver.Navigate().GoToUrl(baseUrl);
        }
       
        public void NameOfStationsContatingLeicester(string locationPrompt, string locationBox)
        {
             
            _driver.FindElement(By.Id($"Input{locationBox}")).SendKeys(locationPrompt);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search').style.display='block';");
            Thread.Sleep(1000);
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search > span > div').style.display='block';");
            Thread.Sleep(1000);
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search > span > div').click();");

            
        }

        public void NameOfStationsContatingCovent(string locationPrompt, string locationBox)
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.Id($"Input{locationBox}")).SendKeys(locationPrompt);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search').style.display='block';");
            Thread.Sleep(1000);
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search > span > div').style.display='block';");
            Thread.Sleep(1000);
            js.ExecuteScript("document.querySelector('.tt-dataset-stop-points-search > span > div').click();");
            


        }
        public string DisplayStationNameOnTheAddressField()
        {
            var stationName = _driver.FindElement(By.XPath("//*[@id='InputFrom']")).Text;
            return stationName;            
        }

        public void ClickPlanMyJourney()
        {
            var button = _driver.FindElement(By.CssSelector("#plan-journey-button"));
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", button);
        }

        
        public List<string> JourneyResults()
        {
            var elementsList = new List<string>().ToList();

            // Suppose you want to add all elements that match certain criteria
            var groupOneElements = new List<IWebElement>(_driver.FindElements(By.XPath("//*[@id=\"full-width-content\"]/div/div[7]/div/div[1]/a[1]")));
            var groupTwoElements = new List<IWebElement>(_driver.FindElements(By.XPath("//*[@id=\"full-width-content\"]/div/div[7]/div/div[1]/a[2]")));

            // Add all elements from both groups to the main list
            foreach (var element in groupOneElements)
            {
                elementsList.Add(element.Text);
            }

            foreach (var element in groupTwoElements)
            {
                elementsList.Add(element.Text);
            }

            return elementsList;
        }

        public void ClickOnCycling()
        {
            var cyclingButton = _driver.FindElement(By.XPath("\"//*[@id=\\\"full-width-content\\\"]/div/div[7]/div/div[1]/a[1]\""));  
                cyclingButton.Click();
        }

        public string GetCyclingTime()
        {
            Thread.Sleep(5000);
            var elements = _driver.FindElements(By.CssSelector("div.col2.journey-info > strong"));
            return elements[0].Text;
        }

        public bool PageTitle()
        {
            return _driver.FindElement(By.XPath("//*[@id=\"full-width-content\"]/div/div[2]/div/h1/span")).Displayed;
        }

        public string GetJourneyTitle(string title)
        {
            return _driver.FindElement(By.CssSelector($"div.method.{title.ToLower()}.notranslate")).Text;
        }

        public string GetWalkingTime()
        {
            Thread.Sleep(3000);
            var elements = _driver.FindElements(By.CssSelector("div.col2.journey-info > strong"));
            return elements[1].Text;
        }
                  
       
        
    }
}
