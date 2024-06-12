using BettingTournament.Collections;
using BettingTournament.Collections.Extensions;
using BettingTournament.Core.Models;
using BettingTournament.Data;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class ChatService
    {
        private static int _maxMessagesCount = 50;

        private readonly LimitedQueue<Message> _messages;
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public event Action OnChange;

        public ChatService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                _messages = dbContext.Messages
                    .Include(x => x.ApplicationUser)
                    .OrderByDescending(x => x.DateTime)
                    .Take(_maxMessagesCount)
                    .ToList()
                    .OrderBy(x => x.DateTime)
                    .ToList()
                    .ToLimitedQueue(_maxMessagesCount);
            }
        }

        public void AddMessage(string content, DateTime dt, ApplicationUser author)
        {
            var newMessage = new Message()
            {
                Content = content,
                DateTime = dt,
                ApplicationUserId = author.Id,
                ApplicationUser = author,
            };
            _messages.Enqueue(newMessage);

            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Entry(author).State = EntityState.Unchanged;
                dbContext.Messages.Add(newMessage);
                dbContext.SaveChanges();
            }

            NotifyStateChanged();
        }

        public IReadOnlyCollection<Message> GetMessages()
            => _messages.ToList();

        private void NotifyStateChanged() 
            => OnChange?.Invoke();
    }
}
