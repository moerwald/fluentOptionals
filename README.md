![fluentOptionals](https://raw.githubusercontent.com/duffleit/fluentOptionals/master/fluentOptionals.png)


# Fluent Optionals [![NuGet](https://img.shields.io/nuget/v/FluentOptionals.svg)](https://www.nuget.org/packages/FluentOptionals) [![Build status](https://ci.appveyor.com/api/projects/status/bn58b7k9xeh9073a?svg=true)](https://ci.appveyor.com/project/duffleit/fluentoptionals) [![Build Status](https://travis-ci.org/duffleit/fluentOptionals.svg)](https://travis-ci.org/duffleit/fluentOptionals) [![Coverage Status](https://coveralls.io/repos/github/duffleit/fluentOptionals/badge.svg?branch=master)](https://coveralls.io/github/duffleit/fluentOptionals?branch=master)


**A lightweight optionals implementation based on .Net Standard:**

```csharp   
//creating an optional
Optional<string> some = Optional.Some("Marty McFly");
Optional<string> none = Optional.None<string>();

//receiving it's value
string name = some.ValueOr("unknown Person");

//pattern matching approach
optional.Match(
    some: name => Console.WriteLine("hey, " + name),
    none: ()   => Console.WriteLine("we don't know your name")
)

```

Check out the __[complete documentation](https://github.com/duffleit/fluentOptionals/wiki)__ of FluentOptionals.