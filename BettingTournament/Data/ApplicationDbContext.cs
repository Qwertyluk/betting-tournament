using BettingTournament.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ActiveGame> ActiveGames { get; set; }

        public DbSet<ActiveBet> ActiveBets { get; set; }

        public DbSet<ArchivedBet> ArchivedBets { get; set; }

        public DbSet<ArchivedGame> ArchivedGames { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
