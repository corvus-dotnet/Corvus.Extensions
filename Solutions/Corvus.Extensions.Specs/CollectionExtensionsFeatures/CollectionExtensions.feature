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

Scenario: Add list to null
    Given I have a null destination list
    And I have a source list containing 1, 2, 3
    When I call AddRange on the destination list passing in the source list expecting an exception
    Then AddRange should have thrown an ArgumentNullException

Scenario: Add null to list
    Given I have a destination list containing 1, 2, 3
    And I have a null source list
    When I call AddRange on the destination list passing in the source list expecting an exception
    Then AddRange should have thrown an ArgumentNullException

Scenario: Add a list to itself
    Given I have a destination list containing 1, 2, 3
    And I use the destination list as the source list
    When I call AddRange on the destination list passing in the source list expecting an exception
    Then AddRange should have thrown an ArgumentException