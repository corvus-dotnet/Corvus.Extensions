// <copyright file="CollectionBindings.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.SharedBindings
{
    using System.Collections.Generic;
    using System.Linq;

    using TechTalk.SpecFlow;

    [Binding]
    public class CollectionBindings
    {
        private readonly ScenarioContext context;

        public CollectionBindings(ScenarioContext context)
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
    }
}