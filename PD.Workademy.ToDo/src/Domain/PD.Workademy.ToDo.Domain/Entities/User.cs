using PD.Workademy.ToDo.Domain.SharedKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public User(Guid id,string firstName,string lastName)
        {
            Id = id;
            FirstName = firstName;  
            LastName = lastName;
        }

    }
}
