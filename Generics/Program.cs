/*var numbers = new SimpleList<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(40);
numbers.Add(50);
numbers.RemoveAt(2);

var words = new SimpleList<string>();
words.Add("aaa");
words.Add("bbb");
words.Add("ccc");

var dates = new SimpleList<DateTime>();
dates.Add(new DateTime(2025, 1, 6));
dates.Add(new DateTime(2025, 6, 6));*/

var numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
SimpleTuple<int,int> mindAndMax = GetMinAndMax(numbers);
Console.WriteLine("Minimum is : " + mindAndMax.Item1);
Console.WriteLine("Maximum is : " + mindAndMax.Item2);

Console.ReadKey();

SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException(
            $"The input collection cannot be empty.");
    }
    int min = input.First();
    int max = input.First();

    foreach (var number in input)
    {
        if (number < min)
        {
            min = number;
        }
        if (number > max)
        {
            max = number;
        }
    }
    return new SimpleTuple<int, int>(min, max);
}

public class SimpleTuple<T1, T2>
{
    public T1 Item1 { get; set; }
    public T2 Item2 { get; set; }

    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;

        Item2 = item2;

    }
}


//Generic Class Definition
class SimpleList<T>
{

    private T[] _items = new T[4];
    private int _size = 0;

    public void Add(T item)
    {
        if (_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        _items[_size] = item;
        ++_size;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException(
                $"Index {index} is outside the bounds of the list.");
        }
        --_size;
        for (int i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default;
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException(
                $"Index {index} is outside the bounds of the list.");
        }
        return _items[index];
    }
}
