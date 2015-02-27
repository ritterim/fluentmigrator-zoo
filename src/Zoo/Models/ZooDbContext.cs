using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;

namespace Zoo.Models
{
    public class ZooDbContext : DbContext, IZooDbContext
    {
        public ZooDbContext()
            :base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {}

        public ZooDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {}

        public IDbSet<Enclosure> Enclosures { get; set; }
        public IDbSet<Animal> Animals { get; set; }
        public IDbSet<Keeper> Keepers { get; set; }
    }

    public interface IZooDbContext
    {
        IDbSet<Enclosure> Enclosures { get; set; }
        IDbSet<Animal> Animals { get; set; }
        IDbSet<Keeper> Keepers { get; set; }

        int SaveChanges();
    }

    public class Enclosure
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Environment { get; set; }
        public virtual IList<Animal> Animals { get; set; }
        public virtual IList<Keeper> Keepers { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }
        public int EnclosureId { get; set; }
        public virtual Enclosure Enclosure { get; set; }        
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class Keeper
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual IList<Enclosure> Enclosures { get; set; }
    }

    public class ValidateDatabase<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {
            if (!context.Database.Exists())
            {
                throw new ConfigurationErrorsException("Database does not exist");
            }
        }
    }
}