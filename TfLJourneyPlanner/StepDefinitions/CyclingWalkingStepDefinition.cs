using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TfLJourneyPlanner.PageObjects;

namespace TfLJourneyPlanner.StepDefinitions
{
    [Binding]
    public class CyclingWalkingStepDefinition
    {
        JourneyPlannerPageObjects _journeyPlannerObjects;
        public CyclingWalkingStepDefinition(JourneyPlannerPageObjects journeyPlannerObjects)
        {
            _journeyPlannerObjects = journeyPlannerObjects;       
        }
        [Given(@"that the user has navigated to TfL website journey planner")]
        public void GivenThatTheUserHasNavigatedToTfLWebsiteJourneyPlanner()
        {
            _journeyPlannerObjects.NavigateToTflWebSite();
        }       
        
        [When(@"the user types ""([^""]*)"" in the ""([^""]*)"" field and selects “Leicester Square Underground Station”")]
        public void WhenTheUserTypesInTheFieldAndSelectsLeicesterSquareUndergroundStation(string locationPrompt, string locationBox)
        {
            _journeyPlannerObjects.NameOfStationsContatingLeicester(locationPrompt, locationBox);
        }
        [When(@"the user enters ""([^""]*)"" in the ""([^""]*)"" field and selects “Covent Garden Underground Station”")]
        public void WhenTheUserEntersInTheFieldAndSelectsLeicesterSquareUndergroundStation(string locationPrompt, string locationBox)
        {
            _journeyPlannerObjects.NameOfStationsContatingCovent(locationPrompt, locationBox);
        }


        [Then(@"""([^""]*)"" should be polutated in the From Field")]
        public void ThenShouldBePolutatedInTheFromField(string actualStation)
        {
            var expectedStationName = _journeyPlannerObjects.DisplayStationNameOnTheAddressField();
            actualStation.Should().Be(expectedStationName); 
        
        }


        

       /* 
        public void WhenTheUserTypesInTheToField(string p0)
        {
            throw new PendingStepException();
        }*/

/*
        [Then(@"the list of stations beginning with ""([^""]*)"" from the drop down menu should be displayed")]
        public void ThenTheListOfStationsBeginningWithFromTheDropDownMenuShouldBeDisplayed(string cov)
        {
            throw new PendingStepException();
        }

        [When(@"the User selects “Covent Garden Underground Station”  from the list of displayed stations""")]
        public void WhenTheUserSelectsCoventGardenUndergroundStationFromTheListOfDisplayedStations()
        {
            throw new PendingStepException();
        }*/

        /*[Then(@"“Covent Garden Underground Station” should be polutated in the From Field""")]
        public void ThenCoventGardenUndergroundStationShouldBePolutatedInTheFromField()
        {
            throw new PendingStepException();
        }
*/
      

       

        [When(@"the User clicks on Plan my journey")]
        public void WhenTheUserClicksOnPlanMyJourney()
        {
            _journeyPlannerObjects.ClickPlanMyJourney();
        }


        [Then(@"the journey results page should be displayed")]
        public void ThenTheJourneyResultsPageShouldBeDisplayed()
        {
            _journeyPlannerObjects.PageTitle().Should().Be(true);
        }

        [Then(@"""([^""]*)"" results option should be displayed as ""([^""]*)"" mins")]
        public void ThenResultsOptionShouldBeDisplayedAs(string journeyName, string time)
        {            
            _journeyPlannerObjects.GetCyclingTime().Should().Be(time);
            _journeyPlannerObjects.GetJourneyTitle(journeyName).Should().Contain(journeyName).ToString();

        }

        [Then(@"""([^""]*)"" results option displayed as ""([^""]*)"" mins")]
        public void ThenResultsOptionDisplayedAs(string journeyName, string time)
        {
            _journeyPlannerObjects.GetWalkingTime().Should().Be(time);
            _journeyPlannerObjects.GetJourneyTitle(journeyName).Should().Contain(journeyName).ToString();

        }
        
       


    }
}
