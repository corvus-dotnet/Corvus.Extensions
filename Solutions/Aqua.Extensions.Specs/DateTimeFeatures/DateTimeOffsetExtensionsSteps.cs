namespace Aqua.Core.Specs.DateTimeOffsetFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class DateTimeOffsetExtensionsSteps
    {
        private readonly ScenarioContext context;

        public DateTimeOffsetExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"the following datetimeoffsets")]
        public void GivenTheFollowingDateTimeOffsets(Table table)
        {
            var dateTimes = table.Rows.Select(r => DateTimeOffset.Parse(r["Value"])).ToList();
            this.context.Add("DateTimeOffsets", dateTimes);
        }

        [Then(@"the datetimeoffset range should be")]
        public void ThenTheDateTimeOffsetRangeShouldBe(Table table)
        {
            var expected = table.Rows.Select(r => DateTimeOffset.Parse(r["Value"])).ToList();
            IEnumerable<DateTimeOffset> actual = this.context.Get<IEnumerable<DateTimeOffset>>("Result");
            actual.Should().Equal(expected);
        }

        [Then(@"the result should be the datetimeoffset ""(.*)""")]
        public void ThenTheResultShouldBeTheDateTimeOffset(string datetimeoffset)
        {
            this.context.Get<DateTimeOffset>("Result").Should().Be(DateTimeOffset.Parse(datetimeoffset));
        }

        [Then(@"the datetimeoffset keys should be")]
        public void ThenTheTheKeysShouldBe(Table table)
        {
            List<string> actual = this.context.Get<List<string>>("Result");
            var expected = table.Rows.Select(r => r["Value"]).ToList();
            actual.Should().Equal(expected);
        }

        [Then(@"the datetimeoffset keys should match the following with a guid")]
        public void ThenTheTheKeysShouldMatchTheFollowingWithAGuid(Table table)
        {
            List<string> actual = this.context.Get<List<string>>("Result");
            var actualStems = actual.Select(a => a.Substring(0, a.IndexOf("-") + 1)).ToList();
            var actualGuids = actual.Select(a => a.Substring(a.IndexOf("-") + 1)).ToList();
            var expected = table.Rows.Select(r => r["Value"]).ToList();
            actualStems.Should().Equal(expected);
            actualGuids.ForEach(g => Guid.TryParse(g, out Guid result).Should().BeTrue());
        }

        [When(@"I calculate the approximate difference between datetimeoffset (.*) and datetimeoffset (.*)")]
        public void WhenICalculateTheApproximateDifferenceBetweenDateTimeOffsetAndDateTimeOffset(int index1, int index2)
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            this.context.Add("Result", dateTimes[index1 - 1].CalculateApproximateTimeDifferenceFrom(dateTimes[index2 - 1]));
        }

        [When(@"I convert the datetimeoffset ""(.*)"" to a unix timestamp")]
        public void WhenIConvertTheDateTimeOffsetToAUnixTimestamp(string datetimeoffset)
        {
            this.context.Add("Result", DateTimeOffset.Parse(datetimeoffset).ToUnixTime());
        }

        [When(@"I convert the unix timestamp (.*) to a datetimeoffset")]
        public void WhenIConvertTheUnixTimestampToADateTimeOffset(long timestamp)
        {
            this.context.Add("Result", DateTimeOffsetExtensions.FromUnixTime(timestamp));
        }

        [When(@"I create a range of datetimeoffsets from ""(.*)"" to ""(.*)""")]
        public void WhenICreateARangeOfDaysFromTo(string start, string end)
        {
            this.context.Add("Result", DateTimeOffset.Parse(start).ForEachDayUntil(DateTimeOffset.Parse(end)));
        }

        [When(@"I create chronological keys for the datetimeoffsets")]
        public void WhenICreateChronologicalKeysForTheDateTimeOffsets()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateChronological()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological keys for the datetimeoffsets with a unique suffix")]
        public void WhenICreateChronologicalKeysForTheDateTimeOffsetsWithAUniqueSuffix()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateChronologicalWithUniqueSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological keys for the datetimeoffsets with the suffix '(.*)'")]
        public void WhenICreateChronologicalKeysForTheDateTimeOffsetsWithTheSuffix(string suffix)
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateChronological(suffix)).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create chronological key stems for the datetimeoffsets")]
        public void WhenICreateChronologicalKeyStemsForTheDateTimeOffsets()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateChronologicalStemForSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the datetimeoffsets")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimeOffsets()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateReverseChronological()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the datetimeoffsets with a unique suffix")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimeOffsetsWithAUniqueSuffix()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateReverseChronologicalWithUniqueSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological keys for the datetimeoffsets with the suffix '(.*)'")]
        public void WhenICreateReverseChronologicalKeysForTheDateTimeOffsetsWithTheSuffix(string suffix)
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateReverseChronological(suffix)).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I create reverse chronological key stems for the datetimeoffsets")]
        public void WhenICreateReverseChronologicalKeyStemsForTheDateTimeOffsets()
        {
            List<DateTimeOffset> dateTimes = this.context.Get<List<DateTimeOffset>>("DateTimeOffsets");
            var result = dateTimes.Select(d => d.CreateReverseChronologicalStemForSuffix()).ToList();
            this.context.Add("Result", result);
        }

        [When(@"I ask if (.*) is after (.*) with (.*)")]
        public void WhenIAskIfIsAfterWith(string t1, string t2, string granularity)
        {
            this.context.Add("Result", DateTimeOffset.Parse(t1).IsAfterWithGranularity(DateTimeOffset.Parse(t2), Enum.Parse<DateTimeOffsetGranularity>(granularity)));
        }

        [When(@"I ask if (.*) is before (.*) with (.*)")]
        public void WhenIAskIfIsBeforeWith(string t1, string t2, string granularity)
        {
            this.context.Add("Result", DateTimeOffset.Parse(t1).IsBeforeWithGranularity(DateTimeOffset.Parse(t2), Enum.Parse<DateTimeOffsetGranularity>(granularity)));
        }

        [Then(@"the answer should be (.*)")]
        public void ThenTheAnswerShouldBe(bool result)
        {
            this.context.Get<bool>("Result").Should().Be(result);
        }

    }
}