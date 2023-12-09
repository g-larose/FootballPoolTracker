using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Pool_Tracker.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Record { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public bool IsWinner { get; set; }
    }
}
