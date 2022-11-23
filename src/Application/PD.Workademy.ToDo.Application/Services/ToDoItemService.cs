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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository,ICategoryRepository categoryRepository,IUserRepository userRepository)
        {
            _toDoItemRepository = toDoItemRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
        public ToDoItemDTO AddToDoItem(AddToDoDTO toDoItemDTO)
        {
            Category category = _categoryRepository.GetCategoryById(toDoItemDTO.CategoryId);
            User user =_userRepository.GetUserById(toDoItemDTO.UserId);

            ToDoItem toDoItem = new ToDoItem(Guid.NewGuid(), toDoItemDTO.Title, toDoItemDTO.Description,
                                            toDoItemDTO.IsDone, category,user);

            CategoryDTO categoryDTO = new CategoryDTO(category.Id,category.Name);
            UserDTO userDTO = new UserDTO(user.Id,user.FirstName,user.LastName);

            ToDoItem savedToDoItem = _toDoItemRepository.AddToDoItem(toDoItem);
            ToDoItemDTO _toDoItemDTO = new ToDoItemDTO(savedToDoItem.Id, savedToDoItem.Title,
                                            savedToDoItem.Description, savedToDoItem.IsDone,categoryDTO,userDTO);
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
        public ToDoItemDTO UpdateToDoItem(UpdateToDoDTO updatetoDoDTO)
        {
            Category category = _categoryRepository.GetCategoryById(updatetoDoDTO.CategoryId);
            User user = _userRepository.GetUserById(updatetoDoDTO.UserId);

            ToDoItem toDoItem = new(updatetoDoDTO.Id, updatetoDoDTO.Title, updatetoDoDTO.Description, updatetoDoDTO.IsDone,category,user);                            

            _toDoItemRepository.UpdateToDoItem(toDoItem);

            ToDoItemDTO toDoDTO = new ToDoItemDTO(toDoItem.Id, toDoItem.Title, toDoItem.Description, toDoItem.IsDone,
                                  new CategoryDTO(toDoItem.Category.Id, toDoItem.Category.Name),
                                  new UserDTO(toDoItem.User.Id, toDoItem.User.FirstName, toDoItem.User.LastName));
            return toDoDTO;
        }
        public GetFilterDTO GetToDoByFilter(FilterDTO _filterDTO)
        {
            int page = _filterDTO.Page == 0 ? 1 : _filterDTO.Page;
            int perPage =_filterDTO.PerPage == 0 ? 10 : _filterDTO.PerPage;
      
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
            GetFilterDTO output = new(toDoItemDTOs, page, perPage, search, sortBy);
            return output;
        }
    }
}
