namespace CentricElfCalibrator;

public class Calibrator
{
    //
    public static int Total { get; set; }

    public static List<string> GetCalibration(string file)
    {
        string[] lines = File.ReadAllLines(file.Trim());
        List<string> newLines = new();
        foreach (string line in lines)
        {
            int i = GetNum(line);
            Total += i;
            newLines.Add($"{i} - {line}");
        }
        return newLines;
    }

    private static int GetNum(string word)
    {
        int num = 0;

        string nums = string.Concat(word.Where(Char.IsDigit));
        char first = nums[0];
        char last = nums[nums.Length - 1];

        num = int.Parse($"{first}{last}");
        
        return num;
    }
}