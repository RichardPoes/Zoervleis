# Zoervleis
Zoervleis is a C# tool to convert hashes into human readable strings.
This package is heavily inspired on the Python package [humanhash](https://github.com/zacharyvoase/humanhash).

## Example
```csharp
using var alg = SHA256.Create();
var hash = "Hello World"u8.ToArray();

var humanizedString = HumanHash.Humanize(hash);

Console.WriteLine(humanizedString) // Output will be fix-ink-juliet-juliet-kansas-cardinal
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