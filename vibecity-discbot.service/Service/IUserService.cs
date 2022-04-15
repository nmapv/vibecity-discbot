using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;

namespace vibecity_discbot.service.Service
{
    public interface IUserService
    {
        Task<User> GetByNameAsync(string name);
    }
}
