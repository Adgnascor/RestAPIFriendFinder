using FriendFinderAPI.Context;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FriendFinderAPI.Services
{
    public abstract class Repository : IRespository
    {
        protected readonly FriendFinderContext _context;
        protected readonly ILogger<Repository> _logger;

        public Repository(FriendFinderContext context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _context.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _context.Update(entity);
        }
    }
}