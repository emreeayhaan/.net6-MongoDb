using Muvekkil.Collection;

namespace Muvekkil.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task UserAdd(User newUser);
        Task SetUser(User setUser);
        Task DeleteUser(string id, string name);
    }
}
