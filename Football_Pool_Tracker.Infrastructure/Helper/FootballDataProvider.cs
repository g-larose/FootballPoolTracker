using Football_Pool_Tracker.Application.Interface;
using Football_Pool_Tracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Pool_Tracker.Infrastructure.Helper
{
    public class FootballDataProvider : IFootballDataProvider
    {
        public Task<Matchup> GetWeeklyMatchups(string year, string week, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
