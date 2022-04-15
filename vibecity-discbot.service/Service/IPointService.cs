using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;

namespace vibecity_discbot.service.Service
{
    public interface IPointService
    {
        Task<Point> InsertAsync(User user);
    }
}