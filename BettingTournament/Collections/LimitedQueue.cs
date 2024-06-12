using System.Collections;

namespace BettingTournament.Collections
{
    public class LimitedQueue<T> : IEnumerable<T>
    {
        private readonly int _maxSize;
        private readonly Queue<T> _queue;

        public LimitedQueue(int maxSize)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentException("Max size must be greater than zero.", nameof(maxSize));
            }

            _maxSize = maxSize;
            _queue = new Queue<T>();
        }

        public void Enqueue(T item)
        {
            if (_queue.Count >= _maxSize)
            {
                _queue.Dequeue();
            }

            _queue.Enqueue(item);
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _queue.Dequeue();
        }

        public int Count => _queue.Count;

        public T Peek()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _queue.Peek();
        }

        public bool IsEmpty 
            => _queue.Count == 0;

        public bool IsFull 
            => _queue.Count == _maxSize;

        public IEnumerator<T> GetEnumerator() 
            => _queue.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }
}
