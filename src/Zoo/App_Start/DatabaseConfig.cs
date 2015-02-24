using System.Configuration;
using System.Data.Entity;
using Zoo.Models;
using Zoo.Models.Migrations;

namespace Zoo.App_Start
{
    public static class DatabaseConfig
    {
        public static void Start()
        {
            Database.SetInitializer(new ValidateDatabase<ZooDbContext>());
            
            // run migrations
            Runner.MigrateToLatest(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}