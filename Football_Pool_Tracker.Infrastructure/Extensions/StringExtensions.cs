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
            "LA Rams" => "LA",
            "Miami" => "MIA",
            "Minnesota" => "MIN",
            "New England" => "NE",
            "New Orleans" => "NO",
            "Giants" => "NYG",
            "NY Jets" => "NYJ",
            "Raiders" => "LV",
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
}