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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
