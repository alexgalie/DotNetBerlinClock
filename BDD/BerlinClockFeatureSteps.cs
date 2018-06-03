using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter();
        private String _theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, _berlinClock.ConvertTime(_theTime));
        }

    }
}
