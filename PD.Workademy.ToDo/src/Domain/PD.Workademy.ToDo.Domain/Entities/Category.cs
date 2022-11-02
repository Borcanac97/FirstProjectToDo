using PD.Workademy.ToDo.Domain.SharedKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public Category( Guid id, string name)
        {
            Id = id;
            Name = name;
        }



    }
}
