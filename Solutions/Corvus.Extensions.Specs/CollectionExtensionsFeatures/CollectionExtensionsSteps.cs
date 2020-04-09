// <copyright file="CollectionExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.CollectionExtensionsFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class CollectionExtensionsSteps
    {
        private ICollection<int>? destination;
        private List<int>? source;

        [Given(@"I have a destination list containing (.*)")]
        public void GivenIHaveADestinationListContaining(List<int> listContents)
        {
            this.destination = listContents;
        }

        [Given(@"I have a source list containing (.*)")]
        public void GivenIHaveASourceListContaining(List<int> listContents)
        {
            this.source = listContents;
        }

        [When(@"I call AddRange on the destination list passing in the source list")]
        public void WhenICallAddRangeOnTheDestinationListPassingInTheSourceList()
        {
            this.destination!.AddRange(this.source!);
        }

        [Then(@"the destination should now be (.*)")]
        public void ThenTheDestinationShouldNowBe(List<int> listContents)
        {
            Assert.IsTrue(Enumerable.SequenceEqual(this.destination, listContents));
        }

        [StepArgumentTransformation]
        public List<int> TransformToListOfInt(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
        }
    }
}
