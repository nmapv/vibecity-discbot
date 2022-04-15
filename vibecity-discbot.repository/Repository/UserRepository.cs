using vibecity_discbot.entity.Entity;
using vibecity_discbot.repository.Repository.Base;

namespace vibecity_discbot.repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDBContext dbcontext) : base(dbcontext) { }
    }
}
