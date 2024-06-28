namespace BettingTournament.Core.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Entity other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
