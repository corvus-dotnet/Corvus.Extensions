// <copyright file="CollectionExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Extensions.Specs.CollectionExtensionsFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Reqnroll;

    [Binding]
    public class CollectionExtensionsSteps
    {
        private ICollection<int>? destination;
        private List<int>? source;
        private Exception? exception;

        [Given("I have a destination list containing (.*)")]
        public void GivenIHaveADestinationListContaining(List<int> listContents)
        {
            this.destination = listContents;
        }

        [Given("I have a null destination list")]
        public void GivenIHaveANullDestinationList()
        {
            this.destination = null;
        }

        [Given("I have a source list containing (.*)")]
        public void GivenIHaveASourceListContaining(List<int> listContents)
        {
            this.source = listContents;
        }

        [Given("I have a null source list")]
        public void GivenIHaveANullSourceList()
        {
            this.source = null;
        }

        [Given("I use the destination list as the source list")]
        public void GivenIUseTheDestinationListAsTheSourceList()
        {
            this.source = (List<int>?)this.destination;
        }

        [When("I call AddRange on the destination list passing in the source list")]
        public void WhenICallAddRangeOnTheDestinationListPassingInTheSourceList()
        {
            this.destination!.AddRange(this.source!);
        }

        [When("I call AddRange on the destination list passing in the source list expecting an exception")]
        public void WhenICallAddRangeOnTheDestinationListPassingInTheSourceListExpectingAnException()
        {
            try
            {
                this.WhenICallAddRangeOnTheDestinationListPassingInTheSourceList();
            }
            catch (ArgumentException ex)
                when (ex.GetType() == typeof(ArgumentException)
                   || ex.GetType() == typeof(ArgumentNullException))
            {
                this.exception = ex;
            }
        }

        [Then("the destination should now be (.*)")]
        public void ThenTheDestinationShouldNowBe(List<int> listContents)
        {
            CollectionAssert.AreEqual(listContents, this.destination);
        }

        [Then("AddRange should have thrown an ArgumentNullException")]
        public void ThenAddRangeShouldHaveThrownAnArgumentNullException()
        {
            Assert.IsInstanceOf<ArgumentNullException>(this.exception);
        }

        [Then("AddRange should have thrown an ArgumentException")]
        public void ThenAddRangeShouldHaveThrownAnArgumentException()
        {
            Assert.IsInstanceOf<ArgumentException>(this.exception);
        }

        [StepArgumentTransformation]
        public List<int> TransformToListOfInt(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(text => int.Parse(text)).ToList();
        }
    }
}