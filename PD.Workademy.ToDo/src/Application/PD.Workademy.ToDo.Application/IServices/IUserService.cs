using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(Guid id);
        UserDTO UpdateUser(UserDTO user);
        UserDTO DeleteUser(Guid id);
        UserDTO AddUser(UserDTO user);
    }
}
