using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
