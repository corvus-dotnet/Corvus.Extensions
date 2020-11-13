Feature: TaskExWhenAllMany
	In order to fan out tasks and collect all of the results
	As a developer
	I want a combination of Task.WhenALl and SelectMany

Background:
	Given I have a collection with 5 items
	When I invoke TaskEx.WhenAllMany

Scenario: Mapping function invoked for all items
	Then the mapping function should have been invoked for all items

Scenario: Mapping function invoked concurrently
	Then the mapping function should have been invoked concurrently

Scenario: Results from all items in the final result
	Then the results from all items should be in the final result

Scenario: Results produced in consistent order
	Then the results should be ordered by the original collection order
	And for each original item the results should be in the order that the mapping function returned them