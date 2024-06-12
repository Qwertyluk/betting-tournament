namespace BettingTournament.Collections.Extensions
{
    public static class Extensions
    {
        public static LimitedQueue<T> ToLimitedQueue<T>(this List<T> list, int maxSize)
        {
            var limitedQueue = new LimitedQueue<T>(maxSize);
            for (int i = 0; i < list.Count && i < maxSize; i++)
            {
                limitedQueue.Enqueue(list[i]);
            }

            return limitedQueue;
        }

        private static List<T> ToList<T>(this LimitedQueue<T> limitedQueue)
        {
            return new List<T>(limitedQueue);
        }
    }
}
