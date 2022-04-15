using System.Threading.Tasks;
using vibecity_discbot.entity.Entity;
using vibecity_discbot.infrastructure.Tools;
using vibecity_discbot.repository.Repository.Base;

namespace vibecity_discbot.service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            if (!long.TryParse(name.GetValueSplit("#", 1), out long id))
                return null;

            return await _unitOfWork.UserRepository.GetAsync(id);
        }
    }
}
