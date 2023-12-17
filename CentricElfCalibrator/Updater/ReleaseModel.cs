using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace CentricElfCalibrator.Updater;

public class ReleaseModel
{
    [JsonPropertyName("tag_name")]
    public string Tag { get; set; }
    [JsonPropertyName("body")]
    public string Description { get; set; }
    [JsonPropertyName("assets")]
    public List<GitAsset> Assets { get; set; }
}

public class GitAsset
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("browser_download_url")]
    public string Download {get; set; }
}