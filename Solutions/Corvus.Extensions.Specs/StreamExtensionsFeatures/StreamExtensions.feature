Feature: StreamExtensions
	In order to make common stream patterns more usable
	As a developer
	I want to be able to convert various types of object to a string

Scenario: Convert a stream to a byte array
	Given the following bytes in a stream
	| Value |
	| 1     |
	| 10    |
	| 2     |
	| 8     |
	| 255   |
	| 0     |
	| 42    |
	| 42    |
	When I get the bytes from the stream
	Then the result should match
	| Value |
	| 1     |
	| 10    |
	| 2     |
	| 8     |
	| 255   |
	| 0     |
	| 42    |
	| 42    |