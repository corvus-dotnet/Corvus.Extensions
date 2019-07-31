# Aqua.Extensions

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

Aqua.Extensions is available under the Microsoft Public License (MS-PL) open source license. The Aqua.Extensions open source license is ideal for use cases such as open source projects with open source distribution, student/academic purposes, hobby projects, internal research projects without external distribution, or other projects where all Microsoft Public License obligations can be met. 

For any licensing questions, please email

## Project Sponsor

This project is sponsored by [endjin](https://endjin.com), a UK based Microsoft Gold Partner for Cloud Platform, Data Platform, Data Analytics, DevOps, and a Power BI Partner.

For more information about our products and services, or for commercial support of this project, please [contact us](https://endjin.com/contact-us). 

We produce two free weekly newsletters; [Azure Weekly](https://azureweekly.info) for all things about the Microsoft Azure Platform, and [Power BI Weekly](https://powerbiweekly.info).

Keep up with everything that's going on at endjin via our [blog](https://blogs.endjin.com/), follow us on [Twitter](https://twitter.com/endjin), or [LinkedIn](https://www.linkedin.com/company/1671851/).

Our other Open Source projects can be found on [GitHub](https://github.com/endjin)

## Code of conduct

This project has adopted a code of conduct adapted from the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. This code of conduct has been [adopted by many other projects](http://contributor-covenant.org/adopters/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;](&#109;&#097;&#105;&#108;&#116;&#111;:&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;) with any additional questions or comments.
