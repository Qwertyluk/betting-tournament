namespace BettingTournament.Core.Models
{
    public class League : Entity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Round> Rounds { get; set; } = [];
    }
}
