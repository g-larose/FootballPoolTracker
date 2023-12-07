using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace Football_Pool_Tracker.Domain.Entities;

public class TeamNameJson
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("abbr")]
    public string Abbr { get; set; }
    [JsonPropertyName("fullname")]
    public string FullName { get; set; }
}