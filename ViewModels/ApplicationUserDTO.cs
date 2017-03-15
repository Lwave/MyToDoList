using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Models;

namespace MyToDoList.ViewModels
{
    public class ApplicationUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<toDoList> toDoLists { get; set; }
    }
}
