﻿// <copyright file="StringExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.StringExtensionsFeature
{
    using System;
    using System.IO;
    using System.Text;
    using Corvus.Extensions;
    using Corvus.Extensions.Specs.StringExtensionsFeature.Context;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class StringExtensionsSteps
    {
        private readonly ScenarioContext context;

        public StringExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given("the current culture is (.*)")]
        public void GivenTheCurrentCultureIs(string culture)
        {
            this.context.Add("Culture", culture);
        }

        [Given("the empty string")]
        public void GivenTheEmptyString()
        {
            this.context.Add("Subject", string.Empty);
        }

        [Given("the null string")]
        public void GivenTheNullString()
        {
            this.context.Add("NullSubject", true);
        }

        [Given(@"the string ""(.*)""")]
        public void GivenTheString(string subject)
        {
            this.context.Add("Subject", subject);
        }

        [Then("an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            Assert.IsTrue(this.context.ContainsKey("Exception"));
            Assert.IsNotNull(this.context.Get<ArgumentException>("Exception"));
        }

        [Then(@"I should be able to use a big endian Unicode converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseABigEndianUnicodeConverterToReadTheStringFromTheStream(string result)
        {
            using Stream stream = this.GetRequiredResult<Stream>();
            using var reader = new StreamReader(stream, Encoding.BigEndianUnicode);
            Assert.AreEqual(result, reader.ReadToEnd());
        }

        [Then(@"I should be able to use a Unicode converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseAUnicodeConverterToReadTheStringFromTheStream(string result)
        {
            using Stream stream = this.GetRequiredResult<Stream>();
            using var reader = new StreamReader(stream, Encoding.Unicode);
            Assert.AreEqual(result, reader.ReadToEnd());
        }

        [Then(@"I should be able to use a UTF8 converter to read the string ""(.*)"" from the stream")]
        public void ThenIShouldBeAbleToUseAUTFConverterToReadTheStringFromTheStream(string result)
        {
            using Stream stream = this.GetRequiredResult<Stream>();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            Assert.AreEqual(result, reader.ReadToEnd());
        }

        [Then(@"the result should be ExampleEnum\.Second")]
        public void ThenTheResultShouldBeExampleEnum_Second()
        {
            Assert.AreEqual(ExampleEnum.Second, this.context.Get<ExampleEnum>("Result"));
        }

        [Then(@"the result should equal ""(.*)""")]
        public void ThenTheResultShouldBe(string result)
        {
            Assert.AreEqual(result, this.GetResult<string>());
        }

        [When("I base 64 encode the string")]
        public void WhenIBase64EncodeTheString()
        {
            this.SetResult(this.GetRequiredSubject().AsBase64());
        }

        [When("I base 64 decode the string")]
        public void WhenIBaseDecodeTheString()
        {
            this.SetResult(this.GetRequiredSubject().FromBase64());
        }

        [When("I base 64 decode the string with UTF16 encoding")]
        public void WhenIBaseDecodeTheStringWithUTFEncoding()
        {
            this.SetResult(this.GetRequiredSubject().FromBase64(Encoding.Unicode));
        }

        [When("I base 64 encode the string with UTF16 encoding")]
        public void WhenIBaseEncodeTheStringWithUTFEncoding()
        {
            this.SetResult(this.GetRequiredSubject().AsBase64(Encoding.Unicode));
        }

        [When("I get a big endian Unicode stream for the string")]
        public void WhenIGetABigEndianUnicodeStreamForTheString()
        {
            this.SetResult(this.GetRequiredSubject().AsStream(Encoding.BigEndianUnicode));
        }

        [When("I get a stream for the string")]
        public void WhenIGetAStreamForTheString()
        {
            this.SetResult(this.GetRequiredSubject().AsStream());
        }

        [When("I get a Unicode stream for the string")]
        public void WhenIGetAUnicodeStreamForTheString()
        {
            this.SetResult(this.GetRequiredSubject().AsStream(Encoding.Unicode));
        }

        [When("I reverse the string")]
        public void WhenIReverseTheString()
        {
            this.SetResult(this.GetRequiredSubject().Reverse());
        }

        private T GetRequiredResult<T>()
        {
            if (this.context.ContainsKey("NullResult"))
            {
                throw new InvalidOperationException("The result was null, but this test requires a non-null value");
            }

            return this.context.Get<T>("Result");
        }

        private T? GetResult<T>()
            where T : class
        {
            if (this.context.ContainsKey("NullResult"))
            {
                return default;
            }

            return this.context.Get<T>("Result");
        }

        private string GetRequiredSubject()
        {
            if (this.context.ContainsKey("NullSubject"))
            {
                throw new InvalidOperationException("The subject was null, but this test requires a non-null value");
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