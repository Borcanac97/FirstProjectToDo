using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {

        List<User> _user = new()
            {
                new User(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
                new User( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
                new User( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
            };

        public User AddUser(User user)
        {
            _user.Add(user);
            return _user.Find(x => x.Id == user.Id);
        }

        public User DeleteUser(Guid id)
        {
            User user = _user.Find(x => x.Id == id);
            _user.Remove(user);
            return user;
        }

        public User GetUserById(Guid id)
        {
            return _user.Find(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _user;
        }

        public User UpdateUser(Guid id, User user)
        {
            var userUpdate = _user.Find(x => x.Id == id);
            userUpdate.Id=user.Id;
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            return userUpdate;

        }
    }
}
