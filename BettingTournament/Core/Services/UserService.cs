using BettingTournament.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BettingTournament.Core.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal) ?? throw new CustomException();
        }
    }
}
