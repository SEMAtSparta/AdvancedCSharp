using System.Runtime.CompilerServices;

namespace Serialisation;

public class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        //Trainee scot = new Trainee() { FirstName = "Scot", LastName = "Morrison", SpartaNo = 007 };
        _serialiser = new BinarySerialiser();
        //_serialiser.SerialiseToFile<Trainee>($"{_path}/BinaryScot.bin", scot);
        var scot = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryScot.bin");
    }
}

[Serializable]
public class Trainee
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int? SpartaNo { get; init; }
    public string FullName => $"{FirstName} {LastName}";
    public override string ToString()
    {
        return $"{SpartaNo} - {FullName}";
    }
}