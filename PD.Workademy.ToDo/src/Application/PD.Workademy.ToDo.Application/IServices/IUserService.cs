using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IUserService
    {

        IEnumerable<UserDTO> GetUsers();

        UserDTO GetUserById(Guid id);
        
        UserDTO UpdateUser(Guid id, UserDTO user);
        
        UserDTO DeleteUser(Guid id);
        
        UserDTO AddUser(UserDTO user);

    }
}
