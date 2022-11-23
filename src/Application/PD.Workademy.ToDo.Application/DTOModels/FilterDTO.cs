using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Workademy.ToDo.Application.DTOModels
{
    public class FilterDTO
    {
        public int Page { get; set; } 
        public int PerPage { get; set; }
        public string? Search { get; set; }
        public  string? SortBy { get; set; }

        public FilterDTO(string search, string sortBy, int page, int perPage)
        {
            Search = search;
            SortBy = sortBy;
            Page = page;
            PerPage = perPage;
        }
        public FilterDTO() {}
    }
}
