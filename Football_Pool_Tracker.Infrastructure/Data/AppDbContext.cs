using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football_Pool_Tracker.Domain.Entities;

namespace Football_Pool_Tracker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<NFLPlayer> NFLPlayers { get; set; }
    }
}
