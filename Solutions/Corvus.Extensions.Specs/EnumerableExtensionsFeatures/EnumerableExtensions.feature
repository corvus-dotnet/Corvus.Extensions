Feature: EnumerableExtensions
    In order to manipulate enumerations
    As a developer
    I want a variety of Linq extensions

Scenario: A collection of 5 items contains at least 5 items
    Given I have a collection with 5 items
    When I check if a collection has at least 5 items
    Then the result should be true

Scenario: A collection of 5 items contains at least 6 items
    Given I have a collection with 5 items
    When I check if a collection has at least 6 items
    Then the result should be false

Scenario: A collection of 5 items contains at least 4 items
    Given I have a collection with 5 items
    When I check if a collection has at least 4 items
    Then the result should be true

Scenario: A collection of 0 items contains at least 4 items
    Given I have a collection with 0 items
    When I check if a collection has at least 4 items
    Then the result should be false

Scenario: A collection of 0 items contains at least 0 items
    Given I have a collection with 0 items
    When I check if a collection has at least 0 items
    Then an ArgumentOutOfRangeException should be thrown

Scenario: A collection of 4 items contains at least 0 items
    Given I have a collection with 4 items
    When I check if a collection has at least 0 items
    Then an ArgumentOutOfRangeException should be thrown

Scenario: A list of 5 items contains at least 5 items
    Given I have a list with 5 items
    When I check if a collection has at least 5 items
    Then the result should be true

Scenario: A list of 5 items contains at least 6 items
    Given I have a list with 5 items
    When I check if a collection has at least 6 items
    Then the result should be false

Scenario: A list of 5 items contains at least 4 items
    Given I have a list with 5 items
    When I check if a collection has at least 4 items
    Then the result should be true

Scenario: A list of 0 items contains at least 4 items
    Given I have a list with 0 items
    When I check if a collection has at least 4 items
    Then the result should be false

Scenario: A list of 0 items contains at least 0 items
    Given I have a list with 0 items
    When I check if a collection has at least 0 items
    Then an ArgumentOutOfRangeException should be thrown

Scenario: A list of 4 items contains at least 0 items
    Given I have a list with 4 items
    When I check if a collection has at least 0 items
    Then an ArgumentOutOfRangeException should be thrown
