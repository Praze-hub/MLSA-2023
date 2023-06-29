using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly List<UserModel> _user;
         public UserController(List<UserModel> user)
        {
            _user = user;
        }
         [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return _user.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(int id)
        {
            var user = _user.FirstOrDefault(i => i.Id == id);
            if (user == null)
                return NotFound();
            return user;
        }
         [HttpPost]
        public ActionResult<UserModel> Post(UserModel user)
        {
            user.Id = _user.Count + 1; // Generate a new ID
            _user.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserModel user)
        {
            var existingUser = _user.FirstOrDefault(i => i.Id == id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Description = user.Description;

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _user.FirstOrDefault(i => i.Id == id);
            if (user == null)
                return NotFound();

            _user.Remove(user);

            return NoContent();


    }
   }
}