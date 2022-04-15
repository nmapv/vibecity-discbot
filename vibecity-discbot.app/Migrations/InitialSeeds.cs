using FluentMigrator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using vibecity_discbot.entity.Entity;

namespace vibecity_discbot.app.Migrations
{
    [Migration(2)]
    public class InitialSeeds : Migration
    {
        public override void Down()
        {
            Delete.FromTable("User");
        }

        public override void Up()
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));

            users.ForEach(user =>
            {
                Insert.IntoTable("User")
                    .Row(user);
            });            
        }
    }
}
