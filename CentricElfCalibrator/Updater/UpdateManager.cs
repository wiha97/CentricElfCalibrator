using System.Reflection;
using System.Text.Json;

namespace CentricElfCalibrator.Updater;

public class UpdateManager
{
    public static List<ReleaseModel> Releases { get; set; }
    private static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(2);

    public static void CheckUpdates(string url)
    {
        try
        {
            if (url.Contains("github"))
            {
                string json = "";
                using (HttpClient client = new())
                {
                    client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                    json = client.GetStringAsync(url).Result;
                }

                Releases = JsonSerializer.Deserialize<List<ReleaseModel>>(json);
                ReleaseModel release = Releases[0];
                if (int.Parse(release.Tag.Replace(".", "").ToLower().Replace("v","")) >
                    int.Parse(version.Replace(".", "")))
                {
                    Console.WriteLine($"============================\n" +
                                      $"Update available: {release.Tag} (Current: {version})\n" +
                                      $"Changelog:\n" +
                                      $"----------CHANGELOG---------\n" +
                                      $"{release.Description}\n" +
                                      $"----------DOWNLOADS:--------\n" +
                                      $"{release.Assets[0].Name}: {release.Assets[0].Download}\n" +
                                      $"{release.Assets[1].Name}: {release.Assets[1].Download}\n\n" +
                                      $"All releases: https://github.com/wiha97/CentricElfCalibrator/releases\n" +
                                      $"============================");
                }
                else
                {
                    Console.WriteLine($"============================\n" +
                                      $"Update check: Latest version ({version})\n" +
                                      $"============================");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed update check\n{e.Message}");
        }
    }
}