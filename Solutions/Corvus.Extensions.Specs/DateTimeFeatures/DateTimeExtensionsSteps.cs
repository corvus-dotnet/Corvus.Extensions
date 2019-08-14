namespace Corvus.Core.Specs.DateTimeFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class DateTimeExtensionsSteps
    {
        private readonly ScenarioContext context;

        public DateTimeExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"the following datetimes")]
        public void GivenTheFollowingDatetimes(Table table)
        {
            var dateTimes = table.Rows.Select(r => DateTime.Parse(r["Value"])).ToList();
            this.context.Add("DateTimes", dateTimes);
        }

        [Then(@"the approximate difference should be ""(.*)""")]
        public void ThenTheApproximateDifferenceShouldBe(string difference)
        {
            this.context.Get<string>("Result").Should().Be(difference);
        }

        [Then(@"the date range should be")]
        public void ThenTheDateRangeShouldBe(Table table)
        {
            var expected = table.Rows.Select(r => DateTime.Parse(r["Value"])).ToList();
            IEnumerable<DateTime> actual = this.context.Get<IEnumerable<DateTime>>("Result");
            actual.Should().Equal(expected);
        }

        [Then(@"the result should be the datetime ""(.*)""")]
        public void ThenTheResultShouldBeTheDatetime(DateTime datetime)
        {
            this.context.Get<DateTime>("Result").Should().Be(datetime);
        }

        [Then(@"the result should be the unix timestamp (.*)")]
        public void ThenTheResultShouldBeTheUnixTimestamp(long timestamp)
        {
            this.context.Get<long>("Result").Should().Be(timestamp);
        }

        [Then(@"the the keys should be")]
        public void ThenTheTheKeysShouldBe(Table table)
        {
            List<string> actual = this.context.Get<List<string>>("Result");
            var expected = table.Rows.Select(r => r["Value"]).ToList();
            actual.Should().Equal(expected);
        }

        [Then(@"the the keys should match the following with a guid")]
        public void ThenTheTheKeysShouldMatchTheFollowingWithAGuid(Table table)
        {
            List<string> actual = this.context.Get<List<string>>("Result");
            var actualStems = actual.Select(a => a.Substring(0, a.IndexOf("-") + 1)).ToList();
            var actualGuids = actual.Select(a => a.Substring(a.IndexOf("-") + 1)).ToList();
            var expected = table.Rows.Select(r => r["Value"]).ToList();
            actualStems.Should().Equal(expected);
            actualGuids.ForEach(g => Guid.TryParse(g, out Guid result).Should().BeTrue());
        }

        [When(@"I calculate the approximate difference between datetime (.*) and datetime (.*)")]
        public void WhenICalculateTheApproximateDifferenceBetweenDatetimeAndDatetime(int index1, int index2)
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            this.context.Add("Result", dateTimes[index1 - 1].CalculateApproximateTimeDifferenceFrom(dateTimes[index2 - 1]));
        }

        [When(@"I convert the datetime ""(.*)"" to a unix timestamp")]
        public void WhenIConvertTheDatetimeToAUnixTimestamp(DateTime datetime)
        {
            this.context.Add("Result", datetime.ToUnixTime());
        }

        [When(@"I convert the unix timestamp (.*) to a datetime")]
        public void WhenIConvertTheUnixTimestampToADatetime(long timestamp)
        {
            this.context.Add("Result", DateTimeExtensions.FromUnixTime(timestamp));
        }

        [When(@"I create a range of days from ""(.*)"" to ""(.*)""")]
        public void WhenICreateARangeOfDaysFromTo(DateTime start, DateTime end)
        {
            this.context.Add("Result", start.ForEachDayUntil(end));
        }

        [When(@"I create chronological keys for the date times")]
        public void WhenICreateChronologicalKeysForTheDateTimes()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateChronological()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological keys for the date times with a unique suffix")]
        public void WhenICreateChronologicalKeysForTheDateTimesWithAUniqueSuffix()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateChronologicalWithUniqueSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological keys for the date times with the suffix '(.*)'")]
        public void WhenICreateChronologicalKeysForTheDateTimesWithTheSuffix(string suffix)
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateChronological(suffix)).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological key stems for the date times")]
        public void WhenICreateChronologicalKeyStemsForTheDateTimes()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateChronologicalStemForSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the date times")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimes()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateReverseChronological()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the date times with a unique suffix")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimesWithAUniqueSuffix()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateReverseChronologicalWithUniqueSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the date times with the suffix '(.*)'")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimesWithTheSuffix(string suffix)
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateReverseChronological(suffix)).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological key stems for the date times")]
        public void WhenICreateReverseChronologicalKeyStemsForTheDateTimes()
        {
            List<DateTime> dateTimes = this.context.Get<List<DateTime>>("DateTimes");
            var result = dateTimes.Select(d => d.CreateReverseChronologicalStemForSuffix()).ToList();
            this.context.Add("Result", result);
        }
    }
}