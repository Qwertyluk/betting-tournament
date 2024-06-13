using Microsoft.AspNetCore.Identity;

namespace BettingTournament.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int Score { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
