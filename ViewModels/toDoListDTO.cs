using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoList.Models;

namespace MyToDoList.ViewModels
{
    public class toDoListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<toDoItemDTO> toDoItems { get; set; }
    }
}
