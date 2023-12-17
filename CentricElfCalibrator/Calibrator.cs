namespace CentricElfCalibrator;

public class Calibrator
{
    public static int Total { get; set; }
    public static bool Literally { get; set; }

    public static List<string> GetCalibration(string file)
    {
        string[] lines = File.ReadAllLines(file.Trim());
        List<string> newLines = new();
        foreach (string line in lines)
        {
            string word = line;
            if (Literally)
                word = ParseLiterals(line);
            
            int i = GetNum(word);
            Total += i;
            newLines.Add($"{i} - {word}");
        }

        return newLines;
    }

    private static string ParseLiterals(string word)
    {
        return word
            .Replace("one", "(1)")
            .Replace("two", "(2)")
            .Replace("three", "(3)")
            .Replace("four", "(4)")
            .Replace("five", "(5)")
            .Replace("six", "(6)")
            .Replace("seven", "(7)")
            .Replace("eight", "(8)")
            .Replace("nine", "(9)");
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