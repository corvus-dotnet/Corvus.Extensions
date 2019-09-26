# Corvus.Extensions
[![Build Status](https://dev.azure.com/endjin-labs/Corvus.Extensions/_apis/build/status/corvus-dotnet.Corvus.Extensions?branchName=master)](https://dev.azure.com/endjin-labs/Corvus.Extensions/_build/latest?definitionId=4&branchName=master)
[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/corvus-dotnet/Corvus.Extensions/master/LICENSE)
[![IMM](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/total?cache=false)](https://endimmfuncdev.azurewebsites.net/api/imm/github/corvus-dotnet/Corvus.Extensions/total?cache=false)

This provides a library of useful extensions to .NET types.

It is built for netstandard2.0.

## Features

### Casting
There is an efficient `Cast<>` which avoids boxing for value types, derived from [this StackOverflow answer](https://stackoverflow.com/a/23391746).

This is commonly used in generic scenarios.

Consider this interface

```
public interface IEntityInstance
{
  /// <summary>
  /// Gets or sets the entity.
  /// </summary>
  object Entity { get; set; }}
```

and its strongly-typed generic counterpart

```
public interface IEntityInstance<T> : IEntityInstance
{
  /// <summary>
  /// Gets or sets the entity of the given type.
  /// </summary>
  new T Entity { get; set; }
}
```

In the implementation, we will see code like this

```
public sealed class EntityInstance<T> : IEntityInstance<T>
{
  /// <summary>
  /// Gets or sets the entity.
  /// </summary>
  public T Entity { get; set; }
  
  object IEntityInstance.Entity
  {
    get => this.Entity;
    set => this.Entity = CastTo<T>.From(value);
  }
}
```

`CastTo` supports a wide range of conversions with good efficiency trade-offs, including scenarios where `(T)(object)value` will fail.

### Collections

An `AddRange()` extension for `ICollection<T>`

```
ICollection<int> someCollection;

var myList = new List<int> { 1,2,3,4 };
someCollection.AddRange(myList);
```

### Dictionary

#### `AddIfNotExists()`

Adds a value to a key, if the key does not already exist.

```
var myDictionary = new Dictionary<string, int> { { "Hello", 1 }, { "World", 2 } };

myDictionary.AddIfNotExists("Hello", 3); // returns false, does not add to dictionary
myDictionary.AddIfNotExists("Goodbye", 3); // returns true, adds to dictionary
```

#### `ReplaceIfExists()`

Replaces a value in a key, but only if the key already exists.

```
var myDictionary = new Dictionary<string, int> { { "Hello", 1 }, { "World", 2 } };

myDictionary.ReplaceIfExists("Hello", 3); // returns true, sets "Hello" to 3
myDictionary.ReplaceIfExists("Goodbye", 3); // returns false, does not add to dictionary
```

#### `Merge()` 

The union of two dictionaries. Note that this uses `AddIfNotExists()` semantics, so the values in the first dictionary will be preserved.

```
var myDictionary1 = new Dictionary<string, int> { { "Hello", 1 }, { "World", 2 } };
var myDictionary2 = new Dictionary<string, int> { { "Hello", 3 }, { "Goodbye", 4 } };

myDictionary1.Merge(myDictionary2);

// Results in:
// { { "Hello", 1 }, { "World", 2 }, { "Goodbye", 4 } }

``` 

### Enumerable

#### `DistinctPreserveOrder()`

This emits an enumerable of the distinct items in the target, preserving their original ordering.

For example.

```
var list = new List<int> { 1, 2, 3, 2, 4, 5, 6, 3 };
var result = list.DistinctPreserveOrder();

// Results in:

{ 1, 2, 3, 4, 5, 6 }
```

#### `DistinctBy()`

This allows you to provide a function to provide the value for equality comparison for each item.

```
class SomeType
{
  public string Prop1 { get; set; }
  public int Prop2 { get; set; }
}

var list = new List<SomeType> { new SomeType { Prop1 = "Hello", Prop2 = 1 }, new SomeType { Prop1 = "Hello", Prop2 = 3 }, new SomeType { Prop1 = "World", Prop2 = 1 } };
var result = list.DistinctBy(i => i.Prop1);

// Results in:

{ {"Hello", 1}, {"World", 1} }
```

- Concatenation
- Minimum count
- An efficient implementation of `enum.Any() && enum.All(predicate)` that avoids starting the enumeration twice

### LambdaExpression

- Extract a `MemberExpression` from a lambda expression
- Extract a property name from a (property) lambda expression

### ListExtensions

- Remove all items from the list that match a predicate

### String

- Get as a stream in various encodings
- Base64 encode/decode (with or without URL safety)
- Reverse
- To camel case

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

Our other Open Source projects can be found on [GitHub](https://endjin.com/open-source)

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
