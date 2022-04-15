using Dapper.Contrib.Extensions;
using System;
using System.Globalization;

namespace vibecity_discbot.entity.Entity
{
    [Table("Point")]
    public class Point
    {
        [Key]
        public long id { get; private set; }
        public long user_id { get; private set; }
        public DateTime started { get; private set; }

        public Point(long id, long user_id, string started)
        {
            this.id = id;
            this.user_id = user_id;
            this.started = DateTime.ParseExact(started, "yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture); ;
        }

        public Point(long user_id)
        {
            this.user_id = user_id;
            this.started = DateTime.Now;
        }

        public int GetTotalHours()
        {
            return (DateTime.Now - started).Hours;
        }
    }
}
