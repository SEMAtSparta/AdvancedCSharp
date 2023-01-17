﻿using System.IO;
using Newtonsoft.Json;

namespace Serialisation;

public class JSONSerialiser : ISerialise
{
    public T DeserialiseFromFile<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        T item = JsonConvert.DeserializeObject<T>(jsonString);
        return item;
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        string jsonString = JsonConvert.SerializeObject(item);
        File.WriteAllText(filePath, jsonString);
    }
}
