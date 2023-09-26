public interface IVideoGameDeserializer
{
    List<VideoGame> DeserializeFrom(string fileName, string fileContents);
}