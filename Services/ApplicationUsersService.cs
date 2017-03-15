using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Infrastructure;
using MyToDoList.Models;

namespace MyToDoList.Services
{
    public class ApplicationUsersService
    {
        private ApplicationUserRepository _repo;

        public ApplicationUsersService(ApplicationUserRepository repo)
        {
            _repo = repo;
        }

        public ApplicationUser GetApplicationUserById(string name)
        {
            return _repo.GetApplicationUserById(name);
        }
    }
}
