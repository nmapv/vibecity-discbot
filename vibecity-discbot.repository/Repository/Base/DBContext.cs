using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace vibecity_discbot.repository.Repository.Base
{
    public class DBContext : IDBContext
    {
        public IDbConnection connection { get; set; }

        public DBContext()
        {
            connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
            connection.Open();
        }

        public void Dispose()
        {
            connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
