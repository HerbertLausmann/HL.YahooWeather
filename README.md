# HL.YahooWeather
# A .NET C# Multiplatform wrapper for the Yahoo Weather API

This is a very simple to use API. All methods, properties and classes are summarized, so you won't need any documentation.
Trust me, this API is very easy to use. You can use on code or even in the XAML.

YEAH! The main class, YahooWeather, implements the INotifyPropertyChanged Interface and has a property named TwoWayBindableLocation (string).
That property allows you to do Data Binding in XAML.
On the WPF Demo source code you can see this in action.

With HL.YahooWeather you can get all the Weather forecast for a given location in the actual date and the next Week.
It also returns a byte[] that is, basically, a gif icon (52x52) sent by yahoo services that represents the condition (Like a sun for sunny days, Cloud for cloudy days and etc)

### HL.YahooWeather supports async.
You can do somethings like this:
```csharp
            YahooWeather weather = await YahooWeather.LoadAsync("New York city");
            Console.WriteLine(weather.Condition.Text);
```
### .NET CORE 2.0
This library is written for .NET CORE/STANDARD 2.0!
[.NET Core Guide:](https://docs.microsoft.com/en-us/dotnet/core/)
>NET Core is compatible with .NET Framework, Xamarin and Mono, via the .NET Standard.

>Runs on Windows, macOS and Linux; can be ported to other operating systems. The supported Operating Systems (OS), CPUs and application scenarios will grow over time, provided by Microsoft, other companies, and individuals.

I hope you find this Library useful!
