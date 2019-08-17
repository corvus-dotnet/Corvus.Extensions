# Corvus.Extensions
[![Build Status](https://dev.azure.com/endjin-labs/Corvus.Extensions/_apis/build/status/corvus-dotnet.Corvus.Extensions?branchName=master)](https://dev.azure.com/endjin-labs/Corvus.Extensions/_build/latest?definitionId=4&branchName=master)
[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/corvus-dotnet/Corvus.Extensions/master/LICENSE)
[![IMM](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/total?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/total?cache=false)

This provides a library of useful extensions to dotnet types.

It is built for netstandard2.0.

## Features

### Casting
There is an efficient `Cast<>` which avoids boxing for value types.

### Collections

An `AddRange()` extension for `ICollection<T>`

### DateTime and DateTimeOffset

- create time ranged enumerables (e.g. by day)
- `Math.Min()` and `Math.Max()` equivalents for time
- comparison functions with optional granularity (e.g. year, month, week, decade)
- approximate time differences (typically for display purposes)
- sortable chronological and reverse-chronological timestamp strings with and without prefixes
- end of day, last day of month
- quick week number calculation for the current `DateTimeInfo`
- UNIX time conversion
- `DateTimeWithTimezone` type which stores actual time zone information alongside a `DateTime`

If you have more complex date time requirements, we strongly recommend you look at [NodaTime](https://nodatime.org/)

### Dictionary

- Add and Replace if there is no item for the given key
- Merge two dictionaries (preserving the original value if already present)

### Enumerable

- `Distinct()` preserving ordering, or with a predicate
- Concatenation
- Minimum count
- An efficient implementation of `enum.Any() && enum.All(predicate)` that avoids starting the enumeration twice

### FileStream

- Read all bytes in a file into a buffer (of up to 2GB)

### Integer

- Create an integer range from a start value to an end value (like `Enumerable.Range()` but where you know the desired start and end values)

### LambdaExpression

- Extract a `MemberExpression` from a lambda expression
- Extract a property name from a (property) lambda expression

### ListExtensions

- Remove all items from the list that match a predicate

### Stream

- Flush and rewind the stream
- Read as bytes
- Read as a string in various encodings

### String

- Get as a stream in various encodings
- Get the first n characters/words with optional ellipsis
- Base64 encode/decode (with or without URL safety)
- Reverse
- To camel case
- Add/remove prefix or suffix
- Replace XML tags in a string (safely; requires valid XML)

### Task

- Casts `Task`/`Task<?>` to `Task<T>` result type with or without a cast of the actual result value

### Traversals

Various `ForEach` extensions, including:

- async methods
- aggregating and delaying exceptions until the end of the traversal
- with indexing
- until predicates are true/false

## Licenses

[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/corvus-dotnet/Corvus.Extensions/master/LICENSE)

Corvus.Extensions is available under the Apache 2.0 open source license.

For any licensing questions, please email [&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;](&#109;&#97;&#105;&#108;&#116;&#111;&#58;&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;)

## Project Sponsor

This project is sponsored by [endjin](https://endjin.com), a UK based Microsoft Gold Partner for Cloud Platform, Data Platform, Data Analytics, DevOps, and a Power BI Partner.

For more information about our products and services, or for commercial support of this project, please [contact us](https://endjin.com/contact-us). 

We produce two free weekly newsletters; [Azure Weekly](https://azureweekly.info) for all things about the Microsoft Azure Platform, and [Power BI Weekly](https://powerbiweekly.info).

Keep up with everything that's going on at endjin via our [blog](https://blogs.endjin.com/), follow us on [Twitter](https://twitter.com/endjin), or [LinkedIn](https://www.linkedin.com/company/1671851/).

Our other Open Source projects can be found on [GitHub](https://github.com/endjin)

## Code of conduct

This project has adopted a code of conduct adapted from the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. This code of conduct has been [adopted by many other projects](http://contributor-covenant.org/adopters/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;](&#109;&#097;&#105;&#108;&#116;&#111;:&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;) with any additional questions or comments.

## IP Maturity Matrix (IMM)

The IMM is endjin's IP quality framework.

[![Shared Engineering Standards](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/74e29f9b-6dca-4161-8fdd-b468a1eb185d?nocache=true)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/74e29f9b-6dca-4161-8fdd-b468a1eb185d?cache=false)

[![Coding Standards](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/f6f6490f-9493-4dc3-a674-15584fa951d8?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/f6f6490f-9493-4dc3-a674-15584fa951d8?cache=false)

[![Executable Specifications](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/bb49fb94-6ab5-40c3-a6da-dfd2e9bc4b00?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/bb49fb94-6ab5-40c3-a6da-dfd2e9bc4b00?cache=false)

[![Code Coverage](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/0449cadc-0078-4094-b019-520d75cc6cbb?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/0449cadc-0078-4094-b019-520d75cc6cbb?cache=false)

[![Benchmarks](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/64ed80dc-d354-45a9-9a56-c32437306afa?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/64ed80dc-d354-45a9-9a56-c32437306afa?cache=false)

[![Reference Documentation](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/2a7fc206-d578-41b0-85f6-a28b6b0fec5f?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/2a7fc206-d578-41b0-85f6-a28b6b0fec5f?cache=false)

[![Design & Implementation Documentation](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/f026d5a2-ce1a-4e04-af15-5a35792b164b?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/f026d5a2-ce1a-4e04-af15-5a35792b164b?cache=false)

[![How-to Documentation](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/145f2e3d-bb05-4ced-989b-7fb218fc6705?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/145f2e3d-bb05-4ced-989b-7fb218fc6705?cache=false)

[![Date of Last IP Review](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/da4ed776-0365-4d8a-a297-c4e91a14d646?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/da4ed776-0365-4d8a-a297-c4e91a14d646?cache=false)

[![Framework Version](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/6c0402b3-f0e3-4bd7-83fe-04bb6dca7924?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/6c0402b3-f0e3-4bd7-83fe-04bb6dca7924?cache=false)

[![Associated Work Items](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/79b8ff50-7378-4f29-b07c-bcd80746bfd4?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/79b8ff50-7378-4f29-b07c-bcd80746bfd4?cache=false)

[![Source Code Availability](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/30e1b40b-b27d-4631-b38d-3172426593ca?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/30e1b40b-b27d-4631-b38d-3172426593ca?cache=false)

[![License](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/d96b5bdc-62c7-47b6-bcc4-de31127c08b7?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/d96b5bdc-62c7-47b6-bcc4-de31127c08b7?cache=false)

[![Production Use](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/87ee2c3e-b17a-4939-b969-2c9c034d05d7?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/87ee2c3e-b17a-4939-b969-2c9c034d05d7?cache=false)

[![Insights](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/71a02488-2dc9-4d25-94fa-8c2346169f8b?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/71a02488-2dc9-4d25-94fa-8c2346169f8b?cache=false)

[![Packaging](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/547fd9f5-9caf-449f-82d9-4fba9e7ce13a?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/547fd9f5-9caf-449f-82d9-4fba9e7ce13a?cache=false)

[![Deployment](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/edea4593-d2dd-485b-bc1b-aaaf18f098f9?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/rule/edea4593-d2dd-485b-bc1b-aaaf18f098f9?cache=false)