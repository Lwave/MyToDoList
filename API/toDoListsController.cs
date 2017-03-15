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
    public class toDoListsController : Controller
    {

        public toDoListsService _lService;

        public toDoListsController(toDoListsService lService)
        {
            _lService = lService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<toDoListDTO> GetProfileLists()
        {
            string userId = User.Identity.GetUserId();
            return _lService.GetProfileLists(userId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]toDoListDTO todolist)
        {
           
            _lService.AddtoDoList(todolist, User.Identity.GetUserId());
            
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
            _lService.deletetoDoItem(id);
        }
    }
}
