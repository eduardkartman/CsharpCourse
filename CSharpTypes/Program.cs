
//var weatherData = new WeatherData(25.1m, 65);
//Console.WriteLine(weatherData);

//var warmerWeatherDate = weatherData with { Temperature = 30 };
//Console.WriteLine(warmerWeatherDate);

var rectangle = new Rectangle(10,20);
//rectangle.A = 30; immutable if is readonly
Console.WriteLine(rectangle);

Console.ReadKey();

public record WeatherData(decimal Temperature, int Humidity);

public readonly record struct Rectangle(int A, int B);


//public class WeatherData : IEquatable<WeatherData?>
//{
//    public decimal Temperature { get; }
//    public int Humidity { get; }

//    public WeatherData(decimal temperature, int humidity)
//    {
//        Humidity = humidity;
//        Temperature = temperature;
//    }

//    public override string ToString() => $"Temperature: {Temperature}°C, Humidity: {Humidity}";

//    public override bool Equals(object? obj)
//    {
//        return Equals(obj as WeatherData);
//    }

//    public bool Equals(WeatherData? other)
//    {
//        return other is not null &&
//               Temperature == other.Temperature &&
//               Humidity == other.Humidity;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Temperature, Humidity);
//    }

//    public static bool operator ==(WeatherData? left, WeatherData? right)
//    {
//        return EqualityComparer<WeatherData>.Default.Equals(left, right);
//    }

//    public static bool operator !=(WeatherData? left, WeatherData? right)
//    {
//        return !(left == right);
//    }
//}













////var converter = new ObjectToTextConverter();
////Console.WriteLine(converter.Convert(new House("123 Maple Road", 170.6, 2)));
////class ObjectToTextConverter
////{
////    public string Convert(object obj)
////    {
////        Type type = obj.GetType();
////        var properties = type
////            .GetProperties()
////            .Where(p => p.Name != "EqualityContract");
////        return String.Join(
////            ", ",
////            properties
////                .Select(property => 
////                     $"{property.Name} is {property.GetValue(obj)}"));
////    }
////} 

////public record Pet(string Name, PetType PetType, float Weight);
////public record House(string Adress, double Area, int Floors);
////public enum PetType { Cat, Dog, Fish}

//[Some(new int[] { 1,2,3})]
//public class SomeClass
//{
//}
//public class SomeAttribute : Attribute
//{
//    public int[] Numbers { get; }

//    public SomeAttribute(int[] numbers)
//    {
//        Numbers = numbers;
//    }
//}