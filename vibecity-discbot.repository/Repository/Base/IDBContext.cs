using System;
using System.Data;

namespace vibecity_discbot.repository.Repository.Base
{
    public interface IDBContext : IDisposable
    {
        IDbConnection connection { get; }
    }
}