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
    public class VoidLocationStepDefinitions
    {
        [Given(@"the User Clicks on ""([^""]*)""")]
        public void GivenTheUserClicksOn(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"error messages should be displayed beneath the From and To fields ""([^""]*)""")]
        public void ThenErrorMessagesShouldBeDisplayedBeneathTheFromAndToFields(string p0)
        {
            throw new PendingStepException();
        }
    }
}
