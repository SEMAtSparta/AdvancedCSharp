using System.Runtime.CompilerServices;

namespace Serialisation;

public class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        Trainee scot = new Trainee() { FirstName = "Scot", LastName = "Morrison", SpartaNo = 007 };
        _serialiser = new XMLSerialiser();
        //_serialiser.SerialiseToFile<Trainee>($"{_path}/BinaryScot.bin", scot);
        //var scot = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryScot.bin");

        Course eng134 = new Course()
        {
            Title = "Engineering 134",
            Subject = "C# SDET",
            StartDate = new DateTime(2022, 11, 28)
        };

        eng134.AddTrainee(scot);
        eng134.AddTrainee(new Trainee() { FirstName = "Ikra", LastName = "Dahir", SpartaNo = 10 });
        eng134.AddTrainee(new Trainee() { FirstName = "Medhi", LastName = "Hamdi", SpartaNo = 5 });

        _serialiser.SerialiseToFile<Course>($"{_path}/XMLCourse.xml", eng134);
    }
}