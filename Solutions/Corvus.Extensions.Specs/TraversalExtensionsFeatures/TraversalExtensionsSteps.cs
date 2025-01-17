// <copyright file="TraversalExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.TraversalExtensionsFeature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.Extensions;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class TraversalExtensionsSteps
    {
        private readonly ScenarioContext context;

        public TraversalExtensionsSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given("the following collections")]
        public void GivenTheFollowingCollections(Table table)
        {
            IEnumerable<IGrouping<string, DataTableRow>> collections = table.Rows.GroupBy(r => r["Collection"]);
            var result = new List<List<string>>();
            foreach (IGrouping<string, DataTableRow> collection in collections)
            {
                result.Add(collection.Select(r => r["Value"]).ToList());
            }

            this.context.Add("Collections", result);
        }

        [Given("the following dictionaries")]
        public void GivenTheFollowingDictionaries(Table table)
        {
            IEnumerable<IGrouping<string, DataTableRow>> dictionaries = table.Rows.GroupBy(r => r["Dictionary"]);
            var result = new List<Dictionary<int, int>>();
            foreach (IGrouping<string, DataTableRow> dictionary in dictionaries)
            {
                result.Add(dictionary.Select(r => new { v = int.Parse(r["Value"]), k = int.Parse(r["Key"]) }).ToDictionary(key => key.k, value => value.v));
            }

            this.context.Add("Dictionaries", result);
        }

        [Given("the following integer collections")]
        public void GivenTheFollowingIntegerCollections(Table table)
        {
            IEnumerable<IGrouping<string, DataTableRow>> collections = table.Rows.GroupBy(r => r["Collection"]);
            var result = new List<List<int>>();
            foreach (IGrouping<string, DataTableRow> collection in collections)
            {
                result.Add(collection.Select(r => int.Parse(r["Value"])).ToList());
            }

            this.context.Add("Collections", result);
        }

        [Then(@"an Aggregate exception should be thrown containing (.*) ""(.*)"" instances")]
        public void ThenAnAggregateExceptionShouldBeThrownContainingInstances(int count, string exceptionTypeName)
        {
            Exception ex = this.context.Get<Exception>("Exception");
            Assert.IsAssignableFrom<AggregateException>(ex);
            var aex = (AggregateException)ex;
            Assert.AreEqual(count, aex.Flatten().InnerExceptions.Count);
            aex.Flatten().InnerExceptions.ForEach(ie => Assert.AreEqual(exceptionTypeName, ie.GetType().Name));
        }

        [Then(@"an ArgumentNullException should be thrown for parameter ""(.*)""")]
        public void ThenAnArgumentNullExceptionShouldBeThrownForParameter(string parameterName)
        {
            Exception exception = this.context.Get<Exception>("Exception");
            Assert.IsInstanceOf<ArgumentNullException>(exception);
            var ane = (ArgumentNullException)exception;
            Assert.AreEqual(parameterName, ane.ParamName);
        }

        [Then("an ArgumentNullException should be thrown")]
        public void ThenANullReferenceExceptionShouldBeThrown()
        {
            Exception exception = this.context.Get<Exception>("Exception");
            Assert.IsInstanceOf<ArgumentNullException>(exception);
        }

        [Then("Collection (.*) should match Collection (.*)")]
        public void ThenCollectionShouldMatchCollection(int index1, int index2)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index1 - 1];
            List<string> c2 = collections[index2 - 1];
            Assert.AreEqual(c2, c1);
        }

        [Then("Dictionary (.*) should equal Dictionary (.*)")]
        public void ThenDictionaryShouldBeDictionary(int index1, int index2)
        {
            List<Dictionary<int, int>> dictionaries = this.context.Get<List<Dictionary<int, int>>>("Dictionaries");
            Dictionary<int, int> d1 = dictionaries[index1 - 1];
            Dictionary<int, int> d2 = dictionaries[index2 - 1];
            CollectionAssert.AreEqual(d2.OrderBy(k => k.Key), d1.OrderBy(k => k.Key));
        }

        [Then("each index should be passed in order")]
        public void ThenEachIndexShouldBePassedInOrder()
        {
            List<int> indices = this.context.Get<List<int>>("Indices");
            int expectedIndexCount = this.context.Get<int>("ExpectedIndexCount");
            CollectionAssert.AreEqual(Enumerable.Range(0, expectedIndexCount), indices);
        }

        [Then("The range should match collection (.*)")]
        public void ThenTheRangeShouldMatchCollection(int index)
        {
            List<List<int>> collections = this.context.Get<List<List<int>>>("Collections");
            List<int> c1 = collections[index - 1];
            IEnumerable<int> range = this.context.Get<IEnumerable<int>>("Range");
            CollectionAssert.AreEqual(c1, range);
        }

        [When("I enumerate a null collection with foreach")]
        public void WhenIEnumerateANullCollectionWithForeach()
        {
            try
            {
                ((IEnumerable<string>)null!).ForEach(_ => this.Nop());
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate a null collection with foreachasync")]
        public async Task WhenIEnumerateANullCollectionWithForeachasync()
        {
            try
            {
                IEnumerable<string> collection = null!;
                await collection.ForEachAsync(_ => Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate a null collection with foreachatindex")]
        public void WhenIEnumerateANullCollectionWithForeachatindex()
        {
            try
            {
                ((IEnumerable<string>)null!).ForEachAtIndex((_, __) => this.Nop());
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate a null collection with foreachatindexasync")]
        public async Task WhenIEnumerateANullCollectionWithForeachatindexasync()
        {
            try
            {
                await ((IEnumerable<string>)null!).ForEachAtIndexAsync((_, __) => Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate a null collection with foreachfailend")]
        public void WhenIEnumerateANullCollectionWithForeachfailend()
        {
            try
            {
                ((IEnumerable<string>)null!).ForEachFailEnd(_ => this.Nop());
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate a null collection with foreachfailendasync")]
        public async Task WhenIEnumerateANullCollectionWithForeachfailendasync()
        {
            try
            {
                await ((IEnumerable<string>)null!).ForEachFailEndAsync(_ => Task.CompletedTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreach add to another collection")]
        public void WhenIEnumerateCollectionWithForeachAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            var c1 = (IEnumerable<string>)collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            c1.ForEach(i => result.Add(i));
        }

        [When("I enumerate collection (.*) with foreachasync add to another collection")]
        public async Task WhenIEnumerateCollectionWithForeachasyncAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            var c1 = (IEnumerable<string>)collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            await c1.ForEachAsync(i =>
            {
                result.Add(i);
                return Task.CompletedTask;
            }).ConfigureAwait(false);
        }

        [When("I enumerate collection (.*) with foreachasync with no action")]
        public async Task WhenIEnumerateCollectionWithForeachasyncWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                await ((IEnumerable<string>)c1).ForEachAsync(null!).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachatindex add to another collection")]
        public void WhenIEnumerateCollectionWithForeachatindexAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            var indices = new List<int>();
            this.context.Add("Indices", indices);
            this.context.Add("ExpectedIndexCount", c1.Count);
            collections.Add(result);
            ((IEnumerable<string>)c1).ForEachAtIndex((e, i) =>
            {
                result.Add(e);
                indices.Add(i);
            });
        }

        [When("I enumerate collection (.*) with foreachatindexasync add to another collection")]
        public async Task WhenIEnumerateCollectionWithForeachatindexasyncAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            var indices = new List<int>();
            this.context.Add("Indices", indices);
            this.context.Add("ExpectedIndexCount", c1.Count);
            collections.Add(result);
            await ((IEnumerable<string>)c1).ForEachAtIndexAsync((e, i) =>
            {
                result.Add(e);
                indices.Add(i);
                return Task.CompletedTask;
            }).ConfigureAwait(false);
        }

        [When("I enumerate collection (.*) with foreachatindexasync with no action")]
        public async Task WhenIEnumerateCollectionWithForeachatindexasyncWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                await ((IEnumerable<string>)c1).ForEachAtIndexAsync(null!).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachatindex with no action")]
        public void WhenIEnumerateCollectionWithForeachatindexWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                ((IEnumerable<string>)c1).ForEachAtIndex(null!);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachfailend add to another collection")]
        public void WhenIEnumerateCollectionWithForeachfailendAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            var c1 = (IEnumerable<string>)collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            c1.ForEachFailEnd(i => result.Add(i));
        }

        [When("I enumerate collection (.*) with foreachfailendasync add to another collection")]
        public async Task WhenIEnumerateCollectionWithForeachfailendasyncAddToAnotherCollection(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            var c1 = (IEnumerable<string>)collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            await c1.ForEachFailEndAsync(i =>
            {
                result.Add(i);
                return Task.CompletedTask;
            }).ConfigureAwait(false);
        }

        [When("I enumerate collection (.*) with foreachfailendasync with a failing action")]
        public async Task WhenIEnumerateCollectionWithForeachfailendasyncWithAFailingAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];

            try
            {
                await ((IEnumerable<string>)c1).ForEachFailEndAsync(_ => throw new InvalidOperationException()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachfailendasync with no action")]
        public async Task WhenIEnumerateCollectionWithForeachfailendasyncWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                await ((IEnumerable<string>)c1).ForEachFailEndAsync(null!).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachfailend with a failing action")]
        public void WhenIEnumerateCollectionWithForeachfailendWithAFailingAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];

            try
            {
                ((IEnumerable<string>)c1).ForEachFailEnd(_ => throw new InvalidOperationException());
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreachfailend with no action")]
        public void WhenIEnumerateCollectionWithForeachfailendWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                ((IEnumerable<string>)c1).ForEachFailEnd(null!);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I enumerate collection (.*) with foreach with no action")]
        public void WhenIEnumerateCollectionWithForeachWithNoAction(int index)
        {
            List<List<string>> collections = this.context.Get<List<List<string>>>("Collections");
            List<string> c1 = collections[index - 1];
            var result = new List<string>();
            collections.Add(result);
            try
            {
                ((IEnumerable<string>)c1).ForEach((Action<string>)null!);
            }
            catch (Exception ex)
            {
                this.context.Add("Exception", ex);
            }
        }

        [When("I merge Dictionary (.*) with Dictionary (.*)")]
        public void WhenIMergeDictionaryWithDictionary(int index1, int index2)
        {
            List<Dictionary<int, int>> dictionaries = this.context.Get<List<Dictionary<int, int>>>("Dictionaries");
            Dictionary<int, int> d1 = dictionaries[index1 - 1];
            Dictionary<int, int> d2 = dictionaries[index2 - 1];
            d2.Merge(d1);
        }

        [Then("the result should be true")]
        public void ThenTheResultShouldBeTrue()
        {
            Assert.IsTrue(this.context.Get<bool>("Result"));
        }

        [Then("the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            Assert.IsFalse(this.context.Get<bool>("Result"));
        }

        [Then("an ArgumentOutOfRangeException should be thrown")]
        public void ThenAnArgumentOutOfRangeExceptionShouldBeThrown()
        {
            Assert.IsTrue(this.context.ContainsKey("Exception"));
            Assert.IsNotNull(this.context.Get<ArgumentOutOfRangeException>("Exception"));
        }

        private void Nop()
        {
        }
    }
}