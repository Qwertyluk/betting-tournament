namespace BettingTournament.ViewModels
{
    public class ResultViewModel
    {
        public int Rank { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PersonalData { get; set; } = string.Empty;
        public string Bets { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
