using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Models;
using MyToDoList.Data;

namespace MyToDoList.Infrastructure
{
    public class toDoItemRepository : GenericRepository<toDoItem>
    {
        public toDoItemRepository(ApplicationDbContext db) :base(db) { }

        public IQueryable<toDoItem> GetItems()
        {
            return _db.toDoItems;
        }


        public IQueryable<toDoItem> GetProfileItems(string userId)
        {
            return _db.toDoItems.Where(i => i.ApplicationUserId == userId);
        }


        public toDoItem Find(int id)
        {
            return (from i in _db.toDoItems where i.Id == id select i).FirstOrDefault();
        }


        public toDoItem GetItemById(int id)
        {
            return _db.toDoItems.FirstOrDefault(i => i.Id == id);
        }

        public void deletetoDoItem(toDoItem todoitem)
        {
            _db.toDoItems.Remove(todoitem);
            _db.SaveChanges();
        }
    }
}
