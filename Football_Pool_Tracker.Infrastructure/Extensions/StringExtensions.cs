namespace Football_Pool_Tracker.Infrastructure.Extensions;

public static class StringExtensions
{
    public static string ToTeamAbbr(this string teamName)
    {
        var result = teamName switch
        {
            "Arizona" => "ARI",
            "Atlanta" => "ATL",
            "Baltimore" => "BAL",
            "Chicago" => "CHI",
            "Buffalo" => "BUF",
            "Carolina" => "CAR",
            "Cincinnati" => "CIN",
            "Cleveland" => "CLE",
            "Dallas" => "DAL",
            "Denver" => "DEN",
            "Detroit" => "DET",
            "Green Bay" => "GB",
            "Houston" => "HOU",
            "Indianapolis" => "IND",
            "Jacksonville" => "JAX",
            "Kansas City" => "KC",
            "LA Chargers" => "LAC",
            "LA Rams" => "LAR",
            "Miami" => "MIA",
            "Minnesota" => "MIN",
            "New England" => "NE",
            "New Orleans" => "NO",
            "NY Giants" => "NYG",
            "NY Jets" => "NYJ",
            "Las Vegas" => "LV",
            "Philadelphia" => "PHI",
            "Pittsburgh" => "PIT",
            "Chargers" => "SD",
            "San Francisco" => "SF",
            "Seattle" => "SEA",
            "Tampa Bay" => "TB",
            "Tennessee" => "TEN",
            "Washington" => "WAS",
            _ => teamName
        };
        return result;
    }

    public static string ToDivision(this string teamName)
    {
        var result = teamName switch
        {
            "Arizona" => "NFC",
            "Atlanta" => "NFC",
            "Baltimore" => "AFC",
            "Chicago" => "NFC",
            "Buffalo" => "AFC",
            "Carolina" => "NFC",
            "Chargers" => "AFC",
            "Cincinnati" => "AFC",
            "Cleveland" => "AFC",
            "Dallas" => "NFC",
            "Denver" => "AFC",
            "Detroit" => "NFC",
            "Green Bay" => "NFC",
            "Houston" => "AFC",
            "Indianapolis" => "AFC",
            "Jacksonville" => "AFC",
            "Kansas City" => "AFC",
            "LA Chargers" => "AFC",
            "LA Rams" => "NFC",
            "Las Vegas" => "AFC",
            "Miami" => "AFC",
            "Minnesota" => "NFC",
            "New England" => "AFC",
            "New Orleans" => "NFC",
            "NY Giants" => "NFC",
            "NY Jets" => "AFC",
            "Philadelphia" => "NFC",
            "Pittsburgh" => "AFC",
            "San Francisco" => "NFC",
            "Seattle" => "NFC",
            "Tampa Bay" => "NFC",
            "Tennessee" => "AFC",
            "Washington" => "NFC",
            _ => teamName
        };
        return result;
    }
}