using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Data;
using MyToDoList.Models;

namespace MyToDoList.Infrastructure
{
    public class toDoListRepository : GenericRepository<toDoList>
    {
        public toDoListRepository(ApplicationDbContext db) : base(db) { }


        public IQueryable<toDoList> GetLists()
        {
            return _db.toDoLists;
        }

        public IQueryable<toDoList> GetProfileLists(string userId)
        {
            return _db.toDoLists.Where(t => t.ApplicationUserId == userId);
        }

        public toDoList GetListById(int id)
        {
            return _db.toDoLists.FirstOrDefault(t => t.Id == id);
        }

        public toDoList Find(int id)
        {
            return (from l in _db.toDoLists where l.Id == id select l).FirstOrDefault();
        }

        public void deletetoDoList(toDoList todolist)
        {

            _db.toDoLists.Remove(todolist);
            _db.SaveChanges();
        }
    }
}
