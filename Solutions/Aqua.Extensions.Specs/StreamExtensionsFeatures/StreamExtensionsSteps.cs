namespace Aqua.Core.Specs.StreamExtensionsFeatures
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class StreamExtensionsSteps
    {
        private readonly ScenarioContext context;

        public StreamExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"the following bytes in a stream")]
        public void GivenTheFollowingBytesInAStream(Table table)
        {
            var bytes = table.Rows.Select(r => byte.Parse(r["Value"])).ToList();
            this.context.Add("OriginalBytes", bytes);
            var stream = new MemoryStream();
            stream.Write(bytes.ToArray(), 0, bytes.Count);
            stream.Rewind();
            this.context.Add("Stream", stream);
        }

        [Then(@"the result should match")]
        public void ThenTheResultShouldMatch(Table table)
        {
            var expectedBytes = table.Rows.Select(r => byte.Parse(r["Value"])).ToList();
            List<byte> actualBytes = this.context.Get<List<byte>>("Result");
            actualBytes.Should().ContainInOrder(expectedBytes);
        }

        [When(@"I get the bytes from the stream")]
        public void WhenIGetTheBytesFromTheStream()
        {
            Stream stream = this.context.Get<Stream>("Stream");
            byte[] bytes = stream.AsBytes();
            this.context.Add("Result", bytes.ToList());
            stream.Dispose();
        }
    }
}