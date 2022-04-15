using System;

namespace vibecity_discbot.repository.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IPointRepository PointRepository { get; }
        IUserRepository UserRepository { get; }
    }
}