using CentricElfCalibrator;
using CentricElfCalibrator.Updater;

UpdateManager.CheckUpdates($@"https://api.github.com/repos/wiha97/CentricElfCalibrator/releases");

string file = "The_Elves_List.txt";
if (!File.Exists(file))
{
    Console.WriteLine("Please enter path to file:");
    file = Console.ReadLine();
}

Console.Write("Include literals ('one', 'two', 'five', etc.)? (y/N)");

if(Console.ReadKey(true).KeyChar == 'y')
    Calibrator.Literally = true;

Console.WriteLine("\nRunning calibration...");

foreach (string line in Calibrator.GetCalibration(file))
    Console.WriteLine(line);

Console.WriteLine($"\nCalibration number is: {Calibrator.Total}\n\nPress any key to exit...");
Console.ReadKey(true);