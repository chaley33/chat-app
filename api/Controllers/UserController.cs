using api.Models;
using api.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly string[] _firstNames = System.IO.File.ReadAllLines($"Mock Data/FirstNames.txt");
        private readonly string[] _lastNames = System.IO.File.ReadAllLines($"Mock Data/LastNames.txt");

        private readonly IDataRepository _dataRepository;

        public UserController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET: api/user/some_id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            User user = _dataRepository.Get(id);

            if(user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest("User is null.");
            }

            _dataRepository.Add(user);
            return CreatedAtRoute(
                "Get", 
                new { Id = user.UserId },
                user);
        }

        // PUT: api/user
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            User userToUpdate = _dataRepository.Get(id);
            if(userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/user/some_id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _dataRepository.Get(id);
            if(user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }

        private User GenerateUser()
        {
            var user = new User();
            var rng = new Random();
            user.FirstName = _firstNames[rng.Next(_firstNames.Length)];
            user.LastName = _lastNames[rng.Next(_lastNames.Length)];
            user.UserName = $"{user.FirstName.Substring(0, rng.Next(1, user.FirstName.Length))}{user.LastName.Substring(1, rng.Next(1, user.LastName.Length))}{rng.Next(10)}{rng.Next(10)}";
            user.Email = $"{user.UserName}@{RandomDomain()}";

            return user;
        }

        private string RandomDomain()
        {
            var rng = new Random();
            string[] domains = { "gmail.com", "yahoo.com", "aol.com", "outlook.com", "icloud.com", "protonmail.com" };

            return domains[rng.Next(domains.Length)];
        }
    }
}
