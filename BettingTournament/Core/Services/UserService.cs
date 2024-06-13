using BettingTournament.Core.Exceptions;
using BettingTournament.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BettingTournament.Core.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly GameService _gameService;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            GameService gameService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _gameService = gameService;
        }

        public async Task<(ApplicationUser, IdentityResult)> CreateUser(string userName, string password, string firstName, string lastName)
        {
            var user = CreateUser(firstName, lastName);
            await _userStore.SetUserNameAsync(user, userName, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                _gameService.CreateBetsFor(user.Id);
            }

            return (user, result);
        }

        public async Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal) ?? throw new CoreException("User cannot be found.");
        }

        private static ApplicationUser CreateUser(string firstName, string lastName)
        {
            try
            {
                var user = Activator.CreateInstance<ApplicationUser>();
                user.FirstName = firstName;
                user.LastName = lastName;

                return user;
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }
    }
}
