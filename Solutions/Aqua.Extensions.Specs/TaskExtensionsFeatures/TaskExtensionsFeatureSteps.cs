namespace Endjin.Extensions.Specs.TaskExtensionsFeatures
{
    using System;
    using System.Threading.Tasks;
    using Endjin.Extensions.Specs.TaskExtensionsFeatures.Context;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class TaskExtensionsFeatureSteps
    {
        private readonly ScenarioContext context;

        public TaskExtensionsFeatureSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"I start a task which generates an integer value (.*)")]
        public void GivenIStartATaskWhichGeneratesAnIntegerValue(int p0)
        {
            this.context.Set<Task>(Task.FromResult(p0), "SourceTask");
        }

        [Given(@"I start a task with no result")]
        public void GivenIStartATaskWithNoResult()
        {
            this.context.Set(Task.CompletedTask, "SourceTask");
        }

        [When(@"I cast the task to an integer")]
        public async void WhenICastTheTaskToAnInt()
        {
            Task sourceTask = this.context.Get<Task>("SourceTask");

            try
            {
                Task<int> result = sourceTask.CastWithConversion<int>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }

        [Then(@"the task result should be an integer value (.*)")]
        public async Task ThenTheTaskResultShouldBeADoubleValue(int p0)
        {
            Task<int> task = this.context.Get<Task<int>>("Result");
            int result = await task;
            result.Should().Be(p0);
        }

        [When(@"I cast the task to a double")]
        public async void WhenICastTheTaskToAnDouble()
        {
            Task sourceTask = this.context.Get<Task>("SourceTask");

            try
            {
                Task<double> result = sourceTask.CastWithConversion<double>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }

        [Then(@"an InvalidCastException should be thrown")]
        public void ThenAnInvalidCastExceptionShouldBeThrown()
        {
            this.context.ContainsKey("Exception").Should().BeTrue();
            this.context.Get<InvalidCastException>("Exception").Should().NotBeNull();
        }

        [Given(@"I start a task which generates a SimpleChild")]
        public void GivenIStartATaskWhichGeneratesASimpleChild()
        {
            this.context.Set<Task<SimpleChild>>(Task.FromResult(new SimpleChild()), "SourceTask");
        }

        [Given(@"I start a task which generates a SimpleParent")]
        public void GivenIStartATaskWhichGeneratesASimpleParent()
        {
            this.context.Set<Task<SimpleParent>>(Task.FromResult(new SimpleParent()), "SourceTask");
        }

        [When(@"I cast the task to a SimpleChild")]
        public async Task WhenICastTheTaskToASimpleChild()
        {
            Task<SimpleParent> sourceTask = this.context.Get<Task<SimpleParent>>("SourceTask");

            try
            {
                Task<SimpleChild> result = sourceTask.CastWithConversion<SimpleChild>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }


        [When(@"I cast the task to a SimpleParent")]
        public async void WhenICastTheTaskToASimpleParent()
        {
            Task<SimpleChild> sourceTask = this.context.Get<Task<SimpleChild>>("SourceTask");
            try
            {
                Task<SimpleParent> result = sourceTask.CastWithConversion<SimpleParent>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }

        [When(@"I cast from a Task to a SimpleParent")]
        public async Task WhenICastFromATaskToASimpleParent()
        {
            Task sourceTask = this.context.Get<Task<SimpleChild>>("SourceTask");

            try
            {
                Task<SimpleParent> result = sourceTask.Cast<SimpleParent>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }

        [When(@"I cast from a Task to a SimpleChild")]
        public async Task WhenICastFromATaskToASimpleChild()
        {
            Task sourceTask = this.context.Get<Task<SimpleParent>>("SourceTask");

            try
            {
                Task<SimpleChild> result = sourceTask.Cast<SimpleChild>();
                this.context.Set(result, "Result");
                await result;
            }
            catch (InvalidCastException ex)
            {
                await sourceTask;
                this.context.Set(ex, "Exception");
            }
        }


        [Then(@"the task result should be a SimpleParent")]
        public async void ThenTheTaskResultShouldBeASimpleParent()
        {
            if (this.context.ContainsKey("Result"))
            {
                Task<SimpleParent> task = this.context.Get<Task<SimpleParent>>("Result");
                SimpleParent result = await task;
                result.Should().BeAssignableTo<SimpleParent>();
            }
        }
    }
}
