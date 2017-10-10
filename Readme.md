# Pixel Prime
Attempts to turn a photo into a prime number that looks a lot like the photo

## Getting Started

### Prerequisites

- .NET compiler
- Python 3 Interpreter

### Installing

With dotnet
```
dotnet build
```

## Running

Put a `.pgm` image in the base directory

#### From a console:

Run `pgmToNumber.py`
```
python3 pgmToNumber.py
```

Run the main program
```
dotnet run
```

Eventually (you may need to leave it running for a while) you will see `Possible prime found` in stdout. At this point (or after more possible primes are found), terminate the program and run the formatter

```
python3 format.py
```

Now there will be possible primes, formatted, in output.txt

Note that these are *possible* primes. While it is very likely that they are prime, more tests are required to know deterministically.

## Examples

See the Primes folder for examples of primes that have been found with this program

## Acknowledgements



## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

