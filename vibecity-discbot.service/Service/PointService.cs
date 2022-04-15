using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;
using vibecity_discbot.repository.Repository.Base;

namespace vibecity_discbot.service.Service
{
    public class PointService : IPointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Point> InsertAsync(User user)
        {
            var point = await _unitOfWork.PointRepository.GetByUserAsync(user.id);

            if (point != null)
                return point;

            point = new Point(user.id);
            await _unitOfWork.PointRepository.InsertAsync(point);

            return point;
        }
    }
}
