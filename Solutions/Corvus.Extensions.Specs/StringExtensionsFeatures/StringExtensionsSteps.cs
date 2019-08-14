namespace Corvus.Core.Specs.StringExtensionsFeature
{
    using Corvus.Core.Specs.StringExtensionsFeature.Context;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using TechTalk.SpecFlow;
    using FluentAssertions;

    [Binding]
    public class StringExtensionsSteps
    {
        private readonly ScenarioContext context;

        public StringExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"the current culture is (.*)")]
        public void GivenTheCurrentCultureIs(string culture)
        {
            this.context.Add("Culture", culture);
        }

        [Given(@"the empty string")]
        public void GivenTheEmptyString()
        {
            this.context.Add("Subject", string.Empty);
        }

        [Given(@"the null string")]
        public void GivenTheNullString()
        {
            this.context.Add("NullSubject", true);
        }

        [Given(@"the string ""(.*)""")]
        public void GivenTheString(string subject)
        {
            this.context.Add("Subject", subject);
        }

        [Then(@"an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            this.context.ContainsKey("Exception").Should().BeTrue();
            this.context.Get<ArgumentException>("Exception").Should().NotBeNull();
        }

        [Then(@"I should be able to use a big endian Unicode converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseABigEndianUnicodeConverterToReadTheStringFromTheStream(string result)
        {
            using (Stream stream = this.GetResult<Stream>())
            {
                stream.AsString(Encoding.BigEndianUnicode).Should().Be(result);
            }
        }

        [Then(@"I should be able to use a Unicode converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseAUnicodeConverterToReadTheStringFromTheStream(string result)
        {
            using (Stream stream = this.GetResult<Stream>())
            {
                stream.AsString(Encoding.Unicode).Should().Be(result);
            }
        }

        [Then(@"I should be able to use a UTF8 converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseAUTFConverterToReadTheStringFromTheStream(string result)
        {
            using (Stream stream = this.GetResult<Stream>())
            {
                stream.AsString().Should().Be(result);
            }
        }

        [Then(@"the result should be ExampleEnum\.Second")]
        public void ThenTheResultShouldBeExampleEnum_Second()
        {
            this.context.Get<ExampleEnum>("Result").Should().Be(ExampleEnum.Second);
        }

        [Then(@"the result should equal ""(.*)""")]
        public void ThenTheResultShouldBe(string result)
        {
            this.GetResult<string>().Should().Be(result);
        }

        [Then(@"the result should equal null")]
        public void ThenTheResultShouldBeNull()
        {
            this.GetResult<string>().Should().BeNull();
        }

        [Then(@"the result should equal the empty string")]
        public void ThenTheResultShouldBeTheEmptyString()
        {
            this.GetResult<string>().Should().BeEmpty();
        }

        [When(@"I add the prefix ""(.*)""")]
        public void WhenIAddThePrefix(string prefix)
        {
            this.SetResult(this.GetSubject().AddPrefix(prefix));
        }

        [When(@"I add the prefix null")]
        public void WhenIAddThePrefixNull()
        {
            this.SetResult(this.GetSubject().AddPrefix(null));
        }

        [When(@"I base 64 encode the string")]
        public void WhenIBase64EncodeTheString()
        {
            this.SetResult(this.GetSubject().AsBase64());
        }

        [When(@"I base 64 decode the string")]
        public void WhenIBaseDecodeTheString()
        {
            this.SetResult(this.GetSubject().FromBase64());
        }

        [When(@"I base 64 decode the string with UTF16 encoding")]
        public void WhenIBaseDecodeTheStringWithUTFEncoding()
        {
            this.SetResult(this.GetSubject().FromBase64(Encoding.Unicode));
        }

        [When(@"I base 64 encode the string with UTF16 encoding")]
        public void WhenIBaseEncodeTheStringWithUTFEncoding()
        {
            this.SetResult(this.GetSubject().AsBase64(Encoding.Unicode));
        }

        [When(@"I check if the string is null or empty")]
        public void WhenICheckIfTheStringIsNullOrEmpty()
        {
            this.SetResult(this.GetSubject().IsNullOrEmpty());
        }

        [When(@"I format the double (.*)")]
        public void WhenIFormatTheDouble(double value)
        {
            bool changeCulture = this.context.ContainsKey("Culture");
            if (changeCulture)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(this.context.Get<string>("Culture"));
            }
            this.SetResult(this.GetSubject().FormatWith(value));
        }

        [When(@"I get a big endian Unicode stream for the string")]
        public void WhenIGetABigEndianUnicodeStreamForTheString()
        {
            this.SetResult(this.GetSubject().AsStream(Encoding.BigEndianUnicode));
        }

        [When(@"I get a stream for the string")]
        public void WhenIGetAStreamForTheString()
        {
            this.SetResult(this.GetSubject().AsStream());
        }

        [When(@"I get a Unicode stream for the string")]
        public void WhenIGetAUnicodeStreamForTheString()
        {
            this.SetResult(this.GetSubject().AsStream(Encoding.Unicode));
        }

        [When(@"I parse the string as an ExampleEnum case insensitively")]
        public void WhenIParseTheStringAsAnExampleEnumCaseInsensitively()
        {
            try
            {
                this.SetResult(this.GetSubject().ConvertToEnum<ExampleEnum>(false));
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When(@"I parse the string as an ExampleEnum case sensitively")]
        public void WhenIParseTheStringAsAnExampleEnumCaseSensitively()
        {
            try
            {
                this.SetResult(this.GetSubject().ConvertToEnum<ExampleEnum>(true));
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When(@"I parse the string as an object case insensitively")]
        public void WhenIParseTheStringAsAnObjectCaseInsensitively()
        {
            try
            {
                this.SetResult(this.GetSubject().ConvertToEnum<object>(false));
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When(@"I remove the prefix ""(.*)""")]
        public void WhenIRemoveThePrefix(string prefix)
        {
            this.SetResult(this.GetSubject().StripPrefix(prefix));
        }

        [When(@"I remove the prefix null")]
        public void WhenIRemoveThePrefixNull()
        {
            this.SetResult(this.GetSubject().StripPrefix(null));
        }

        [When(@"I replace the tag <(.*)> with the tag <(.*)>")]
        public void WhenIReplaceTheTagWithTheTag(string match, string replace)
        {
            this.SetResult(this.GetSubject().ReplaceXmlTags(match, replace));
        }

        [When(@"I reverse the string")]
        public void WhenIReverseTheString()
        {
            this.SetResult(this.GetSubject().Reverse());
        }

        [When(@"I take the first (.*) characters of the string")]
        public void WhenITakeTheFirstCharactersOfTheString(int count)
        {
            this.SetResult(this.GetSubject().FirstNCharacters(count));
        }

        [When(@"I take the first (.*) characters of the string and adding ellipsis")]
        public void WhenITakeTheFirstCharactersOfTheStringAndAddingEllipsis(int count)
        {
            this.SetResult(this.GetSubject().FirstNCharacters(count, TruncationOptions.AddEllipsis));
        }

        [When(@"I take the first (.*) characters of the string removing partial words")]
        public void WhenITakeTheFirstCharactersOfTheStringRemovingPartialWords(int count)
        {
            this.SetResult(this.GetSubject().FirstNCharacters(count, TruncationOptions.RemovePartialWords));
        }

        [When(@"I take the first (.*) characters of the string removing partial words and adding ellipsis")]
        public void WhenITakeTheFirstCharactersOfTheStringRemovingPartialWordsAndAddingEllipsis(int count)
        {
            this.SetResult(this.GetSubject().FirstNCharacters(count, TruncationOptions.RemovePartialWords | TruncationOptions.AddEllipsis));
        }

        [When(@"I take the first (.*) words of the string")]
        public void WhenITakeTheFirstWordsOfTheString(int count)
        {
            this.SetResult(this.GetSubject().FirstNWords(count));
        }

        [When(@"I take the first (.*) words of the string with ellipsis")]
        public void WhenITakeTheFirstWordsOfTheStringWithEllipsis(int count)
        {
            this.SetResult(this.GetSubject().FirstNWords(count, TruncationOptions.AddEllipsis));
        }

        [When(@"I take the last (.*) characters of the string")]
        public void WhenITakeTheLastCharactersOfTheString(int count)
        {
            this.SetResult(this.GetSubject().LastNCharacters(count));
        }

        [When(@"I take the last (.*) words of the string")]
        public void WhenITakeTheLastWordsOfTheString(int count)
        {
            this.SetResult(this.GetSubject().LastNWords(count));
        }

        private T GetResult<T>()
        {
            if (this.context.ContainsKey("NullResult"))
            {
                return default;
            }
            return this.context.Get<T>("Result");
        }

        private string GetSubject()
        {
            if (this.context.ContainsKey("NullSubject"))
            {
                return null;
            }
            return this.context.Get<string>("Subject");
        }

        private void SetResult(object result)
        {
            if (result == null)
            {
                this.context.Add("NullResult", true);
            }
            else
            {
                this.context.Add("Result", result);
            }
        }
    }
}