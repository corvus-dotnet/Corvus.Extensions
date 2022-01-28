// <copyright file="TaskExWhenAllManySteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.TaskExFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Corvus.Extensions.Tasks;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class TaskExWhenAllManySteps
    {
        private readonly ScenarioContext context;
        private readonly object mapperLock = new();
        private readonly List<(int SourceItem, IList<(int, string)> Result)> mapperInvocationsAndResults = new();
        private IList<(int SourceItem, string Result)>? result;
        private int mappersInProgress = 0;
        private int maxMappersInProgress = 0;

        public TaskExWhenAllManySteps(ScenarioContext context)
        {
            this.context = context;
        }

        private IEnumerable<int> Collection => this.context.Get<IEnumerable<int>>("Collection");

        [When(@"I invoke TaskEx\.WhenAllMany")]
        public async Task WhenIInvokeTaskEx_WhenAllManyAsync()
        {
            var countdown = new Barrier(this.Collection.Count());

            async Task<IEnumerable<(int, string)>> Mapper(int sourceItem)
            {
                lock (this.mapperLock)
                {
                    this.mappersInProgress++;
                    this.maxMappersInProgress = Math.Max(this.maxMappersInProgress, this.mappersInProgress);
                }

                await Task.Run(() => countdown.SignalAndWait(TimeSpan.FromSeconds(5))).ConfigureAwait(false);

                var result = Enumerable.Range(0, sourceItem).Select(i => (sourceItem, $"{i}!")).ToList();

                lock (this.mapperLock)
                {
                    this.mapperInvocationsAndResults.Add((sourceItem, result));

                    this.mappersInProgress--;
                }

                return result;
            }

            this.result = await TaskEx.WhenAllMany(this.Collection, Mapper).ConfigureAwait(false);
        }

        [Then("the mapping function should have been invoked for all items")]
        public void ThenTheMappingFunctionShouldHaveBeenInvokedForAllItems()
        {
            Assert.AreEqual(this.Collection.Count(), this.mapperInvocationsAndResults.Count);
        }

        [Then("the mapping function should have been invoked concurrently")]
        public void ThenTheMappingFunctionShouldHaveBeenInvokedConcurrently()
        {
            Assert.AreEqual(this.Collection.Count(), this.maxMappersInProgress);
        }

        [Then("the results from all items should be in the final result")]
        public void ThenTheResultsFromAllItemsShouldBeInTheFinalResult()
        {
            IEnumerable<(int, string)> expectedResults = this.mapperInvocationsAndResults.SelectMany(r => r.Result);

            CollectionAssert.AreEquivalent(expectedResults, this.result);
        }

        [Then("the results should be ordered by the original collection order")]
        public void ThenTheResultsShouldBeOrderedByTheOriginalCollectionOrder()
        {
            IEnumerable<int> groupedResults = this.result.GroupBy(r => r.SourceItem).Select(g => g.Key);

            CollectionAssert.AreEqual(this.Collection, groupedResults);
        }

        [Then("for each original item the results should be in the order that the mapping function returned them")]
        public void ThenForEachOriginalItemTheResultsShouldBeInTheOrderThatTheMappingFunctionReturnedThem()
        {
            var groupedResults = this.result.GroupBy(r => r.SourceItem).ToDictionary(x => x.Key, x => x.ToList());
            Dictionary<int, IList<(int SourceItem, string Result)>> expectedResults = this.mapperInvocationsAndResults.ToDictionary(x => x.SourceItem, x => x.Result);

            foreach (int i in this.Collection)
            {
                CollectionAssert.AreEqual(expectedResults[i], groupedResults[i]);
            }
        }
    }
}