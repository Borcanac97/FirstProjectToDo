using PD.Workademy.ToDo.Domain.Entities;

namespace PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUserById(Guid id);

        User UpdateUser(Guid id, User user);

        User DeleteUser(Guid id);

        User AddUser(User user);

    }
}
