namespace BettingTournament.Core.Models
{
    public class Round : Entity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = [];
        public bool Completed { get; set; }
    }
}
