using System.Numerics;
using System.Xml;
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
/*var numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
SimpleTuple<int,int> mindAndMax = GetMinAndMax(numbers);
Console.WriteLine("Minimum is : " + mindAndMax.Item1);
Console.WriteLine("Maximum is : " + mindAndMax.Item2);*/
/*Console.WriteLine("Square of 2 is : " + Calculator.Square(2));
Console.WriteLine("Square of 4m is : " + Calculator.Square(4m));
Console.WriteLine("Square of 6d is : " + Calculator.Square(6d));
*/
/*
ProcessString processString1 = TrimTo5Letters;
ProcessString processString2 = ToUpper;
Console.WriteLine(processString1("Helloooooooooo"));
Console.WriteLine(processString2("Helloooooooooo"));*/
/*var countryToCurrencyMapping = new Dictionary<string, string>
{
    ["USA"] = "USD",
    ["India"] = "INR",
    ["Spain"] = "EUR",
};
if (countryToCurrencyMapping.ContainsKey("Italy"))
{
    Console.WriteLine("Currency in Italy is " +
        countryToCurrencyMapping["Italy"]);
}
countryToCurrencyMapping["Poland"] = "PLN";
foreach (var country in countryToCurrencyMapping)
{
    Console.WriteLine($"Country: {country.Key}, " +
        $"currency: {country.Value}");
}
*/
/* Employees exercise with Dictionary
    var employees = new List<Employee>
{
    new Employee("Jake Smith" , "Space Navigation", 25000),
    new Employee("Anna Blake" , "Space Navigation", 29000),
    new Employee("Barbara Oak" , "Xenobiology", 21500),
    new Employee("Damien Parker" , "Xenobiology", 22000),
    new Employee("Nisha Patel" , "Mechanics", 21000),
    new Employee("Gustavo Sanchez" , "Mechanics", 20000),

};
Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(
    IEnumerable<Employee> employees)
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();

    foreach (var employee in employees)
    {
        if (!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();
        }

        employeesPerDepartments[employee.Department].Add(employee);
    }
    var result = new Dictionary<string, decimal>();

    foreach(var employeesPerDepartment in employeesPerDepartments)
    {
        decimal sum = 0;
        foreach(var employee in employeesPerDepartment.Value)
        {
            sum += employee.MonthlySalary;
        }
        var avg = sum / employeesPerDepartment.Value.Count;

        result[employeesPerDepartment.Key] = avg;
    }

    return result;
}
public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }
    public string Name { get; init; }
    public string Department { get; init; }
    public decimal MonthlySalary { get; init; }


}

*/
/* string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}
delegate string ProcessString(string input);*/
/*public static class Calculator
{
    public static T Square<T>(T input) where T : INumber<T> 
        => input * input;
}
*/
/*
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
*/

var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
var filteringStrategySelector = new FilteringStrategySelector();

Console.WriteLine("Select filter: ");
Console.WriteLine(
    string.Join(Environment.NewLine, 
    filteringStrategySelector.FilteringStrategiesName));

var userInput = Console.ReadLine();

var filteringStrategy = new FilteringStrategySelector().Select(userInput);
var result = new Filter().FilterBy(filteringStrategy, numbers);

Print(result);

Console.ReadKey();


void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> _filteringstrategies =
        new Dictionary<string, Func<int, bool>>
        {
            ["Even"] = numbers => numbers % 2 == 0,
            ["Odd"] = numbers => numbers % 2 == 1,
            ["Positive"] = numbers => numbers > 0,
            ["Negative"] = numbers => numbers< 0,
        };

    public IEnumerable<string> FilteringStrategiesName => _filteringstrategies.Keys;

    public Func<int, bool> Select(string filteringType)
    {
        if (!_filteringstrategies.ContainsKey(filteringType))
        {
            throw new NotSupportedException(
                $"{filteringType} is not a valid filter.");
        }
        return _filteringstrategies[filteringType];
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(
        Func<T, bool> predicate,
        IEnumerable<T> numbers)
    {
        var result = new List<T>();
        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                result.Add(number);
            }
        }
        return result;
    }
}
