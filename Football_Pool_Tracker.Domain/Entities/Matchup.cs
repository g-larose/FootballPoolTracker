﻿using MaterialDesignColors.Recommended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Pool_Tracker.Domain.Entities
{
    public class Matchup
    {
        public int Id { get; set; } //this is for DB lookup only.
        public Team AwayTeam { get; set; } = new();
        public Team HomeTeam { get; set; } = new();
        public uint Year { get; set; }
        public uint Week { get; set; }
        public List<int> AwayTeamScores { get; set; }
        public List<int> HomeTeamScores { get; set; }
        public string GameDate { get; set; }
        public GameType GameType { get; set; }

    }
}
