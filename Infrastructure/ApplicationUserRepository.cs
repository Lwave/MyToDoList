using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Data;
using MyToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace MyToDoList.Infrastructure
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public ApplicationUserRepository(ApplicationDbContext db) : base(db) { }

        public ApplicationUser GetApplicationUserById(string name)
        {
            return _db.ApplicationUsers.FirstOrDefault(au => au.UserName == name);
        }
    }
    
}
