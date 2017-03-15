using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using MyToDoList.Models;
using MyToDoList.Services;
using MyToDoList.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyToDoList.API
{
    [Route("api/[controller]")]
    public class toDoItemsController : Controller
    {
        public toDoItemsService _iService;

        public toDoItemsController(toDoItemsService iService)
        {
            _iService = iService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<toDoItemDTO> GetProfileItem()
        {
            string userId = User.Identity.GetUserId();
            return _iService.GetProfileItem(userId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            
        }

        // POST api/values
        [HttpPost("{toDoListId}/{todoitem}")]
        public void Post(int todolistId, string todoitem)
        {
            _iService.AddtoDoItem(todoitem, User.Identity.GetUserId(), todolistId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _iService.deletetoDoItem(id);

        }
        
    }
}
