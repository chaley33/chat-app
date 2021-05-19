using api.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.DataManager
{
    public class UserManager : IDataRepository
    {
        readonly UserContext _userContext;

        public UserManager(UserContext context)
        {
            _userContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public void Add(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public User Get(long id)
        {
            return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public void Update(User user, User entity)
        {
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.UserName = entity.UserName;
            user.Email = entity.Email;

            _userContext.SaveChanges();
        }
    }
}
