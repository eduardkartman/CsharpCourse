public class Exercise
{
    public Func<string, int> GetLength = text => text.Length;



    public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1,11);
}