using System.Collections.Generic;

namespace api.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User user);
        void Update(User user, User entity);
        void Delete(User user);
    }
}
