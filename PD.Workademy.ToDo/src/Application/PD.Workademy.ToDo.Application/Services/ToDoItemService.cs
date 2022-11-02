using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.Services
{
    public class ToDoItemService : IToDoItemService
    {
         List<ToDoItem> toDoItems = new()
         {       
             new ToDoItem (new Guid("928f52a5-7517-4e67-8f08-a96a61e692ed"),
                 "Learn .NET",
                 "U should learn this as soon as you can !",
                 false,
                 new Category(new Guid("928f52a5-7517-4e67-8f08-a96a61e692ed"), "Easy"),
                  new User(new Guid("1beae11c-75a4-4c87-84a8-f3926cf1aa99"), "Nikola", "Djokic"))
         }; 
        public List<ToDoItem> GetItems()
        {
            return toDoItems;
        }
    }
}
