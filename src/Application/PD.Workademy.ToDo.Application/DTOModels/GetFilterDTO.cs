using PD.Workademy.ToDo.Web.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.DTOModels
{
    public class GetFilterDTO
    {
        public IEnumerable<ToDoItemDTO> ToDoItemDTOs { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public GetFilterDTO(IEnumerable<ToDoItemDTO> toDoItemDTOs, int page,int perPage, string? search, string? sortBy)
        {
            ToDoItemDTOs = toDoItemDTOs;
            Page = page;
            PerPage = perPage;
            Search = search;
            SortBy = sortBy;
        }
    }
}
