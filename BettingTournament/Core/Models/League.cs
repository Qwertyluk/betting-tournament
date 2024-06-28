namespace BettingTournament.Core.Models
{
    public class League : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Round> Rounds { get; set; } = [];
    }
}
