using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Models
{
    public class toDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<toDoItem> toDoItems { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
