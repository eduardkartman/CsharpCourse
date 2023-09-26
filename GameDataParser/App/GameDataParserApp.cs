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

