namespace Aqua.Core.Specs.EnumerableExtensionsFeatures
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TechTalk.SpecFlow;

    #endregion

    [Binding]
    public class EnumerableExtensionsSteps
    {
        private readonly ScenarioContext context;

        public EnumerableExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"I have a collection with (.*) items")]
        public void GivenIHaveACollectionWithItems(int numberOfItemsInCollection)
        {
            IEnumerable<int> collection = 1.To(numberOfItemsInCollection);
            this.context.Set(collection, "Collection");
        }

        [Given(@"I have a list with (.*) items")]
        public void GivenIHaveAListWithItems(int numberOfItemsInCollection)
        {
            var collection = 1.To(numberOfItemsInCollection).ToList();
            this.context.Set(collection, "Collection");
        }


        [When(@"I check if a collection has at least (.*) items")]
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