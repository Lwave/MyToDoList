using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Models
{
    public class toDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        //double check to confirm we need this foreign key.should be used to link comment to specified feedback
        public int toDoListId { get; set; }
        [ForeignKey("toDoListId")]
        public toDoList toDoList { get; set; }
    }
}
