using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime DateTimeCEST
            => DateTime + TimeSpan.FromHours(2);

        public string ApplicationUserId { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
    }
}
