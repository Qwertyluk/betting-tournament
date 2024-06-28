namespace BettingTournament.Core.Models
{
    public class Round : Entity
    {
        public string Name { get; set; } = string.Empty;
        public virtual League League { get; set; }
        public virtual ICollection<Game> Games { get; set; } = [];
        public bool Completed { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Round other)
            {
                return Name.Equals(other.Name) && League.Equals(other.League);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(League, Name);
        }
    }
}
