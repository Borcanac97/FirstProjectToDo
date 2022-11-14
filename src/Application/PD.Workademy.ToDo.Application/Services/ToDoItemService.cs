using PD.Workademy.ToDo.Application.DTOModels;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Domain.Entities;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Web.ApiModels;

namespace PD.Workademy.ToDo.Application.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }
        public ToDoItemDTO AddToDoItem(ToDoItemDTO toDoItemDTO)
        {
            User user = new User(toDoItemDTO.User.Id, toDoItemDTO.User.FirstName, toDoItemDTO.User.LastName);
            Category category = new Category(toDoItemDTO.Category.Id, toDoItemDTO.Category.Name);

            ToDoItem toDoItem = new ToDoItem(toDoItemDTO.Id, toDoItemDTO.Title, toDoItemDTO.Description,
                                            toDoItemDTO.IsDone, category, user);

            UserDTO userDTO = new UserDTO(user.Id, user.FirstName, user.LastName);
            CategoryDTO categoryDTO = new CategoryDTO(category.Id, category.Name);

            ToDoItem savedToDoItem = _toDoItemRepository.AddToDoItem(toDoItem);
            ToDoItemDTO _toDoItemDTO = new ToDoItemDTO(savedToDoItem.Id, savedToDoItem.Title,
                                            savedToDoItem.Description, savedToDoItem.IsDone, categoryDTO, userDTO);
            return _toDoItemDTO;
        }
        public ToDoItemDTO DeleteToDoItem(Guid id)
        {
            ToDoItem toDoItem = _toDoItemRepository.DeleteToDoItem(id);
            ToDoItemDTO toDoItemDTO = new ToDoItemDTO(toDoItem.Id, toDoItem.Title, toDoItem.Description, toDoItem.IsDone,
                                      new CategoryDTO(toDoItem.Category.Id, toDoItem.Category.Name),
                                      new UserDTO(toDoItem.User.Id, toDoItem.User.FirstName, toDoItem.User.LastName));
            return toDoItemDTO;
        }
        public ToDoItemDTO GetToDoItemById(Guid id)
        {
            ToDoItem toDoItem = _toDoItemRepository.GetToDoItemById(id);
            ToDoItemDTO toDoItemDTO = new ToDoItemDTO(toDoItem.Id, toDoItem.Title, toDoItem.Description, toDoItem.IsDone,
                                      new CategoryDTO(toDoItem.Category.Id, toDoItem.Category.Name),
                                      new UserDTO(toDoItem.User.Id, toDoItem.User.FirstName, toDoItem.User.LastName));
            return toDoItemDTO;
        }
        public IEnumerable<ToDoItemDTO> GetToDoItems()
        {
            var toDoItems = _toDoItemRepository.GetToDoItems();
            return toDoItems.Select(x => new ToDoItemDTO(x.Id, x.Title, x.Description, x.IsDone,
                                         new CategoryDTO(x.Category.Id, x.Category.Name),
                                         new UserDTO(x.User.Id, x.User.FirstName, x.User.LastName)));
        }
        public ToDoItemDTO UpdateToDoItem(ToDoItemDTO toDoItemDTO)
        {
            ToDoItem toDoItem = new(toDoItemDTO.Id, toDoItemDTO.Title, toDoItemDTO.Description, toDoItemDTO.IsDone,
                                new Category(toDoItemDTO.Category.Id, toDoItemDTO.Category.Name),
                                new User(toDoItemDTO.User.Id, toDoItemDTO.User.FirstName, toDoItemDTO.User.LastName));

            _toDoItemRepository.UpdateToDoItem(toDoItem);

            ToDoItemDTO toDoDTO = new ToDoItemDTO(toDoItem.Id, toDoItem.Title, toDoItem.Description, toDoItem.IsDone,
                                  new CategoryDTO(toDoItem.Category.Id, toDoItem.Category.Name),
                                  new UserDTO(toDoItem.User.Id, toDoItem.User.FirstName, toDoItem.User.LastName));
            return toDoDTO;
        }
        public IEnumerable<ToDoItemDTO> GetToDoByFilter(FilterDTO _filterDTO)
        {
            int page = _filterDTO.Page == null || _filterDTO.Page == 0 ? 1 : _filterDTO.Page;
            int perPage = _filterDTO.PerPage == null || _filterDTO.PerPage == 0 ? 10 : _filterDTO.PerPage;
            string sortBy = _filterDTO.SortBy ?? "Id";
            string search = _filterDTO.Search ?? "";
            
            ToDoItemDTO toDoItemDTO = new();

            var toDoItem = _toDoItemRepository.GetToDoByFilter(search, sortBy, page, perPage);

            IEnumerable<ToDoItemDTO> toDoItemDTOs = toDoItem.Select(
                x => new ToDoItemDTO(
                        x.Id,
                        x.Title,
                        x.Description,
                        x.IsDone,
                        new CategoryDTO(x.Category.Id, x.Category.Name),
                        new UserDTO(x.User.Id, x.User.FirstName, x.User.LastName)
                        )
                );
            return toDoItemDTOs;
        }
    }
}
