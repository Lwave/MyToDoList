using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyToDoList.Models;
using MyToDoList.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyToDoList.API
{
    
    [Route("api/[controller]")]
    public class ApplicationUsersController : Controller
    {
        public ApplicationUsersService _aService;

        public ApplicationUsersController(ApplicationUsersService aService)
        {
            _aService = aService; 
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("getLoginUser")]
        public ApplicationUser GetLoginUser()
        {
            string name = User.Identity.Name;
            var applicationUser = _aService.GetApplicationUserById(name);
            return applicationUser;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
        }
    }
}
