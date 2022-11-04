using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;

namespace PD.Workademy.ToDo.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public User AddUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);
        }

        public User DeleteUser(Guid id)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User GetUserById(Guid id)
        {
            _dbContext.SaveChanges();
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            _dbContext.SaveChanges();
            return _dbContext.Users;
        }

        public User UpdateUser(Guid id, User user)
        {
            var userUpdate = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            userUpdate.Id = user.Id;
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            _dbContext.SaveChanges();
            return userUpdate;

        }
    }
}
