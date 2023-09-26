using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The app has experienced an unexpected error" +
        "and will have to be closed.");
    logger.Log(ex);
}
Console.WriteLine("Press any key to close.");
Console.ReadKey();


public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGameDeserializer _videoGameDeserialize;
    private readonly IFileReader _reader;

    public GameDataParserApp(
        IUserInteractor userInteractor,
        IGamesPrinter gamesPrinter,
        IVideoGameDeserializer videoGameDeserialize,
        IFileReader reader)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGameDeserialize = videoGameDeserialize;
        _reader = reader;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var fileContents = _reader.Read(fileName);
        var videoGames = _videoGameDeserialize.DeserializeFrom(fileName, fileContents);
        _gamesPrinter.Print(videoGames);
    }
}

public interface IFileReader
{
    string Read(string fileName);
}

public class LocalFileReader : IFileReader
{
    public string Read(string fileName) => File.ReadAllText(fileName);
}

public class VideoGameDeserializer : IVideoGameDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGameDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DeserializeFrom(string fileName, string fileContents)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException ex)
        {

            _userInteractor.PrintError($"JSON in {fileName} file was not" +
                $"in a valid format. JSON bodY: ");
            _userInteractor.PrintError(fileContents);
            throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
        }
    }
}

public class GamesPrinter : IGamesPrinter
{
    private readonly IUserInteractor _userInteractor;

    public GamesPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Print(List<VideoGame> videoGames)
    {
        if (videoGames.Count > 0)
        {
            _userInteractor.PrintMessage(
                Environment.NewLine + "Loaded games are:");
            foreach (var videoGame in videoGames)
            {
                _userInteractor.PrintMessage(videoGame.ToString());
            }
        }
        else
        {
            _userInteractor.PrintMessage("No games" +
                " are present in the input file.");
        }
    }
}

public interface IUserInteractor
{
    string ReadValidFilePath();
    void PrintMessage(string message);
    void PrintError(string message);
}

public class ConsoleUserInteractor : IUserInteractor
{
    public void PrintError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadValidFilePath()
    {
        bool isFilePathValid = false;
        string fileName;

        do
        {
            Console.WriteLine("Enter the name of the file you want to read:");
            fileName = Console.ReadLine();

            if (fileName is null)
            {
                Console.WriteLine("The file name cannot be null");
            }
            else if (fileName == string.Empty)
            {
                Console.WriteLine("The file name cannot be empty");
            }
            else if (!File.Exists(fileName))
            {
                Console.WriteLine("The file doesn't exists ");
            }
            else
            {
                isFilePathValid = true;
            }

        } while (!isFilePathValid);
        return fileName;
    }

}


public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => $"{Title}, released in {ReleaseYear}, with rating {Rating}";
}

