using PD.Workademy.ToDo.Domain.SharedKarnel;

namespace PD.Workademy.ToDo.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Category(){}
        public ICollection<ToDoItem> toDoItems { get; set; }
    }
}
