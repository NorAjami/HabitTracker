using HabitTracker.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HabitTracker.Services
{
    public class MongoHabitService
    {
        private readonly IMongoCollection<Habit> _habits;

        public MongoHabitService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _habits = database.GetCollection<Habit>(config["MongoDB:CollectionName"]);
        }

        public async Task<List<Habit>> GetHabitsByDateAsync(DateTime date)
        {
            return await _habits.Find(h => h.Date.Date == date.Date).ToListAsync();
        }

        public async Task AddHabitAsync(Habit habit)
        {
            await _habits.InsertOneAsync(habit);
        }

        public async Task ToggleHabitStatusAsync(int id)
        {
            var filter = Builders<Habit>.Filter.Eq(h => h.Id, id);
            var habit = await _habits.Find(filter).FirstOrDefaultAsync();
            if (habit != null)
            {
                habit.IsCompleted = !habit.IsCompleted;
                await _habits.ReplaceOneAsync(filter, habit);
            }
        }
    }
}
