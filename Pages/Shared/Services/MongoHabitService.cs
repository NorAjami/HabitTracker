using HabitTracker.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace HabitTracker.Services
{
    public class MongoHabitService
    {
        private readonly IMongoCollection<Habit> _habits;

        // 🚪 Ansluter till databasen via din connection string
        public MongoHabitService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _habits = database.GetCollection<Habit>(config["MongoDB:CollectionName"]);
        }

        // 🧠 Hämtar vanor som skapades under ett visst dygn (för t.ex. dagens datum)
        public async Task<List<Habit>> GetHabitsByDateAsync(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            var filter = Builders<Habit>.Filter.And(
                Builders<Habit>.Filter.Gte(h => h.Date, startOfDay),
                Builders<Habit>.Filter.Lt(h => h.Date, endOfDay)
            );

            return await _habits.Find(filter).ToListAsync();
        }

        // ➕ Lägger till en ny vana i databasen
        public async Task AddHabitAsync(Habit habit)
        {
            await _habits.InsertOneAsync(habit);
        }

        // ✅ Växlar om vanan är klar eller inte (baserat på ID)
        public async Task ToggleHabitStatusAsync(string id)
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
