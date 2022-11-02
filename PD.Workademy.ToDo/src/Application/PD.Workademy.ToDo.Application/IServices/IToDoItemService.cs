using PD.Workademy.ToDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.IServices
{
    public interface IToDoItemService
    {
        List<ToDoItem> GetItems();
    
    }
}
