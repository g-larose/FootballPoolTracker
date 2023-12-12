namespace Football_Pool_Tracker.Domain.Entities;

public class NFLPlayer
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public string College { get; set; } = string.Empty;
    public string CurrentTeam { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string ProfileImageUrl { get; set; } = String.Empty;
    public string[]? Teams { get; set; }
}