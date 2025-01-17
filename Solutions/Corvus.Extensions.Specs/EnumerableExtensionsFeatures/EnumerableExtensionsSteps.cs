// <copyright file="EnumerableExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.EnumerableExtensionsFeatures
{
    using System;
    using System.Collections.Generic;
    using Reqnroll;

    [Binding]
    public class EnumerableExtensionsSteps
    {
        private readonly ScenarioContext context;

        public EnumerableExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
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