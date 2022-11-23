using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.DTOModels
{
    public class UpdateToDoDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; private set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public UpdateToDoDTO(Guid id, string title, string? description,
                           bool isDone, Guid categoryid, Guid userid)
        {
            Id = id;
            Title = title;
            Description = description;
            IsDone = isDone;
            CategoryId = categoryid;
            UserId = userid;
        }
    }
}
