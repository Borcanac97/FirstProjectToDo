using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.Services
{
    public class UserService : IUserService
    {
        List<User> users = new()
        {
            new User(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"),"Nikola","Djokic"),
            new User( new Guid("a57d5050-0471-454a-bccc-c2a15ee0574f"),"Aleksandar","Vidakovic"),
            new User( new Guid("0e6cead0-5a12-41bd-8946-0cea43724b3c"),"Matija","Davidovic")
        };
        public List<User> GetUsers()
        {
            return users;
        }
    }
}
