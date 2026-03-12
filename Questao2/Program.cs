using Newtonsoft.Json;
using System.Net.Http;
using Questao2.Interfaces;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        var url = "https://jsonmock.hackerrank.com/api/football_matches?";
        var totalGoals = 0;
        
        if(year > 0)
            url += "year=" + year + "&";

        var urlTeam1 = url + "team1=" + team + "&";

        
        var dataTeam1 = await fetchData(urlTeam1);

        if (dataTeam1 is not null)
        {
            totalGoals += dataTeam1.Data.Sum(x => x.Team1Goals);
            
            for (int page = 2; page <= dataTeam1.TotalPages; page++)
            {
                var pageData = await fetchData(urlTeam1 + "page=" + page);
                if (pageData is not null)
                    totalGoals += pageData.Data.Sum(x => x.Team1Goals);
            }
        }
        
        var urlTeam2 = url + "team2=" + team + "&";
        var dataTeam2 = await fetchData(urlTeam2);
        
        if (dataTeam2 is not null)
        {
            totalGoals += dataTeam2.Data.Sum(x => x.Team2Goals);
            
            for (int page = 2; page <= dataTeam2.TotalPages; page++)
            {
                var pageData = await fetchData(urlTeam2 + "page=" + page);
                if (pageData is not null)
                    totalGoals += pageData.Data.Sum(x => x.Team2Goals);
            }
        }
        
        return totalGoals;
    }

    public static async Task<Response<ScoredGoals>?> fetchData(string url)
    {
        using (var client = new HttpClient())
        {
            var responseMessage = await client.GetAsync(url);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<Response<ScoredGoals>>(jsonString);
        }
    }
}