Feature: StringExtensions
	In order to manipulate strings
	As a developer
	I want a variety of helper methods

Scenario: Check a null string for null or empty
	Given the null string
	When I check if the string is null or empty
	Then the result should be true

Scenario: Check an empty string for null or empty
	Given the empty string
	When I check if the string is null or empty
	Then the result should be true

Scenario: Check a string for null or empty
	Given the string "four five nine five"
	When I check if the string is null or empty
	Then the result should be false

Scenario: Add a null prefix to a string
	Given the string "four five nine five"
	When I add the prefix null
	Then the result should equal "four five nine five"

Scenario: Remove a null prefix from a string
	Given the string "four five nine five"
	When I remove the prefix null
	Then the result should equal "four five nine five"

Scenario: Add a prefix to null string
	Given the null string
	When I add the prefix "prefix"
	Then the result should equal "prefix"

Scenario: Add a prefix to a string
	Given the string "four five nine five"
	When I add the prefix "four "
	Then the result should equal "four four five nine five"

Scenario: Add an empty prefix to a string
	Given the string "four five nine five"
	When I add the prefix ""
	Then the result should equal "four five nine five"

Scenario: Add an empty prefix to an empty string
	Given the empty string
	When I add the prefix ""
	Then the result should equal the empty string

Scenario: Add an empty prefix to a null string
	Given the null string
	When I add the prefix ""
	Then the result should equal the empty string

Scenario: Add a null prefix to an empty string
	Given the empty string
	When I add the prefix null
	Then the result should equal the empty string

Scenario: Add an null prefix to a null string
	Given the null string
	When I add the prefix null
	Then the result should equal the empty string

Scenario: Add a prefix to an empty string
	Given the empty string
	When I add the prefix "prefix"
	Then the result should equal "prefix"

Scenario: Remove a prefix from a null string
	Given the null string
	When I remove the prefix "prefix"
	Then the result should equal null

Scenario: Remove a prefix from a string
	Given the string "four five nine five"
	When I remove the prefix "four "
	Then the result should equal "five nine five"

Scenario: Remove an empty prefix from a string
	Given the string "four five nine five"
	When I remove the prefix ""
	Then the result should equal "four five nine five"

Scenario: Remove a prefix from a string that does not start with the prefix
	Given the string "four five nine five"
	When I remove the prefix "notright"
	Then the result should equal "four five nine five"

Scenario: Remove a prefix from an empty string
	Given the empty string
	When I remove the prefix "prefix"
	Then the result should equal the empty string

Scenario: Parse a string to an enum case insensitively where the string matches except for case
	Given the string "SECOND"
	When I parse the string as an ExampleEnum case insensitively
	Then the result should be ExampleEnum.Second

Scenario: Parse a string to an enum case sensitively where the string matches
	Given the string "Second"
	When I parse the string as an ExampleEnum case sensitively
	Then the result should be ExampleEnum.Second

Scenario: Parse a string to an enum case sensitively where the string matches except for case
	Given the string "SECOND"
	When I parse the string as an ExampleEnum case sensitively
	Then an ArgumentException should be thrown

Scenario: Parse a string to an enum case insensitively where the enum type is not an enum
	Given the string "SECOND"
	When I parse the string as an object case insensitively
	Then an ArgumentException should be thrown

Scenario: Replace an xml tag
	Given the string "<root><first>The first</first><first /><second /></root>"
	When I replace the tag <first> with the tag <replacement>
	Then the result should equal "<root><replacement>The first</replacement><replacement /><second /></root>"

Scenario: Replace an xml tag for a null string
	Given the null string
	When I replace the tag <first> with the tag <replacement>
	Then the result should equal the empty string

Scenario: Replace an xml tag for an empty string
	Given the empty string
	When I replace the tag <first> with the tag <replacement>
	Then the result should equal the empty string

Scenario: Format a double as a string in French
	Given the current culture is fr-F
	And the string "{0:0.00}"
	When I format the double 1.23456
	Then the result should equal "1,23"

Scenario: Format a double as a string in British English
	Given the current culture is en-GB
	And the string "{0:0.00}"
	When I format the double 1.23456
	Then the result should equal "1.23"

Scenario: Take the first n characters of a null string
	Given the null string
	When I take the first 20 characters of the string
	Then the result should equal null

Scenario: Take the first n characters of an empty string
	Given the empty string
	When I take the first 20 characters of the string
	Then the result should equal the empty string

Scenario: Take the first n characters of a string with less than n characters
	Given the string "four five nine five"
	When I take the first 20 characters of the string
	Then the result should equal "four five nine five"

Scenario: Take the first n characters of a string with more than n characters
	Given the string "four five nine five"
	When I take the first 4 characters of the string
	Then the result should equal "four"

Scenario: Take the first n characters of a string with more than n characters and add ellipsis
	Given the string "four five nine five"
	When I take the first 9 characters of the string and adding ellipsis
	Then the result should equal "four f.."

Scenario: Take the first n characters of a string removing partial words
	Given the string "four five nine five"
	When I take the first 7 characters of the string removing partial words
	Then the result should equal "four"

Scenario: Take the first n characters of a string removing partial words and adding an ellipsis
	Given the string "four five nine five"
	When I take the first 7 characters of the string removing partial words and adding ellipsis
	Then the result should equal "four.."

Scenario: Take the first n characters of a string removing partial words and adding an ellipsis within the first word
	Given the string "four five nine five"
	When I take the first 6 characters of the string removing partial words and adding ellipsis
	Then the result should equal "fou.."

Scenario: Take the first n words of a null string
	Given the null string
	When I take the first 3 words of the string
	Then the result should equal the empty string

Scenario: Take the first n words of an empty string
	Given the empty string
	When I take the first 3 words of the string
	Then the result should equal the empty string

Scenario: Take the first n words of a string with fewer than n words
	Given the string "four five nine five"
	When I take the first 5 words of the string
	Then the result should equal "four five nine five"

Scenario: Take the first n words of a string with more than n words
	Given the string "four five nine five"
	When I take the first 3 words of the string
	Then the result should equal "four five nine"

Scenario: Take the first n words of a string with more than n words and add ellipsis
	Given the string "four five nine five"
	When I take the first 3 words of the string with ellipsis
	Then the result should equal "four five nine.."

Scenario: Take the first n words of a string with exactly n words and add ellipsis
	Given the string "four five nine five"
	When I take the first 4 words of the string with ellipsis
	Then the result should equal "four five nine five"

Scenario: Take the last n characters of a null string
	Given the null string
	When I take the last 3 characters of the string
	Then the result should equal the empty string

Scenario: Take the last n characters of an empty string
	Given the empty string
	When I take the last 3 characters of the string
	Then the result should equal the empty string

Scenario: Take the last n characters of a string with less than n characters
	Given the string "four five nine five"
	When I take the last 20 characters of the string
	Then the result should equal "four five nine five"

Scenario: Take the last n characters of a string with more than n characters
	Given the string "four five nine five"
	When I take the last 4 characters of the string
	Then the result should equal "five"

Scenario: Take the last n words of a null string
	Given the null string
	When I take the last 3 words of the string
	Then the result should equal the empty string

Scenario: Take the last n words of an empty string
	Given the empty string
	When I take the last 3 words of the string
	Then the result should equal the empty string

Scenario: Take the last n words of a string with fewer than n words
	Given the string "four five nine five"
	When I take the last 5 words of the string
	Then the result should equal "four five nine five"

Scenario: Take the last n words of a string with more than n words
	Given the string "four five nine five"
	When I take the last 3 words of the string
	Then the result should equal "five nine five"

Scenario: Take the first 0 words of a string
	Given the string "four five nine five"
	When I take the first 0 words of the string
	Then the result should equal the empty string

Scenario: Take the last 0 words of a string
	Given the string "four five nine five"
	When I take the last 0 words of the string
	Then the result should equal the empty string

Scenario: Take the first 0 characters of a string
	Given the string "four five nine five"
	When I take the first 0 characters of the string
	Then the result should equal the empty string

Scenario: Take the last 0 characters of a string
	Given the string "four five nine five"
	When I take the last 0 characters of the string
	Then the result should equal the empty string

Scenario: Convert a string to a base 64 encoded string
	Given the string "I will be base 64 encoded"
	When I base 64 encode the string
	Then the result should equal "SSB3aWxsIGJlIGJhc2UgNjQgZW5jb2RlZA=="

Scenario: Convert a string from a base 64 encoded string
	Given the string "SSB3YXMgYmFzZSA2NCBlbmNvZGVk"
	When I base 64 decode the string
	Then the result should equal "I was base 64 encoded"

Scenario: Convert a string to a base 64 encoded UTF16 string
	Given the string "I will be base 64 encoded"
	When I base 64 encode the string with UTF16 encoding
	Then the result should equal "SQAgAHcAaQBsAGwAIABiAGUAIABiAGEAcwBlACAANgA0ACAAZQBuAGMAbwBkAGUAZAA="

Scenario: Convert a string from a base 64 encoded UTF16 string
	Given the string "SQAgAHcAYQBzACAAYgBhAHMAZQAgADYANAAgAGUAbgBjAG8AZABlAGQA"
	When I base 64 decode the string with UTF16 encoding
	Then the result should equal "I was base 64 encoded"

Scenario: Reverse a string
	Given the string "The quick brown fox jumped over the lazy dog"
	When I reverse the string
	Then the result should equal "god yzal eht revo depmuj xof nworb kciuq ehT"

Scenario: Reverse a string in arabic (this translates to 'From Wikipedia, the free encyclopedia')
	Given the string "از ویکی‌پدیا، دانشنامهٔ آزاد"
	When I reverse the string
	Then the result should equal "دازآ هٔمانشناد ،ایدپ‌یکیو زا"

Scenario: Get a UTF8 stream from a string
	Given the string "The quick brown fox jumped over the lazy dog"
	When I get a stream for the string
	Then I should be able to use a UTF8 converter to read the string "The quick brown fox jumped over the lazy dog" from the stream

Scenario: Get a Unicode stream from a string
	Given the string "The quick brown fox jumped over the lazy dog"
	When I get a Unicode stream for the string
	Then I should be able to use a Unicode converter to read the string "The quick brown fox jumped over the lazy dog" from the stream

Scenario: Get a big-endian Unicode stream from a string
	Given the string "The quick brown fox jumped over the lazy dog"
	When I get a big endian Unicode stream for the string
	Then I should be able to use a big endian Unicode converter to read the string "The quick brown fox jumped over the lazy dog" from the stream

Scenario: Get a UTF8 stream from a string in arabic
	Given the string "از ویکی‌پدیا، دانشنامهٔ آزاد"
	When I get a stream for the string
	Then I should be able to use a UTF8 converter to read the string "از ویکی‌پدیا، دانشنامهٔ آزاد" from the stream

Scenario: Get a Unicode stream from a string in arabic
	Given the string "از ویکی‌پدیا، دانشنامهٔ آزاد"
	When I get a Unicode stream for the string
	Then I should be able to use a Unicode converter to read the string "از ویکی‌پدیا، دانشنامهٔ آزاد" from the stream

Scenario: Get a big-endian Unicode stream from a string in arabic
	Given the string "از ویکی‌پدیا، دانشنامهٔ آزاد"
	When I get a big endian Unicode stream for the string
	Then I should be able to use a big endian Unicode converter to read the string "از ویکی‌پدیا، دانشنامهٔ آزاد" from the stream
