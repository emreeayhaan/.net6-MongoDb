using MongoDB.Driver;
using Muvekkil.Collection;

namespace Muvekkil.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _userCollection = mongoDatabase.GetCollection<User>("user");
        }

        public async Task DeleteUser(string id, string name)
        {
            await _userCollection.DeleteOneAsync(x => x.Id == id || x.Name == name);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userCollection.Find(x => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task SetUser(User setUser)
        {
            await _userCollection.ReplaceOneAsync(x => x.Id == setUser.Id || x.Name == setUser.Name, setUser);
        }

        public async Task UserAdd(User newUser)
        {
            await _userCollection.InsertOneAsync(newUser);
        }
    }
}