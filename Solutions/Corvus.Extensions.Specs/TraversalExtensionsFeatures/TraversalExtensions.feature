Feature: TraversalExtensions
	In order to manipulate enumerations
	As a developer
	I want a variety of Linq extensions

Scenario: A collection is enumerated with foreach
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreach add to another collection 
	Then Collection 2 should match Collection 1

Scenario: A collection is enumerated with foreach with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreach with no action
	Then an ArgumentNullException should be thrown for parameter "onNext"

Scenario: A collection is enumerated with foreachatindex
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachatindex add to another collection
	Then Collection 2 should match Collection 1
	And each index should be passed in order

Scenario: A collection is enumerated with foreachatindex with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachatindex with no action
	Then an ArgumentNullException should be thrown for parameter "action"

Scenario: A collection is enumerated with foreachfailend
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailend add to another collection 
	Then Collection 2 should match Collection 1

Scenario: A collection is enumerated with foreachfailend with a failing action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailend with a failing action
	Then an Aggregate exception should be thrown containing 5 "InvalidOperationException" instances

Scenario: A collection is enumerated with foreachfailend with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailend with no action
	Then an ArgumentNullException should be thrown for parameter "action"

Scenario: A null collection is enumerated with foreach
	When I enumerate a null collection with foreach
	Then an ArgumentNullException should be thrown for parameter "source"

Scenario: A null collection is enumerated with foreachfailend
	When I enumerate a null collection with foreachfailend
	Then a NullReferenceException should be thrown

Scenario: A null collection is enumerated with foreachatindex
	When I enumerate a null collection with foreachatindex
	Then a NullReferenceException should be thrown

Scenario: A collection is enumerated with foreachasync
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachasync add to another collection 
	Then Collection 2 should match Collection 1

Scenario: A collection is enumerated with foreachasync with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachasync with no action
	Then an ArgumentNullException should be thrown for parameter "action"

Scenario: A null collection is enumerated with foreachasync
	When I enumerate a null collection with foreachasync
	Then a NullReferenceException should be thrown

Scenario: A collection is enumerated with foreachfailendasync
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailendasync add to another collection 
	Then Collection 2 should match Collection 1

Scenario: A collection is enumerated with foreachfailendasync with a failing action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailendasync with a failing action
	Then an Aggregate exception should be thrown containing 5 "InvalidOperationException" instances

Scenario: A collection is enumerated with foreachfailendasync with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachfailendasync with no action
	Then an ArgumentNullException should be thrown for parameter "action"

Scenario: A null collection is enumerated with foreachfailendasync
	When I enumerate a null collection with foreachfailendasync
	Then a NullReferenceException should be thrown


Scenario: A collection is enumerated with foreachatindexasync
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachatindexasync add to another collection 
	Then Collection 2 should match Collection 1
	And each index should be passed in order

Scenario: A collection is enumerated with foreachatindexasync with no action
	Given the following collections
	| Collection | Value       |
	| 1          | 1           |
	| 1          | 2           |
	| 1          | 3           |
	| 1          | 4           |
	| 1          | 5           |
	When I enumerate collection 1 with foreachatindexasync with no action
	Then an ArgumentNullException should be thrown for parameter "action"

Scenario: A null collection is enumerated with foreachatindexasync
	When I enumerate a null collection with foreachatindexasync
	Then a NullReferenceException should be thrown


Scenario: When you merge two dictionaries
	Given the following dictionaries
	| Dictionary | Key | Value |
	| 1          | 1   | 3     |
	| 1          | 4   | 1     |
	| 1          | 5   | 2     |
	| 2          | 1   | 1     |
	| 2          | 2   | 3     |
	| 2          | 3   | 5     |
	| 2          | 4   | 3     |
	| 3          | 1   | 1     |
	| 3          | 2   | 3     |
	| 3          | 3   | 5     |
	| 3          | 4   | 3     |
	| 3          | 5   | 2     |
	When I merge Dictionary 1 with Dictionary 2
	Then Dictionary 2 should equal Dictionary 3