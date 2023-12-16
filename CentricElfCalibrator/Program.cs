using CentricElfCalibrator;

string file = "The_Elves_List.txt";
if (!File.Exists(file))
{
    Console.WriteLine("Please enter path to file:");
    file = Console.ReadLine();
}

foreach (string line in Calibrator.GetCalibration(file))
    Console.WriteLine(line);

Console.WriteLine($"\nCalibration number is: {Calibrator.Total}\n\nPress any key to exit...");
Console.ReadKey();