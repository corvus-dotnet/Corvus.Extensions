Feature: TaskExtensionsFeature
	In order to convert the return type of a task, but retain a Task
	As a developer
	I want to be able to cast from a Task[<T1<] to a Task<T2>

Scenario: Cast from a Task between compatible value types
	Given I start a task which generates an integer value 1
	When I cast the task to an integer
	Then the task result should be an integer value 1

Scenario: Cast from a Task between incompatible value types
	Given I start a task which generates an integer value 1
	When I cast the task to a double
	Then an InvalidCastException should be thrown

Scenario: Cast from a Task which has no result
	Given I start a task with no result
	When I cast the task to a double
	Then an InvalidCastException should be thrown

Scenario: Cast from a Task between compatible reference types
	Given I start a task which generates a SimpleChild
	When I cast the task to a SimpleParent
	Then the task result should be a SimpleParent

Scenario: Cast from a Task between incompatible reference types
	Given I start a task which generates a SimpleParent
	When I cast the task to a SimpleChild
	Then an InvalidCastException should be thrown

Scenario: Cast from a simple Task between compatible reference types
	Given I start a task which generates a SimpleChild
	When I cast from a Task to a SimpleParent
	Then the task result should be a SimpleParent

Scenario: Cast from a simple Task between incompatible reference types
	Given I start a task which generates a SimpleParent
	When I cast from a Task to a SimpleChild
	Then an InvalidCastException should be thrown
