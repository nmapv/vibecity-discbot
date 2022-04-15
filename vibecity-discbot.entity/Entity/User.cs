using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace vibecity_discbot.entity.Entity
{
    [Table("User")]
    public class User
    {
        [ExplicitKey]
        public long id { get; private set; }
        public string fac { get; private set; }
        public string name { get; private set; }

        [JsonConstructor]
        public User(long id, string fac, string name)
        {
            this.id = id;
            this.fac = fac;
            this.name = name;
        }
    }
}
