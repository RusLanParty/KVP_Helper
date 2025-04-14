A minimal utility for managing resource KVPs in FiveM using C#.  
Avoids the default `0` problem by checking key existence before returning values.  

## Features

- ✅ `Get`/`Set` support for `string`, `int`, `float`, `bool`
- ✅ Checks if key exists before returning value
- ✅ Automatically sets default if missing

## Usage

```csharp
int myValue = Settings.Get("my_key", 42);
Settings.Set("my_key", 1337);

bool isEnabled = Settings.Get("feature_toggle", false);
Settings.Set("feature_toggle", true);
