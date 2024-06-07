using Microsoft.AspNetCore.Identity;

namespace BettingTournament.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int Score { get; set; }
    }
}
