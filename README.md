# Zoervleis
!["Logo Zoervleis"](https://raw.githubusercontent.com/RichardPoes/Zoervleis/refs/heads/main/assets/Icon.png)


Zoervleis is a C# tool to convert hashes into human-readable and human-friendly strings.
At the moment this is done in one of two ways.
One can use `HumanHash` to convert a hash into a sequence of words.
One can also use `DigitHash` to turn a hash into a sequence of integers.
Although `DigitHash` is more information dense, `HumanHash` provides a better way for humans to remember the words and detect errors themselves.

## Index
- [Example](#example)
- [When to use](#when-to-use)
- [Etymology](#etymology)
- [To-Do](#to-do)
- [License](#license)
- [Attributions](#attributions)

## Example
We can use `HumanHash` as follows
```csharp
var toHash = "Hello World"u8.ToArray();
var hash = SHA256.HashData(toHash);

var humanizedString = HumanHash.Humanize(hash);

// Output will be "orange-monkey-oranges-steak-asparagus-white"
Console.WriteLine(humanizedString); 
```

We can use `DigitHash` as follows
```csharp
var toHash = "Hello World"u8.ToArray();
var hash = SHA256.HashData(toHash);

var humanizedString = DigitHash.Digitize(hash);

// Output will be "11109-73930-84387-59824-87079"
Console.WriteLine(humanizedString); 
```

## Why
The reason this package was built was as follows:
we generated contracts for sub-clients of our client A.
These contracts were automatically generated and the final appearance of that contract would be influenced by around 100 data-points supplied by the sub-client.
The sub-clients could generate intermediate contracts.
Once they were happy with the result, they could sign the contract and upload it again to our platform.

However, client A wanted to be sure that they uploaded a contract containing the most recent data they filled in.
This is where `Zoervleis` comes in. 
On every generated contract there is a human-readable and human-friendly hash code.
During upload of the contract a sub-client needs to provide that code.
We can then check whether the humanized hash is the same as the humanized hash we calculate on the back-end from the most recent data.

## Etymology
The word [Zoervleis](https://en.wikipedia.org/wiki/Zoervleis) might seem strange.
It is the [Limburgian](https://en.wikipedia.org/wiki/Limburgish) name for a traditional stewed dish from there.
The food is also referred to as a form of [Hachée](https://en.wikipedia.org/wiki/Hach%C3%A9e).
Here we start to see the connection with this library:

> The word hachée in French means chopped or ground, being the past participle of the verb hacher - to chop or grind.

This word has the same etymology as the word hash.
Hence the name of the library.

## To do
The following list includes ideas for what I still want to implement.
I am open for suggestions.

- [ ] Multiple languages
- [ ] Custom dictionary support
- [ ] Arbitrary length dictionaries
- [ ] Error detection methods
- [ ] Dependency injection support
- [ ] Support for hashing-and-humanizing in one

## License
This project is licensed under the MIT license.

## Attributions
- This package is heavily inspired on the Python package [humanhash](https://github.com/zacharyvoase/humanhash).
- [Cauldron icon](assets/Icon.svg) was based off a creation by [Wishforge.games](https://www.wishforge.games/?ref=svgrepo.com) in CC Attribution License via [SVG Repo](https://www.svgrepo.com/).