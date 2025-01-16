Feature: StringExtensions
	In order to manipulate strings
	As a developer
	I want a variety of helper methods

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
	Then the result should equal "دازآ هٔمانشناد ،ایدپی‌کیو زا"

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
