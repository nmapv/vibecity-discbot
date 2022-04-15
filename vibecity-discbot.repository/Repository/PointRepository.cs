using Dapper;
using System.Linq;
using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;
using vibecity_discbot.repository.Repository.Base;

namespace vibecity_discbot.repository.Repository
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        public PointRepository(IDBContext dbcontext) : base(dbcontext) { }

        public async Task<Point> GetByUserAsync(long id)
        {
            var res = await _dbcontext.connection.QueryAsync<Point>(@"select * from Point where user_id=@id", param: new { id });
            return res.FirstOrDefault();
        }
    }
}
