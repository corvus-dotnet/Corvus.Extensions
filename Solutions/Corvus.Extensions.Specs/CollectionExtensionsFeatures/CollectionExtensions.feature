Feature: CollectionExtensions
	In order to manipulate collections
	As a developer
	I want extension methods

Scenario Outline: Add a list to an existing list
	Given I have a destination list containing <DestinationInitialContents>
	And I have a source list containing <SourceInitialContents>
	When I call AddRange on the destination list passing in the source list
	Then the destination should now be <ExpectedResult>

	Examples:
	| DestinationInitialContents | SourceInitialContents | ExpectedResult   |
	| 1, 2, 3                    | 4, 5, 6               | 1, 2, 3, 4, 5, 6 |
	| 1, 2, 3                    |                       | 1, 2, 3          |
	|                            | 4, 5, 6               | 4, 5, 6          |
	|                            |                       |                  |
	| 1, 2, 3                    | 2, 3, 4               | 1, 2, 3, 2, 3, 4 |



# Multiple Target collection types
# Empty vs non-empty initial target collections
# Empty vs non-empty initial source collections
# Source items overlap with target items
# Null argument tests
# Calling AddRange on itself