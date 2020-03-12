// <copyright file="EnumerableExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.EnumerableExtensionsFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TechTalk.SpecFlow;

    [Binding]
    public class EnumerableExtensionsSteps
    {
        private readonly ScenarioContext context;

        public EnumerableExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given("I have a collection with (.*) items")]
        public void GivenIHaveACollectionWithItems(int numberOfItemsInCollection)
        {
            IEnumerable<int> collection = Enumerable.Range(1, numberOfItemsInCollection);
            this.context.Set(collection, "Collection");
        }

        [Given("I have a list with (.*) items")]
        public void GivenIHaveAListWithItems(int numberOfItemsInCollection)
        {
            var collection = Enumerable.Range(1, numberOfItemsInCollection).ToList();
            this.context.Set(collection, "Collection");
        }

        [When("I check if a collection has at least (.*) items")]
        public void WhenICheckIfACollectionHasAtLeastItems(int minimumItemCount)
        {
            try
            {
                IEnumerable<int> collection = this.context.Get<IEnumerable<int>>("Collection");
                bool result = collection.HasMinimumCount(minimumItemCount);

                this.context.Set(result, "Result");
            }
            catch (Exception ex)
            {
                this.context.Set(ex, "Exception");
            }
        }
    }
}