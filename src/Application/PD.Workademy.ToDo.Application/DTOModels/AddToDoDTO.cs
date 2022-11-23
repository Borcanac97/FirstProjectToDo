using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.DTOModels
{
    public class AddToDoDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; private set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public AddToDoDTO() { }
        public AddToDoDTO( string title, string? description,
                           bool isDone, Guid categoryId, Guid userId)
        {
            Title = title;
            Description = description;
            IsDone = isDone;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
