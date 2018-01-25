# OneOf
[![Build status](https://ci.appveyor.com/api/projects/status/h67jylh563m71kaq/branch/DiscU?svg=true)](https://ci.appveyor.com/project/jamesbascle/oneof/branch/DiscU)
[![NuGet version](https://badge.fury.io/nu/DiscU.svg)](https://badge.fury.io/nu/DiscU)
[![NuGet Status](http://nugetstatus.com/DiscU.png)](http://nugetstatus.com/packages/DiscU)



> install-package OneOf


This library provides F# style discriminated unions for C#, using a custom type ```OneOf<T0, ... Tn>```. An instance of this type holds a single value, which is one of the types in its generic argument list.

News
---

Version 1.0.0

* Great speed improvements, greater than 100% in most cases, and up to 800% in some!

* .When method added, though not perfectly type safe.  Next thing to work on though.


Use cases
-------

You can use this as a parameter type, allowing a caller to pass different types without requiring additional overloads. This might not seem that useful for a single parameter, but if you have multiple parameters, the number of overloads required increases rapidly.

```C#

// This method can be called with either a string, a ColorName enum value or a Color instance.
public void SetBackground(OneOf<string, ColorName, Color> backgroundColor) { ... }

```
Or as a return type, giving the ability to return strongly typed results without having to implement a type with a common base type or interface:

```C#
public OneOf<User, InvalidName, NameTaken> CreateUser(string username)
{
    if (!IsValid(username)) return new InvalidName();
    
    var user = _repo.FindByUsername(username);
    if (user != null) return new NameTaken();
    
    var user = new User(username);
    _repo.Save(user);
    
    return user;
}

```

Matching
-------

`Match` is used for translating the value depending on it's type.  Each Match must translate the value to the same type.
When all cases are handled the last call to `Match` returns the result.    
```C#
OneOf<string, ColorName, Color> backgroundColor = ...;

Color c = backgroundColor
   .Match((string str) => CssHelper.GetColorFromString(str))
   .Match((ColorName name) => new Color(name))
   .Match((Color col) => col)
```
`Else` can be used to return a default value when nothing matches.
```C#
Color c2 = backgroundColor
   .Match((Color col) => col)
   .Else(obj => /* return default value */)

Color c2 = backgroundColor
   .Match((Color col) => col)
   .Else(/* default value*/)
```
`ElseThrow` can be used to create an exception to throw when nothing matches.
```C#
Color c3 = backgroundColor
   .Match((Color col) => col)
   .ElseThrow(obj => new InvalidOperationException("this will be thrown when not Color"))
```

Switching
-------

You use the `Switch` methods along with `Else` and `ElseThrow` methods to execute specific actions based on the value's type. E.g.

```C#
OneOf<string, NotFound, ErrX, ErrY, Etc> fileContents = ReadFile(fileName)
    .Switch((string contents) => /* handle success */)
    .Switch((NotFound notFound) => /* handle file not found */)
    .Else(object x => /* handle other types */)
    
OneOf<string, NotFound, ErrX, ErrY, Etc> fileContents = ReadFile(fileName)
    .Switch((string contents) => /* handle success */)
    .Switch((NotFound notFound) => /* handle file not found */)
    .ElseThrow(x => /* return Exception to throw when not handled above by any Switch's */);
```

ToOneOf
-------

The `ToOneOf` method enables conversion to other OneOfs. E.g.

```C#
OneOf<True,False> trueOrFalse = True;

// this will work as the new OneOf supports True
OneOf<True,False,Unknown> success = trueOrFalse.ToOneOf<True,False,Unknown>();

// this will fail at runtime as the new OneOf doesn't support True
// (compile-time checks not yet available, yet to figure out how to do that)
OneOf<False, Unknown> fail = trueOrFalse.ToOneOf<False, Unknown>();
```
