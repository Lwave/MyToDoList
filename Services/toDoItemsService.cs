using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Infrastructure;
using MyToDoList.Models;
using MyToDoList.ViewModels;

namespace MyToDoList.Services
{
    public class toDoItemsService
    {
        private toDoItemRepository _tRepo;

        public toDoItemsService(toDoItemRepository tRepo)
        {
            _tRepo = tRepo;
        }

        public IEnumerable<toDoItemDTO> Get()
        {
            return from i in _tRepo.GetItems()
                   select new toDoItemDTO
                   {
                       Description = i.Description,
                       IsCompleted = i.IsCompleted
                   };
        }

        public IEnumerable<toDoItemDTO> GetProfileItem(string userId)
        {
            return from i in _tRepo.GetProfileItems(userId)
                   where i.ApplicationUserId == userId
                   select new toDoItemDTO
                   {
                       Id = i.Id,
                       Description = i.Description,
                       IsCompleted = i.IsCompleted,
                       

                   };
        }
        public void AddtoDoItem(string item, string username, int id)
        {
            toDoItem newitem = new toDoItem
            {
                ApplicationUserId = username,
                Description = item,
                IsCompleted = false,
               toDoListId = id

            };
            _tRepo.Add(newitem);
        }
        public toDoItem FindToDoItem(int id)
        {
            return _tRepo.Find(id);
        }

        public void deletetoDoItem(int id)
        {
            var doitem = _tRepo.Find(id);
            _tRepo.Delete(doitem);

        }

    }
}
