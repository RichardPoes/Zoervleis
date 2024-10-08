# Zoervleis
Zoervleis is a C# tool to convert hashes into human readable strings.
If hashes need to be communicated human to human `HumanHash` is advised.
If hashes need to be communicated human to computer or vice versa, `DigitHash` is advised.
One extra perk of `DigitHash` is that is more information dense.

## Example
We can use `HumanHash` as follows
```csharp
    var toHash = "Hello World"u8.ToArray();
    var hash = SHA256.HashData(toHash);

    var humanizedString = HumanHash.Humanize(hash);

    Console.WriteLine(humanizedString); // Output will be "orange-monkey-oranges-steak-asparagus-white"
```

We can use `DigitHash` as follows
```csharp
    var toHash = "Hello World"u8.ToArray();
    var hash = SHA256.HashData(toHash);

    var humanizedString = DigitHash.Digitize(hash);

    Console.WriteLine(humanizedString); // Output will be "11109-73930-84387-59824-87079"
```

## To do:
The following list includes ideas for what I still want to implement.
I am open for suggestions.

- [ ] Multi language support
- [ ] Dependency injection support
- [ ] Custom dictionary support
- [ ] Support for hashing-and-humanizing in one

## License
This project is licensed under the GNU GPLv3 license.

## Attributions
- This package is heavily inspired on the Python package [humanhash](https://github.com/zacharyvoase/humanhash).
- [Cauldron icon](assets/Icon.svg) was based off a creation by [Wishforge.games](https://www.wishforge.games/?ref=svgrepo.com) in CC Attribution License via [SVG Repo](https://www.svgrepo.com/)