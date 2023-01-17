namespace Serialisation;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerialiser : ISerialise
{
    public void SerialiseToFile<T>(string filePath, T item)
    {
        FileStream fileStream = File.Create(filePath);
        BinaryFormatter writer = new BinaryFormatter();
        writer.Serialize(fileStream, item);
        fileStream.Close();
    }

    public T DeserialiseFromFile<T>(string filePath)
    {
        Stream fileStream = File.OpenRead(filePath);

        BinaryFormatter reader = new BinaryFormatter();
        var deserialisedItem = (T)reader.Deserialize(fileStream);
        fileStream.Close();
        return deserialisedItem;
    }
}
