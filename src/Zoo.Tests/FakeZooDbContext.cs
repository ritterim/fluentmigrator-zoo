using System;
using System.Data.Entity;
using System.Linq;
using Zoo.Models;

namespace Zoo.Tests
{
    public class FakeZooDbContext : IZooDbContext, IDisposable
    {
        /// <summary>
        /// Sets up the fake database.
        /// </summary>
        public FakeZooDbContext()
        {
            // We're setting our DbSets to be InMemoryDbSets rather than using SQL Server.
            Enclosures = new InMemoryDbSet<Enclosure> { FindFunction = (a, i) => a.FirstOrDefault(x => x.Id == i.Cast<int>().First()) };
            Animals = new InMemoryDbSet<Animal> { FindFunction = (a, i) => a.FirstOrDefault(x => x.Id == i.Cast<int>().First()) };
            Keepers = new InMemoryDbSet<Keeper> { FindFunction = (a, i) => a.FirstOrDefault(x => x.Id == i.Cast<int>().First()) };
        }

        public IDbSet<Enclosure> Enclosures { get; set; }
        public IDbSet<Animal> Animals { get; set; }
        public IDbSet<Keeper> Keepers { get; set; }

        public int SaveChanges()
        {
            // Pretend that each entity gets a database id when we hit save.
            int changes = 0;
            changes += DbSetHelper.IncrementPrimaryKey(x => x.Id, Enclosures);
            changes += DbSetHelper.IncrementPrimaryKey(x => x.Id, Animals);
            changes += DbSetHelper.IncrementPrimaryKey(x => x.Id, Keepers);

            return changes;
        }

        public void Dispose()
        {
            // Do nothing!
        }
    }
}
