namespace BettingTournament.Core.Extensions
{
    public static class Extensions
    {
        public static TimeSpan ToTimeSpan(this DateTime dt)
            => new TimeSpan(dt.Hour, dt.Minute, dt.Second);
    }
}
