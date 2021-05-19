using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly string[] _firstNames = System.IO.File.ReadAllLines($"Mock Data/FirstNames.txt");
        private readonly string[] _lastNames = System.IO.File.ReadAllLines($"Mock Data/LastNames.txt");

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Enumerable.Range(1, 5).Select(index => GenerateUser()).ToArray();
        }

        private User GenerateUser()
        {
            var user = new User();
            var rng = new Random();
            user.FirstName = _firstNames[rng.Next(_firstNames.Length)];
            user.LastName = _lastNames[rng.Next(_lastNames.Length)];
            user.Username = $"{user.FirstName.Substring(0, rng.Next(1, user.FirstName.Length))}{user.LastName.Substring(1, rng.Next(1, user.LastName.Length))}{rng.Next(10)}{rng.Next(10)}";
            user.Email = $"{user.Username}@{RandomDomain()}";

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
