using PD.Workademy.ToDo.Domain.SharedKarnel;
using System.Reflection;

namespace PD.Workademy.ToDo.Domain.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public bool IsDone { get; private set; }

        public Category? Category { get; set; }

        public User? User { get; set; }

        public ToDoItem(){}
        public ToDoItem(Guid id, string? title, string? description, bool isDone, Category? category, User? user)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
            Category = category;
            User = user;
        }
        public void ChangeStatus(bool isDone)
        {
            IsDone = isDone;
           
        }

        public object this[string propertyName]
        {
            get
            {
                PropertyInfo property = GetType().GetProperty(propertyName);
                return property.GetValue(this, null);
            }
            set
            {
                PropertyInfo property = GetType().GetProperty(propertyName);
                property.SetValue(this, value, null);
            }
        }



    }
}
