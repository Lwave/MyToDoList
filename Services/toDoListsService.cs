using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Models;
using MyToDoList.Data;
using MyToDoList.Infrastructure;
using MyToDoList.ViewModels;

namespace MyToDoList.Services
{
    public class toDoListsService 
    {
        private toDoListRepository _repo;

        public toDoListsService(toDoListRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<toDoListDTO> Get()
        {
            return (from t in _repo.GetLists()
                   select new toDoListDTO
                   {
                       Id = t.Id,
                       Title = t.Title,
                       toDoItems = (from i in t.toDoItems
                                   select new toDoItemDTO
                                   {
                                       Description = i.Description,
                                       IsCompleted = i.IsCompleted,
                                       Id = i.Id
                                   }).ToList()
                   }).ToList();
        }

        public ICollection<toDoListDTO> GetProfileLists(string userId)
        {
            return (from t in _repo.GetProfileLists(userId)
                    where t.ApplicationUserId == userId
                    select new toDoListDTO
                    {
                        Id = t.Id,
                        Title = t.Title,
                        toDoItems = (from di in t.toDoItems
                                     select new toDoItemDTO
                                     {
                                         Description = di.Description,
                                         Id = di.Id,
                                         IsCompleted = di.IsCompleted
                                     }).ToList()
                    }).ToList();
        }
                   
        public void AddtoDoList(toDoListDTO list, string username)
        {
            toDoList newlist = new toDoList
            {
                ApplicationUserId = username,
                Title = list.Title,
                
            };
            _repo.Add(newlist);
        }
        public toDoList FindToDoList(int id)
        {
            return _repo.Find(id);
        }

        public void deletetoDoItem(int id)
        {
            var dolist = _repo.Find(id);
            _repo.Delete(dolist);

        }
    }
}
