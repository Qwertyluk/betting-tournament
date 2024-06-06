namespace BettingTournament.Core.Extensions
{
    public static class Extensions
    {
        public static TimeSpan FromUTCToPolishTimeSpan(this DateTime dt)
            => new TimeSpan(dt.Hour + 2, dt.Minute, dt.Second); // polish timezone = UTC + 2
    }
}
