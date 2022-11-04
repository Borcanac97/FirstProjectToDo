
namespace PD.Workademy.ToDo.Web.ApiModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
