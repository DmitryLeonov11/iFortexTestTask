using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db) {
            _db = db;
        }
        public async Task<User> GetUser()
        {
            return _db.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefault();
        }

        public async Task<List<User>> GetUsers()
        {
            return _db.Users.Where(u => u.Status.Equals(UserStatus.Inactive)).ToList();
        }
    }
}
