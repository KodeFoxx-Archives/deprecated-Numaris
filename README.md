# Numaris
A toolset to validate, format, parse and generate structured (organisational, government, ...) numbers/codes.

Build status | Test status
--- | --- 
[![Build status](https://ci.appveyor.com/api/projects/status/ylx7kd61ro7cqbpu/branch/master?svg=true)](https://ci.appveyor.com/project/aredfox/numaris/branch/master) | [![Test status](http://flauschig.ch/batch.php?type=tests&account=aredfox&slug=numaris)](https://ci.appveyor.com/project/aredfox/numaris/build/tests)

## How & what?
Numaris is build around the idea of a specification. This means that you make a marker class for your number, e.g. `IbanNumberSpecification`. You then implement the specification further by making specifications for fields, e.g. `CheckDigitsFieldSpecification`. Those field specifications carry an order, which is used for parsing, validation etc.. In essence, you build up a number in code, or in other words you "specify" your number characteristics.

The API is designed for flexible use of Dependency Injection. Every formatter, parser, generator you create you can link to either a `NumberSpecification` or a `FieldSpecification`. This makes it that you have to implement as little as possible and can leave the boilerplate code behind, and focus on the real implementation details.

## Formatting
Formatters have a method `Format(string)`. This method first uses the parser defined for the number specification. If there is no number defined it will pass it on the the `Format(string[])` method. The latter method does the formatting work, where it takes each string and formats it accordingly.
### Example
See FormattingExample.cs https://github.com/KodeFoxx/Numaris/blob/master/Source/Frontend/Kf.Numaris.Presentation.ConsoleApplicationExample/FormattingExample.cs

## Parsing
StringParsers are the parsers that are used intsensively inside the API, although they're optional, if you want to use Formatting for example it is recommended to implement a StringParser for your NumberSpecification. Their purpose is to parse a input string into an array of strings which either a Formatter or Validator can use later on in the process.
### Example
See ParsingExample.cs
https://github.com/KodeFoxx/Numaris/blob/master/Source/Frontend/Kf.Numaris.Presentation.ConsoleApplicationExample/ParsingExample.cs

## Validation
Todo

## Generation
Todo
