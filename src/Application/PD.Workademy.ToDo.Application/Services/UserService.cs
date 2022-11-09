using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO AddUser(UserDTO userDTO)
        {
            User user = new User(userDTO.Id, userDTO.FirstName,
                                                          userDTO.LastName);
            User savedUser = _userRepository.AddUser(user);
            UserDTO _userDTO = new UserDTO(savedUser.Id,
                                    savedUser.FirstName, savedUser.LastName);
            return _userDTO;
        }
        public UserDTO DeleteUser(Guid id)
        {
            User userToDelete = _userRepository.DeleteUser(id);
            UserDTO userDTO = new(userToDelete.Id, userToDelete.FirstName,
                                                      userToDelete.LastName);
            return userDTO;
        }
        public UserDTO GetUserById(Guid id)
        {
            User user = _userRepository.GetUserById(id);
            UserDTO userDTO = new(user.Id, user.FirstName, user.LastName);
            return userDTO;
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var user = _userRepository.GetUsers();
            return user.Select(x => new UserDTO(x.Id, x.FirstName, x.LastName));
        }
        public UserDTO UpdateUser(UserDTO userDTO)
        {
            User userUpdate = new(userDTO.Id, userDTO.FirstName, userDTO.LastName);
            _userRepository.UpdateUser(userUpdate);
            UserDTO user = new(userDTO.Id, userDTO.FirstName, userDTO.LastName);
            return user;
        }
    }
}
