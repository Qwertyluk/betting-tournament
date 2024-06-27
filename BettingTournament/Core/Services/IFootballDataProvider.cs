using BettingTournament.Core.Models;

namespace BettingTournament.Core.Services
{
    public interface IFootballDataProvider
    {
        IList<League> FetchLeagues();
    }
}
