
//var converter = new ObjectToTextConverter();
//Console.WriteLine(converter.Convert(new House("123 Maple Road", 170.6, 2)));
//class ObjectToTextConverter
//{
//    public string Convert(object obj)
//    {
//        Type type = obj.GetType();
//        var properties = type
//            .GetProperties()
//            .Where(p => p.Name != "EqualityContract");
//        return String.Join(
//            ", ",
//            properties
//                .Select(property => 
//                     $"{property.Name} is {property.GetValue(obj)}"));
//    }
//} 

//public record Pet(string Name, PetType PetType, float Weight);
//public record House(string Adress, double Area, int Floors);
//public enum PetType { Cat, Dog, Fish}

[Some(new int[] { 1,2,3})]
public class SomeClass
{

}

 
public class SomeAttribute : Attribute
{
    public int[] Numbers { get; }

    public SomeAttribute(int[] numbers)
    {
        Numbers = numbers;
    }
}