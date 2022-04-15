using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;
using vibecity_discbot.repository.Repository.Base;

namespace vibecity_discbot.repository.Repository
{
    public interface IPointRepository : IRepository<Point>
    {
        Task<Point> GetByUserAsync(long id);
    }
}