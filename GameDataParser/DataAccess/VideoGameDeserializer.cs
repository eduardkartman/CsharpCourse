using System.Text.Json;

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

